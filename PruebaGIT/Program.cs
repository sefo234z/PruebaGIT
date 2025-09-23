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
        static void Main(string[] args)
        {
            DatosDePrueba();
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
                            break;
                        case 2:
                            Console.Write("¿De qué equipo quieres ver los jugadores?: ");
                            break;
                        case 3:
                            Console.WriteLine("-FORMULARIO DE INSCRIPCION DE UN EQUIPO-");
                            break;
                        case 4:
                            Console.Write("¿Qué equipo quiere fichar un jugador?: ");
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





        public static void DatosDePrueba()
        {
            // Crear algunos jugadores
            Jugador ab = new Jugador(ePosicion.POR, "Unai Simon", 1);
            Jugador ab1 = new Jugador(ePosicion.DEF, "Adama Boiro", 19);
            Jugador ab2 = new Jugador(ePosicion.CEN, "Unai Gomez", 20);
            Jugador ab3 = new Jugador(ePosicion.DEL, "Iñaki Williams", 9);
            Jugador fcb = new Jugador(ePosicion.DEL, "Lamine Yamal", 10);
            Jugador fcb1 = new Jugador(ePosicion.CEN, "Pedri", 8);
            Jugador fcb2 = new Jugador(ePosicion.DEF, "Ronald Araujo", 4);
            Jugador fcb3 = new Jugador(ePosicion.DEF, "Eric Garcia", 24);
            Jugador rm = new Jugador(ePosicion.DEL, "Kylian Mbappe", 10);
            Jugador rm1 = new Jugador(ePosicion.DEL, "Vinicius junior", 7);
            Jugador rm2 = new Jugador(ePosicion.CEN, "Federico Valverde", 8);
            Jugador rm3 = new Jugador(ePosicion.DEF, "Dani Carvajal", 2);
            Jugador am = new Jugador(ePosicion.POR, "Jan Oblak", 13);
            Jugador am1 = new Jugador(ePosicion.DEF, "Laurent Lenglet", 15);
            Jugador am2 = new Jugador(ePosicion.CEN, "Marcos Llorente", 14);
            Jugador am3 = new Jugador(ePosicion.DEL, "Antoine Griezmann", 7);
            // Crear un equipo
            Equipo AtleticoBilbao = new Equipo("Atletico de Bilbao");
            Equipo Barcelona = new Equipo("Barcelona");
            Equipo RealMadrid = new Equipo("Real Madrid");
            Equipo AtleticoMadrid  = new Equipo("Atletico de Madrid");


            // Agregar jugadores
            AtleticoBilbao.AgregarJugador(ab);
            AtleticoBilbao.AgregarJugador(ab1);
            AtleticoBilbao.AgregarJugador(ab2);
            AtleticoBilbao.AgregarJugador(ab3);
            //ff
            AtleticoMadrid.AgregarJugador(am);
            AtleticoMadrid.AgregarJugador(am1);
            AtleticoMadrid.AgregarJugador(am2);
            AtleticoMadrid.AgregarJugador(am3);
            //ff
            Barcelona.AgregarJugador(fcb);
            Barcelona.AgregarJugador(fcb1);
            Barcelona.AgregarJugador(fcb2);
            Barcelona.AgregarJugador(fcb3);
            //ff
            RealMadrid.AgregarJugador(rm);
            RealMadrid.AgregarJugador(rm1);
            RealMadrid.AgregarJugador(rm2);
            RealMadrid.AgregarJugador(rm3);
            // Mostrar información
            //Console.WriteLine(AtleticoBilbao.ToString());
            //Console.ReadLine();

        }

    }
}