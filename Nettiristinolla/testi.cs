using System;
using System.Windows.Forms;

namespace Nettiristinolla
{
    public partial class testi : Form
    {
        public testi()
        {
            InitializeComponent();
            nettiliikenne1.avattu += new Yhteys(nettiliikenne1_avattu);
            nettiliikenne1.katkaistu += new Yhteys(nettiliikenne1_katkaistu);
            nettiliikenne1.lahetysEiOnnistu += new Yhteysongelma(nettiliikenne1_lahetysEiOnnistu);
            nettiliikenne1.uusiViesti += new Viesti(nettiliikenne1_uusiViesti);
            nettiliikenne1.yhdistysEiOnnistu += new Yhteys(nettiliikenne1_yhdistysEiOnnistu);

            nettiliikenne2.avattu += new Yhteys(nettiliikenne2_avattu);
            nettiliikenne2.katkaistu += new Yhteys(nettiliikenne2_katkaistu);
            nettiliikenne2.lahetysEiOnnistu += new Yhteysongelma(nettiliikenne2_lahetysEiOnnistu);
            nettiliikenne2.uusiViesti += new Viesti(nettiliikenne2_uusiViesti);
            nettiliikenne2.yhdistysEiOnnistu += new Yhteys(nettiliikenne2_yhdistysEiOnnistu);
        }

        void nettiliikenne1_yhdistysEiOnnistu(object lahettaja, string tasmennys)
        {
            lisaaViestiPalvelin("Yhdistys ei onnistu " + tasmennys);
        }

        void nettiliikenne1_uusiViesti(string viesti, int tyyppi)
        {
            lisaaViestiPalvelin("Uusi viesti " + viesti + ", tyyppi: " + tyyppi);
        }

        void nettiliikenne1_lahetysEiOnnistu(string selite)
        {
            lisaaViestiPalvelin("Lähetys ei onnistu " + selite);
        }

        void nettiliikenne1_katkaistu(object lahettaja, string tasmennys)
        {
            lisaaViestiPalvelin("Katkaistu " + tasmennys);
        }

        void nettiliikenne1_avattu(object lahettaja, string tasmennys)
        {
            lisaaViestiPalvelin("Avattu" + tasmennys);
            nettiliikenne1.LukuSeis = false;
        }

        void nettiliikenne2_yhdistysEiOnnistu(object lahettaja, string tasmennys)
        {
            lisaaViestiAsiakas("Yhdistys ei onnistu " + tasmennys);
        }

        void nettiliikenne2_uusiViesti(string viesti, int tyyppi)
        {
            lisaaViestiAsiakas("Uusi viesti " + viesti + ", tyyppi: " + tyyppi);
        }

        void nettiliikenne2_lahetysEiOnnistu(string selite)
        {
            lisaaViestiAsiakas("Lähetys ei onnistu " + selite);
        }

        void nettiliikenne2_katkaistu(object lahettaja, string tasmennys)
        {
            lisaaViestiAsiakas("Katkaistu " + tasmennys);
        }

        void nettiliikenne2_avattu(object lahettaja, string tasmennys)
        {
            lisaaViestiAsiakas("Yhteys avattu " + tasmennys);
            nettiliikenne2.LukuSeis = false;
        }

        private delegate void SetLabelTextDelegate(String viesti);
        /// <summary>
        /// Lisää keskusteluikkunaan uuden viestin.
        /// </summary>
        /// <param name="viesti">Lisättävä viesti</param>
        private void lisaaViestiPalvelin(String viesti)
        {
            if (viesti == null) viesti = "null";
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(lisaaViestiPalvelin), new object[] { viesti });
                return;
            }
            listBoxPalvelin.Items.Add(viesti);
        }

        private delegate void SetLabelTextDelegate2(String viesti);
        /// <summary>
        /// Lisää keskusteluikkunaan uuden viestin.
        /// </summary>
        /// <param name="viesti">Lisättävä viesti</param>
        private void lisaaViestiAsiakas(String viesti)
        {
            if (viesti == null) viesti = "null";
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate2(lisaaViestiAsiakas), new object[] { viesti });
                return;
            }
            listBoxAsiakas.Items.Add(viesti);
        }

        private void buttonLuo_Click(object sender, EventArgs e)
        {
            String viesti = nettiliikenne1.aloitaYhteys();
            lisaaViestiPalvelin("Yritetään luoda peli...");
            if (viesti != null) listBoxPalvelin.Items.Add(viesti);
        }

        private void buttonYhdista_Click(object sender, EventArgs e)
        {
            lisaaViestiAsiakas("Yritetään yhdistää...");
            nettiliikenne2.Osoite = textBoxOsoite.Text;
            String viesti = nettiliikenne2.aloitaYhteys();
            if (viesti != null) listBoxPalvelin.Items.Add(viesti);
        }

        private void testi_Load(object sender, EventArgs e)
        {

        }

        private void buttonViestiPalvelin_Click(object sender, EventArgs e)
        {
            lisaaViestiPalvelin("Viesti lähetetty");
            nettiliikenne1.lahetaViesti("Palvelin lähetti", "viesti");
        }

        private void buttonViestiAsiakas_Click(object sender, EventArgs e)
        {
            lisaaViestiAsiakas("Viesti lähetetty");
            nettiliikenne2.lahetaViesti("Asiakas lähetti", "viesti");
        }

        private void buttonKatkaisePalvelin_Click(object sender, EventArgs e)
        {
            nettiliikenne1.lopetaYhteys();
        }

        private void buttonKatkaiseAsiakas_Click(object sender, EventArgs e)
        {
            nettiliikenne2.lopetaYhteys();
        }

        private void buttonSuljeVakisinPalvelin_Click(object sender, EventArgs e)
        {
            nettiliikenne1.suljeYhteys();
        }

        private void buttonSuljeVakisinAsiakas_Click(object sender, EventArgs e)
        {
            nettiliikenne2.suljeYhteys();
        }
    }
}
