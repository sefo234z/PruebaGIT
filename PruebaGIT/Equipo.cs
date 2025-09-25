using System;
using System.Collections.Generic;

namespace PruebaGIT
{
    public class Equipo
    {
        

        public string NombreClub { get; set; }
        public List<Jugador> Jugadores { get; }

        public Equipo(string nombreClub)
        {
            this.NombreClub = nombreClub;
            Jugadores = new List<Jugador>();
        }

        public void AgregarJugador(Jugador jugador)
        {
            if (jugador == null) throw new ArgumentNullException(nameof(jugador));
            Jugadores.Add(jugador);
        }

        public static string FormularioNuevoEquipo()
        {
            string nombre = " ";
            do
            {
                Console.Write("Dime el nombre del equipo: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("Nombre no valido, vuelva a introducirlo");
                }
            } while (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre));

            return nombre;
        }

        public override string ToString()
        {
            return $"El equipo {NombreClub.ToUpper()} tiene {Jugadores.Count} jugadores en plantilla\n";
        }
    }
}