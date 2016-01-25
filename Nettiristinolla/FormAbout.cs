using System;
using System.Windows.Forms;

namespace Nettiristinolla
{
    /// <summary>
    /// Ohjelmasta tietoja kertova ikkuna.
    /// </summary>
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        public void asetaVersio(String versio) {
            labelVersio.Text = "Versio: " + versio;
        }

        private void FormAbout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) this.Close();
        }

        private void buttonAboutSulje_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) Nettiristinolla.FormAlusta.avaaOhje(); 
        }
    }
}
