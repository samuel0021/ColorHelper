using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace ColorHelper
{
    public partial class Form1 : Form
    {
        private readonly ColorPickerHelper _picker = new ColorPickerHelper();

        bool _pickingScreen = false;
        bool _pickingMouseDown = false;

        bool buttonPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pctColorSpectrum.Image = _picker.GerarGradiente(pctColorSpectrum.Width, pctColorSpectrum.Height);

            CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(BackgroundThread) { IsBackground = true };
            thread.Start();
        }

        Color GetColorAt(Point location)
        {
            using (Bitmap pixelContainer = new Bitmap(1, 1))
            {
                using(Graphics graphics = Graphics.FromImage(pixelContainer))
                {
                    graphics.CopyFromScreen(location, Point.Empty, pixelContainer.Size);
                }
                return pixelContainer.GetPixel(0, 0);
            }
        }

        void BackgroundThread()
        {
            while (true)
            {
                if (buttonPressed)
                {
                    Point cursorPosition = Cursor.Position;
                    Color selectedColor = GetColorAt(cursorPosition);
                    lblSmallScreen.BackColor = selectedColor;
                    string hexValue = ColorTranslator.ToHtml(selectedColor);

                    txtColor.Text = hexValue;
                }
            }
        }
        private void btnPickScreenColor_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPressed = true;
            Cursor = Cursors.Cross;
        }

        private void btnPickScreenColor_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressed = false;
            Cursor = Cursors.Default;
        }


        // ==============================================================

        private void pctColorSpectrum_MouseMove(object sender, MouseEventArgs e)
        {
            _picker.OnMouseMove(pctColorSpectrum, lblSmallScreen,
                        txtColor, txtAlpha, txtRed, txtGreen, txtBlue, e);
        }

        private void pctColorSpectrum_MouseDown(object sender, MouseEventArgs e)
        {
            if (_pickingScreen) return;

            _picker.OnMouseDown(pctColorSpectrum, lblSmallScreen,
                        txtColor, txtAlpha, txtRed, txtGreen, txtBlue, e);
        }
        private void pctColorSpectrum_MouseUp(object sender, MouseEventArgs e)
        {
            _picker.OnMouseUp();
        }
        private void pctColorSpectrum_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }
        private void pctColorSpectrum_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void btnCopyHex_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtColor.Text))
            {
                Clipboard.SetText(txtColor.Text);
                MessageBox.Show($"HEX: {txtColor.Text}", "HEX COPIED", MessageBoxButtons.OK);
            }
        }

        private void trkAlpha_Scroll(object sender, EventArgs e)
        {
            int alpha = trkAlpha.Value;

            Color baseColor = lblSmallScreen.BackColor;

            Color newColor = Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);

            lblSmallScreen.BackColor = newColor;

            txtAlpha.Text = alpha.ToString();
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            string hex = txtColor.Text.Trim();
            if (string.IsNullOrWhiteSpace(hex))
                return;

            try
            {
                Color c = _picker.HexToColor(hex);   // #RRGGBB ou #AARRGGBB

                lblSmallScreen.BackColor = c;

                txtAlpha.Text = c.A.ToString();
                txtRed.Text = c.R.ToString();
                txtGreen.Text = c.G.ToString();
                txtBlue.Text = c.B.ToString();
                trkAlpha.Value = c.A;
            }
            catch
            {
                // ignorar enquanto o usuário digita algo inválido
            }
        }

        private void txtAlpha_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromChannels();
        }

        private void txtRed_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromChannels();
        }

        private void txtGreen_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromChannels();
        }

        private void txtBlue_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromChannels();
        }

        private void UpdateColorFromChannels()
        {
            if (!int.TryParse(txtAlpha.Text, out int a)) a = 255;
            if (!int.TryParse(txtRed.Text, out int r)) r = 0;
            if (!int.TryParse(txtGreen.Text, out int g)) g = 0;
            if (!int.TryParse(txtBlue.Text, out int b)) b = 0;

            a = Math.Max(0, Math.Min(255, a));
            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            // sincroniza trackbar de alpha
            trkAlpha.Value = a;

            Color c = Color.FromArgb(a, r, g, b);
            lblSmallScreen.BackColor = c;

            // atualiza HEX
            txtColor.TextChanged -= txtColor_TextChanged; // evita loop
            txtColor.Text = $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}"; // #AARRGGBB
            txtColor.TextChanged += txtColor_TextChanged;
        }

        private void pctColorSpectrum_Click(object sender, EventArgs e)
        {

        }

        private void btnPickScreenColor_Click(object sender, EventArgs e)
        {
            _pickingScreen = true;
            Cursor = Cursors.Cross;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_pickingScreen || e.Button != MouseButtons.Left)
                return;

            _pickingMouseDown = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_pickingScreen || !_pickingMouseDown)
                return;

            Point screenPos = Cursor.Position;
            Color c = _picker.GetScreenColorAt(screenPos);

            _picker.ApplyColorToControls(
                c, lblSmallScreen, txtColor, txtAlpha, txtRed, txtGreen, txtBlue);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_pickingScreen || e.Button != MouseButtons.Left)
                return;

            _pickingMouseDown = false;
            _pickingScreen = false;
            Cursor = Cursors.Default;
        }

    }
}
