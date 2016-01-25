using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nettiristinolla
{
    /// <summary>
    /// Online-Ristinollan pääikkuna. Peli aloitetaan tästä.
    /// </summary>
    public partial class FormAlusta : Form
    {
        private FormAsetukset asetukset = new FormAsetukset();
        private const string VERSIO = "1.0";
        private string[] alustusviestit;
        private string vastustaja = "";
        private string[] kanavat = { "keskustelu", "protokolla" };
        private Liikenne nettiliikenne;

        // asetuksista ladattava tiedot
        private int leveys = 25, pituus = 25, voittopituus = 5, portti = 9696;
        private string ip = "127.0.0.1", nimi;

        private const int valikkokoko = 25; // Ylävalikon koko
        private const int marginaali = 10;  // Marginaali reunoihin, tosin ei yläreunaan
        private const int ylatila = 23; // tila, jossa ehdotetaan revanssia
        private const int ylamarginaali = 0; // Valikon alla olevan tila

        private const int minimileveys = 300; // Ruudukon ilmestyessä ruudukon osan minimileveys, pelaaja voi pienentää pienemmäksikin
        private const int minimikorkeus = 300;  // Ruudukon ilmestyessä ruudukon osan minimikorkeus, pelaaja voi pienentää pienemmäksikin
        private const int minimisivu = 23; // Ruudukon ilmestyessä ruudun sivun pituus, jos ikkunan koko ei jää alle yllä olevien minimien

        private const string ohjetiedosto = "http://arto0.github.io/online-xo/help.html";
        private string nimeton = "nimetön";
        private int revanssiVastustaja = 0; // Haluaako vastustaja revanssin (2) vai ei (1)
        private int revanssiOma = 0; // Haluaako pelaaja itse revanssin vai ei, 0 on määrittelemätön

        private bool peliKaynnissa = false;
        private const int keskustelukorkeus = 120;

        public FormAlusta()
        {
            InitializeComponent();
            labelVersio.Text = "Versio: " + VERSIO;
            asetukset.Taustavari = Color.White;
            String[] viestit = {"Versio:"+VERSIO, "Versio:"+VERSIO};
            alustusviestit = viestit;

            // Nämä voi tehdä vain kerran
            ristikkoPeliristikko.siirtoTehty += new Siirto(ristikkoPeliristikko_siirtoTehty);
            ristikkoPeliristikko.peliPaattyi += new Peli(ristikkoPeliristikko_peliPaattyi);
            ristikkoPeliristikko.tasapeli += new Peli(ristikkoPeliristikko_tasapeli);
            ristikkoPeliristikko.vuoronVaihto += new Vuoro(ristikkoPeliristikko_vuoronVaihto);
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nettiliikenne != null && nettiliikenne.Yhdistetty) nettiliikenne.lahetaViesti("L|0", "protokolla");
            if (nettiliikenne != null) nettiliikenne.suljeYhteys();
            Application.Exit();
        }

        /// <summary>
        /// Avataan peliinliittymisikkuna. Ikkuna sisältää mahdollisen 
        /// luodun yhteyden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLiityPeliin_Click(object sender, EventArgs e)
        {
            FormLiity yhdistys = new FormLiity();
            yhdistys.Portti = this.portti;
            yhdistys.Ip = this.ip;
            yhdistys.ShowDialog();
            if (yhdistys.Yhteys == null) return;
            nettiliikenne = yhdistys.Yhteys;
            nettiliikenne.Kanavat = kanavat;
            nettiliikenne.uusiViesti += new Viesti(nettiliikenne_uusiViesti);
            nettiliikenne.LukuSeis = false;
            ristikkoPeliristikko.Vuorossa = false;
        }

        /// <summary>
        /// Asetetaan kentän arvot oikeiksi.
        /// Säädetään peliPanelin koko.
        /// </summary>
        private void laskeKenttaarvot()
        {
            labelInfo.Location = new Point(marginaali, valikkokoko + ylamarginaali);
            buttonPaavalikkoon.Location = new Point(Width / 2 - buttonPaavalikkoon.Width / 2, valikkokoko + ylamarginaali);

            ristikkoPeliristikko.Width = Width-marginaali*3;
            ristikkoPeliristikko.Height = Height - keskustelukorkeus - valikkokoko - marginaali - ylatila;

            panelRevanssinappulat.Location = new Point(Width/2 - panelRevanssinappulat.Width/2, valikkokoko+ylamarginaali);

            panelKeskustelu.Width = Width - marginaali*3;
            panelKeskustelu.Height = keskustelukorkeus;

            ristikkoPeliristikko.Location = new Point(0+marginaali, valikkokoko + ylatila);
            panelKeskustelu.Location = new Point(0+marginaali, ristikkoPeliristikko.Height);

            if (!panelRevanssinappulat.Visible) buttonPaavalikkoon.Visible = true;
            labelInfo.Visible = true;
            panelAlku.Visible = false;
            ristikkoPeliristikko.Visible = true;
            panelKeskustelu.Visible = true;      
        }

        /// <summary>
        /// Siirtää keskustelun oikeaan kohtaan ja oikeaan kokoon.
        /// </summary>
        private void paivitaKeskustelu()
        {
            panelKeskustelu.Location = new Point(0+marginaali, Height - keskustelukorkeus-marginaali);
            panelKeskustelu.Size = new Size(Width-marginaali*3, keskustelukorkeus);

            listBoxViestit.Location = new Point(0, 0);
            listBoxViestit.Size = new Size(panelKeskustelu.Width, listBoxViestit.Height);

            textBoxViesti.Size = new Size(panelKeskustelu.Width - buttonLaheta.Width,textBoxViesti.Height);
            textBoxViesti.Location = new Point(0, listBoxViestit.Height);
            buttonLaheta.Location = new Point(panelKeskustelu.Width - buttonLaheta.Width, listBoxViestit.Height);
            
        }

        /// <summary>
        /// Päivitettään nettiliikenteen kanavat 
        /// ja luodaan kenttä näkyviin.
        /// </summary>
        private void alustaPeli(int pituus, int leveys, int voittopituus) 
        {
            nettiliikenne.katkaistu += new Yhteys(nettiliikenne_katkaistu);
            tallennaAsetukset(pituus, leveys, voittopituus);
            ristikkoPeliristikko.asetaKoot(pituus, leveys, voittopituus);
            peliKaynnissa = true;
            listBoxViestit.Items.Clear();
            asetaAlkukoko(pituus, leveys);
            laskeKenttaarvot();
            paivitaKeskustelu();
        }

        /// <summary>
        /// Laskee ja asettaa kentälle alkukoon.
        /// </summary>
        private void asetaAlkukoko(int pituus, int leveys)
        {
            int tulevaKorkeus = pituus * minimisivu + marginaali * 2;
            if (tulevaKorkeus < minimikorkeus) tulevaKorkeus = minimikorkeus;
            
            int tulevaLeveys = valikkokoko + leveys * minimisivu;
            if (tulevaLeveys < minimileveys) tulevaLeveys = minimileveys;
            
            Width = tulevaKorkeus;
            Height = tulevaLeveys;
        }

        /// <summary>
        /// Tallentaa configiin asetukset.
        /// Muuttaa myös paikalliset muuttujat.
        /// </summary>
        private void tallennaAsetukset(int pituus, int leveys, int voittopituus)
        {
            this.pituus = pituus;
            this.leveys = leveys;
            this.voittopituus = voittopituus;
            this.portti = nettiliikenne.Portti;
            if (!nettiliikenne.Palvelin) this.ip = nettiliikenne.Osoite;
            Properties.Settings.Default.nimi = textBoxNimi.Text;
            Properties.Settings.Default.pituus = pituus;
            Properties.Settings.Default.leveys = leveys;
            Properties.Settings.Default.voittopituus = voittopituus;
            Properties.Settings.Default.portti = nettiliikenne.Portti;
            if (!nettiliikenne.Palvelin) Properties.Settings.Default.ip = nettiliikenne.Osoite;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Suoritetaan, jos tulee tasapeli.
        /// </summary>
        void ristikkoPeliristikko_tasapeli()
        {
            labelInfo.Text = "Tasapeli";
            panelRevanssinappulat.Visible = true;
            buttonPaavalikkoon.Visible = false;
        }

        /// <summary>
        /// Päivitetään vuorotieto ikkunaan.
        /// </summary>
        void ristikkoPeliristikko_vuoronVaihto()
        {
            if (ristikkoPeliristikko.Vuorossa) labelInfo.Text = "Vuorossa: " + textBoxNimi.Text;
            else labelInfo.Text = "Vuorossa: " + vastustaja;
        }

        private delegate void nettiliikenne_katkaistuDelegate(object sender, string tasmennys);
        /// <summary>
        /// Tapahtuu kun liikenne katkeaa. Päivitetään käyttäjälle tieto tapahtuneesta.
        /// </summary>
        /// <param name="sender">ei käytössä</param>
        /// <param name="tasmennys">ei käytössä</param>
        void nettiliikenne_katkaistu(object sender, string tasmennys)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new nettiliikenne_katkaistuDelegate(nettiliikenne_katkaistu), new Object[] { sender, tasmennys });
                return;
            }
            muutaRevanssivalinnat();
            lisaaViesti("Yhteys katkesi");
        }

        private delegate void aloitaAlustaDelegate();
        /// <summary>
        /// Tuo aloitusnäytön näkyviin.
        /// </summary>
        private void aloitaAlusta()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new aloitaAlustaDelegate(aloitaAlusta), new Object[] {});
                return;
            }
            
            panelRevanssinappulat.Visible = false;
            if (nettiliikenne != null) nettiliikenne.suljeYhteys();
            nettiliikenne = null;
            peliKaynnissa = false;
            labelInfo.Visible = false;
            panelAlku.Visible = true;
            ristikkoPeliristikko.Visible = false;
            panelKeskustelu.Visible = false;
            buttonPaavalikkoon.Visible = false;
            this.Size = new Size(390, 240);
        }

        private delegate void aloitaRevanssiDelegate();
        /// <summary>
        /// Aloitetaan revanssi vanhoilla valinnoilla
        /// </summary>
        private void aloitaRevanssi()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new aloitaRevanssiDelegate(aloitaRevanssi), new Object[] { });
                return;
            }
            lisaaViesti("Uusi peli alkaa!");
            buttonPaavalikkoon.Visible = true;
            panelRevanssinappulat.Visible = false;
            peliKaynnissa = true;
            labelInfo.Visible = true;
            panelAlku.Visible = false;
            ristikkoPeliristikko.nollaa();
            ristikkoPeliristikko.Visible = true;
            panelKeskustelu.Visible = true;
            ristikkoPeliristikko_vuoronVaihto();
            revanssiOma = 0;
            revanssiVastustaja = 0;
            if (nettiliikenne.Palvelin) ristikkoPeliristikko.Vuorossa = true;
            else ristikkoPeliristikko.Vuorossa = false;
        }

        /// <summary>
        /// Päivitetään tieto voittajasta.
        /// </summary>
        void ristikkoPeliristikko_peliPaattyi()
        {       
            if (ristikkoPeliristikko.Vuorossa) labelInfo.Text = "Voitit!";
            else labelInfo.Text = "Hävisit...";
            panelRevanssinappulat.Visible = true;
            buttonPaavalikkoon.Visible = false;
        }

        /// <summary>
        /// Kun on itse tehty siirto.
        /// </summary>
        /// <param name="sender">Ristikko</param>
        /// <param name="x">Siirron x</param>
        /// <param name="y">Siirron y</param>
        void ristikkoPeliristikko_siirtoTehty(object sender, int x, int y)
        {
            nettiliikenne.lahetaViesti("S"+x+":"+y, "protokolla");
        }

        /// <summary>
        /// Käsittelee uuden viestin.
        /// </summary>
        /// <param name="viesti">Saatava viesti.</param>
        /// <param name="tyyppi">Viestin tyyppi</param>
        void nettiliikenne_uusiViesti(string viesti, int tyyppi)
        {
            if (kanavat[tyyppi] == "keskustelu") lisaaViesti(vastustaja + ": " + viesti);
            if (kanavat[tyyppi] == "protokolla") teeSiirto(viesti);
        }

        private delegate void teeSiirtoDelegate(String siirto);
        /// <summary>
        /// Käsittelee protokollaviestin.
        /// </summary>
        /// <param name="protokollaviesti">Käsiteltävä protokollaviesti</param>
        private void teeSiirto(String protokollaviesti) 
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new teeSiirtoDelegate(teeSiirto), new String[] { protokollaviesti });
                return;
            }

            if (protokollaviesti[0] == 'L') // vastapuoli lopettaa
            {
                if (protokollaviesti[2] == '0') // vastapuoli lopettanut exitistä
                {
                    muutaRevanssivalinnat();
                    lisaaViesti("Vastustaja lähti");
                    ristikkoPeliristikko.Enabled = false;
                    //MessageBox.Show(vastustaja + " lopetti pelin", "Vastustaja lähti",
                    //MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //aloitaAlusta();
                    //return;
                }

                if (protokollaviesti[2] == 'V') // väärä versio
                {
                    MessageBox.Show("Peliä ei voi aloittaa, koska versiot eivät täsmää", "Versio-ongelma",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    aloitaAlusta();
                    return;
                }
            }

            if (protokollaviesti[0] == 'V') // vastaus alustukseen
            {
                vastustaja = selvitaVastustaja(protokollaviesti);
                lisaaViesti("Uusi peli alkaa! Vastustajanasi on " + vastustaja); 
            }

            if (protokollaviesti[0] == 'R') // revanssitieto
            {
                kasitteleRevanssi(protokollaviesti[2]);
            }

            if (protokollaviesti[0] == 'A') // alustusviesti
            {
                //lisaaViesti(siirto);

                int voittopituus, kentanLeveys, kentanPituus;
                string versio, vastustajanNimi;
                
                selvitaAlustusarvot(out versio, out vastustajanNimi, out voittopituus, out kentanLeveys, out kentanPituus, protokollaviesti);
                if (versio != VERSIO) {
                    nettiliikenne.lahetaViesti("L" + "|" + "V", "protokolla");
                    MessageBox.Show("Vastapuolen versio ("+versio+") ei kelpaa", "Versio-ongelma",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    aloitaAlusta();
                    return;
                }
                vastustaja = vastustajanNimi;
                if (vastustaja == "") vastustaja = nimeton;
                labelInfo.Text = "Vuorossa: " + vastustaja;
                nettiliikenne.lahetaViesti("V" + "|" + textBoxNimi.Text, "protokolla");
                alustaPeli(kentanPituus, kentanLeveys, voittopituus);
                lisaaViesti("Uusi peli alkaa! Vastustajanasi on " + vastustaja); 
            }


            if (protokollaviesti[0] == 'S') // tehdään siirto
            {
                int x = 0; int y = 0;
               // MessageBox.Show(siirto);
                parsiParametrit(protokollaviesti.Substring(1, protokollaviesti.Length-1), out x, out y);
              //  MessageBox.Show("Tulkinta: " + x + ", " + y);
                ristikkoPeliristikko.annaSiirto(x, y);
                if (!ristikkoPeliristikko.PeliOhi) ristikkoPeliristikko_vuoronVaihto();
            }
         }

       
        /// <summary>
        /// Hoitaa vastustajan revanssivastauksen.
        /// </summary>
        /// <param name="vastaus">Vastustajan revanssivastaus</param>
        private void kasitteleRevanssi(char vastaus)
        {
            if (vastaus == 'K')
            {
                lisaaViesti(vastustaja + " haluaa revanssin");
                
                revanssiVastustaja = 2;
                if (revanssiOma == 2) // kumpikin haluaa revanssin
                {
                    aloitaRevanssi();
                }
            }

            if (vastaus == 'E')
            {
                lisaaViesti(vastustaja + " poistui pelistä");
                nettiliikenne.suljeYhteys();
                revanssiVastustaja = 1;
                buttonPaavalikkoon.Visible = true;
                panelRevanssinappulat.Visible = false;
            }
        }

        private delegate void muutaRevanssivalinnatDelegate();
        /// <summary>
        /// Vaihtaa revanssinapit poistumisnappiin.
        /// </summary>
        private void muutaRevanssivalinnat()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new muutaRevanssivalinnatDelegate(muutaRevanssivalinnat), new String[] { });
                return;
            }
            if (!(buttonPaavalikkoon.Visible == true || panelRevanssinappulat.Visible == true)) return;
            panelRevanssinappulat.Visible = false;
            buttonPaavalikkoon.Visible = true;
        }

        /// <summary>
        /// Selvittää vastustajan annetusta merkkijonosta.
        /// Vastustajan nimi muodostuu toisesta merkistä eteenpäin.
        /// </summary>
        /// <param name="viesti">Merkkijono, josta selvitettään</param>
        /// <returns>Vastustaja</returns>
        private String selvitaVastustaja(String viesti)
        {
            String vastustaja = "";
            for (int i = 2; i < viesti.Length; i++) vastustaja += viesti[i];
            if (vastustaja == "") vastustaja = nimeton;
            return vastustaja;
        }

        /// <summary>
        /// Selvittää A|voittopituus:kentanleveys:kentanpituus-tyylisestä viestistä
        /// parametrit.
        /// </summary>
        /// <param name="voittopituus">Voittopituus</param>
        /// <param name="kentaLeveys">Kentän leveys, X</param>
        /// <param name="kentanpituus">Kentän pituus, Y</param>
        /// <param name="viesti">Viesti, josta parsitaan</param>
        private void selvitaAlustusarvot(out String versio, out String nimi, out int voittopituus, out int kentaLeveys, out int kentanpituus, String viesti) 
        {
            int i = 1; // aloitetaan luku toisesta merkistä
            versio = ""; nimi = "";
            string voittopituusString = "";
            string kentanLeveysString = "";
            string kentanPituusString = "";
            for (; viesti[i] != '|'; i++) versio += viesti[i];
            i++;
            for (; viesti[i] != '|'; i++) nimi += viesti[i];
            i++;
            for (; viesti[i] != ':'; i++) voittopituusString += viesti[i];
            i++;
            for (; viesti[i] != ':'; i++) kentanLeveysString += viesti[i];
            i++;
            for (; i < viesti.Length; i++) kentanPituusString += viesti[i];

            voittopituus = int.Parse(voittopituusString);
            kentaLeveys = int.Parse(kentanLeveysString);
            kentanpituus = int.Parse(kentanPituusString);
        }


        /// <summary>
        /// Parsii muotoa x:y-olevan merkkijonon x:n muuttujaan x
        /// ja y:n muuttujaan y.
        /// </summary>
        /// <param name="siirto">Parsittava parametri</param>
        /// <param name="x">Parametrin x</param>
        /// <param name="y">Parametrin y</param>
        private void parsiParametrit(String siirto, out int x, out int y)
        {
            y = 0;
            x = 0;
            for (int i = 0; i < siirto.Length; i++)
            {
                if (siirto[i] == ':') 
                {
                    x = int.Parse(siirto.Substring(0,i));
                    y = int.Parse(siirto.Substring(i+1,siirto.Length-i-1));
                    return;
                }
            }
        }

        private delegate void SetLabelTextDelegate(String viesti);
        /// <summary>
        /// Lisää keskusteluikkunaan uuden viestin.
        /// </summary>
        /// <param name="viesti">Lisättävä viesti</param>
        private void lisaaViesti(String viesti)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLabelTextDelegate(lisaaViesti), new object[] { viesti });
                return;
            }
            listBoxViestit.Items.Add(viesti);
            listBoxViestit.SelectedIndex = listBoxViestit.Items.Count - 1;
        }

        /// <summary>
        /// Luodaan uusi peli. Näytetään pelinluonti-ikkuna.
        /// Ikkunan sulkeutumisen jälkeen luodaan peli ikkunan
        /// nettiliikennekomponentin avulla. Jos ikkunan 
        /// Katkaise-property on true, ei luoda peliä.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLuoUusiPeli_Click(object sender, EventArgs e)
        {
            FormLuoPeli luonti = new FormLuoPeli();
            luonti.Korkeus = Properties.Settings.Default.pituus;
            luonti.Leveys = Properties.Settings.Default.leveys;
            luonti.Voittorivi = Properties.Settings.Default.voittopituus;
            luonti.Portti = Properties.Settings.Default.portti;
            luonti.ShowDialog();
            if (luonti.Yhteys == null) return;
            if (!luonti.Yhteys.Yhdistetty) return; // keskeytetty katkaisu....
            nettiliikenne = luonti.Yhteys;
            nettiliikenne.Kanavat = kanavat;
            
            //Ensimmäinen viesti, joka sisältää kentän koon
            nettiliikenne.lahetaViesti("A"+VERSIO+"|"+textBoxNimi.Text+"|"+luonti.Voittorivi+":"+luonti.Leveys+":"+luonti.Korkeus, "protokolla");
            nettiliikenne.uusiViesti += new Viesti(nettiliikenne_uusiViesti);
            nettiliikenne.LukuSeis = false;
            ristikkoPeliristikko.Vuorossa = true;
            labelInfo.Text = "Vuorossa: " + textBoxNimi.Text;
            alustaPeli(luonti.Korkeus, luonti.Leveys, luonti.Voittorivi);
        }

        /// <summary>
        /// Lasketaan kentän uusi koko.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAlusta_SizeChanged(object sender, EventArgs e)
        {
            if (!(peliKaynnissa)) return;
            laskeKenttaarvot();
            paivitaKeskustelu();

        }

        private void buttonLaheta_Click(object sender, EventArgs e)
        {
            lahetaViesti();
        }

        /// <summary>
        /// Hoitaa viestin lähettämisen. Ottaa sen
        /// textBoxViestistä ja tyhjentää kentän lopuksi.
        /// </summary>
        private void lahetaViesti()
        {
            listBoxViestit.Items.Add(textBoxNimi.Text + ": " + textBoxViesti.Text);
            listBoxViestit.SelectedIndex = listBoxViestit.Items.Count - 1;
            nettiliikenne.lahetaViesti(textBoxViesti.Text, "keskustelu"); 
            textBoxViesti.Text = "";
        }

        private void textBoxViesti_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) lahetaViesti();          
        }

        /// <summary>
        /// Näytetään about-ikkuna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.asetaVersio(VERSIO);
            about.ShowDialog();
        }

        /// <summary>
        /// Näytetään asetusikkuna. Toteutetaan asetukset ja 
        /// tallennetaan ne.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ulkoasuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            asetukset.ShowDialog();
            ristikkoPeliristikko.BackColor = asetukset.Taustavari;
            ristikkoPeliristikko.Viivavari = asetukset.Viivavari;
            ristikkoPeliristikko.OmaMerkkivari = asetukset.OmanMerkinvari;
            ristikkoPeliristikko.VierasMerkkiVari = asetukset.VieraanMerkinvari;

            Properties.Settings.Default.viivavari = asetukset.Viivavari;
            Properties.Settings.Default.omanMerkinvari = asetukset.OmanMerkinvari;
            Properties.Settings.Default.vieraanMerkinvari = asetukset.VieraanMerkinvari;
            Properties.Settings.Default.taustavari = asetukset.Taustavari;
            Properties.Settings.Default.Save();
        }

        private void buttonUusiPeli_Click(object sender, EventArgs e)
        {
            nettiliikenne.lahetaViesti("R|E", "protokolla");
            nettiliikenne.suljeYhteys();
            buttonPaavalikkoon.Visible = false;
            //nettiliikenne.LukuSeis = true;
            aloitaAlusta();
        }

        /// <summary>
        /// Suoritetaan, jos ei oteta revanssia pelin päätteeksi.
        /// Lähtetään vastapuolelle tieto tapahtuneesta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEiUutta_Click(object sender, EventArgs e)
        {
            buttonPaavalikkoon.Visible = true;
            panelRevanssinappulat.Visible = false;
            revanssiOma = 2;
            if (revanssiVastustaja == 2)
            {
                lisaaViesti("Hyväksyit revanssiehdotuksen");
                aloitaRevanssi();
            }
            else
            {
                lisaaViesti("Ehdoti revanssia! Odotetaan vastustajan päätöstä...");
            }
            nettiliikenne.lahetaViesti("R|K", "protokolla");
        }

        /// <summary>
        /// Siirtää päävalikkoon. Lähettää tiedon vastapuolelle tapahtuneesta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPaavalikkoon_Click(object sender, EventArgs e)
        {        
            if (nettiliikenne!= null & nettiliikenne.Yhdistetty) nettiliikenne.lahetaViesti("L:0", "protokolla");
            aloitaAlusta();
            buttonPaavalikkoon.Visible = false;
        }

        /// <summary>
        /// Lomakkeen latauksen yhteydessä ladataan myös asetukset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAlusta_Load(object sender, EventArgs e)
        {
            //(new testi()).Show();
            this.portti = Properties.Settings.Default.portti;
            this.ip = Properties.Settings.Default.ip;
            this.leveys = Properties.Settings.Default.leveys;
            this.pituus = Properties.Settings.Default.pituus;
            this.voittopituus = Properties.Settings.Default.voittopituus;
            this.nimi = Properties.Settings.Default.nimi;

            ristikkoPeliristikko.Viivavari = Properties.Settings.Default.viivavari;
            ristikkoPeliristikko.VierasMerkkiVari = Properties.Settings.Default.vieraanMerkinvari;
            ristikkoPeliristikko.OmaMerkkivari = Properties.Settings.Default.omanMerkinvari;
            ristikkoPeliristikko.BackColor = Properties.Settings.Default.taustavari;

            asetukset.Viivavari = Properties.Settings.Default.viivavari;
            asetukset.Taustavari = Properties.Settings.Default.taustavari;
            asetukset.OmanMerkinvari = Properties.Settings.Default.omanMerkinvari;
            asetukset.VieraanMerkinvari = Properties.Settings.Default.vieraanMerkinvari;

            textBoxNimi.Text = nimi;
        }

        /// <summary>
        /// Avaa ohjeen selaimeen.
        /// </summary>
        /// <param name="tarkennin">Mikä kohta näytettävää html-sivua näytetään.</param>
        public static void avaaOhje(String tarkennin) {

            if (tarkennin == null) tarkennin = "";
            else tarkennin = "#" + tarkennin;
            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = "iexplore";
            //proc.StartInfo.Arguments = ohjetiedosto+tarkennin;
            //proc.Start();
            System.Diagnostics.Process.Start(ohjetiedosto + tarkennin);

        }

        /// <summary>
        /// Avaa ohjeen nettiselaimeen.
        /// </summary>
        public static void avaaOhje()
        {
            avaaOhje(null);
        }

        /// <summary>
        /// Avaa IE:hen avustussivun.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ohjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            avaaOhje();
        }

        /// <summary>
        /// Sulkee ikkunan, jos esciä painettu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAlusta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) Application.Exit();
        }

        private void FormAlusta_KeyUp(object sender, KeyEventArgs e)
        {
            if (panelAlku.Visible) { if (e.KeyCode == Keys.F1) Nettiristinolla.FormAlusta.avaaOhje("aloittaminen"); }
            else  if (e.KeyCode == Keys.F1) Nettiristinolla.FormAlusta.avaaOhje("pelitila"); 
        }

    }
}
