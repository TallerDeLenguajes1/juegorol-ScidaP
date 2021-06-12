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
    public partial class Pelea : Form {
        public Pelea(List<Personaje> Personajes) {
            InitializeComponent();
            cargarDatosPelea(Personajes);
        }

        public void cargarDatosPelea(List<Personaje> Peleadores) {
            Random rand = new Random();
            int IndiceRandom1 = rand.Next(0, Peleadores.Count);
            int IndiceRandom2 = IndiceRandom1;
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
        }
    }
}
