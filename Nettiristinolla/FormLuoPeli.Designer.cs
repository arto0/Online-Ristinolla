namespace Nettiristinolla
{
    partial class FormLuoPeli
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
            this.labelYhdistaPeliin = new System.Windows.Forms.Label();
            this.panelYhdistys = new System.Windows.Forms.Panel();
            this.progressBarYhdistys = new System.Windows.Forms.ProgressBar();
            this.labelInfoYhdistetaan = new System.Windows.Forms.Label();
            this.buttonLuoPeli = new System.Windows.Forms.Button();
            this.buttonPeruutaLuonti = new System.Windows.Forms.Button();
            this.buttonPois = new System.Windows.Forms.Button();
            this.numerovalitsinPortti = new Nettiristinolla.Numerovalitsin();
            this.numerovalitsinVoittopituus = new Nettiristinolla.Numerovalitsin();
            this.numerovalitsinKorkeus = new Nettiristinolla.Numerovalitsin();
            this.numerovalitsinLeveys = new Nettiristinolla.Numerovalitsin();
            this.panelYhdistys.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelYhdistaPeliin
            // 
            this.labelYhdistaPeliin.AutoSize = true;
            this.labelYhdistaPeliin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYhdistaPeliin.Location = new System.Drawing.Point(12, 9);
            this.labelYhdistaPeliin.Name = "labelYhdistaPeliin";
            this.labelYhdistaPeliin.Size = new System.Drawing.Size(121, 25);
            this.labelYhdistaPeliin.TabIndex = 2;
            this.labelYhdistaPeliin.Text = "Luo uusi peli";
            // 
            // panelYhdistys
            // 
            this.panelYhdistys.Controls.Add(this.progressBarYhdistys);
            this.panelYhdistys.Controls.Add(this.labelInfoYhdistetaan);
            this.panelYhdistys.Location = new System.Drawing.Point(33, 183);
            this.panelYhdistys.Name = "panelYhdistys";
            this.panelYhdistys.Size = new System.Drawing.Size(286, 74);
            this.panelYhdistys.TabIndex = 8;
            // 
            // progressBarYhdistys
            // 
            this.progressBarYhdistys.BackColor = System.Drawing.Color.GhostWhite;
            this.progressBarYhdistys.Location = new System.Drawing.Point(0, 41);
            this.progressBarYhdistys.Name = "progressBarYhdistys";
            this.progressBarYhdistys.Size = new System.Drawing.Size(286, 23);
            this.progressBarYhdistys.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarYhdistys.TabIndex = 5;
            // 
            // labelInfoYhdistetaan
            // 
            this.labelInfoYhdistetaan.Location = new System.Drawing.Point(3, 0);
            this.labelInfoYhdistetaan.Name = "labelInfoYhdistetaan";
            this.labelInfoYhdistetaan.Size = new System.Drawing.Size(280, 38);
            this.labelInfoYhdistetaan.TabIndex = 6;
            this.labelInfoYhdistetaan.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonLuoPeli
            // 
            this.buttonLuoPeli.BackColor = System.Drawing.Color.Lavender;
            this.buttonLuoPeli.Location = new System.Drawing.Point(181, 154);
            this.buttonLuoPeli.Name = "buttonLuoPeli";
            this.buttonLuoPeli.Size = new System.Drawing.Size(138, 23);
            this.buttonLuoPeli.TabIndex = 9;
            this.buttonLuoPeli.Text = "&Luo peli";
            this.buttonLuoPeli.UseVisualStyleBackColor = false;
            this.buttonLuoPeli.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPeruutaLuonti
            // 
            this.buttonPeruutaLuonti.BackColor = System.Drawing.Color.Lavender;
            this.buttonPeruutaLuonti.Location = new System.Drawing.Point(181, 154);
            this.buttonPeruutaLuonti.Name = "buttonPeruutaLuonti";
            this.buttonPeruutaLuonti.Size = new System.Drawing.Size(138, 23);
            this.buttonPeruutaLuonti.TabIndex = 27;
            this.buttonPeruutaLuonti.Text = "&Peruuta";
            this.buttonPeruutaLuonti.UseVisualStyleBackColor = false;
            this.buttonPeruutaLuonti.Visible = false;
            this.buttonPeruutaLuonti.Click += new System.EventHandler(this.buttonPeruutaLuonti_Click);
            // 
            // buttonPois
            // 
            this.buttonPois.BackColor = System.Drawing.Color.Lavender;
            this.buttonPois.Location = new System.Drawing.Point(33, 154);
            this.buttonPois.Name = "buttonPois";
            this.buttonPois.Size = new System.Drawing.Size(138, 23);
            this.buttonPois.TabIndex = 28;
            this.buttonPois.Text = "&Päävalikkoon";
            this.buttonPois.UseVisualStyleBackColor = false;
            this.buttonPois.Click += new System.EventHandler(this.buttonPois_Click);
            // 
            // numerovalitsinPortti
            // 
            this.numerovalitsinPortti.Alaraja = 0;
            this.numerovalitsinPortti.Arvo = 9696;
            this.numerovalitsinPortti.HScrollBar = false;
            this.numerovalitsinPortti.Klikattavissa = true;
            this.numerovalitsinPortti.Location = new System.Drawing.Point(33, 128);
            this.numerovalitsinPortti.Name = "numerovalitsinPortti";
            this.numerovalitsinPortti.Size = new System.Drawing.Size(286, 20);
            this.numerovalitsinPortti.TabIndex = 26;
            this.numerovalitsinPortti.Teksti = "Portti:";
            this.numerovalitsinPortti.Ylaraja = 65535;
            // 
            // numerovalitsinVoittopituus
            // 
            this.numerovalitsinVoittopituus.Alaraja = 3;
            this.numerovalitsinVoittopituus.Arvo = 5;
            this.numerovalitsinVoittopituus.HScrollBar = true;
            this.numerovalitsinVoittopituus.Klikattavissa = true;
            this.numerovalitsinVoittopituus.Location = new System.Drawing.Point(33, 101);
            this.numerovalitsinVoittopituus.Name = "numerovalitsinVoittopituus";
            this.numerovalitsinVoittopituus.Size = new System.Drawing.Size(294, 20);
            this.numerovalitsinVoittopituus.TabIndex = 25;
            this.numerovalitsinVoittopituus.Teksti = "Voittopituus:";
            this.numerovalitsinVoittopituus.Ylaraja = 20;
            // 
            // numerovalitsinKorkeus
            // 
            this.numerovalitsinKorkeus.Alaraja = 3;
            this.numerovalitsinKorkeus.Arvo = 25;
            this.numerovalitsinKorkeus.HScrollBar = true;
            this.numerovalitsinKorkeus.Klikattavissa = true;
            this.numerovalitsinKorkeus.Location = new System.Drawing.Point(33, 74);
            this.numerovalitsinKorkeus.Name = "numerovalitsinKorkeus";
            this.numerovalitsinKorkeus.Size = new System.Drawing.Size(286, 20);
            this.numerovalitsinKorkeus.TabIndex = 24;
            this.numerovalitsinKorkeus.Teksti = "Kentän korkeus:";
            this.numerovalitsinKorkeus.Ylaraja = 90;
            // 
            // numerovalitsinLeveys
            // 
            this.numerovalitsinLeveys.Alaraja = 3;
            this.numerovalitsinLeveys.Arvo = 25;
            this.numerovalitsinLeveys.HScrollBar = true;
            this.numerovalitsinLeveys.Klikattavissa = true;
            this.numerovalitsinLeveys.Location = new System.Drawing.Point(33, 47);
            this.numerovalitsinLeveys.Name = "numerovalitsinLeveys";
            this.numerovalitsinLeveys.Size = new System.Drawing.Size(309, 20);
            this.numerovalitsinLeveys.TabIndex = 23;
            this.numerovalitsinLeveys.Teksti = "Kentän leveys:";
            this.numerovalitsinLeveys.Ylaraja = 90;
            // 
            // FormLuoPeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(332, 268);
            this.ControlBox = false;
            this.Controls.Add(this.buttonPois);
            this.Controls.Add(this.buttonPeruutaLuonti);
            this.Controls.Add(this.buttonLuoPeli);
            this.Controls.Add(this.numerovalitsinPortti);
            this.Controls.Add(this.numerovalitsinVoittopituus);
            this.Controls.Add(this.numerovalitsinKorkeus);
            this.Controls.Add(this.numerovalitsinLeveys);
            this.Controls.Add(this.panelYhdistys);
            this.Controls.Add(this.labelYhdistaPeliin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLuoPeli";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nettiristinolla - Luo peli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLuoPeli_FormClosing);
            this.Load += new System.EventHandler(this.FormLuoPeli_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormLuoPeli_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormLuoPeli_KeyUp);
            this.panelYhdistys.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelYhdistaPeliin;
        private System.Windows.Forms.Panel panelYhdistys;
        private System.Windows.Forms.ProgressBar progressBarYhdistys;
        private System.Windows.Forms.Label labelInfoYhdistetaan;
        private System.Windows.Forms.Button buttonLuoPeli;
        private Numerovalitsin numerovalitsinLeveys;
        private Numerovalitsin numerovalitsinKorkeus;
        private Numerovalitsin numerovalitsinVoittopituus;
        private Numerovalitsin numerovalitsinPortti;
        private System.Windows.Forms.Button buttonPeruutaLuonti;
        private System.Windows.Forms.Button buttonPois;
    }
}