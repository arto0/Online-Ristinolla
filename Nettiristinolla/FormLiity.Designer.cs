namespace Nettiristinolla
{
    partial class FormLiity
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
            this.labelLiityIp = new System.Windows.Forms.Label();
            this.labelYhdistaPeliin = new System.Windows.Forms.Label();
            this.buttonYhdista = new System.Windows.Forms.Button();
            this.textBoxIPosoite = new System.Windows.Forms.TextBox();
            this.progressBarYhdistys = new System.Windows.Forms.ProgressBar();
            this.labelInfoYhdistetaan = new System.Windows.Forms.Label();
            this.panelYhdistys = new System.Windows.Forms.Panel();
            this.buttonPaavalikkoon = new System.Windows.Forms.Button();
            this.numerovalitsinPortti = new Nettiristinolla.Numerovalitsin();
            this.panelYhdistys.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLiityIp
            // 
            this.labelLiityIp.AutoSize = true;
            this.labelLiityIp.Location = new System.Drawing.Point(15, 55);
            this.labelLiityIp.Name = "labelLiityIp";
            this.labelLiityIp.Size = new System.Drawing.Size(51, 13);
            this.labelLiityIp.TabIndex = 0;
            this.labelLiityIp.Text = "IP-osoite:";
            // 
            // labelYhdistaPeliin
            // 
            this.labelYhdistaPeliin.AutoSize = true;
            this.labelYhdistaPeliin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYhdistaPeliin.Location = new System.Drawing.Point(12, 9);
            this.labelYhdistaPeliin.Name = "labelYhdistaPeliin";
            this.labelYhdistaPeliin.Size = new System.Drawing.Size(127, 25);
            this.labelYhdistaPeliin.TabIndex = 1;
            this.labelYhdistaPeliin.Text = "Yhdistä peliin";
            // 
            // buttonYhdista
            // 
            this.buttonYhdista.BackColor = System.Drawing.Color.Lavender;
            this.buttonYhdista.Location = new System.Drawing.Point(122, 102);
            this.buttonYhdista.Name = "buttonYhdista";
            this.buttonYhdista.Size = new System.Drawing.Size(93, 23);
            this.buttonYhdista.TabIndex = 4;
            this.buttonYhdista.Text = "&Yhdistä";
            this.buttonYhdista.UseVisualStyleBackColor = false;
            this.buttonYhdista.Click += new System.EventHandler(this.buttonYhdista_Click);
            // 
            // textBoxIPosoite
            // 
            this.textBoxIPosoite.Location = new System.Drawing.Point(98, 49);
            this.textBoxIPosoite.Name = "textBoxIPosoite";
            this.textBoxIPosoite.Size = new System.Drawing.Size(117, 20);
            this.textBoxIPosoite.TabIndex = 1;
            this.textBoxIPosoite.Text = "127.0.0.1";
            // 
            // progressBarYhdistys
            // 
            this.progressBarYhdistys.Location = new System.Drawing.Point(0, 23);
            this.progressBarYhdistys.Name = "progressBarYhdistys";
            this.progressBarYhdistys.Size = new System.Drawing.Size(198, 23);
            this.progressBarYhdistys.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarYhdistys.TabIndex = 5;
            // 
            // labelInfoYhdistetaan
            // 
            this.labelInfoYhdistetaan.Location = new System.Drawing.Point(3, 7);
            this.labelInfoYhdistetaan.Name = "labelInfoYhdistetaan";
            this.labelInfoYhdistetaan.Size = new System.Drawing.Size(192, 13);
            this.labelInfoYhdistetaan.TabIndex = 6;
            // 
            // panelYhdistys
            // 
            this.panelYhdistys.Controls.Add(this.progressBarYhdistys);
            this.panelYhdistys.Controls.Add(this.labelInfoYhdistetaan);
            this.panelYhdistys.Location = new System.Drawing.Point(17, 131);
            this.panelYhdistys.Name = "panelYhdistys";
            this.panelYhdistys.Size = new System.Drawing.Size(198, 50);
            this.panelYhdistys.TabIndex = 7;
            // 
            // buttonPaavalikkoon
            // 
            this.buttonPaavalikkoon.BackColor = System.Drawing.Color.Lavender;
            this.buttonPaavalikkoon.Location = new System.Drawing.Point(17, 102);
            this.buttonPaavalikkoon.Name = "buttonPaavalikkoon";
            this.buttonPaavalikkoon.Size = new System.Drawing.Size(93, 23);
            this.buttonPaavalikkoon.TabIndex = 3;
            this.buttonPaavalikkoon.Text = "&Päävalikkoon";
            this.buttonPaavalikkoon.UseVisualStyleBackColor = false;
            this.buttonPaavalikkoon.Click += new System.EventHandler(this.buttonPaavalikkoon_Click);
            // 
            // numerovalitsinPortti
            // 
            this.numerovalitsinPortti.Alaraja = 0;
            this.numerovalitsinPortti.Arvo = 9696;
            this.numerovalitsinPortti.HScrollBar = false;
            this.numerovalitsinPortti.Klikattavissa = true;
            this.numerovalitsinPortti.Location = new System.Drawing.Point(12, 75);
            this.numerovalitsinPortti.Name = "numerovalitsinPortti";
            this.numerovalitsinPortti.Size = new System.Drawing.Size(203, 21);
            this.numerovalitsinPortti.TabIndex = 2;
            this.numerovalitsinPortti.Teksti = "Portti:";
            this.numerovalitsinPortti.Ylaraja = 65535;
            // 
            // FormLiity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(232, 182);
            this.ControlBox = false;
            this.Controls.Add(this.numerovalitsinPortti);
            this.Controls.Add(this.buttonPaavalikkoon);
            this.Controls.Add(this.buttonYhdista);
            this.Controls.Add(this.panelYhdistys);
            this.Controls.Add(this.textBoxIPosoite);
            this.Controls.Add(this.labelYhdistaPeliin);
            this.Controls.Add(this.labelLiityIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLiity";
            this.Text = "Nettiristinolla - Liity peliin";
            this.Load += new System.EventHandler(this.FormLiity_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormLiity_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormLiity_KeyUp);
            this.panelYhdistys.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLiityIp;
        private System.Windows.Forms.Label labelYhdistaPeliin;
        private System.Windows.Forms.Button buttonYhdista;
        private System.Windows.Forms.TextBox textBoxIPosoite;
        private System.Windows.Forms.ProgressBar progressBarYhdistys;
        private System.Windows.Forms.Label labelInfoYhdistetaan;
        private System.Windows.Forms.Panel panelYhdistys;
        private System.Windows.Forms.Button buttonPaavalikkoon;
        private Numerovalitsin numerovalitsinPortti;
    }
}