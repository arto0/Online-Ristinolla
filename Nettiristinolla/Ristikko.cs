using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nettiristinolla
{

    public delegate void Siirto(object sender, int x, int y);
    public delegate void Peli();
    public delegate void Vuoro();

    /// <summary>
    /// Luodaan ristinollapelin ristikko. Osaa
    /// hallita painallukset oikein. Kertoo 
    /// tapahtumin painalluksesta ja pelin
    /// päättymisestä. Ruudukkoa voi ulkoasullisesti
    /// muokata.
    /// </summary>
    public partial class Ristikko : Panel
    {
        public event Siirto siirtoTehty;
        public event Peli peliPaattyi;
        public event Peli tasapeli;
        public event Vuoro vuoronVaihto;

        private const int VAPAAMERKKI = 0;
        private int siirto = 0;
        private int voittopituus = 5;
        private int[,] ruudut;
        private int tyyppiOma = 2;
        private int tyyppiVieras = 1;
        bool vuorossa = true;
        private int nappuloitaRivissa = 100;
        private int nappuloitaSarakkeessa = 100;
        private Point voitto1;
        private Point voitto2;
        private bool peliOhi = false;

        private Color viivavari = Color.Black;
        private Color vierasMerkkivari = Color.Black;
        private Color omaMerkkivari = Color.Black;

        public Ristikko()
        {
            InitializeComponent();
            asetaKoot(20,20,4);
        }

        [Category("Pelitiedot"),
        Description("Tieto siitä, onko vuoro tällä ristikolla"),
        DefaultValue(true),
        Browsable(true)]
        public bool Vuorossa
        {
            set { vuorossa = value; }
            get { return vuorossa; }
        }

        [Category("Ulkoasu"),
        Description("Ruudukon viivojen väri"),
        Browsable(true)]
        public Color Viivavari
        {
            set { viivavari = value; Invalidate(); }
            get { return viivavari; }
        }

        [Category("Ulkoasu"),
        Description("Oman merkin väri"),
        Browsable(true)]
        public Color OmaMerkkivari
        {
            set { omaMerkkivari = value; Invalidate(); }
            get { return omaMerkkivari; }
        }

        [Category("Ulkoasu"),
        Description("Vieraan merkin väri"),
        Browsable(true)]
        public Color VierasMerkkiVari
        {
            set { vierasMerkkivari = value; Invalidate(); }
            get { return vierasMerkkivari; }
        }

        [Category("Pelitiedot"),
        Description("Tieto siitä, onko peli ohi"),
        DefaultValue(true),
        Browsable(true)]
        public bool PeliOhi
        {
            get { return peliOhi; }
        }

        /// <summary>
        /// Nollaa ristikon.
        /// </summary>
        public void nollaa()
        {
            peliOhi = false;
            siirto = 0;
            ruudut = new int[nappuloitaRivissa, nappuloitaSarakkeessa];
            voitto1 = new Point(-1, -1);
            voitto2 = new Point(-1,-1);
            Enabled = true;
            Invalidate();     
        }

        /// <summary>
        /// Asetetaan kentän rivien ja sarakkeiden määrä.
        /// Kolmea pienempi leveys, korkeus tai voittopituus 
        /// astetaan kolmeksi.
        /// </summary>
        /// <param name="sarakkeet">Laitetavat rivit</param>
        /// <param name="rivit">Laitettavat sarakkeet</param>
        /// /// <param name="voittopituus">Laitettava voittopituus</param>
        public void asetaKoot(int sarakkeet, int rivit, int voittopituus) 
        {
            if (rivit < 3) rivit = 3;
            if (sarakkeet < 3) sarakkeet = 3;
            if (voittopituus < 3) voittopituus = 3;
            nappuloitaRivissa = sarakkeet;
            nappuloitaSarakkeessa = rivit;
            this.voittopituus = voittopituus;
            nollaa();
        }

        /// <summary>
        /// Palauttaa rivin korkeuden.
        /// </summary>
        /// <returns>Rivin korkeus</returns>
        private int annaRivinKorkeus()
        {
            return Height / nappuloitaSarakkeessa;
        }

        /// <summary>
        /// Palauttaa sarakkeen leveyden
        /// </summary>
        /// <returns>Sarakkeen leveys</returns>
        private int annaSarakkeenLeveys()
        {
            return Width / nappuloitaRivissa;
        }

        /// <summary>
        /// Piirretään kaikki tarpeellinen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ristikko_Paint(object sender, PaintEventArgs e)
        {
            int korkeus = annaRivinKorkeus();
            int leveys = annaSarakkeenLeveys();

            Pen penViiva = new Pen(Brushes.Black, 1);
            penViiva.Color = viivavari;

            for (int i = 0; i < nappuloitaRivissa; i++)
            {
                // Piirretään pystysuorat viivat
                if (i != 0) e.Graphics.DrawLine(penViiva, new Point(i * leveys, 0), new Point(i * leveys, Height));
                for (int j = 0; j < nappuloitaSarakkeessa; j++)
                {
                    // Piirretään vaakasuorat viivat
                    if (i == 0 && j != 0) e.Graphics.DrawLine(penViiva, new Point(0, j * korkeus), new Point(Width, j * korkeus));
                    if (ruudut[i,j] != 0) teeSiirto(new Point(i, j), ruudut[i, j]);
                }
            }
            if (peliOhi) piirraVoittolinja(voitto1, voitto2, e.Graphics);
        }

        /// <summary>
        /// Tutkitaan kulkeeko annetun pisteen kautta voittosuora.
        /// </summary>
        /// <param name="piste">Piste, jonka ympäristöä tutkitaan</param>
        /// <param name="tyyppi">Tyyppi, jota etsitään</param>
        /// <returns>Null, jos ei voittoa. Muutoin taulukko, jonka eka kohta on voittorivin ensimmäinen piste ja toinen kohta rivin toinen piste.</returns>
        private Point[] tarkistaVoitto(Point piste, int tyyppi)
        {
            Point[] pisteet;
            
            // Vaakarivin tarkistus
            pisteet = tarkistaRivi(new Point(piste.X - voittopituus, piste.Y), 1, 0, voittopituus, voittopituus * 2, tyyppi);
            if (pisteet != null) return pisteet;

            // Pystyrivin tarkistus
            pisteet = tarkistaRivi(new Point(piste.X, piste.Y - voittopituus), 0, 1, voittopituus, voittopituus * 2, tyyppi);
            if (pisteet != null) return pisteet;

            // Vasemmalta oikealla vino
            pisteet = tarkistaRivi(new Point(piste.X - voittopituus, piste.Y - voittopituus), 1, 1, voittopituus, voittopituus * 2, tyyppi);
            if (pisteet != null) return pisteet;

            // Oikealta vasemmalle vino
            pisteet = tarkistaRivi(new Point(piste.X + voittopituus, piste.Y - voittopituus), -1, 1, voittopituus, voittopituus * 2, tyyppi);
            if (pisteet != null) return pisteet;

            return null;
        }
         
        /// <summary>
        /// Ottaa vastaan pisteen ja tarkistaa siitä eteenpäin 
        /// haluttuun suuntaan halutun määrän pisteitä ja palauttaa
        /// haluttua tyyppiä olevan pistejonon päätepisteet tai 
        /// nullin.
        /// </summary>
        /// <param name="piste">Piste, josta tutkiminen aloitetaan</param>
        /// <param name="muutosX">Seuraavan pisteen x:n muutos</param>
        /// <param name="muutosY">Seuraavan pisteen y:n muutos</param>
        /// <param name="voittopituus">Haluttu voittopituus</param>
        /// <param name="tarkistuspituus">Kuinka pitkälle tarkistetaan</param>
        /// <param name="tyyppi">Tyyppiä, jota etsitään</param>
        /// <returns>Null, jos jonoa ei löydetty, muutoin päätepisteet.</returns>
        private Point[] tarkistaRivi(Point piste, int muutosX, int muutosY, int voittopituus, int tarkistuspituus, int tyyppi)
        {
            int tarkistettavaX = piste.X;
            int tarkistettavaY = piste.Y;
            int saatuPituus = 0;
            for (int i = 0; i < tarkistuspituus; i++)
            {
                tarkistettavaX = piste.X + muutosX * i;
                tarkistettavaY = piste.Y + muutosY * i;
                if (tarkistettavaX < 0 || tarkistettavaX >= nappuloitaRivissa || tarkistettavaY < 0 || tarkistettavaY >= nappuloitaSarakkeessa || ruudut[tarkistettavaX, tarkistettavaY] != tyyppi)
                {
                    // Ollaan joko alueen ulkopuolella tai ruudussa väärä tyyppi
                    saatuPituus = 0;
                    continue;
                }
                saatuPituus++;

                if (saatuPituus == voittopituus)
                {
                    int alkuX = tarkistettavaX - muutosX * (voittopituus-1);
                    int alkuY = tarkistettavaY - muutosY * (voittopituus-1);
                    Point[] taulu = { new Point(alkuX, alkuY), new Point(tarkistettavaX, tarkistettavaY) };
                    return taulu;
                }
            }
            return null;
        }

        /// <summary>
        /// Selvittää mihin ruudukon pisteeseen annetut koordinaatit
        /// kuuluvat.
        /// </summary>
        /// <param name="x">Tutkittava x</param>
        /// <param name="y">Tutkittava y</param>
        private Point selvitaPiste(int x, int y)
        {
            double suhdeX = (double)x / (nappuloitaRivissa * annaSarakkeenLeveys());
            int kohtaX = (int)(suhdeX * nappuloitaRivissa);

            double suhdeY = (double)y / (nappuloitaSarakkeessa * annaRivinKorkeus());
            int kohtaY = (int)(suhdeY * nappuloitaSarakkeessa);
            
            // Liukulukujen takia ruudukko ei välttämättä ole jakautunut täysin tasaisesti,
            // joten on mahdollista klikata sen ulkopuolelta. Alla varmistetaan,
            // että tällöin ei yritetä merkata pelitaulun ulkopuolelle.
            if (kohtaX > nappuloitaRivissa-1) kohtaX = nappuloitaRivissa-1;
            if (kohtaY > nappuloitaSarakkeessa-1) kohtaY = nappuloitaSarakkeessa-1;

            return new Point(kohtaX, kohtaY);
        }

        /// <summary>
        /// Piirtää ruudukkoon pisteen annetun tyypin
        /// mukaisesti. Piste asetetaan myös ruudut-tauluun.
        /// </summary>
        /// <param name="piste">Piste, johon piirretään</param>
        /// <param name="tyyppi">Piirrettävä merkki: 1 = X, 2 = Y</param>
        private void teeSiirto(Point piste, int tyyppi)
        {
            ruudut[piste.X, piste.Y] = tyyppi;
            Pen penViivaOma = new Pen(Brushes.Black, 1);
            Pen penViivaVieras = new Pen(Brushes.Black, 1);
            penViivaOma.Color = omaMerkkivari;
            penViivaVieras.Color = vierasMerkkivari;

            int vasenX = annaSarakkeenLeveys() * piste.X;
            int oikeaX = annaSarakkeenLeveys() * (piste.X+1);
            int ylaY = annaRivinKorkeus() * piste.Y;
            int alaY = annaRivinKorkeus() * (piste.Y+1);
            if (tyyppi == 1)
            {
                this.CreateGraphics().DrawLine(penViivaOma, new Point(vasenX, ylaY), new Point(oikeaX, alaY));
                this.CreateGraphics().DrawLine(penViivaOma, new Point(vasenX, alaY), new Point(oikeaX, ylaY));
            }
            else
            {
                // Alla olevat hihavakiot ovat sitä varten, ettei
                // ympyrän reunat mene ruudukon päälle.
                this.CreateGraphics().DrawEllipse(penViivaVieras, vasenX+1, ylaY+1, annaSarakkeenLeveys()-2, annaRivinKorkeus()-2);
            }
        }

        /// <summary>
        /// Piirtää viivan kahden annetun pisteen välille.
        /// </summary>
        /// <param name="piste1">Aloituspisteen kohta ruudut-taulussa</param>
        /// <param name="piste2">Lopetuspisteen kohta ruudut-taulussa</param>
        private void piirraVoittolinja(Point piste1, Point piste2, Graphics e) 
        {
            int piste1X = piste1.X * annaSarakkeenLeveys() + annaSarakkeenLeveys() / 2;
            int piste1Y = piste1.Y * annaRivinKorkeus() + annaRivinKorkeus() / 2;

            int piste2X = piste2.X * annaSarakkeenLeveys() + annaSarakkeenLeveys() / 2;
            int piste2Y = piste2.Y * annaRivinKorkeus() + annaRivinKorkeus() / 2;

            Pen penViiva = new Pen(Brushes.Red, 3);

            e.DrawLine(penViiva, new Point(piste1X, piste1Y), new Point(piste2X, piste2Y));
        }

        /// <summary>
        /// Kun hiiren nappi on noussut ylös, selvitetään
        /// mitä ruutua painettiin ja tehdään siirto siihen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ristikko_MouseUp(object sender, MouseEventArgs e)
        {
           // MessageBox.Show("" + siirto);
            if (peliOhi == true) return;
            if (vuorossa == false) return;
            Point painettu = selvitaPiste(e.X, e.Y);
            if (!onkoVapaa(painettu)) return;
            vuorossa = false;
            siirtoTehty(this, painettu.X, painettu.Y);
            siirtotapahtumat(tyyppiOma, painettu);                            
        }

        /// <summary>
        /// Annetaan siirto ruudukolle.
        /// </summary>
        /// <param name="x">Siirron x.</param>
        /// <param name="y">Siirron y.</param>
        public void annaSiirto(int x, int y) 
        {
          //  MessageBox.Show(""+siirto);
            if (peliOhi == true) return;
            vuorossa = true;
            siirtotapahtumat(tyyppiVieras, new Point(x, y));
        }

        /// <summary>
        /// Tekee siirron, lisää siirtolaskuria, tarkistaa voittorivit ja
        /// jos voitto tulee tai peli loppuu, ilmoittaa asiasta.
        /// </summary>
        /// <param name="tyyppi"></param>
        /// <param name="painettu"></param>
        private void siirtotapahtumat(int tyyppi, Point painettu)
        {
            teeSiirto(painettu, tyyppi);
            siirto++;
            Point[] taulu = tarkistaVoitto(painettu, tyyppi);
            if (taulu != null) {
                vuorossa = !vuorossa; // perutaan tehty vuoronvaihto
                voitto1 = taulu[0]; 
                voitto2 = taulu[1]; 
                peliOhi = true; 
                Invalidate(); 
                if (peliPaattyi != null) peliPaattyi(); 
                return; 
            }
            //else vuorossa = true;
            if (taulu == null & vuoronVaihto != null) vuoronVaihto();
            if (siirto == nappuloitaRivissa * nappuloitaSarakkeessa) { peliOhi = true; tasapeli(); }
        }

        /// <summary>
        /// Tarkistaa onko annettu paikka vapaa.
        /// </summary>
        /// <param name="piste">Tarkistettava paikka</param>
        private bool onkoVapaa(Point piste)
        {
            if (ruudut[piste.X, piste.Y] == VAPAAMERKKI) return true;
            return false;
        }

        private void Ristikko_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
