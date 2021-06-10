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
    public partial class Form1 : Form {
        private List<Personaje> ListaPersonajes = new List<Personaje>();
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) { // Botón de crear personaje
            Personaje nuevaClasePersonaje = new Personaje();
            Personaje nuevoPersonaje = nuevaClasePersonaje.datosAleatorios();
            agregarPersonajeALista(nuevoPersonaje);

        }

        private void agregarPersonajeALista(Personaje nuevoPersonaje) {
            ListaPersonajes.Add(nuevoPersonaje);
        }

        private void button2_Click(object sender, EventArgs e) {

        }
    }
}
