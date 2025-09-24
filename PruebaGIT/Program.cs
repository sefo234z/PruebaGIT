using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGIT
{
    //Listar equipos
    //Crear Equipos
    //Listas jugadores x equipos
    internal class Program
    {
        static Liga liga = new Liga();
        
        static void Main(string[] args)
        {
            liga.DatosDePrueba();
            MenuOpciones();
        }


          public static void MenuOpciones()
        {
            int opcionMenu = 0;

            do
            {
                Console.WriteLine("---------------GESTION DE LA LIGA 25/26----------------");
                Console.WriteLine("1-Mostrar equipos de la Liga.");
                Console.WriteLine("2-Mostrar jugadores de un equipo.");
                Console.WriteLine("3-Inscribir un nuevo equipo.");
                Console.WriteLine("4-Fichar un jugador.");
                Console.WriteLine("5-Salir.");

                Console.Write("Opcion(1-5): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out opcionMenu))
                {
                    switch (opcionMenu)
                    {
                        case 1:
                            Console.WriteLine("-LISTADOS DE TODOS LOS EQUIPOS DE LA LIGA-");
                            liga.MostrarNombresEquipos();
                            break;
                        case 2:
                            Console.Write("¿De qué equipo quieres ver los jugadores?: ");
                            liga.MostrarJugadoresDeEquipo();
                            break;
                        case 3:
                            Console.WriteLine("---INSCRIPCION DE UN EQUIPO---");
                            liga.CrearEquipo();
                            break;
                        case 4:
                            Console.Write("¿Qué equipo quiere fichar un jugador?: ");
                            liga.CrearJugador();
                            break;
                        case 5:
                            Console.WriteLine("Has decidido salir, adiós!");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("No has seleccionado un número entre 1-5");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor introduce un número válido.");
                }

                Console.WriteLine(); // Línea en blanco para separar iteraciones del menú
            } while (opcionMenu != 5); // Repetir hasta que el usuario seleccione 5
        }

    }
}