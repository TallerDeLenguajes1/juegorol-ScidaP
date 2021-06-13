﻿using System;
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
        int IndiceRandom1, IndiceRandom2, cantAtaques = 0; // cantAtaques = contador de ataques. Solo se pueden 3 por jugador.
        List<Personaje> ListaPeleadores = new List<Personaje>();
        public Pelea(List<Personaje> Personajes) {
            InitializeComponent();
            ListaPeleadores = Personajes;
            cargarDatosPelea(Personajes);
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
            int ED = rand2.Next(39, 101); // Efectividad de disparo: valor de 1 a 100 (Personaje que ataca)
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
                lblVidaP2.Text = nuevaSaludP2.ToString();
            } else {
                int nuevaSaludP1 = Peleadores[IndiceRandom1].Salud -= danio;
                lblVidaP1.Text = nuevaSaludP1.ToString();
                cantAtaques++;
            }
        }
    }
}