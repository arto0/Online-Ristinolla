using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nettiristinolla
{
    /// <summary>
    /// Ikkuna, joka hoitaa yhdistämisen olemassa olevaan peliin.
    /// </summary>
    public partial class FormLiity : Form
    {
        private Liikenne yhteys;

        [Category("Yhteys"),
        Description("Lomakkeen luoma nettiyhteys"),
        Browsable(false)]
        public Liikenne Yhteys
        {
            get { return yhteys; }
        }

        [Category("Asetukset"),
        Description("Portin arvo"),
        Browsable(false)]
        public int Portti
        {
            set { numerovalitsinPortti.Arvo = value; }
            get { return numerovalitsinPortti.Arvo;  }
        }

        [Category("Asetukset"),
        Description("IP-osoite"),
        Browsable(false)]
        public String Ip
        {
            set { textBoxIPosoite.Text = value; }
            get { return textBoxIPosoite.Text; }
        }

        public FormLiity()
        {
            InitializeComponent();
            progressBarYhdistys.MarqueeAnimationSpeed = 0;
        }

        /// <summary>
        /// Yritetään yhdistää lomakkeen tietojen mukaisesti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonYhdista_Click(object sender, EventArgs e)
        {
            labelInfoYhdistetaan.Visible = true;
            labelInfoYhdistetaan.Text = "yhdistetään...";
            progressBarYhdistys.MarqueeAnimationSpeed = 80;
            panelYhdistys.Visible = true;
            textBoxIPosoite.ReadOnly = true;
            numerovalitsinPortti.Klikattavissa = false;
            buttonYhdista.Visible = false;

            yhteys = new Liikenne();
            yhteys.avattu += new Yhteys(yhteys_avattu);
            yhteys.yhdistysEiOnnistu += new Yhteys(yhteys_eiOnnistu);
            yhteys.Osoite = textBoxIPosoite.Text;
            yhteys.Portti = numerovalitsinPortti.Arvo;

            String virhe = yhteys.aloitaYhteys();
        }

        private delegate void yhteys_avattuDelegate(object sender, String e);
        /// <summary>
        /// Kun yhteys avautuu.
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
            paivitaTieto("yhteys luotu");
            suljeIkkuna();
            

            //labelInfoYhdistetaan.Text = "Yhteys luotu, alustetaan peli...";
        }

        private delegate void yhteys_eiOnnistuDelegate(object sender, String e);
        /// <summary>
        /// Hoidetaan tilanne, jossa yhteyttä ei saada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void yhteys_eiOnnistu(object sender, String e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new yhteys_eiOnnistuDelegate(yhteys_eiOnnistu), new object[] { sender, e });

                return;
            }
            if (e != "") e = ": " + e;
            paivitaTieto("ei yhteyttä" + e);
            progressBarYhdistys.MarqueeAnimationSpeed = 0;
            textBoxIPosoite.ReadOnly = false;
            numerovalitsinPortti.Klikattavissa = true;
            buttonYhdista.Visible = true;

            //labelInfoYhdistetaan.Text = "Yhteys luotu, alustetaan peli...";
        }

        /// <summary>
        /// Päivittää tilanteen infokenttään.
        /// </summary>
        /// <param name="tilanne">Infokenttä</param>
        private delegate void SetLabelTextDelegate(String tilanne);
        private void paivitaTieto(String tilanne)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(paivitaTieto), new object[] { tilanne });

                return;
            }

            labelInfoYhdistetaan.Text = tilanne;
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

        private void buttonPaavalikkoon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLiity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) this.Close();
        }

        private void FormLiity_Load(object sender, EventArgs e)
        {

        }

        private void FormLiity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Nettiristinolla.FormAlusta.avaaOhje("liittyminen"); 
        }


    }
}
