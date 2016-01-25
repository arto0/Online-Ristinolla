using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nettiristinolla
{
    /// <summary>
    /// Form, joka näyttää pelinluontiasetukset.
    /// Jos luokan sulkemisen jälkeen Katkaise-property on
    /// true, ei yhteyttä tule jatkaa, koska se on
    /// peruutettu.
    /// </summary>
    public partial class FormLuoPeli : Form
    {
        private Liikenne yhteys;
        private String[] alustukset;
        private bool katkaise = false;


        [Category("Asetukset"),
        Description("Portti"),
        Browsable(false)]
        public int Portti
        {
            set { numerovalitsinPortti.Arvo = value; }
            get { return numerovalitsinPortti.Arvo; }
        }

        [Category("Asetukset"),
        Description("Voittorivi"),
        Browsable(false)]
        public int Voittorivi
        {
            set { numerovalitsinVoittopituus.Arvo = value; }
            get { return numerovalitsinVoittopituus.Arvo; }
        }

        [Category("Asetukset"),
        Description("Korkeus"),
        Browsable(false)]
        public int Korkeus
        {
            set { numerovalitsinKorkeus.Arvo = value; }
            get { return numerovalitsinKorkeus.Arvo; }
        }

        [Category("Asetukset"),
        Description("Leveys"),
        Browsable(false)]
        public int Leveys
        {
            set { numerovalitsinLeveys.Arvo = value; }
            get { return numerovalitsinLeveys.Arvo; }
        }

        [Category("Yhteys"),
        Description("Lomakkeen luoma nettiyhteys"),
        Browsable(false)]
        public Liikenne Yhteys
        {
            get { return yhteys; }
        }

        [Category("Yhteys"),
        Description("Katkaistaanko luotu yhteys"),
        Browsable(false)]
        public bool Katkaise {
            get { return katkaise; }
        }

        public String[] Alustukset
        {
            get { return alustukset; }
            set { alustukset = value; }
        }

        public FormLuoPeli()
        {
            InitializeComponent();
            progressBarYhdistys.MarqueeAnimationSpeed = 0;
        }

      
        /// <summary>
        /// Yritetään luoda uusi peli. Estetään asetusten 
        /// muuttaminen ja näytetään odotuspaneli.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            buttonPois.Visible = false;
            buttonLuoPeli.Visible = false;
            buttonPeruutaLuonti.Visible = true;
            progressBarYhdistys.MarqueeAnimationSpeed = 80;
            panelYhdistys.Visible = true;
            buttonLuoPeli.Visible = false;
            numerovalitsinLeveys.Klikattavissa = false;
            numerovalitsinKorkeus.Klikattavissa = false;
            numerovalitsinPortti.Klikattavissa = false;
            numerovalitsinVoittopituus.Klikattavissa = false;


            yhteys = new Liikenne();
            //yhteysTemp.Alustusviestit = alustukset;
            yhteys.Palvelin = true;
            yhteys.avattu += new Yhteys(yhteys_avattu);
            yhteys.yhdistysEiOnnistu += new Yhteys(yhteys_eiOnnistu);
            yhteys.Portti = numerovalitsinPortti.Arvo;


            labelInfoYhdistetaan.Text = "Peli luotu osoitteeseen " + yhteys.palautaIP() + ", odotetaan yhteyttä...";
            String virhe = yhteys.aloitaYhteys();
            if (virhe != null) { paivitaTieto("virhe: " + virhe); nollaa();  }
        }

        private delegate void nollaaDelegate();
        /// <summary>
        /// Nollataan kaikki vastaamaan aloitustilaa.
        /// </summary>
        private void nollaa()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new nollaaDelegate(nollaa), new object[] { });
                return;
            }
            progressBarYhdistys.MarqueeAnimationSpeed = 0;
            buttonLuoPeli.Visible = true;
            buttonPeruutaLuonti.Visible = false;
            buttonLuoPeli.Visible = true;
            buttonPois.Visible = true;
            numerovalitsinLeveys.Klikattavissa = true;
            numerovalitsinKorkeus.Klikattavissa = true;
            numerovalitsinPortti.Klikattavissa = true;
            numerovalitsinVoittopituus.Klikattavissa = true;
        }

        private delegate void yhteys_avattuDelegate(object sender, String e);
        /// <summary>
        /// Suoritetaan kun yhtey son avattu. Tulostetaan tieto
        /// ja suljetaan ikkuna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void yhteys_avattu(object sender, String e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new yhteys_avattuDelegate(yhteys_avattu), new object[] { sender, e });
                return;
            }
            if (katkaise) // luotu yhteys on vain katkaisua varten.
            {
                buttonLuoPeli.Visible = true;
                buttonPeruutaLuonti.Visible = false;
                buttonPois.Visible = true;
                nollaa();
                yhteys.suljeYhteys();
                paivitaTieto("peruutettu");
                katkaise = false;
                return;
            }
            paivitaTieto("yhteys saatu");
           // yhteys = yhteysTemp;
            suljeIkkuna();
        }

        /// <summary>
        /// Tulostetaan, ettei yhteys onnistu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void yhteys_eiOnnistu(object sender, String e)
        {
            paivitaTieto("ei yhteyttä " + e);
        }

        private delegate void suljeIkkunaDelegate();
        /// <summary>
        /// Sulkee ikkunan.
        /// </summary>
        private void suljeIkkuna()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new suljeIkkunaDelegate(suljeIkkuna), new object[] { });
                return;
            }
            this.Close();
        }

        private delegate void SetLabelTextDelegate(String tilanne);
        /// <summary>
        /// Muuttaa yhteysinfoa. Toimii muistakin säikeistä.
        /// </summary>
        /// <param name="tilanne">Näytettävä yhteysinfo.</param>
        private void paivitaTieto(String tilanne)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(paivitaTieto), new object[] { tilanne });
                return;
            }
            labelInfoYhdistetaan.Text = tilanne;
        }

        /// <summary>
        /// Peruutetaan yhteyden odottaminen. Toteutetaan 
        /// siten, että luodaan uusi yhteys, joka suljetaan 
        /// heti. Muutetaan tämän jälkeen katkaisumuuttuja
        /// trueksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPeruutaLuonti_Click(object sender, EventArgs e)
        {
            paivitaTieto("peruutetaan luonti...");
            katkaise = true;
            Liikenne nettiperuutus = new Liikenne();
            nettiperuutus.Palvelin = false;
            nettiperuutus.Portti = numerovalitsinPortti.Arvo;
            nettiperuutus.Osoite = "127.0.0.1";
            nettiperuutus.aloitaYhteys();
            nettiperuutus.suljeYhteys();
        }

        private void FormLuoPeli_Load(object sender, EventArgs e)
        {

        }

        private void FormLuoPeli_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void buttonPois_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLuoPeli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27 && buttonPois.Visible == true) this.Close();
            if (e.KeyChar == (char)27) buttonPeruutaLuonti_Click(null, null);
        }

        private void FormLuoPeli_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Nettiristinolla.FormAlusta.avaaOhje("luonti"); 
        }
    }
}
