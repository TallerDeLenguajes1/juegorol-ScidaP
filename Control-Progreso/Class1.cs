using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Progreso {
    class Class1 {

        public enum tipoPersonaje {
            Elfo,
            Orco,
            Hobbit,
            Humano
        }

        class Personaje {
            private tipoPersonaje tipo;
            private string nombre;
            private string apodo;
            private DateTime fechaNac;
            private int edad;
            private int salud;
            private int personajeCreado = 0;

            private int velocidad, destreza, fuerza, nivel, armadura;

            public string Nombre { get => nombre; set => nombre = value; }
            public string Apodo { get => apodo; set => apodo = value; }
            public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
            public int Edad { get => edad; set => edad = value; }
            public int Salud { get => salud; set => salud = value; }
            public int Velocidad { get => velocidad; set => velocidad = value; }
            public int Destreza { get => destreza; set => destreza = value; }
            public int Fuerza { get => fuerza; set => fuerza = value; }
            public int Nivel { get => nivel; set => nivel = value; }
            public int Armadura { get => armadura; set => armadura = value; }
            public tipoPersonaje Tipo { get => tipo; set => tipo = value; }
            public int PersonajeCreado { get => personajeCreado; set => personajeCreado = value; }

            public Personaje datosAleatorios() { // no estoy seguro desde dónde llamar a esta funcion
                Random rand = new Random();
                Personaje nuevoPersonaje = new Personaje();
                nuevoPersonaje.Salud = 100;
                nuevoPersonaje.edad = rand.Next(0, 300);
                nuevoPersonaje.Velocidad = rand.Next(1, 11);
                nuevoPersonaje.Destreza = rand.Next(1, 6);
                nuevoPersonaje.Fuerza = rand.Next(1, 11);
                nuevoPersonaje.Nivel = rand.Next(1, 11);
                nuevoPersonaje.Armadura = rand.Next(1, 11);
                switch (rand.Next(1,6)) {
                    case 1:
                        nuevoPersonaje.tipo = tipoPersonaje.Elfo;
                        break;
                    case 2:
                        nuevoPersonaje.tipo = tipoPersonaje.Hobbit;
                        break;
                    case 3:
                        nuevoPersonaje.tipo = tipoPersonaje.Humano;
                        break;
                    case 4:
                        nuevoPersonaje.tipo = tipoPersonaje.Orco;
                        break;
                }
                nuevoPersonaje.personajeCreado = 1;
                return nuevoPersonaje;
            }
        }
    }
}
