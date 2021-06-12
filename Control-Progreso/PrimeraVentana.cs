using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Progreso {
    public partial class PrimeraVentana : Form {
        private List<Personaje> ListaPersonajes = new List<Personaje>();
        public PrimeraVentana() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) { // Botón de crear personaje
            Personaje nuevoPersonaje = Personaje.crearPersonajeConDatosAleatorios();
            agregarPersonajeALista(nuevoPersonaje);
            listPersonajesCreados.Items.Add(Personaje.mostrarPersonaje(nuevoPersonaje));
        }

        private void agregarPersonajeALista(Personaje nuevoPersonaje) {
            ListaPersonajes.Add(nuevoPersonaje);
        }

        private void btnIniciarPelea_Click(object sender, EventArgs e) {
            if (ListaPersonajes.Count < 2) {
                MessageBox.Show("Debe crear al menos 2 personajes.", "ERROR");
            } else {
                Pelea VentanaPelea = new Pelea(ListaPersonajes);
                VentanaPelea.Show();
            }
        }
    }
}
