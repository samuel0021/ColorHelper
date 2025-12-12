using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorHelper
{
    public class ColorPickerHelper
    {
        private bool _dragging = false;
        private Rectangle _pbScreenBounds;

        public Color HexToColor(string hex)
        {
            hex = hex.Trim().TrimStart('#');

            if (hex.Length == 6) // RRGGBB
            {
                byte r = Convert.ToByte(hex.Substring(0, 2), 16);
                byte g = Convert.ToByte(hex.Substring(2, 2), 16);
                byte b = Convert.ToByte(hex.Substring(4, 2), 16);
                return Color.FromArgb(255, r, g, b);
            }
            else if (hex.Length == 8) // AARRGGBB
            {
                byte a = Convert.ToByte(hex.Substring(0, 2), 16);
                byte r = Convert.ToByte(hex.Substring(2, 2), 16);
                byte g = Convert.ToByte(hex.Substring(4, 2), 16);
                byte b = Convert.ToByte(hex.Substring(6, 2), 16);
                return Color.FromArgb(a, r, g, b);
            }

            throw new ArgumentException("Hex inválido.");
        }

        public void OnMouseDown(
        PictureBox pcb,
        Label lblPreview,
        TextBox txtColor,
        TextBox txtAlpha,
        TextBox txtRed,
        TextBox txtGreen,
        TextBox txtBlue,
        MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _dragging = true;
            _pbScreenBounds = pcb.RectangleToScreen(pcb.ClientRectangle);

            // captura na hora do clique
            CaptureColor(pcb, lblPreview, txtColor, txtAlpha, txtRed, txtGreen, txtBlue, e);
        }

        public void OnMouseMove(
        PictureBox pcb,
        Label lblPreview,
        TextBox txtColor,
        TextBox txtAlpha,
        TextBox txtRed,
        TextBox txtGreen,
        TextBox txtBlue,
        MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = Cursor.Position;
                int x = Math.Min(Math.Max(p.X, _pbScreenBounds.Left), _pbScreenBounds.Right - 1);
                int y = Math.Min(Math.Max(p.Y, _pbScreenBounds.Top), _pbScreenBounds.Bottom - 1);
                if (x != p.X || y != p.Y)
                    Cursor.Position = new Point(x, y);
            }

            if (e.Button == MouseButtons.Left)
            {
                CaptureColor(pcb, lblPreview, txtColor, txtAlpha, txtRed, txtGreen, txtBlue, e);
            }
        }

        public void OnMouseUp()
        {
            _dragging = false;
        }

        public void CaptureColor(
        PictureBox pcb,
        Label lblPreview,
        TextBox txtColor,
        TextBox txtAlpha,
        TextBox txtRed,
        TextBox txtGreen,
        TextBox txtBlue,
        MouseEventArgs e)
        {
            if (pcb.Image == null)
                return;

            if (e.X < 0 || e.Y < 0 ||
                e.X >= pcb.Image.Width ||
                e.Y >= pcb.Image.Height)
                return;

            var bmp = (Bitmap)pcb.Image;
            Color color = bmp.GetPixel(e.X, e.Y);
            ApplyColorToControls(color, lblPreview, txtColor, txtAlpha, txtRed, txtGreen, txtBlue);
        }

        public Color GetScreenColorAt(Point screenLocation)
        {
            using (var bmp = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(screenLocation, Point.Empty, new Size(1, 1));
                return bmp.GetPixel(0, 0);
            }
        }

        public void ApplyColorToControls(
        Color color,
        Label lblPreview,
        TextBox txtColor,
        TextBox txtAlpha,
        TextBox txtRed,
        TextBox txtGreen,
        TextBox txtBlue)
        {
            lblPreview.BackColor = color;

            txtColor.Text = $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";

            var conv = new Converters();
            int percent = conv.AlphaToPercentage(color.A);

            txtAlpha.Text = color.A.ToString();  // 0–255
            txtRed.Text = color.R.ToString();
            txtGreen.Text = color.G.ToString();
            txtBlue.Text = color.B.ToString();
        }

        #region Generate Spectrum
        public Bitmap GerarGradiente(int largura, int altura)
        {
            var bmp = new Bitmap(largura, altura);

            for (int x = 0; x < largura; x++)
            {
                float h = (float)x / (largura - 1) * 360f; // 0..360

                for (int y = 0; y < altura; y++)
                {
                    float v = 1f - (float)y / (altura - 1); // 1..0
                    float s = 1f;

                    Color c = FromHsv(h, s, v);
                    bmp.SetPixel(x, y, c);
                }
            }
            return bmp;
        }

        private Color FromHsv(float hue, float saturation, float value)
        {
            if (saturation == 0)
            {
                int vByte = (int)(value * 255);
                return Color.FromArgb(vByte, vByte, vByte);
            }

            float h = hue / 60f;
            int i = (int)Math.Floor(h);
            float f = h - i;
            float p = value * (1f - saturation);
            float q = value * (1f - saturation * f);
            float t = value * (1f - saturation * (1f - f));

            float r = 0, g = 0, b = 0;

            switch (i)
            {
                case 0: r = value; g = t; b = p; break;
                case 1: r = q; g = value; b = p; break;
                case 2: r = p; g = value; b = t; break;
                case 3: r = p; g = q; b = value; break;
                case 4: r = t; g = p; b = value; break;
                default: r = value; g = p; b = q; break; // setor 5
            }

            return Color.FromArgb(
                (int)(r * 255),
                (int)(g * 255),
                (int)(b * 255));
        }
        #endregion
    }
}
