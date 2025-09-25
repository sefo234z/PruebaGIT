using System;

namespace PruebaGIT
{
    public enum ePosicion
    {
        POR,
        DEF,
        CEN,
        DEL
    }

    public class Jugador
    {
        public ePosicion Posicion { get; set; }
        public string Nombre { get; set; }
        public int Dorsal { get; set; }
        public string NombreEquipo { get; set; }

        public Jugador(ePosicion posicion, string nombre, int dorsal, string equipo)
        {
            Posicion = posicion;
            Nombre = nombre;
            Dorsal = dorsal;
            NombreEquipo = equipo;
        }

        public Jugador()
        {
        }

       

        public static Jugador FormularioNuevoJugador()
        {
            string nombre;
            int dorsal;
            ePosicion posicion;
            string equipo;

            do
            {
                Console.Write("Dime el nombre completo del jugador: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("Error: El nombre no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(nombre));

            bool dorsalValido = false;
            do
            {
                Console.Write("Dime el dorsal del jugador: ");
                string dorsalInput = Console.ReadLine();

                if (int.TryParse(dorsalInput, out dorsal) && dorsal > 0)
                {
                    dorsalValido = true;
                }
                else
                {
                    Console.WriteLine("Error: El dorsal debe ser un número entero positivo.");
                }
            } while (!dorsalValido);

            bool posicionValida = false;
            do
            {
                Console.Write("Dime la posición del jugador (POR, DEF, CEN, DEL): ");
                string posicionInput = Console.ReadLine().ToUpper();

                if (Enum.TryParse<ePosicion>(posicionInput, out posicion) &&
                    Enum.IsDefined(typeof(ePosicion), posicion))
                {
                    posicionValida = true;
                }
                else
                {
                    Console.WriteLine("Error: Posición no válida. Usa POR, DEF, CEN o DEL.");
                }
            } while (!posicionValida);

            do
            {
                Console.Write("Dime equipo: ");
                equipo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(equipo))
                {
                    Console.WriteLine("Error: El equipo no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(equipo));

            return new Jugador(posicion, nombre, dorsal, equipo);
        }

        public override string ToString()
        {
            return $"{Nombre} con dorsal {Dorsal} juega en la posicion {Posicion} y en el equipo {NombreEquipo}.";
        }
    }
}