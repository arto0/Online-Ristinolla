using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nettiristinolla
{
    /// <summary>
    /// Luokka numerokentälle. Sisältää labelin, tekstikentän 
    /// ja arvonvalitsimen. Tekstikenttä muuttuu punaiseksi, 
    /// jos arvo ei kelpaa.
    /// </summary>
    public partial class Numerovalitsin : UserControl
    {

        private int ylaraja;
        private int alaraja;
        private int arvo;
        private bool klikattavissa = true;
        private bool hScrollBarBool = false;

        [Category("Rajat"),
        Description("Suurin sallittu arvo"),
        Browsable(true)]
        public int Ylaraja
        {
            set { ylaraja = value; hScrollBarPalkki.Maximum = ylaraja; labelRajat.Text = "(" + alaraja + " - " + ylaraja + ")"; }
            get { return ylaraja; }
        }

        [Category("Rajat"),
        Description("Pienin sallittu arvo"),
        Browsable(true)]
        public int Alaraja
        {
            set { alaraja = value; hScrollBarPalkki.Minimum = alaraja; labelRajat.Text = "(" + alaraja + " - " + ylaraja + ")"; }
            get { return alaraja; }
        }

        [Category("Valitsin"),
        Description("Näytetäänkö vedettävä valitsin"),
        Browsable(true)]
        public bool HScrollBar
        {
            set { hScrollBarPalkki.Visible = value; hScrollBarBool = value; }
            get { return hScrollBarPalkki.Visible; }
        }

        [Category("Ulkoasu"),
        Description("Voiko arvoja muuttaa"),
        Browsable(true)]
        public bool Klikattavissa
        {
            set { asetaKlikattavissa(value); }
            get { return klikattavissa; }
        }

        [Category("Arvot"),
        Description("Tämänhetkinen arvo"),
        Browsable(true)]
        public int Arvo
        {
            set { laitaArvo(value); }
            get { return arvo; }
        }

        [Category("Arvot"),
        Description("Kentän edellä näytettävä arvo"),
        DefaultValue(""),
        Browsable(true)]
        public string Teksti
        {
            set { labelNimi.Text = value; }
            get { return labelNimi.Text; }
        }

        private void asetaKlikattavissa(bool klikattatvissa)
        {
            textBoxArvo.ReadOnly = !klikattatvissa;
            hScrollBarPalkki.Visible = klikattatvissa & hScrollBarBool;
        }

        /// <summary>
        /// Laittaa arvon. Ei välitä, vaikka menee rajoista yli. 
        /// Vetopalkin rajan ylittäessä laittaa rajan arvon.
        /// </summary>
        /// <param name="arvo"></param>
        private void laitaArvo(int arvo)
        {
            if (arvo > hScrollBarPalkki.Maximum) hScrollBarPalkki.Value = hScrollBarPalkki.Maximum;
            if (arvo < hScrollBarPalkki.Minimum) hScrollBarPalkki.Value = hScrollBarPalkki.Minimum;
            if (arvo >= hScrollBarPalkki.Minimum & arvo <= hScrollBarPalkki.Maximum) hScrollBarPalkki.Value = arvo;
            this.arvo = arvo;
            textBoxArvo.Text = arvo.ToString();
        }

        public Numerovalitsin()
        {
            InitializeComponent();
            hScrollBarBool = false;
        }

        private void hScrollBarPalkki_ValueChanged(object sender, EventArgs e)
        {

            textBoxArvo.BackColor = Color.White;
            arvo = hScrollBarPalkki.Value;
            textBoxArvo.Text = arvo.ToString();
        }

        /// <summary>
        /// Tarkistetaan arvot kentästä poistuttaessa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxArvo_Leave(object sender, EventArgs e)
        {
            textBoxArvo.BackColor = Color.White;

            try
            {
                int numero = int.Parse(textBoxArvo.Text);
                arvo = numero;
                if (arvo < alaraja) arvo = alaraja;
                if (arvo > ylaraja) arvo = ylaraja;
                textBoxArvo.Text = arvo.ToString();
                hScrollBarPalkki.Value = arvo;
            }
            catch (Exception)
            {
                textBoxArvo.BackColor = Color.Red;
            }
        }
    }
}
