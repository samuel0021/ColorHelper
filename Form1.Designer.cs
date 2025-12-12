namespace ColorHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pctColorSpectrum = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.lblSmallScreen = new System.Windows.Forms.Label();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trkAlpha = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCopyHex = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPickScreenColor = new System.Windows.Forms.Button();
            this.txtOpacity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctColorSpectrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAlpha)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctColorSpectrum
            // 
            this.pctColorSpectrum.Image = global::ColorHelper.Properties.Resources.color_spectrum;
            this.pctColorSpectrum.Location = new System.Drawing.Point(12, 12);
            this.pctColorSpectrum.Name = "pctColorSpectrum";
            this.pctColorSpectrum.Size = new System.Drawing.Size(474, 189);
            this.pctColorSpectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctColorSpectrum.TabIndex = 5;
            this.pctColorSpectrum.TabStop = false;
            this.pctColorSpectrum.Click += new System.EventHandler(this.pctColorSpectrum_Click);
            this.pctColorSpectrum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctColorSpectrum_MouseDown);
            this.pctColorSpectrum.MouseEnter += new System.EventHandler(this.pctColorSpectrum_MouseEnter);
            this.pctColorSpectrum.MouseLeave += new System.EventHandler(this.pctColorSpectrum_MouseLeave);
            this.pctColorSpectrum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctColorSpectrum_MouseMove);
            this.pctColorSpectrum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctColorSpectrum_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Blue";
            // 
            // txtRed
            // 
            this.txtRed.Location = new System.Drawing.Point(104, 72);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(100, 20);
            this.txtRed.TabIndex = 9;
            this.txtRed.TextChanged += new System.EventHandler(this.txtRed_TextChanged);
            // 
            // txtGreen
            // 
            this.txtGreen.Location = new System.Drawing.Point(104, 116);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(100, 20);
            this.txtGreen.TabIndex = 10;
            this.txtGreen.TextChanged += new System.EventHandler(this.txtGreen_TextChanged);
            // 
            // txtBlue
            // 
            this.txtBlue.Location = new System.Drawing.Point(104, 158);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(100, 20);
            this.txtBlue.TabIndex = 11;
            this.txtBlue.TextChanged += new System.EventHandler(this.txtBlue_TextChanged);
            // 
            // lblSmallScreen
            // 
            this.lblSmallScreen.Location = new System.Drawing.Point(25, 31);
            this.lblSmallScreen.Name = "lblSmallScreen";
            this.lblSmallScreen.Size = new System.Drawing.Size(173, 147);
            this.lblSmallScreen.TabIndex = 13;
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(104, 31);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(100, 20);
            this.txtAlpha.TabIndex = 14;
            this.txtAlpha.TextChanged += new System.EventHandler(this.txtAlpha_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Alpha";
            // 
            // trkAlpha
            // 
            this.trkAlpha.Location = new System.Drawing.Point(264, 242);
            this.trkAlpha.Maximum = 100;
            this.trkAlpha.Name = "trkAlpha";
            this.trkAlpha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trkAlpha.Size = new System.Drawing.Size(222, 45);
            this.trkAlpha.TabIndex = 17;
            this.trkAlpha.Value = 100;
            this.trkAlpha.Scroll += new System.EventHandler(this.trkAlpha_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAlpha);
            this.groupBox1.Controls.Add(this.txtRed);
            this.groupBox1.Controls.Add(this.txtGreen);
            this.groupBox1.Controls.Add(this.txtBlue);
            this.groupBox1.Location = new System.Drawing.Point(12, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 196);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ARGB";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSmallScreen);
            this.groupBox2.Location = new System.Drawing.Point(264, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 196);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // btnCopyHex
            // 
            this.btnCopyHex.Location = new System.Drawing.Point(46, 242);
            this.btnCopyHex.Name = "btnCopyHex";
            this.btnCopyHex.Size = new System.Drawing.Size(68, 31);
            this.btnCopyHex.TabIndex = 16;
            this.btnCopyHex.Text = "Copy HEX";
            this.btnCopyHex.UseVisualStyleBackColor = true;
            this.btnCopyHex.Click += new System.EventHandler(this.btnCopyHex_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(12, 219);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(29, 13);
            this.lblColor.TabIndex = 0;
            this.lblColor.Text = "HEX";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(46, 216);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(91, 20);
            this.txtColor.TabIndex = 3;
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            this.txtColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColor_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Opacity";
            // 
            // btnPickScreenColor
            // 
            this.btnPickScreenColor.Location = new System.Drawing.Point(157, 216);
            this.btnPickScreenColor.Name = "btnPickScreenColor";
            this.btnPickScreenColor.Size = new System.Drawing.Size(91, 46);
            this.btnPickScreenColor.TabIndex = 21;
            this.btnPickScreenColor.Text = "Pick Screen Color";
            this.btnPickScreenColor.UseVisualStyleBackColor = true;
            this.btnPickScreenColor.Click += new System.EventHandler(this.btnPickScreenColor_Click);
            this.btnPickScreenColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPickScreenColor_MouseDown);
            this.btnPickScreenColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPickScreenColor_MouseUp);
            // 
            // txtOpacity
            // 
            this.txtOpacity.Location = new System.Drawing.Point(347, 213);
            this.txtOpacity.Name = "txtOpacity";
            this.txtOpacity.Size = new System.Drawing.Size(100, 20);
            this.txtOpacity.TabIndex = 22;
            this.txtOpacity.TextChanged += new System.EventHandler(this.txtOpacity_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 496);
            this.Controls.Add(this.txtOpacity);
            this.Controls.Add(this.btnPickScreenColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCopyHex);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trkAlpha);
            this.Controls.Add(this.pctColorSpectrum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pctColorSpectrum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAlpha)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pctColorSpectrum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.TextBox txtGreen;
        private System.Windows.Forms.TextBox txtBlue;
        private System.Windows.Forms.Label lblSmallScreen;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trkAlpha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCopyHex;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPickScreenColor;
        private System.Windows.Forms.TextBox txtOpacity;
    }
}

