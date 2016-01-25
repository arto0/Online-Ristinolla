using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nettiristinolla
{
    /// <summary>
    /// Asetusten hallintaan tarkoitettu ikkuna.
    /// </summary>
    public partial class FormAsetukset : Form
    {
        private Color taustavari = Color.White;
        private Color viivavari = Color.Black;
        private Color omanMerkinvari = Color.Black;
        private Color vieraanMerkinvari = Color.Black;

        [Category("Asetukset"),
        Description("Taustaväri"),
        Browsable(false)]
        public Color Taustavari
        {
            set { taustavari = value; panelVari.BackColor = taustavari; }
            get { return taustavari; }
        }

        [Category("Asetukset"),
        Description("Ruudukon viivojen väri"),
        Browsable(false)]
        public Color Viivavari
        {
            set { viivavari = value; panelViivavari.BackColor = viivavari; }
            get { return viivavari; }
        }

        [Category("Asetukset"),
        Description("Oman merkin väri"),
        Browsable(false)]
        public Color OmanMerkinvari
        {
            set { omanMerkinvari = value; panelOmaMerkkivari.BackColor = omanMerkinvari; }
            get { return omanMerkinvari; }
        }

        [Category("Asetukset"),
        Description("Vieraan merkin väri"),
        Browsable(false)]
        public Color VieraanMerkinvari
        {
            set { vieraanMerkinvari = value; panelVierasMerkkivari.BackColor = vieraanMerkinvari; }
            get { return vieraanMerkinvari; }
        }

        public FormAsetukset()
        {
            InitializeComponent();
            panelVari.BackColor = taustavari;
            panelViivavari.BackColor = viivavari;
        }

        private void buttonVari_Click(object sender, EventArgs e)
        {
            colorDialogVari.Color = taustavari;
            colorDialogVari.ShowDialog();
            panelVari.BackColor = colorDialogVari.Color;
            taustavari = colorDialogVari.Color;
        }

        private void buttonViivavari_Click(object sender, EventArgs e)
        {
            colorDialogVari.Color = viivavari;
            colorDialogVari.ShowDialog();
            panelViivavari.BackColor = colorDialogVari.Color;
            viivavari = colorDialogVari.Color;
        }

        private void buttonOmaMerkkivari_Click(object sender, EventArgs e)
        {
            colorDialogVari.Color = omanMerkinvari;
            colorDialogVari.ShowDialog();
            panelOmaMerkkivari.BackColor = colorDialogVari.Color;
            omanMerkinvari = colorDialogVari.Color;
        }

        private void buttonVierasMerkkivari_Click(object sender, EventArgs e)
        {
            colorDialogVari.Color = vieraanMerkinvari;
            colorDialogVari.ShowDialog();
            panelVierasMerkkivari.BackColor = colorDialogVari.Color;
            vieraanMerkinvari = colorDialogVari.Color;
        }

        private void FormAsetukset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) this.Close();
        }

        private void buttonOKAsetukset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAsetukset_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Nettiristinolla.FormAlusta.avaaOhje("ulkoasu"); 
        }
    }
}
