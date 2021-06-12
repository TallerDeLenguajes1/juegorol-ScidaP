using System;

namespace Control_Progreso {
    public enum tipoPersonaje {
        Elfo,
        Orco,
        Hobbit,
        Humano
    }

    public enum nombresPersonajes {
        Pedro,
        Roberto,
        Juana,
        LGante,
        Patrik,
        Sofia,
        Matias,
        Victoria,
        RafaNadal,
        Chespirito
    }

    public class Personaje {
        private string tipo;
        private string nombre;
        private DateTime fechaNac;
        private int edad;
        private int salud;

        private int velocidad, destreza, fuerza, nivel, armadura;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }

        public static Personaje crearPersonajeConDatosAleatorios() {
            Random rand = new Random();
            Personaje nuevoPersonaje = new Personaje();
            nuevoPersonaje.Salud = 100;
            nuevoPersonaje.Edad = rand.Next(0, 300);
            nuevoPersonaje.Velocidad = rand.Next(1, 11);
            nuevoPersonaje.Destreza = rand.Next(1, 6);
            nuevoPersonaje.Fuerza = rand.Next(1, 11);
            nuevoPersonaje.Nivel = rand.Next(1, 11);
            nuevoPersonaje.Armadura = rand.Next(1, 11);
            nuevoPersonaje.Tipo = Enum.GetName(typeof(tipoPersonaje), rand.Next(1, Enum.GetNames(typeof(tipoPersonaje)).Length));
            nuevoPersonaje.Nombre = Enum.GetName(typeof(nombresPersonajes), rand.Next(1, Enum.GetNames(typeof(nombresPersonajes)).Length));
            return nuevoPersonaje;
        }

        public static string mostrarPersonaje(Personaje personaje) {
            string datosPersonaje = "*Nombre*: " + personaje.nombre + " *Tipo*: " + personaje.tipo + " *Edad*: " + personaje.edad;
            return datosPersonaje;
        }
    }
}
