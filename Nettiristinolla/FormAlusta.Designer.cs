namespace Nettiristinolla
{
    partial class FormAlusta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlusta));
            this.menuStripValikko = new System.Windows.Forms.MenuStrip();
            this.tiedostoToolStripMenuItemTiedosto = new System.Windows.Forms.ToolStripMenuItem();
            this.lopetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asetuksetToolStripMenuItemAsetukset = new System.Windows.Forms.ToolStripMenuItem();
            this.ulkoasuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ohjeToolStripMenuItemOhje = new System.Windows.Forms.ToolStripMenuItem();
            this.tietojaNettiristinollastaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiedostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asetuksetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ohjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAlku = new System.Windows.Forms.Panel();
            this.textBoxNimi = new System.Windows.Forms.TextBox();
            this.labelNimi = new System.Windows.Forms.Label();
            this.labelAlkuohje = new System.Windows.Forms.Label();
            this.buttonLuoUusiPeli = new System.Windows.Forms.Button();
            this.buttonLiityPeliin = new System.Windows.Forms.Button();
            this.labelVersio = new System.Windows.Forms.Label();
            this.labelNettiristinolla = new System.Windows.Forms.Label();
            this.panelKeskustelu = new System.Windows.Forms.Panel();
            this.textBoxViesti = new System.Windows.Forms.TextBox();
            this.buttonLaheta = new System.Windows.Forms.Button();
            this.listBoxViestit = new System.Windows.Forms.ListBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panelRevanssinappulat = new System.Windows.Forms.Panel();
            this.labelRevanssi = new System.Windows.Forms.Label();
            this.buttonEiUutta = new System.Windows.Forms.Button();
            this.buttonUusiPeli = new System.Windows.Forms.Button();
            this.buttonPaavalikkoon = new System.Windows.Forms.Button();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ulkoasuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ohjeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ristikkoPeliristikko = new Nettiristinolla.Ristikko();
            this.menuStripValikko.SuspendLayout();
            this.panelAlku.SuspendLayout();
            this.panelKeskustelu.SuspendLayout();
            this.panelRevanssinappulat.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripValikko
            // 
            this.menuStripValikko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.menuStripValikko.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStripValikko.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiedostoToolStripMenuItemTiedosto,
            this.asetuksetToolStripMenuItemAsetukset,
            this.ohjeToolStripMenuItemOhje});
            this.menuStripValikko.Location = new System.Drawing.Point(0, 0);
            this.menuStripValikko.Name = "menuStripValikko";
            this.menuStripValikko.Padding = new System.Windows.Forms.Padding(16, 5, 0, 5);
            this.menuStripValikko.Size = new System.Drawing.Size(976, 55);
            this.menuStripValikko.TabIndex = 0;
            this.menuStripValikko.Text = "menuStrip1";
            // 
            // tiedostoToolStripMenuItemTiedosto
            // 
            this.tiedostoToolStripMenuItemTiedosto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lopetaToolStripMenuItem});
            this.tiedostoToolStripMenuItemTiedosto.Name = "tiedostoToolStripMenuItemTiedosto";
            this.tiedostoToolStripMenuItemTiedosto.Size = new System.Drawing.Size(146, 45);
            this.tiedostoToolStripMenuItemTiedosto.Text = "&Tiedosto";
            // 
            // lopetaToolStripMenuItem
            // 
            this.lopetaToolStripMenuItem.Name = "lopetaToolStripMenuItem";
            this.lopetaToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.lopetaToolStripMenuItem.Text = "&Lopeta";
            this.lopetaToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // asetuksetToolStripMenuItemAsetukset
            // 
            this.asetuksetToolStripMenuItemAsetukset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ulkoasuToolStripMenuItem1});
            this.asetuksetToolStripMenuItemAsetukset.Name = "asetuksetToolStripMenuItemAsetukset";
            this.asetuksetToolStripMenuItemAsetukset.Size = new System.Drawing.Size(159, 45);
            this.asetuksetToolStripMenuItemAsetukset.Text = "&Asetukset";
            // 
            // ulkoasuToolStripMenuItem1
            // 
            this.ulkoasuToolStripMenuItem1.Name = "ulkoasuToolStripMenuItem1";
            this.ulkoasuToolStripMenuItem1.Size = new System.Drawing.Size(327, 46);
            this.ulkoasuToolStripMenuItem1.Text = "&Ulkoasu";
            this.ulkoasuToolStripMenuItem1.Click += new System.EventHandler(this.ulkoasuToolStripMenuItem_Click);
            // 
            // ohjeToolStripMenuItemOhje
            // 
            this.ohjeToolStripMenuItemOhje.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tietojaNettiristinollastaToolStripMenuItem,
            this.abouToolStripMenuItem});
            this.ohjeToolStripMenuItemOhje.Name = "ohjeToolStripMenuItemOhje";
            this.ohjeToolStripMenuItemOhje.Size = new System.Drawing.Size(93, 45);
            this.ohjeToolStripMenuItemOhje.Text = "&Ohje";
            // 
            // tietojaNettiristinollastaToolStripMenuItem
            // 
            this.tietojaNettiristinollastaToolStripMenuItem.Name = "tietojaNettiristinollastaToolStripMenuItem";
            this.tietojaNettiristinollastaToolStripMenuItem.Size = new System.Drawing.Size(444, 46);
            this.tietojaNettiristinollastaToolStripMenuItem.Text = "T&ietoja Nettiristinollasta";
            this.tietojaNettiristinollastaToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // abouToolStripMenuItem
            // 
            this.abouToolStripMenuItem.Name = "abouToolStripMenuItem";
            this.abouToolStripMenuItem.Size = new System.Drawing.Size(444, 46);
            this.abouToolStripMenuItem.Text = "&Ohje";
            this.abouToolStripMenuItem.Click += new System.EventHandler(this.ohjeToolStripMenuItem1_Click);
            // 
            // tiedostoToolStripMenuItem
            // 
            this.tiedostoToolStripMenuItem.Name = "tiedostoToolStripMenuItem";
            this.tiedostoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.tiedostoToolStripMenuItem.Text = "&Tiedosto";
            // 
            // asetuksetToolStripMenuItem
            // 
            this.asetuksetToolStripMenuItem.Name = "asetuksetToolStripMenuItem";
            this.asetuksetToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.asetuksetToolStripMenuItem.Text = "&Asetukset";
            // 
            // ohjeToolStripMenuItem
            // 
            this.ohjeToolStripMenuItem.Name = "ohjeToolStripMenuItem";
            this.ohjeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ohjeToolStripMenuItem.Text = "&Ohje";
            // 
            // panelAlku
            // 
            this.panelAlku.Controls.Add(this.textBoxNimi);
            this.panelAlku.Controls.Add(this.labelNimi);
            this.panelAlku.Controls.Add(this.labelAlkuohje);
            this.panelAlku.Controls.Add(this.buttonLuoUusiPeli);
            this.panelAlku.Controls.Add(this.buttonLiityPeliin);
            this.panelAlku.Controls.Add(this.labelVersio);
            this.panelAlku.Controls.Add(this.labelNettiristinolla);
            this.panelAlku.Location = new System.Drawing.Point(32, 93);
            this.panelAlku.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelAlku.Name = "panelAlku";
            this.panelAlku.Size = new System.Drawing.Size(944, 384);
            this.panelAlku.TabIndex = 1;
            // 
            // textBoxNimi
            // 
            this.textBoxNimi.Location = new System.Drawing.Point(227, 86);
            this.textBoxNimi.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxNimi.Name = "textBoxNimi";
            this.textBoxNimi.Size = new System.Drawing.Size(409, 38);
            this.textBoxNimi.TabIndex = 3;
            // 
            // labelNimi
            // 
            this.labelNimi.AutoSize = true;
            this.labelNimi.Location = new System.Drawing.Point(48, 93);
            this.labelNimi.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelNimi.Name = "labelNimi";
            this.labelNimi.Size = new System.Drawing.Size(163, 32);
            this.labelNimi.TabIndex = 5;
            this.labelNimi.Text = "Nimimerkki:";
            // 
            // labelAlkuohje
            // 
            this.labelAlkuohje.AutoSize = true;
            this.labelAlkuohje.Location = new System.Drawing.Point(48, 160);
            this.labelAlkuohje.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelAlkuohje.Name = "labelAlkuohje";
            this.labelAlkuohje.Size = new System.Drawing.Size(609, 32);
            this.labelAlkuohje.TabIndex = 4;
            this.labelAlkuohje.Text = "Haluatko luoda pelin vai yhdistää toisen peliin?";
            // 
            // buttonLuoUusiPeli
            // 
            this.buttonLuoUusiPeli.BackColor = System.Drawing.Color.Lavender;
            this.buttonLuoUusiPeli.Location = new System.Drawing.Point(56, 227);
            this.buttonLuoUusiPeli.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonLuoUusiPeli.Name = "buttonLuoUusiPeli";
            this.buttonLuoUusiPeli.Size = new System.Drawing.Size(392, 93);
            this.buttonLuoUusiPeli.TabIndex = 1;
            this.buttonLuoUusiPeli.Text = "Luo &uusi peli";
            this.buttonLuoUusiPeli.UseVisualStyleBackColor = false;
            this.buttonLuoUusiPeli.Click += new System.EventHandler(this.buttonLuoUusiPeli_Click);
            // 
            // buttonLiityPeliin
            // 
            this.buttonLiityPeliin.BackColor = System.Drawing.Color.Lavender;
            this.buttonLiityPeliin.Location = new System.Drawing.Point(464, 227);
            this.buttonLiityPeliin.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonLiityPeliin.Name = "buttonLiityPeliin";
            this.buttonLiityPeliin.Size = new System.Drawing.Size(392, 93);
            this.buttonLiityPeliin.TabIndex = 2;
            this.buttonLiityPeliin.Text = "Liity &peliin";
            this.buttonLiityPeliin.UseVisualStyleBackColor = false;
            this.buttonLiityPeliin.Click += new System.EventHandler(this.buttonLiityPeliin_Click);
            // 
            // labelVersio
            // 
            this.labelVersio.AutoSize = true;
            this.labelVersio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersio.Location = new System.Drawing.Point(773, 346);
            this.labelVersio.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelVersio.Name = "labelVersio";
            this.labelVersio.Size = new System.Drawing.Size(99, 32);
            this.labelVersio.TabIndex = 1;
            this.labelVersio.Text = "Versio ";
            // 
            // labelNettiristinolla
            // 
            this.labelNettiristinolla.AutoSize = true;
            this.labelNettiristinolla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNettiristinolla.Location = new System.Drawing.Point(8, 0);
            this.labelNettiristinolla.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelNettiristinolla.Name = "labelNettiristinolla";
            this.labelNettiristinolla.Size = new System.Drawing.Size(312, 58);
            this.labelNettiristinolla.TabIndex = 0;
            this.labelNettiristinolla.Text = "Nettiristinolla";
            // 
            // panelKeskustelu
            // 
            this.panelKeskustelu.Controls.Add(this.textBoxViesti);
            this.panelKeskustelu.Controls.Add(this.buttonLaheta);
            this.panelKeskustelu.Controls.Add(this.listBoxViestit);
            this.panelKeskustelu.Location = new System.Drawing.Point(1088, 93);
            this.panelKeskustelu.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelKeskustelu.Name = "panelKeskustelu";
            this.panelKeskustelu.Size = new System.Drawing.Size(720, 250);
            this.panelKeskustelu.TabIndex = 17;
            this.panelKeskustelu.Visible = false;
            // 
            // textBoxViesti
            // 
            this.textBoxViesti.Location = new System.Drawing.Point(0, 196);
            this.textBoxViesti.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxViesti.Name = "textBoxViesti";
            this.textBoxViesti.Size = new System.Drawing.Size(497, 38);
            this.textBoxViesti.TabIndex = 2;
            this.textBoxViesti.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxViesti_KeyUp);
            // 
            // buttonLaheta
            // 
            this.buttonLaheta.BackColor = System.Drawing.Color.Lavender;
            this.buttonLaheta.Location = new System.Drawing.Point(520, 196);
            this.buttonLaheta.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonLaheta.Name = "buttonLaheta";
            this.buttonLaheta.Size = new System.Drawing.Size(192, 55);
            this.buttonLaheta.TabIndex = 1;
            this.buttonLaheta.Text = "&Lähetä";
            this.buttonLaheta.UseVisualStyleBackColor = false;
            this.buttonLaheta.Click += new System.EventHandler(this.buttonLaheta_Click);
            // 
            // listBoxViestit
            // 
            this.listBoxViestit.FormattingEnabled = true;
            this.listBoxViestit.ItemHeight = 31;
            this.listBoxViestit.Location = new System.Drawing.Point(0, 0);
            this.listBoxViestit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBoxViestit.Name = "listBoxViestit";
            this.listBoxViestit.Size = new System.Drawing.Size(713, 159);
            this.listBoxViestit.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(1080, 694);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(135, 32);
            this.labelInfo.TabIndex = 20;
            this.labelInfo.Text = "Vuorossa";
            this.labelInfo.Visible = false;
            // 
            // panelRevanssinappulat
            // 
            this.panelRevanssinappulat.Controls.Add(this.labelRevanssi);
            this.panelRevanssinappulat.Controls.Add(this.buttonEiUutta);
            this.panelRevanssinappulat.Controls.Add(this.buttonUusiPeli);
            this.panelRevanssinappulat.Location = new System.Drawing.Point(941, 732);
            this.panelRevanssinappulat.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelRevanssinappulat.Name = "panelRevanssinappulat";
            this.panelRevanssinappulat.Size = new System.Drawing.Size(651, 60);
            this.panelRevanssinappulat.TabIndex = 21;
            this.panelRevanssinappulat.Visible = false;
            // 
            // labelRevanssi
            // 
            this.labelRevanssi.AutoSize = true;
            this.labelRevanssi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRevanssi.Location = new System.Drawing.Point(8, 7);
            this.labelRevanssi.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelRevanssi.Name = "labelRevanssi";
            this.labelRevanssi.Size = new System.Drawing.Size(171, 38);
            this.labelRevanssi.TabIndex = 2;
            this.labelRevanssi.Text = "Revanssi?";
            // 
            // buttonEiUutta
            // 
            this.buttonEiUutta.BackColor = System.Drawing.Color.Lavender;
            this.buttonEiUutta.Location = new System.Drawing.Point(432, 0);
            this.buttonEiUutta.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonEiUutta.Name = "buttonEiUutta";
            this.buttonEiUutta.Size = new System.Drawing.Size(200, 55);
            this.buttonEiUutta.TabIndex = 1;
            this.buttonEiUutta.Text = "&Kyllä!";
            this.buttonEiUutta.UseVisualStyleBackColor = false;
            this.buttonEiUutta.Click += new System.EventHandler(this.buttonEiUutta_Click);
            // 
            // buttonUusiPeli
            // 
            this.buttonUusiPeli.BackColor = System.Drawing.Color.Lavender;
            this.buttonUusiPeli.Location = new System.Drawing.Point(216, 0);
            this.buttonUusiPeli.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonUusiPeli.Name = "buttonUusiPeli";
            this.buttonUusiPeli.Size = new System.Drawing.Size(200, 55);
            this.buttonUusiPeli.TabIndex = 0;
            this.buttonUusiPeli.Text = "&Ei...";
            this.buttonUusiPeli.UseVisualStyleBackColor = false;
            this.buttonUusiPeli.Click += new System.EventHandler(this.buttonUusiPeli_Click);
            // 
            // buttonPaavalikkoon
            // 
            this.buttonPaavalikkoon.BackColor = System.Drawing.Color.Lavender;
            this.buttonPaavalikkoon.Location = new System.Drawing.Point(1125, 806);
            this.buttonPaavalikkoon.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonPaavalikkoon.Name = "buttonPaavalikkoon";
            this.buttonPaavalikkoon.Size = new System.Drawing.Size(333, 55);
            this.buttonPaavalikkoon.TabIndex = 22;
            this.buttonPaavalikkoon.Text = "&Päävalikkoon";
            this.buttonPaavalikkoon.UseVisualStyleBackColor = false;
            this.buttonPaavalikkoon.Visible = false;
            this.buttonPaavalikkoon.Click += new System.EventHandler(this.buttonPaavalikkoon_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Lopeta";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ulkoasuToolStripMenuItem
            // 
            this.ulkoasuToolStripMenuItem.Name = "ulkoasuToolStripMenuItem";
            this.ulkoasuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ulkoasuToolStripMenuItem.Text = "&Ulkoasu";
            this.ulkoasuToolStripMenuItem.Click += new System.EventHandler(this.ulkoasuToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutToolStripMenuItem.Text = "T&ietoja Nettiristinollasta";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ohjeToolStripMenuItem1
            // 
            this.ohjeToolStripMenuItem1.Name = "ohjeToolStripMenuItem1";
            this.ohjeToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.ohjeToolStripMenuItem1.Text = "O&hje";
            this.ohjeToolStripMenuItem1.Click += new System.EventHandler(this.ohjeToolStripMenuItem1_Click);
            // 
            // ristikkoPeliristikko
            // 
            this.ristikkoPeliristikko.AutoScroll = true;
            this.ristikkoPeliristikko.BackColor = System.Drawing.Color.White;
            this.ristikkoPeliristikko.Location = new System.Drawing.Point(1088, 384);
            this.ristikkoPeliristikko.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ristikkoPeliristikko.Name = "ristikkoPeliristikko";
            this.ristikkoPeliristikko.OmaMerkkivari = System.Drawing.Color.Black;
            this.ristikkoPeliristikko.Size = new System.Drawing.Size(648, 303);
            this.ristikkoPeliristikko.TabIndex = 19;
            this.ristikkoPeliristikko.VierasMerkkiVari = System.Drawing.Color.Black;
            this.ristikkoPeliristikko.Viivavari = System.Drawing.Color.Black;
            this.ristikkoPeliristikko.Visible = false;
            // 
            // FormAlusta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(976, 475);
            this.Controls.Add(this.buttonPaavalikkoon);
            this.Controls.Add(this.panelRevanssinappulat);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.ristikkoPeliristikko);
            this.Controls.Add(this.panelKeskustelu);
            this.Controls.Add(this.panelAlku);
            this.Controls.Add(this.menuStripValikko);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripValikko;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FormAlusta";
            this.Text = "Nettiristinolla";
            this.Load += new System.EventHandler(this.FormAlusta_Load);
            this.SizeChanged += new System.EventHandler(this.FormAlusta_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormAlusta_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormAlusta_KeyUp);
            this.menuStripValikko.ResumeLayout(false);
            this.menuStripValikko.PerformLayout();
            this.panelAlku.ResumeLayout(false);
            this.panelAlku.PerformLayout();
            this.panelKeskustelu.ResumeLayout(false);
            this.panelKeskustelu.PerformLayout();
            this.panelRevanssinappulat.ResumeLayout(false);
            this.panelRevanssinappulat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripValikko;
        private System.Windows.Forms.ToolStripMenuItem tiedostoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asetuksetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ulkoasuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ohjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panelAlku;
        private System.Windows.Forms.Label labelAlkuohje;
        private System.Windows.Forms.Button buttonLuoUusiPeli;
        private System.Windows.Forms.Button buttonLiityPeliin;
        private System.Windows.Forms.Label labelVersio;
        private System.Windows.Forms.Label labelNettiristinolla;
        private System.Windows.Forms.Panel panelKeskustelu;
        private System.Windows.Forms.TextBox textBoxViesti;
        private System.Windows.Forms.Button buttonLaheta;
        private System.Windows.Forms.ListBox listBoxViestit;
        private System.Windows.Forms.FontDialog fontDialog1;
        private Ristikko ristikkoPeliristikko;
        private System.Windows.Forms.TextBox textBoxNimi;
        private System.Windows.Forms.Label labelNimi;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Panel panelRevanssinappulat;
        private System.Windows.Forms.Button buttonEiUutta;
        private System.Windows.Forms.Button buttonUusiPeli;
        private System.Windows.Forms.Label labelRevanssi;
        private System.Windows.Forms.Button buttonPaavalikkoon;
        private System.Windows.Forms.ToolStripMenuItem ohjeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tiedostoToolStripMenuItemTiedosto;
        private System.Windows.Forms.ToolStripMenuItem lopetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asetuksetToolStripMenuItemAsetukset;
        private System.Windows.Forms.ToolStripMenuItem ulkoasuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ohjeToolStripMenuItemOhje;
        private System.Windows.Forms.ToolStripMenuItem tietojaNettiristinollastaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abouToolStripMenuItem;
    }
}

