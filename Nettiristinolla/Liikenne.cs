using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Nettiristinolla
{
    /// <summary>
    /// Viesti-ilmoitukset
    /// </summary>
    /// <param name="viesti">Kyseessä oleva viesti</param>
    /// <param name="tyyppi">Viestin tyyppi</param>
    public delegate void Viesti(String viesti, int tyyppi);

    /// <summary>
    /// Avatun yhteyden toiminaan liittyvä ongelma.
    /// </summary>
    /// <param name="selite">Ongelman suomenkielinen selite tai null</param>
    public delegate void Yhteysongelma(String selite);

    /// <summary>
    /// Yhteyteen liittyvä ilmoitus
    /// </summary>
    /// <param name="sender">Tämä nettiliikenteen esiintymä</param>
    /// <param name="tasmennys">Tapahtuman suomenkielinen kuvaus tai null</param>
    public delegate void Yhteys(object lahettaja, String tasmennys);

    /// <summary>
    /// Komponentti nettiliikenteen hoitamiseen.
    /// Osaa muodostaa yhteyden palvelimena ja
    /// asiakkaana. Lukee viestejä ja ilmoittaa
    /// niistä tapahtumilla. Osaa lopuksi sulkea
    /// yhteydet.
    /// </summary>
    public partial class Liikenne : Component
    {
        /// <summary>
        /// Suoritetaan, kun uusi viesti tulee. Sisältää tiedon
        /// viestin tyypistä ja itse viestin.
        /// </summary>
        public event Viesti uusiViesti;

        /// <summary>
        /// Tapahtuu, jos viestinvälitys ei onnistu.
        /// </summary>
        public event Yhteysongelma lahetysEiOnnistu;

        /// <summary>
        /// Tapahtuu, kun yhteys on saatu avattua.
        /// </summary>
        public event Yhteys avattu;

        /// <summary>
        /// Suoritetaan yhdistysvaiheessa, jos yhteyden muodostaminen
        /// ei onnistukaan.
        /// </summary>
        public event Yhteys yhdistysEiOnnistu;

        /// <summary>
        /// Suoritetaan, jos yhteys katkeaa
        /// </summary>
        public event Yhteys katkaistu;

        private String osoite = "127.0.0.1";
        private String[] kanavat;
        private System.Windows.Forms.Timer ajastin = new System.Windows.Forms.Timer();
        private bool palvelin = false;
        private TcpClient client;
        private TcpListener server;
        private int portti = 9696;
        private bool yhdistetty = false;
        private bool lukuSeis = true;
        private bool lopetettu = false; // kertoo onko olemasasollut yhteys lopetettu

        private NetworkStream nettivirta;
        private StreamReader lukuvirta;
        private StreamWriter kirjoitusvirta;

        [Category("Yhteys"),
        Description("Yrittääkö yhteys lukea tulevia viestejä (false) vai ei (true). Tämä pitää laittaa trueksi. Tämän vaihto falseksi kesken yhteyden lopettaa viestien lukemisen vasta kuin yksi viesti muutoksen jälkeen on tullut."),
        Browsable(false)]
        public bool LukuSeis
        {
            set { lukuSeis = value; }
            get { return lukuSeis; }
        }

        [Category("Yhteys"),
        Description("Tieto siitä, onko yhdistetty"),
        Browsable(false)]
        public bool Yhdistetty
        {
            get { return yhdistetty; }
        }

        [Category("Katkaistu"),
        Description("Tieto siitä, onko yhteys katkaistu"),
        Browsable(false)]
        public bool Katkaistu
        {
            get { return yhdistetty; }
        }

        [Category("Yhteys"),
        Description("Yhteyden käyttämä portti"),
        Browsable(true)]
        public int Portti
        {
            set { portti = value; }
            get { return portti; }
        }

        [Category("Yhteys"),
        Description("Onko yhteys palvelinmuodossa"),
        Browsable(true)]
        public bool Palvelin
        {
            set { palvelin = value; }
            get { return palvelin; }
        }

        [Category("Yhteys"),
        Description("Yhteyden tuntemat kanavat"),
        Browsable(true)]
        public String[] Kanavat {
            set { kanavat = value; }
            get { return kanavat; }
        }

        [Category("Yhteys"),
        Description("Käytettävä osoite"),
        Browsable(true)]
        public String Osoite
        {
            set { osoite = value; }
            get { return osoite; }
        }

        public Liikenne()
        {
            if (client != null) return;
            InitializeComponent();
        }

        /// <summary>
        /// Aloittaa yhteyden komponentin parametreilla.
        /// </summary>
        /// <returns>Tieto onnistuiko kaikki</returns>
        public String aloitaYhteys() {
            if (yhdistetty || lopetettu) return "yhteys jo muodostettu tai suljettu";
            if (palvelin) return luoYhteysPalvelin();
            else return luoYhteysAsiakas();    
        }

        /// <summary>
        /// Yrittää sulkea kaikki yhteydet
        /// </summary>
        /// <returns>Aina null</returns>
        public void suljeYhteys()
        {
            try
            {
                if (server != null) server.Stop();
            } catch (Exception) { }
            try
            {
                if (client != null) client.Close();
            }
            catch (Exception) { }
            try
            {
                if (lukuvirta != null) lukuvirta.Close();
            } catch(Exception) {}
            try
            {
                if (kirjoitusvirta != null) kirjoitusvirta.Close();
            } catch(Exception) {}
            try
            {
                if (nettivirta != null) nettivirta.Close();
            } catch(Exception) {}

            yhdistetty = false;
            lopetettu = true;
        }

        /// <summary>
        /// Aloittaa palvelinyhteyden.
        /// </summary>
        private String luoYhteysPalvelin()
        {
            try
            {
                server = new TcpListener(System.Net.IPAddress.Any, portti);
                server.Start(1);
                server.BeginAcceptTcpClient(new AsyncCallback(serverCallBack), server);
            }
            catch (SocketException e)
            {
                return "yhteyttä ei voi muodostaa: " + e;
            }
            return null;
        }

        /// <summary>
        /// Palauttaa IP-osoitteen. Jos komponentti on palvelin,
        /// palautetaan koneen ip-osoite. Muussa tapauksessa
        /// palautetaan yhdistystä varten komponenttiin asetettu
        /// ip-osoite.
        /// </summary>
        public String palautaIP()
        {
            if (!palvelin) return osoite;
            else
            {
                IPHostEntry IPHost = Dns.GetHostEntry(Dns.GetHostName());
                // Jotta tulisi ipv4-osoite, pitää alun ipv6-osoitteet rullata yli
                for (int i = 0; i < IPHost.AddressList.Length; i++)
                {
                    if (IPHost.AddressList[i].AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString()) return IPHost.AddressList[i].ToString();
                }
            }
            return null;
        }

        /// <summary>
        /// Lähettää viestin protokollakanavalla. Tarkoitettu 
        /// komponentin omaan viestintään. Eteen liitetään
        /// tunnus "P|".
        /// </summary>
        /// <param name="viesti">Lähetettävä viesti.</param>
        private void lahetaProtokollaviesti(String viesti)
        {
            lahetaViesti("P|" + viesti);
        }

        /// <summary>
        /// Lähettää viestin halutulla kanavalla. Kanavanumero
        /// liitettään viestni alkuun.
        /// </summary>
        /// <param name="viesti">Lähetettävä viesti.</param>
        /// <param name="kanava">Käytettävän kanavan numero.</param>
        private void lahetaKanavaviesti(String viesti, int kanava)
        {
            lahetaViesti("" + kanava + "|" + viesti);
        }

        /// <summary>
        /// Lähettää annetun viestin annetulla kanavalla.
        /// Jos kanavaa ei löydy, lähetetään tuntemattomien
        /// viestien kanavilla.
        /// </summary>
        /// <param name="viesti">Lähetettävä viesti</param>
        /// <param name="kanava">Käytettävän kanavan nimi</param>
        public void lahetaViesti(String viesti, String kanava)
        {
            lahetaKanavaviesti(viesti, selvitaKanava(kanava));
        }

        /// <summary>
        /// Suoritetaan, kun yhteys halutaan lopettaa siten, että vastapuolelle
        /// ilmoitetaan asiasta. Sulkee kaikki yhteydet. Jos ei ole yhteyttä,
        /// ei tehdä mitään.
        /// </summary>
        public void lopetaYhteys()
        {
            if (yhdistetty) lahetaProtokollaviesti("-2");
        }

        /// <summary>
        /// Selvittää annetun kanavan järjestysnumeron.
        /// </summary>
        /// <param name="kanava">Kanava, jonka järjestysnumero palautetaan.</param>
        /// <returns>Kanavan järjestysnumero. -1, jos ei löydy.</returns>
        private int selvitaKanava(String kanava)
        {
            for (int i = 0; i < kanavat.Length; i++)
            {
                if (kanavat[i] == kanava) return i;
            }
            return -1;
        }

        /// <summary>
        /// Lähettää annetun viestin sellaisenaan.
        /// </summary>
        /// <param name="viesti">Lähetettävä viesti.</param>
        private void lahetaViesti(String viesti)
        {
            if (!yhdistetty) { if (lahetysEiOnnistu != null) lahetysEiOnnistu("viestiä yritettiin lähettää vaikka yhteyttä ei ole"); return; }
            kirjoitusvirta.WriteLine(viesti);
            try
            {
                Thread.Sleep(0);
                kirjoitusvirta.Flush();
            }
            catch (IOException)
            {
                suljeYhteys();
                if (lahetysEiOnnistu != null) lahetysEiOnnistu("iO-virhe");
            }
        }

        /// <summary>
        /// Suoritetaan kun palvelin saa yhteydenoton.
        /// Muodostetaan luku- ja kirjoitusvirrat.
        /// Aletaan lukea viestejä loputtomassa 
        /// silmukassa.
        /// </summary>
        /// <param name="Ar"></param>
        public void serverCallBack(IAsyncResult Ar)
        {
            TcpListener server = (TcpListener)Ar.AsyncState;
            TcpClient client = (TcpClient)server.EndAcceptTcpClient(Ar);
            //if (client == null) { if (yhdistysEiOnnistu != null) yhdistysEiOnnistu(this, "palvelinta ei löydy"); return; }
            //if (!client.Connected) { if (yhdistysEiOnnistu != null) yhdistysEiOnnistu(this, "palvelinta ei löydy"); return; }
           
            nettivirta = client.GetStream();
            lukuvirta = new StreamReader(nettivirta);
            kirjoitusvirta = new StreamWriter(nettivirta);
            
            yhdistetty = true;
            if (avattu != null) avattu(this, "yhteys vastaanotettu");
            lueViesteja();
        }

        /// <summary>
        /// Aloittaa asiakasyhteyden.
        /// </summary>
        /// <returns>Mahdollinen virhe. Null, jos ei virhettä.</returns>
        private String luoYhteysAsiakas()
        {        
            try
            {
                client = new TcpClient();
                client.BeginConnect(osoite, portti, new AsyncCallback(httpCallBack), client);
            }
            catch (Exception err)
            {
                return err.Message;
            }
            return null;
        }

        /// <summary>
        /// Suoritetaan kun yhteys palvelimeen on saatu.
        /// Muodostaa luku- ja kirjoitusvirran ja 
        /// alkaa lukea viestejä loputtomassa silmukassa.
        /// Aiheuttaa myös avattu-tapahtuman. Jos 
        /// yhteyttä ei ole, aiheuttaa eiOnnistu-tapahtuman.
        /// </summary>
        /// <param name="Ar"></param>
        public void httpCallBack(IAsyncResult Ar)
        {         
            TcpClient client = (TcpClient)Ar.AsyncState;
            if (lopetettu) { if (yhdistysEiOnnistu != null)yhdistysEiOnnistu(this, "yhteys on jo lopetettu"); return; };
            if (!client.Connected) { if (yhdistysEiOnnistu != null)yhdistysEiOnnistu(this, "palvelinta ei löydy"); return; }
            
            lukuvirta = new StreamReader(client.GetStream());
            kirjoitusvirta = new StreamWriter(client.GetStream());
            if (avattu != null) avattu(this, "yhteys palvelimeen muodostettu"); 
            yhdistetty = true;
            lueViesteja();
        }

        /// <summary>
        /// Lukee viestejä ja aiheuttaa tapahtumia uusien viestin tullessa.
        /// </summary>
        private void lueViesteja()
        {
            String rivi;
            int tyyppi;
            while (yhdistetty)
            {
                if (lukuSeis) { Thread.Sleep(0); continue; }
                try
                {
                    rivi = lukuvirta.ReadLine();
                    if (rivi == null) break;
                    if (rivi == "P|-2") { lahetaProtokollaviesti("-3"); katkaistu(this, "vastapuoli katkaisi yhteyden"); suljeYhteys(); return; };
                    if (rivi == "P|-3") { katkaistu(this, "yhteys suljettu"); suljeYhteys(); return; }
                    tyyppi = parsiTyyppi(rivi);
                    rivi = poistaTyyppi(rivi);
                    uusiViesti(rivi, tyyppi);
                }
                catch (IOException)
                {
                    if (katkaistu != null) { yhdistetty = false; katkaistu(this, "yhteys katkesi");}
                    suljeYhteys();
                    break;
                }
                Thread.Sleep(0);
            }

        }

        /// <summary>
        /// Poistaa rivin alusta kaiken |-merkkiin asti.
        /// </summary>
        /// <param name="rivi">Rivi, jota muokataan</param>
        /// <returns>Muokattu rivi</returns>
        private String poistaTyyppi(String rivi)
        {
            int kohta = 0;
            for (int i = 0; i < rivi.Length; i++)
            {
                if (rivi[i] == '|') { kohta = i+1; break; }
            }
            return rivi.Substring(kohta, rivi.Length - kohta);
        }

        /// <summary>
        /// Parsii tulleesta viestistä alussa
        /// olevan numeron.
        /// </summary>
        /// <param name="rivi">Parsittava merkkijono</param>
        /// <returns>Alun numero</returns>
        private int parsiTyyppi(String rivi)
        {
            int i = 0;
            String tyyppi = "";
            foreach (char merkki in rivi)
            {
                i++;
                if (merkki == '|') break;
                tyyppi += merkki;
            }

            int palautettavaTyyppi = -1;
            try
            {
                palautettavaTyyppi = int.Parse(tyyppi);
            }
            catch (Exception) {
            }
                
            return palautettavaTyyppi;
        }
    }
}
