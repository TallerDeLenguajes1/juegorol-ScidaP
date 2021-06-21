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

    public enum tipoGuerrero {
        Arquero, // Los arqueros tienen precisión aumentada
        Culturista, // Los culturistas tienen fuerza aumentada
        Bolt, // Los bolts tienen velocidad aumentada
        Tanque // Los tanques tienen armadura aumentada
    }

    public class Personaje {
        private string tipo;
        private string tipoGuerrero;
        private string nombre;
        private int edad;
        private int salud;

        private int velocidad, precision, fuerza, nivel, armadura;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Precision { get => precision; set => precision = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public string TipoGuerrero { get => tipoGuerrero; set => tipoGuerrero = value; }

        public static Personaje crearPersonajeConDatosAleatorios() {
            Random rand = new Random();
            Personaje nuevoPersonaje = new Personaje();
            nuevoPersonaje.TipoGuerrero = Enum.GetName(typeof(tipoGuerrero), rand.Next(1, Enum.GetNames(typeof(tipoGuerrero)).Length));
            nuevoPersonaje.Salud = 100;
            nuevoPersonaje.Edad = rand.Next(0, 300);
            switch (nuevoPersonaje.TipoGuerrero) {
                case "Arquero":
                    nuevoPersonaje.Velocidad = rand.Next(1, 11);
                    nuevoPersonaje.Precision = rand.Next(4, 6);
                    nuevoPersonaje.Armadura = rand.Next(1, 11);
                    nuevoPersonaje.Fuerza = rand.Next(1, 11);
                    break;
                case "Tanque":
                    nuevoPersonaje.Velocidad = rand.Next(1, 11);
                    nuevoPersonaje.Precision = rand.Next(1, 6);
                    nuevoPersonaje.Armadura = rand.Next(9, 11);
                    nuevoPersonaje.Fuerza = rand.Next(1, 11);
                    break;
                case "Bolt":
                    nuevoPersonaje.Velocidad = rand.Next(9, 11);
                    nuevoPersonaje.Precision = rand.Next(1, 6);
                    nuevoPersonaje.Armadura = rand.Next(1, 11);
                    nuevoPersonaje.Fuerza = rand.Next(1, 11);
                    break;
                case "Culturista":
                    nuevoPersonaje.Velocidad = rand.Next(9, 11);
                    nuevoPersonaje.Precision = rand.Next(1, 6);
                    nuevoPersonaje.Armadura = rand.Next(1, 11);
                    nuevoPersonaje.Fuerza = rand.Next(9, 11);
                    break;
            }
            nuevoPersonaje.Nivel = rand.Next(1, 11);
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
