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
    public partial class PrimeraVentana : Form {
        private List<Personaje> ListaPersonajes = new List<Personaje>();
        public PrimeraVentana() {
            InitializeComponent();
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
                            foreach(var clima in ListClimas) {
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

        private void button1_Click(object sender, EventArgs e) { // Botón de crear personaje
            Personaje nuevoPersonaje = Personaje.crearPersonajeConDatosAleatorios();
            agregarPersonajeALista(nuevoPersonaje);
            listPersonajesCreados.Items.Add(Personaje.mostrarPersonaje(nuevoPersonaje));
        }

        private void agregarPersonajeALista(Personaje nuevoPersonaje) {
            ListaPersonajes.Add(nuevoPersonaje);
        }

        public void RecargarListbox() {
            listPersonajesCreados.Items.Clear();
            for (int i = 0; i < ListaPersonajes.Count; i++) {
                listPersonajesCreados.Items.Add(Personaje.mostrarPersonaje(ListaPersonajes[i]));
            }
        }

        private void btnIniciarPelea_Click(object sender, EventArgs e) {
            if (ListaPersonajes.Count < 2) {
                MessageBox.Show("Debe crear al menos 2 personajes.", "ERROR");
            } else {
                Pelea VentanaPelea = new Pelea(ListaPersonajes);
                VentanaPelea.ShowDialog();
                RecargarListbox();
                //FileStream miArchivo = new FileStream("holamundo.csv", FileMode.CreateNew);
                //StreamWriter writer = new StreamWriter(miArchivo);
                //writer.WriteLine("HOLA");
                DeterminarCampeon();
            }
        }

        public void DeterminarCampeon() {
            if (ListaPersonajes.Count == 1) {
                MessageBox.Show("¡" + ListaPersonajes[0].Nombre + "(" + ListaPersonajes[0].Tipo + ") ES EL CAMPEÓN DEFINITIVO!", "TENEMOS CAMPEON!");
            }
        }
    }
}
