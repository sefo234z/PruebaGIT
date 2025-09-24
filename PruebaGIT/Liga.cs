using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGIT
{
    internal class Liga
    {
        List<Equipo> liga = new List<Equipo>();
    
    public Liga()
    {
    }

        public void CrearEquipo()
        {
            string nombre = FormularioNuevoEquipo();
            Equipo equipoEncontrado = liga
                .FirstOrDefault(e => e.NombreClub.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (equipoEncontrado != null)
            {
                Console.WriteLine("No se ha podido inscribir, el equipo '"+ nombre+"' ya juega en esta liga");
            }
            else
            {
                Equipo e = new Equipo(nombre);
                liga .Add(e);
                Console.WriteLine("El equipo '" + e.NombreClub + "' ha sido inscrito correctamente");
            }
        }
        public String FormularioNuevoEquipo()
        {
            string nombre = " ";
            do
            {
               Console.Write("Dime el nombre del equipo: ");
               nombre = Console.ReadLine();
                if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("Nombre no valido, vuelva a introducirlo");
                }
            } while (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre));

            return nombre;

        }
        public void MostrarNombresEquipos()
        {
            foreach (var equipo in liga)
            {
                Console.Write(equipo);
            }
        }

        public void MostrarJugadoresDeEquipo()
        {
            Console.Write("Introduce el nombre del equipo: ");
            string nombreEquipo = Console.ReadLine();

            // Buscar el equipo
            Equipo equipoEncontrado = liga.FirstOrDefault(e =>
                e.NombreClub.Equals(nombreEquipo, StringComparison.OrdinalIgnoreCase));

            if (equipoEncontrado == null)
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' no existe.");

            }
            else
            {
                // Mostrar jugadores del equipo
                Console.WriteLine($"\n--- Jugadores del equipo {equipoEncontrado.NombreClub} ---");

                if (equipoEncontrado.Jugadores == null || equipoEncontrado.Jugadores.Count == 0)
                {
                    Console.WriteLine("No hay jugadores en este equipo.");
                }
                else
                {
                    foreach (var jugador in equipoEncontrado.Jugadores)
                    {
                        Console.WriteLine(jugador.ToString());
                    }
                    Console.WriteLine($"Total de jugadores: {equipoEncontrado.Jugadores.Count}");
                }
            }

                
        }
        public void CrearJugador()
        {
            Jugador jugador = FormularioNuevoJugador();

            // Verificar si el equipo existe
            Equipo equipoEncontrado = liga.FirstOrDefault(e =>
                e.NombreClub.Equals(jugador.NombreEquipo, StringComparison.OrdinalIgnoreCase));

            if (equipoEncontrado == null)
            {
                Console.WriteLine($"Error: El equipo '{jugador.NombreEquipo}' no existe en la liga.");
                Console.WriteLine("Equipos disponibles: " +
                    string.Join(", ", liga.Select(e => e.NombreClub)));
                return;
            }

            // Verificar que no hay otro jugador con el mismo nombre en el equipo
            bool jugadorExiste = equipoEncontrado.Jugadores.Any(j =>
                j.Nombre.Equals(jugador.Nombre, StringComparison.OrdinalIgnoreCase));

            if (jugadorExiste)
            {
                Console.WriteLine($"Error: Ya existe un jugador con el nombre '{jugador.Nombre}' en el equipo '{jugador.NombreEquipo}'.");
                return;
            }

            // Añadir el jugador a la lista del equipo
            equipoEncontrado.Jugadores.Add(jugador);
            Console.WriteLine($"Jugador '{jugador.Nombre}' añadido correctamente al equipo '{jugador.NombreEquipo}'.");
        }
        public Jugador FormularioNuevoJugador()
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

        public void DatosDePrueba()
        {
             Jugador ab = new Jugador(ePosicion.POR, "Unai Simon", 1, "Atletico de Bilbao");
             Jugador ab1 = new Jugador(ePosicion.DEF, "Adama Boiro", 19, "Atletico de Bilbao");
             Jugador ab2 = new Jugador(ePosicion.CEN, "Unai Gomez", 20, "Atletico de Bilbao");
             Jugador ab3 = new Jugador(ePosicion.DEL, "Iñaki Williams", 9, "Atletico de Bilbao");
             Jugador fcb = new Jugador(ePosicion.DEL, "Lamine Yamal", 10, "Barcelona");
             Jugador fcb1 = new Jugador(ePosicion.CEN, "Pedri", 8, "Barcelona");
             Jugador fcb2 = new Jugador(ePosicion.DEF, "Ronald Araujo", 4, "Barcelona");
             Jugador fcb3 = new Jugador(ePosicion.DEF, "Eric Garcia", 24, "Barcelona");
             Jugador rm = new Jugador(ePosicion.DEL, "Kylian Mbappe", 10, "Real Madrid");
             Jugador rm1 = new Jugador(ePosicion.DEL, "Vinicius junior", 7, "Real Madrid");
             Jugador rm2 = new Jugador(ePosicion.CEN, "Federico Valverde", 8, "Real Madrid");
             Jugador rm3 = new Jugador(ePosicion.DEF, "Dani Carvajal", 2, "Real Madrid");
             Jugador am = new Jugador(ePosicion.POR, "Jan Oblak", 13, "Atletico de Madrid");
             Jugador am1 = new Jugador(ePosicion.DEF, "Laurent Lenglet", 15, "Atletico de Madrid");
             Jugador am2 = new Jugador(ePosicion.CEN, "Marcos Llorente", 14, "Atletico de Madrid");
             Jugador am3 = new Jugador(ePosicion.DEL, "Antoine Griezmann", 7, "Atletico de Madrid");
            // Crear un equipo
             Equipo AtleticoBilbao = new Equipo("Atletico de Bilbao");
             Equipo Barcelona = new Equipo("Barcelona");
             Equipo RealMadrid = new Equipo("Real Madrid");
             Equipo AtleticoMadrid  = new Equipo("Atletico de Madrid");
             liga.Add(Barcelona);
             liga.Add(RealMadrid);
             liga.Add(AtleticoMadrid);
             liga.Add(AtleticoBilbao);   
          


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

