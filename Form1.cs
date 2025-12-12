using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ColorHelper
{
    public partial class Form1 : Form
    {
        private readonly ColorPickerHelper _picker = new ColorPickerHelper();
        private readonly Converters _converters = new Converters();

        bool _pickingScreen = false;
        bool _pickingMouseDown = false;

        bool buttonPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trkAlpha.Minimum = 0;
            trkAlpha.Maximum = 100;
            trkAlpha.Value = 100;

            txtOpacity.Text = "100%";
            txtAlpha.Text = "255";

            txtColor.Text = "#";

            pctColorSpectrum.Image = _picker.GerarGradiente(pctColorSpectrum.Width, pctColorSpectrum.Height);

            CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(BackgroundThread) { IsBackground = true };
            thread.Start();
        }

        Color GetColorAt(Point location)
        {
            using (Bitmap pixelContainer = new Bitmap(1, 1))
            {
                using (Graphics graphics = Graphics.FromImage(pixelContainer))
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

        #region Mouse Events
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
        #endregion

        private void trkAlpha_Scroll(object sender, EventArgs e)
        {
            int percent = trkAlpha.Value;                    // 0–100
            int alpha255 = _converters.PercentageToAlpha(percent); // 0–255

            Color baseColor = lblSmallScreen.BackColor;
            Color newColor = Color.FromArgb(alpha255, baseColor.R, baseColor.G, baseColor.B);

            lblSmallScreen.BackColor = newColor;

            txtAlpha.Text = alpha255.ToString();
            txtOpacity.Text = percent + "%";
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            if (!txtColor.Text.StartsWith("#"))
            {
                int textPosition = txtColor.SelectionStart;

                txtColor.Text = "#" + txtColor.Text.TrimStart('#');

                txtColor.SelectionStart = Math.Max(textPosition, 1);
                return;
            }

            string hex = txtColor.Text.Trim();
            if (string.IsNullOrWhiteSpace(hex) || hex == "#")
                return;

            try
            {
                Color c = _picker.HexToColor(hex);   // #RRGGBB ou #AARRGGBB

                lblSmallScreen.BackColor = c;

                int percent = _converters.AlphaToPercentage(c.A);

                txtAlpha.Text = c.A.ToString();   // 0–100
                txtRed.Text = c.R.ToString();
                txtGreen.Text = c.G.ToString();
                txtBlue.Text = c.B.ToString();

                trkAlpha.Value = percent;
                txtOpacity.Text = percent + "%";
            }
            catch
            {
                // ignorar enquanto o usuário digita algo inválido
            }
        }

        #region ARGB TextChanged
        private void txtAlpha_TextChanged(object sender, EventArgs e)
        {
            // permite vazio ou um número parcial enquanto digita
            if (string.IsNullOrWhiteSpace(txtAlpha.Text))
                return;

            if (!int.TryParse(txtAlpha.Text, out _))
                return;

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
        #endregion

        private void UpdateColorFromChannels()
        {
            if (!int.TryParse(txtAlpha.Text, out int a255)) a255 = 255;
            if (!int.TryParse(txtRed.Text, out int r)) r = 0;
            if (!int.TryParse(txtGreen.Text, out int g)) g = 0;
            if (!int.TryParse(txtBlue.Text, out int b)) b = 0;

            a255 = Math.Max(0, Math.Min(255, a255));
            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            int percent = _converters.AlphaToPercentage(a255); // 0–100

            trkAlpha.Value = percent;
            txtOpacity.Text = percent + "%";

            Color c = Color.FromArgb(a255, r, g, b);
            lblSmallScreen.BackColor = c;

            txtColor.TextChanged -= txtColor_TextChanged;
            txtColor.Text = $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";
            txtColor.TextChanged += txtColor_TextChanged;

            // garante que o valor visível esteja clampado, sem recursão
            txtAlpha.TextChanged -= txtAlpha_TextChanged;
            txtAlpha.Text = a255.ToString();
            txtAlpha.TextChanged += txtAlpha_TextChanged;
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

        private void txtColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && txtColor.SelectionStart <= 1)
                e.SuppressKeyPress = true;
        }

        private void txtOpacity_TextChanged(object sender, EventArgs e)
        {
            string text = txtOpacity.Text.Replace("%", "").Trim();
            if (!int.TryParse(text, out int percent))
                return;

            percent = Math.Max(0, Math.Min(100, percent));
            trkAlpha.Value = percent;

            int a255 = _converters.PercentageToAlpha(percent);
            Color baseColor = lblSmallScreen.BackColor;
            lblSmallScreen.BackColor = Color.FromArgb(a255, baseColor.R, baseColor.G, baseColor.B);

            txtAlpha.Text = a255.ToString();   // mostra 0–255
            txtOpacity.TextChanged -= txtOpacity_TextChanged;
            txtOpacity.Text = percent + "%";
            txtOpacity.TextChanged += txtOpacity_TextChanged;
        }
    }
}
