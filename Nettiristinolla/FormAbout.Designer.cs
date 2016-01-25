namespace Nettiristinolla
{
    partial class FormAbout
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
            this.labelAboutOtsikko = new System.Windows.Forms.Label();
            this.labelTekija = new System.Windows.Forms.Label();
            this.labelSelitys = new System.Windows.Forms.Label();
            this.labelVersio = new System.Windows.Forms.Label();
            this.buttonAboutSulje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAboutOtsikko
            // 
            this.labelAboutOtsikko.AutoSize = true;
            this.labelAboutOtsikko.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboutOtsikko.Location = new System.Drawing.Point(32, 21);
            this.labelAboutOtsikko.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelAboutOtsikko.Name = "labelAboutOtsikko";
            this.labelAboutOtsikko.Size = new System.Drawing.Size(390, 58);
            this.labelAboutOtsikko.TabIndex = 0;
            this.labelAboutOtsikko.Text = "Online-Ristinolla";
            // 
            // labelTekija
            // 
            this.labelTekija.AutoSize = true;
            this.labelTekija.Location = new System.Drawing.Point(32, 320);
            this.labelTekija.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTekija.Name = "labelTekija";
            this.labelTekija.Size = new System.Drawing.Size(345, 32);
            this.labelTekija.TabIndex = 1;
            this.labelTekija.Text = "Arto Rytkönen 2016.01.25";
            // 
            // labelSelitys
            // 
            this.labelSelitys.Location = new System.Drawing.Point(77, 110);
            this.labelSelitys.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelSelitys.Name = "labelSelitys";
            this.labelSelitys.Size = new System.Drawing.Size(504, 100);
            this.labelSelitys.TabIndex = 2;
            this.labelSelitys.Text = "Kahden pelaajan muokattava ristinollapeli. Toimii parhaiten samassa lähiverkossa." +
    "";
            // 
            // labelVersio
            // 
            this.labelVersio.AutoSize = true;
            this.labelVersio.Location = new System.Drawing.Point(520, 320);
            this.labelVersio.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelVersio.Name = "labelVersio";
            this.labelVersio.Size = new System.Drawing.Size(96, 32);
            this.labelVersio.TabIndex = 3;
            this.labelVersio.Text = "Versio";
            // 
            // buttonAboutSulje
            // 
            this.buttonAboutSulje.BackColor = System.Drawing.Color.Lavender;
            this.buttonAboutSulje.Location = new System.Drawing.Point(192, 244);
            this.buttonAboutSulje.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonAboutSulje.Name = "buttonAboutSulje";
            this.buttonAboutSulje.Size = new System.Drawing.Size(200, 55);
            this.buttonAboutSulje.TabIndex = 1;
            this.buttonAboutSulje.Text = "&OK";
            this.buttonAboutSulje.UseVisualStyleBackColor = false;
            this.buttonAboutSulje.Click += new System.EventHandler(this.buttonAboutSulje_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(688, 392);
            this.Controls.Add(this.buttonAboutSulje);
            this.Controls.Add(this.labelVersio);
            this.Controls.Add(this.labelSelitys);
            this.Controls.Add(this.labelTekija);
            this.Controls.Add(this.labelAboutOtsikko);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.Text = "Online-Ristinolla - Tietoja";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormAbout_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormAbout_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAboutOtsikko;
        private System.Windows.Forms.Label labelTekija;
        private System.Windows.Forms.Label labelSelitys;
        private System.Windows.Forms.Label labelVersio;
        private System.Windows.Forms.Button buttonAboutSulje;
    }
}