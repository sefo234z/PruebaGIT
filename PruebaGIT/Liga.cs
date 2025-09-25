using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PruebaGIT
{
    internal class Liga
    {
        List<Equipo> liga = new List<Equipo>();

        public Liga()
        {
        }

        // 1-Listar los equipos de la Liga.
        public void MostrarNombresEquipos()
        {
            foreach (var equipo in liga)
            {
                Console.Write(equipo);
            }
        }

        // 2-Listar los jugadores de un equipo.
        public void MostrarJugadoresDeEquipo(string nombreEquipo)
        {
            Equipo equipoEncontrado = liga.FirstOrDefault(e =>
                e.NombreClub.Equals(nombreEquipo, StringComparison.OrdinalIgnoreCase));

            if (equipoEncontrado == null)
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' no existe.");
            }
            else
            {
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
                }
            }
        }

        // 3-Crear un nuevo equipo.
        public void CrearEquipo()
        {
            string nombre = Equipo.FormularioNuevoEquipo();
            Equipo equipoEncontrado = liga
                .FirstOrDefault(e => e.NombreClub.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (equipoEncontrado != null)
            {
                Console.WriteLine("No se ha podido inscribir, el equipo '" + nombre + "' ya juega en esta liga");
            }
            else
            {
                Equipo e = new Equipo(nombre);
                liga.Add(e);
                Console.WriteLine("El equipo '" + e.NombreClub + "' ha sido inscrito correctamente");
            }
        }

        // 4-Crear un nuevo jugador.
        public void CrearJugador()
        {
            Jugador jugador = Jugador.FormularioNuevoJugador();

            Equipo equipoEncontrado = liga.FirstOrDefault(e =>
                e.NombreClub.Equals(jugador.NombreEquipo, StringComparison.OrdinalIgnoreCase));

            if (equipoEncontrado == null)
            {
                Console.WriteLine($"Error: El equipo '{jugador.NombreEquipo}' no existe en la liga.");
                Console.WriteLine("Equipos disponibles: " +
                    string.Join(", ", liga.Select(e => e.NombreClub)));
                return;
            }

            bool jugadorExiste = equipoEncontrado.Jugadores.Any(j =>
                j.Nombre.Equals(jugador.Nombre, StringComparison.OrdinalIgnoreCase));

            if (jugadorExiste)
            {
                Console.WriteLine($"Error: Ya existe un jugador con el nombre '{jugador.Nombre}' en el equipo '{jugador.NombreEquipo}'.");
                return;
            }

            equipoEncontrado.Jugadores.Add(jugador);
            Console.WriteLine($"Jugador '{jugador.Nombre}' añadido correctamente al equipo '{jugador.NombreEquipo}'.");
        }

        // 5-Modificar un jugador
        public void ModificarJugador()
        {
            Console.Write("Introduce el nombre del equipo: ");
            string nombreEquipo = Console.ReadLine();

            Equipo equipoEncontrado = liga
                .FirstOrDefault(e => e.NombreClub.Equals(nombreEquipo, StringComparison.OrdinalIgnoreCase));

            if (equipoEncontrado == null)
            {
                Console.WriteLine("No se ha podido modificar, el equipo '" + nombreEquipo + "' no existe en esta liga");
                return;
            }

            MostrarJugadoresDeEquipo(nombreEquipo);
            Console.WriteLine("----------------------------");
            Console.Write("Introduce el nombre del jugador que quieres modificar: ");
            string nombreJugador = Console.ReadLine();

            Jugador jugadorAModificar = equipoEncontrado.Jugadores
                .FirstOrDefault(j => j.Nombre.Equals(nombreJugador, StringComparison.OrdinalIgnoreCase));

            if (jugadorAModificar != null)
            {
                Console.WriteLine($"Modificando jugador: {jugadorAModificar.Nombre}");

                string equipoOriginal = jugadorAModificar.NombreEquipo;
                Jugador nuevoJugador = Jugador.FormularioNuevoJugador();

                if (!nuevoJugador.NombreEquipo.Equals(equipoOriginal, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"El jugador cambió del equipo '{equipoOriginal}' al '{nuevoJugador.NombreEquipo}'");

                    Equipo nuevoEquipo = liga.FirstOrDefault(e =>
                        e.NombreClub.Equals(nuevoJugador.NombreEquipo, StringComparison.OrdinalIgnoreCase));

                    if (nuevoEquipo != null)
                    {
                        bool jugadorExisteEnNuevoEquipo = nuevoEquipo.Jugadores.Any(j =>
                            j.Nombre.Equals(nuevoJugador.Nombre, StringComparison.OrdinalIgnoreCase));

                        if (jugadorExisteEnNuevoEquipo)
                        {
                            Console.WriteLine($"Error: Ya existe un jugador con el nombre '{nuevoJugador.Nombre}.");
                            return;
                        }

                        equipoEncontrado.Jugadores.Remove(jugadorAModificar);
                        nuevoEquipo.Jugadores.Add(nuevoJugador);

                        Console.WriteLine($"Jugador movido exitosamente de '{equipoOriginal}' a '{nuevoJugador.NombreEquipo}'");
                    }
                    else
                    {
                        Console.WriteLine($"Error: El equipo '{nuevoJugador.NombreEquipo}' no existe en la liga.");
                        Console.WriteLine("El jugador se mantendrá en su equipo original con los nuevos datos.");

                        int indice = equipoEncontrado.Jugadores.IndexOf(jugadorAModificar);
                        if (indice != -1)
                        {
                            Jugador jugadorActualizado = new Jugador(
                                nuevoJugador.Posicion,
                                nuevoJugador.Nombre,
                                nuevoJugador.Dorsal,
                                equipoOriginal);

                            equipoEncontrado.Jugadores[indice] = jugadorActualizado;
                        }
                    }
                }
                else
                {
                    int indice = equipoEncontrado.Jugadores.IndexOf(jugadorAModificar);
                    if (indice != -1)
                    {
                        equipoEncontrado.Jugadores[indice] = nuevoJugador;
                        Console.WriteLine($"Jugador '{nombreJugador}' modificado exitosamente!");

                    }
                }
            }
            else
            {
                Console.WriteLine("Ese jugador no existe en el equipo " + nombreEquipo);
            }
        }
    }
}

