namespace Nettiristinolla
{
    partial class testi
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
            this.buttonLuo = new System.Windows.Forms.Button();
            this.buttonYhdista = new System.Windows.Forms.Button();
            this.buttonKatkaisePalvelin = new System.Windows.Forms.Button();
            this.buttonKatkaiseAsiakas = new System.Windows.Forms.Button();
            this.listBoxPalvelin = new System.Windows.Forms.ListBox();
            this.listBoxAsiakas = new System.Windows.Forms.ListBox();
            this.buttonViestiPalvelin = new System.Windows.Forms.Button();
            this.buttonViestiAsiakas = new System.Windows.Forms.Button();
            this.buttonSuljeVakisinPalvelin = new System.Windows.Forms.Button();
            this.buttonSuljeVakisinAsiakas = new System.Windows.Forms.Button();
            this.nettiliikenne1 = new Nettiristinolla.Liikenne();
            this.nettiliikenne2 = new Nettiristinolla.Liikenne();
            this.textBoxOsoite = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLuo
            // 
            this.buttonLuo.Location = new System.Drawing.Point(25, 24);
            this.buttonLuo.Name = "buttonLuo";
            this.buttonLuo.Size = new System.Drawing.Size(75, 23);
            this.buttonLuo.TabIndex = 0;
            this.buttonLuo.Text = "Luo peli";
            this.buttonLuo.UseVisualStyleBackColor = true;
            this.buttonLuo.Click += new System.EventHandler(this.buttonLuo_Click);
            // 
            // buttonYhdista
            // 
            this.buttonYhdista.Location = new System.Drawing.Point(367, 24);
            this.buttonYhdista.Name = "buttonYhdista";
            this.buttonYhdista.Size = new System.Drawing.Size(75, 23);
            this.buttonYhdista.TabIndex = 1;
            this.buttonYhdista.Text = "Yhdistä";
            this.buttonYhdista.UseVisualStyleBackColor = true;
            this.buttonYhdista.Click += new System.EventHandler(this.buttonYhdista_Click);
            // 
            // buttonKatkaisePalvelin
            // 
            this.buttonKatkaisePalvelin.Location = new System.Drawing.Point(25, 53);
            this.buttonKatkaisePalvelin.Name = "buttonKatkaisePalvelin";
            this.buttonKatkaisePalvelin.Size = new System.Drawing.Size(75, 23);
            this.buttonKatkaisePalvelin.TabIndex = 2;
            this.buttonKatkaisePalvelin.Text = "Katkaise";
            this.buttonKatkaisePalvelin.UseVisualStyleBackColor = true;
            this.buttonKatkaisePalvelin.Click += new System.EventHandler(this.buttonKatkaisePalvelin_Click);
            // 
            // buttonKatkaiseAsiakas
            // 
            this.buttonKatkaiseAsiakas.Location = new System.Drawing.Point(367, 53);
            this.buttonKatkaiseAsiakas.Name = "buttonKatkaiseAsiakas";
            this.buttonKatkaiseAsiakas.Size = new System.Drawing.Size(75, 23);
            this.buttonKatkaiseAsiakas.TabIndex = 3;
            this.buttonKatkaiseAsiakas.Text = "Katkaise";
            this.buttonKatkaiseAsiakas.UseVisualStyleBackColor = true;
            this.buttonKatkaiseAsiakas.Click += new System.EventHandler(this.buttonKatkaiseAsiakas_Click);
            // 
            // listBoxPalvelin
            // 
            this.listBoxPalvelin.FormattingEnabled = true;
            this.listBoxPalvelin.Location = new System.Drawing.Point(25, 153);
            this.listBoxPalvelin.Name = "listBoxPalvelin";
            this.listBoxPalvelin.Size = new System.Drawing.Size(302, 173);
            this.listBoxPalvelin.TabIndex = 4;
            // 
            // listBoxAsiakas
            // 
            this.listBoxAsiakas.FormattingEnabled = true;
            this.listBoxAsiakas.Location = new System.Drawing.Point(367, 153);
            this.listBoxAsiakas.Name = "listBoxAsiakas";
            this.listBoxAsiakas.Size = new System.Drawing.Size(304, 173);
            this.listBoxAsiakas.TabIndex = 5;
            // 
            // buttonViestiPalvelin
            // 
            this.buttonViestiPalvelin.Location = new System.Drawing.Point(25, 83);
            this.buttonViestiPalvelin.Name = "buttonViestiPalvelin";
            this.buttonViestiPalvelin.Size = new System.Drawing.Size(75, 23);
            this.buttonViestiPalvelin.TabIndex = 6;
            this.buttonViestiPalvelin.Text = "Uusi viesti";
            this.buttonViestiPalvelin.UseVisualStyleBackColor = true;
            this.buttonViestiPalvelin.Click += new System.EventHandler(this.buttonViestiPalvelin_Click);
            // 
            // buttonViestiAsiakas
            // 
            this.buttonViestiAsiakas.Location = new System.Drawing.Point(367, 83);
            this.buttonViestiAsiakas.Name = "buttonViestiAsiakas";
            this.buttonViestiAsiakas.Size = new System.Drawing.Size(75, 23);
            this.buttonViestiAsiakas.TabIndex = 7;
            this.buttonViestiAsiakas.Text = "Uusi viesti";
            this.buttonViestiAsiakas.UseVisualStyleBackColor = true;
            this.buttonViestiAsiakas.Click += new System.EventHandler(this.buttonViestiAsiakas_Click);
            // 
            // buttonSuljeVakisinPalvelin
            // 
            this.buttonSuljeVakisinPalvelin.Location = new System.Drawing.Point(106, 53);
            this.buttonSuljeVakisinPalvelin.Name = "buttonSuljeVakisinPalvelin";
            this.buttonSuljeVakisinPalvelin.Size = new System.Drawing.Size(75, 23);
            this.buttonSuljeVakisinPalvelin.TabIndex = 8;
            this.buttonSuljeVakisinPalvelin.Text = "Sulje väkisin";
            this.buttonSuljeVakisinPalvelin.UseVisualStyleBackColor = true;
            this.buttonSuljeVakisinPalvelin.Click += new System.EventHandler(this.buttonSuljeVakisinPalvelin_Click);
            // 
            // buttonSuljeVakisinAsiakas
            // 
            this.buttonSuljeVakisinAsiakas.Location = new System.Drawing.Point(448, 53);
            this.buttonSuljeVakisinAsiakas.Name = "buttonSuljeVakisinAsiakas";
            this.buttonSuljeVakisinAsiakas.Size = new System.Drawing.Size(75, 23);
            this.buttonSuljeVakisinAsiakas.TabIndex = 9;
            this.buttonSuljeVakisinAsiakas.Text = "Sulje väkisin";
            this.buttonSuljeVakisinAsiakas.UseVisualStyleBackColor = true;
            this.buttonSuljeVakisinAsiakas.Click += new System.EventHandler(this.buttonSuljeVakisinAsiakas_Click);
            // 
            // nettiliikenne1
            // 
            this.nettiliikenne1.Kanavat = new string[] {
        "viesti"};
            this.nettiliikenne1.LukuSeis = true;
            this.nettiliikenne1.Osoite = "127.0.0.1";
            this.nettiliikenne1.Palvelin = true;
            this.nettiliikenne1.Portti = 9696;
            // 
            // nettiliikenne2
            // 
            this.nettiliikenne2.Kanavat = new string[] {
        "viesti"};
            this.nettiliikenne2.LukuSeis = true;
            this.nettiliikenne2.Osoite = "127.0.0.1";
            this.nettiliikenne2.Palvelin = false;
            this.nettiliikenne2.Portti = 9696;
            // 
            // textBoxOsoite
            // 
            this.textBoxOsoite.Location = new System.Drawing.Point(367, 113);
            this.textBoxOsoite.Name = "textBoxOsoite";
            this.textBoxOsoite.Size = new System.Drawing.Size(136, 20);
            this.textBoxOsoite.TabIndex = 10;
            this.textBoxOsoite.Text = "127.0.0.1";
            // 
            // testi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 404);
            this.Controls.Add(this.textBoxOsoite);
            this.Controls.Add(this.buttonSuljeVakisinAsiakas);
            this.Controls.Add(this.buttonSuljeVakisinPalvelin);
            this.Controls.Add(this.buttonViestiAsiakas);
            this.Controls.Add(this.buttonViestiPalvelin);
            this.Controls.Add(this.listBoxAsiakas);
            this.Controls.Add(this.listBoxPalvelin);
            this.Controls.Add(this.buttonKatkaiseAsiakas);
            this.Controls.Add(this.buttonKatkaisePalvelin);
            this.Controls.Add(this.buttonYhdista);
            this.Controls.Add(this.buttonLuo);
            this.Name = "testi";
            this.Text = "testi";
            this.Load += new System.EventHandler(this.testi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Liikenne nettiliikenne1;
        private Liikenne nettiliikenne2;
        private System.Windows.Forms.Button buttonLuo;
        private System.Windows.Forms.Button buttonYhdista;
        private System.Windows.Forms.Button buttonKatkaisePalvelin;
        private System.Windows.Forms.Button buttonKatkaiseAsiakas;
        private System.Windows.Forms.ListBox listBoxPalvelin;
        private System.Windows.Forms.ListBox listBoxAsiakas;
        private System.Windows.Forms.Button buttonViestiPalvelin;
        private System.Windows.Forms.Button buttonViestiAsiakas;
        private System.Windows.Forms.Button buttonSuljeVakisinPalvelin;
        private System.Windows.Forms.Button buttonSuljeVakisinAsiakas;
        private System.Windows.Forms.TextBox textBoxOsoite;
    }
}