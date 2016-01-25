namespace Nettiristinolla
{
    partial class FormAsetukset
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
            this.labelAsetukset = new System.Windows.Forms.Label();
            this.labelVari = new System.Windows.Forms.Label();
            this.colorDialogVari = new System.Windows.Forms.ColorDialog();
            this.buttonVari = new System.Windows.Forms.Button();
            this.panelVari = new System.Windows.Forms.Panel();
            this.panelViivavari = new System.Windows.Forms.Panel();
            this.buttonViivavari = new System.Windows.Forms.Button();
            this.labelViivavari = new System.Windows.Forms.Label();
            this.panelOmaMerkkivari = new System.Windows.Forms.Panel();
            this.buttonOmaMerkkivari = new System.Windows.Forms.Button();
            this.labelOmaMerkkivari = new System.Windows.Forms.Label();
            this.panelVierasMerkkivari = new System.Windows.Forms.Panel();
            this.buttonVierasMerkkivari = new System.Windows.Forms.Button();
            this.labelVierasMerkkivari = new System.Windows.Forms.Label();
            this.labelUlkoasuinfo = new System.Windows.Forms.Label();
            this.buttonOKAsetukset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAsetukset
            // 
            this.labelAsetukset.AutoSize = true;
            this.labelAsetukset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAsetukset.Location = new System.Drawing.Point(12, 9);
            this.labelAsetukset.Name = "labelAsetukset";
            this.labelAsetukset.Size = new System.Drawing.Size(99, 25);
            this.labelAsetukset.TabIndex = 1;
            this.labelAsetukset.Text = "Asetukset";
            // 
            // labelVari
            // 
            this.labelVari.AutoSize = true;
            this.labelVari.Location = new System.Drawing.Point(39, 73);
            this.labelVari.Name = "labelVari";
            this.labelVari.Size = new System.Drawing.Size(109, 13);
            this.labelVari.TabIndex = 2;
            this.labelVari.Text = "Ruudukon pohjaväri: ";
            // 
            // buttonVari
            // 
            this.buttonVari.BackColor = System.Drawing.Color.Lavender;
            this.buttonVari.Location = new System.Drawing.Point(212, 68);
            this.buttonVari.Name = "buttonVari";
            this.buttonVari.Size = new System.Drawing.Size(75, 23);
            this.buttonVari.TabIndex = 1;
            this.buttonVari.Text = "Valitse väri";
            this.buttonVari.UseVisualStyleBackColor = false;
            this.buttonVari.Click += new System.EventHandler(this.buttonVari_Click);
            // 
            // panelVari
            // 
            this.panelVari.Location = new System.Drawing.Point(142, 68);
            this.panelVari.Name = "panelVari";
            this.panelVari.Size = new System.Drawing.Size(64, 23);
            this.panelVari.TabIndex = 4;
            // 
            // panelViivavari
            // 
            this.panelViivavari.Location = new System.Drawing.Point(142, 97);
            this.panelViivavari.Name = "panelViivavari";
            this.panelViivavari.Size = new System.Drawing.Size(64, 23);
            this.panelViivavari.TabIndex = 7;
            // 
            // buttonViivavari
            // 
            this.buttonViivavari.BackColor = System.Drawing.Color.Lavender;
            this.buttonViivavari.Location = new System.Drawing.Point(212, 97);
            this.buttonViivavari.Name = "buttonViivavari";
            this.buttonViivavari.Size = new System.Drawing.Size(75, 23);
            this.buttonViivavari.TabIndex = 2;
            this.buttonViivavari.Text = "Valitse väri";
            this.buttonViivavari.UseVisualStyleBackColor = false;
            this.buttonViivavari.Click += new System.EventHandler(this.buttonViivavari_Click);
            // 
            // labelViivavari
            // 
            this.labelViivavari.AutoSize = true;
            this.labelViivavari.Location = new System.Drawing.Point(39, 102);
            this.labelViivavari.Name = "labelViivavari";
            this.labelViivavari.Size = new System.Drawing.Size(105, 13);
            this.labelViivavari.TabIndex = 5;
            this.labelViivavari.Text = "Ruudukon viivaväri: ";
            // 
            // panelOmaMerkkivari
            // 
            this.panelOmaMerkkivari.Location = new System.Drawing.Point(142, 126);
            this.panelOmaMerkkivari.Name = "panelOmaMerkkivari";
            this.panelOmaMerkkivari.Size = new System.Drawing.Size(64, 23);
            this.panelOmaMerkkivari.TabIndex = 10;
            // 
            // buttonOmaMerkkivari
            // 
            this.buttonOmaMerkkivari.BackColor = System.Drawing.Color.Lavender;
            this.buttonOmaMerkkivari.Location = new System.Drawing.Point(212, 126);
            this.buttonOmaMerkkivari.Name = "buttonOmaMerkkivari";
            this.buttonOmaMerkkivari.Size = new System.Drawing.Size(75, 23);
            this.buttonOmaMerkkivari.TabIndex = 3;
            this.buttonOmaMerkkivari.Text = "Valitse väri";
            this.buttonOmaMerkkivari.UseVisualStyleBackColor = false;
            this.buttonOmaMerkkivari.Click += new System.EventHandler(this.buttonOmaMerkkivari_Click);
            // 
            // labelOmaMerkkivari
            // 
            this.labelOmaMerkkivari.AutoSize = true;
            this.labelOmaMerkkivari.Location = new System.Drawing.Point(39, 160);
            this.labelOmaMerkkivari.Name = "labelOmaMerkkivari";
            this.labelOmaMerkkivari.Size = new System.Drawing.Size(92, 13);
            this.labelOmaMerkkivari.TabIndex = 8;
            this.labelOmaMerkkivari.Text = "Oman merkin väri:";
            // 
            // panelVierasMerkkivari
            // 
            this.panelVierasMerkkivari.Location = new System.Drawing.Point(142, 155);
            this.panelVierasMerkkivari.Name = "panelVierasMerkkivari";
            this.panelVierasMerkkivari.Size = new System.Drawing.Size(64, 23);
            this.panelVierasMerkkivari.TabIndex = 10;
            // 
            // buttonVierasMerkkivari
            // 
            this.buttonVierasMerkkivari.BackColor = System.Drawing.Color.Lavender;
            this.buttonVierasMerkkivari.Location = new System.Drawing.Point(212, 155);
            this.buttonVierasMerkkivari.Name = "buttonVierasMerkkivari";
            this.buttonVierasMerkkivari.Size = new System.Drawing.Size(75, 23);
            this.buttonVierasMerkkivari.TabIndex = 4;
            this.buttonVierasMerkkivari.Text = "Valitse väri";
            this.buttonVierasMerkkivari.UseVisualStyleBackColor = false;
            this.buttonVierasMerkkivari.Click += new System.EventHandler(this.buttonVierasMerkkivari_Click);
            // 
            // labelVierasMerkkivari
            // 
            this.labelVierasMerkkivari.AutoSize = true;
            this.labelVierasMerkkivari.Location = new System.Drawing.Point(39, 131);
            this.labelVierasMerkkivari.Name = "labelVierasMerkkivari";
            this.labelVierasMerkkivari.Size = new System.Drawing.Size(100, 13);
            this.labelVierasMerkkivari.TabIndex = 8;
            this.labelVierasMerkkivari.Text = "Vieraan merkin väri:";
            // 
            // labelUlkoasuinfo
            // 
            this.labelUlkoasuinfo.AutoSize = true;
            this.labelUlkoasuinfo.Location = new System.Drawing.Point(26, 43);
            this.labelUlkoasuinfo.Name = "labelUlkoasuinfo";
            this.labelUlkoasuinfo.Size = new System.Drawing.Size(286, 13);
            this.labelUlkoasuinfo.TabIndex = 11;
            this.labelUlkoasuinfo.Text = "Nämä ulkoasuasetukset vaikuttavat ristinollan ruudukkoon.";
            // 
            // buttonOKAsetukset
            // 
            this.buttonOKAsetukset.BackColor = System.Drawing.Color.Lavender;
            this.buttonOKAsetukset.Location = new System.Drawing.Point(142, 184);
            this.buttonOKAsetukset.Name = "buttonOKAsetukset";
            this.buttonOKAsetukset.Size = new System.Drawing.Size(64, 23);
            this.buttonOKAsetukset.TabIndex = 5;
            this.buttonOKAsetukset.Text = "&Sulje";
            this.buttonOKAsetukset.UseVisualStyleBackColor = false;
            this.buttonOKAsetukset.Click += new System.EventHandler(this.buttonOKAsetukset_Click);
            // 
            // FormAsetukset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(323, 220);
            this.Controls.Add(this.buttonOKAsetukset);
            this.Controls.Add(this.labelUlkoasuinfo);
            this.Controls.Add(this.panelVierasMerkkivari);
            this.Controls.Add(this.buttonVierasMerkkivari);
            this.Controls.Add(this.panelOmaMerkkivari);
            this.Controls.Add(this.labelVierasMerkkivari);
            this.Controls.Add(this.buttonOmaMerkkivari);
            this.Controls.Add(this.panelViivavari);
            this.Controls.Add(this.labelOmaMerkkivari);
            this.Controls.Add(this.buttonViivavari);
            this.Controls.Add(this.panelVari);
            this.Controls.Add(this.labelViivavari);
            this.Controls.Add(this.buttonVari);
            this.Controls.Add(this.labelVari);
            this.Controls.Add(this.labelAsetukset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FormAsetukset";
            this.Text = "Nettiristinolla - Asetukset";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormAsetukset_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormAsetukset_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAsetukset;
        private System.Windows.Forms.Label labelVari;
        private System.Windows.Forms.ColorDialog colorDialogVari;
        private System.Windows.Forms.Button buttonVari;
        private System.Windows.Forms.Panel panelVari;
        private System.Windows.Forms.Panel panelViivavari;
        private System.Windows.Forms.Button buttonViivavari;
        private System.Windows.Forms.Label labelViivavari;
        private System.Windows.Forms.Panel panelOmaMerkkivari;
        private System.Windows.Forms.Button buttonOmaMerkkivari;
        private System.Windows.Forms.Label labelOmaMerkkivari;
        private System.Windows.Forms.Panel panelVierasMerkkivari;
        private System.Windows.Forms.Button buttonVierasMerkkivari;
        private System.Windows.Forms.Label labelVierasMerkkivari;
        private System.Windows.Forms.Label labelUlkoasuinfo;
        private System.Windows.Forms.Button buttonOKAsetukset;
    }
}