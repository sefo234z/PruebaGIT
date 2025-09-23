using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGIT
{

    public class Equipo
    {
        private List<Jugador> jugadores;
        private string nombre;

        public List<Jugador> Jugadores
        {
            get { return jugadores; }
        }

        // Constructor que inicializa la lista y el nombre
        public Equipo(string nombre)
        {
            this.nombre = nombre;
            this.jugadores = new List<Jugador>();
        }

        // Método para añadir un jugador
        public void AgregarJugador(Jugador jugador)
        {
            if (jugador == null) throw new ArgumentNullException(nameof(jugador));
            jugadores.Add(jugador);
        }

        public override string ToString()
        {
            string resultado = $"El equipo {nombre} tiene {jugadores.Count} jugadores:\n";

            foreach (var jugador in jugadores)
            {
                resultado += jugador + "\n";
            }
            return resultado;
        }
    }
}