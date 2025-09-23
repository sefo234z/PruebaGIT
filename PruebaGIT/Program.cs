using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGIT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear algunos jugadores
            Jugador j1 = new Jugador(ePosicion.POR, "Iker Casillas", 1);
            Jugador j2 = new Jugador(ePosicion.DEF, "Carles Puyol", 5);
            Jugador j3 = new Jugador(ePosicion.CEN, "Xavi Hernández", 6);
            Jugador j4 = new Jugador(ePosicion.DEL, "David Villa", 7);

            // Crear un equipo
            Equipo espana = new Equipo("España");

            // Agregar jugadores
            espana.AgregarJugador(j1);
            espana.AgregarJugador(j2);
            espana.AgregarJugador(j3);
            espana.AgregarJugador(j4);

            // Mostrar información
            Console.WriteLine(espana.ToString());

            // Mantener la consola abierta si ejecutas desde Visual Studio diretamente
            Console.WriteLine("\nPulsa Enter para salir...");
            Console.ReadLine();
        }
    }
}