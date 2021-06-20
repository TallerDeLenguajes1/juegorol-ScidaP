using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace Control_Progreso {
    public partial class Pelea : Form {
        int IndiceRandom1, IndiceRandom2, cantAtaques = 0; // cantAtaques = contador de ataques. Solo se pueden 3 por jugador.
        List<Personaje> ListaPeleadores = new List<Personaje>();
        public Pelea(List<Personaje> Personajes) {
            InitializeComponent();
            ListaPeleadores = Personajes;
            cargarDatosPelea(Personajes);
            usarAPIClima();
        }

        public void usarAPIClima() { // Dependiendo del clima que haya en San miguel de tucumán, se pondrá una imagen de fondo en las ventanas.
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())); // Agarrar directorio para poder usar las imagenes
            path = path.Replace("\\bin", "");
            string error;
            var url = $"https://ws.smn.gob.ar/map_items/weather";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try {
                using (WebResponse response = request.GetResponse()) {
                    using (Stream strReader = response.GetResponseStream()) {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader)) {
                            string responseBody = objReader.ReadToEnd();
                            List<Provincias> ListClimas = JsonSerializer.Deserialize<List<Provincias>>(responseBody);
                            foreach (var clima in ListClimas) {
                                if (clima.Name == "San Miguel de Tucumán") {
                                    string descripcionClima = clima.Weather.Description;
                                    switch (ChequearClima(descripcionClima)) {
                                        case 1:
                                            Image img1 = Image.FromFile(path + "\\FotosClima\\nublado.jpg");
                                            this.BackgroundImage = img1;
                                            break;
                                        case 2:
                                            Image img2 = Image.FromFile(path + "\\FotosClima\\cubierto.jpg");
                                            this.BackgroundImage = img2;
                                            break;
                                        case 3:
                                            Image img3 = Image.FromFile(path + "\\FotosClima\\parc-nublado.jpg");
                                            this.BackgroundImage = img3;
                                            break;
                                        case 4:
                                            Image img4 = Image.FromFile(path + "\\FotosClima\\despejado.jpg");
                                            this.BackgroundImage = img4;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            } catch (WebException ex) {
                error = ex.ToString();
            }
        }

        public int ChequearClima(string desc) {
            string[] tiposDeClima = new string[14] { "Nublado", "Algo Nublado", "Algo nublado con bruma", "Algo nublado con humo", "Algo nublado con neblina"
        , "Cubierto", "Cubierto con neblina", "Cubierto con humo", "Cubierto con ventisca baja", "Parcialmente nublado", "Parcialmente nublado con nevlina", "Parcialmente nublado con bruma", "Parcialmente nublado con humo", "Despejado" };
            if (desc == tiposDeClima[0] || desc == tiposDeClima[1] || desc == tiposDeClima[2] || desc == tiposDeClima[3] || desc == tiposDeClima[4]) {
                return 1; // NUBLADO
            } else if (desc == tiposDeClima[5] || desc == tiposDeClima[6] || desc == tiposDeClima[7] || desc == tiposDeClima[8]) {
                return 2; // CUBIERTO
            } else if (desc == tiposDeClima[9] || desc == tiposDeClima[10] || desc == tiposDeClima[11] || desc == tiposDeClima[12]) {
                return 3; // PARCIALMENTE NUBLADO
            } else if (desc == tiposDeClima[12]) {
                return 4; // DESPEJADO
            }
            return 0;
        }

        public void cargarDatosPelea(List<Personaje> Peleadores) {
            Random rand = new Random();
            IndiceRandom1 = rand.Next(0, Peleadores.Count);
            IndiceRandom2 = IndiceRandom1;
            while (IndiceRandom2 == IndiceRandom1) { // Para que no se elijan dos jugadores iguales al pelear.
                IndiceRandom2 = rand.Next(0, Peleadores.Count);
            }
            lblPersonaje1.Text = Peleadores[IndiceRandom1].Nombre;
            lblNombreP1.Text = Peleadores[IndiceRandom1].Nombre;
            lblTipoP1.Text = Peleadores[IndiceRandom1].Tipo;
            lblEdadP1.Text = Peleadores[IndiceRandom1].Edad.ToString();
            lblVidaP1.Text = Peleadores[IndiceRandom1].Salud.ToString();
            lblVelocidadP1.Text = Peleadores[IndiceRandom1].Velocidad.ToString();
            lblFuerzaP1.Text = Peleadores[IndiceRandom1].Fuerza.ToString();
            lblNivelP1.Text = Peleadores[IndiceRandom1].Nivel.ToString();
            lblDestrezaP1.Text = Peleadores[IndiceRandom1].Destreza.ToString();
            lblArmaduraP1.Text = Peleadores[IndiceRandom1].Armadura.ToString();
            // Player 2
            lblPersonaje2.Text = Peleadores[IndiceRandom2].Nombre;
            lblNombreP2.Text = Peleadores[IndiceRandom2].Nombre;
            lblTipoP2.Text = Peleadores[IndiceRandom2].Tipo;
            lblEdadP2.Text = Peleadores[IndiceRandom2].Edad.ToString();
            lblVidaP2.Text = Peleadores[IndiceRandom2].Salud.ToString();
            lblVelocidadP2.Text = Peleadores[IndiceRandom2].Velocidad.ToString();
            lblFuerzaP2.Text = Peleadores[IndiceRandom2].Fuerza.ToString();
            lblNivelP2.Text = Peleadores[IndiceRandom2].Nivel.ToString();
            lblDestrezaP2.Text = Peleadores[IndiceRandom2].Destreza.ToString();
            lblArmaduraP2.Text = Peleadores[IndiceRandom2].Armadura.ToString();
            // Desactivar boton de atacar del player 2
            btnAtacar2.Enabled = false;
        }

        private int calcularDanioAtaque(List<Personaje> Peleadores, object sender) {
            Random rand2 = new Random();
            Button boton = (Button)sender;
            int ED = rand2.Next(40, 101); // Efectividad de disparo: valor de 40 a 100 (Personaje que ataca)
            if (boton.Name == "btnAtacar1") {
                int PD = Peleadores[IndiceRandom1].Destreza * Peleadores[IndiceRandom1].Fuerza * Peleadores[IndiceRandom1].Nivel; // Poder de disparo (Personaje que ataca)
                int VA = PD * ED; // Valor de ataque (Personaje que ataca)
                int PDEF = Peleadores[IndiceRandom2].Armadura * Peleadores[IndiceRandom2].Velocidad; // Poder de Defensa (personaje que defiende)
                int MDP = 50000; // Maximo daño provocable
                int danioTotal = (((VA * ED) - PDEF) / MDP) * rand2.Next(2, 5); // Daño total: Valor de ataque * efectividad de disparo - poder de defensa. Todo divido por el
                                                                                // Maximo daño provocable, y todo multiplicado por 100 (tuve que cambiar el 100 porque me daba
                                                                                // resultados muy altos).
                return danioTotal;
            } else {
                int PD = Peleadores[IndiceRandom2].Destreza * Peleadores[IndiceRandom2].Fuerza * Peleadores[IndiceRandom2].Nivel;
                int VA = PD * ED;
                int PDEF = Peleadores[IndiceRandom1].Armadura * Peleadores[IndiceRandom2].Velocidad;
                int MDP = 50000;
                int danioTotal = (((VA * ED) - PDEF) / MDP) * rand2.Next(2, 5);
                return danioTotal;
            }
        }

        private void btnAtacar_Click(object sender, EventArgs e) {
            Button boton = (Button)sender;
            if (boton.Name == "btnAtacar1") {
                btnAtacar1.Enabled = false;
                btnAtacar2.Enabled = true;
            } else {
                btnAtacar1.Enabled = true;
                btnAtacar2.Enabled = false;
            }
            int danioAtaque = calcularDanioAtaque(ListaPeleadores, sender);
            Atacar(ListaPeleadores, danioAtaque, sender);
        }

        private void Atacar(List<Personaje> Peleadores, int danio, object sender) {
            Button boton = (Button)sender;
            if (boton.Name == "btnAtacar1") {
                int nuevaSaludP2 = Peleadores[IndiceRandom2].Salud -= danio;
                if (nuevaSaludP2 < 0) { // Para que la vida de algún personaje no aparezca en negativo.
                    lblVidaP2.Text = "0";
                    Peleadores[IndiceRandom2].Salud = 0;
                    MostrarVencedor(Peleadores);
                } else {
                    lblVidaP2.Text = nuevaSaludP2.ToString();
                }
            } else {
                cantAtaques++;
                int nuevaSaludP1 = Peleadores[IndiceRandom1].Salud -= danio;
                if (nuevaSaludP1 < 0) { // Para que la vida de algún personaje no aparezca en negativo.
                    lblVidaP1.Text = "0";
                    Peleadores[IndiceRandom1].Salud = 0;
                    MostrarVencedor(Peleadores);
                } else {
                    lblVidaP1.Text = nuevaSaludP1.ToString();
                }
            }
            if (cantAtaques >= 3) {
                MostrarVencedor(Peleadores);
            }
        }

        private void MostrarVencedor(List<Personaje> Peleadores) {
            string Vencedor;
            if (Peleadores[IndiceRandom1].Salud > Peleadores[IndiceRandom2].Salud) {
                Vencedor = Peleadores[IndiceRandom1].Nombre + " (" + Peleadores[IndiceRandom1].Tipo + ")";
            } else if (Peleadores[IndiceRandom1].Salud < Peleadores[IndiceRandom2].Salud) {
                Vencedor = Peleadores[IndiceRandom2].Nombre + " (" + Peleadores[IndiceRandom2].Tipo + ")";
            } else {
                Vencedor = "EMPATE";
            }
            if (Vencedor == "EMPATE") {
                MessageBox.Show("Fue Empate! ABURRIDISMO!", "EMPATE");
            } else {
                MessageBox.Show("¡" + Vencedor + " ganó la batalla!", "¡Ya tenemos un ganador!");
            }
            ModificarPeleadores(Peleadores);
            this.Close();
        }

        private void ModificarPeleadores(List<Personaje> Peleadores) { // Elimina al perdedor y le bonifica un poco de vida, nivel y fuerza al ganador
            if (Peleadores[IndiceRandom1].Salud > Peleadores[IndiceRandom2].Salud) {
                //Bonificar al ganador
                Peleadores[IndiceRandom1].Salud += 20;
                Peleadores[IndiceRandom1].Fuerza += 1;
                Peleadores[IndiceRandom1].Nivel += 1;
                //Elminar al perdedor
                Peleadores.RemoveAt(IndiceRandom2);
            } else if (Peleadores[IndiceRandom1].Salud < Peleadores[IndiceRandom2].Salud) {
                //Bonificar al ganador
                Peleadores[IndiceRandom2].Salud += 20;
                Peleadores[IndiceRandom2].Fuerza += 1;
                Peleadores[IndiceRandom2].Nivel += 1;
                //Elminar al perdedor
                Peleadores.RemoveAt(IndiceRandom1);
            }
        } 
    }
}
