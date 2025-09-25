using System;

namespace PruebaGIT
{
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
                Console.WriteLine("5-Modificar un jugador.");
                Console.WriteLine("6-Salir.");
                Console.Write("Opcion(1-6): ");
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
                            Console.WriteLine("-MOSTRAR PLANTILLA-");
                            Console.Write("Introduce el nombre del equipo: ");
                            string nombreEquipo = Console.ReadLine();
                            liga.MostrarJugadoresDeEquipo(nombreEquipo);
                            break;
                        case 3:
                            Console.WriteLine("-INSCRIPCION DE UN EQUIPO-");
                            liga.CrearEquipo();
                            break;
                        case 4:
                            Console.WriteLine("-NUEVO FICHAJE-");
                            liga.CrearJugador();
                            break;
                        case 5:
                            Console.WriteLine("-MODIFICACION DE UN JUGADOR-");
                            liga.ModificarJugador();
                            break;
                        case 6:
                            Console.WriteLine("Has decidido salir, adiós!");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("No has seleccionado un número entre 1-6");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor introduce un número válido.");
                }
                Console.WriteLine();
            } while (opcionMenu != 6);
        }
    }
}