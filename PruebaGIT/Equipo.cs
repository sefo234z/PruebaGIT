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
        private string nombreClub;

        public string NombreClub
        {
            get { return nombreClub; }
            set { nombreClub = value; }
        }

        public List<Jugador> Jugadores
        {
            get { return jugadores; }
        }

        public Equipo(string nombreClub)
        {
            this.nombreClub = nombreClub;
            this.jugadores = new List<Jugador>();
        }
        public void AgregarJugador(Jugador jugador)
        {
            if (jugador == null) throw new ArgumentNullException(nameof(jugador));
            jugadores.Add(jugador);
        }

        public override string ToString()
        {
            return $"El equipo {nombreClub.ToUpper()} tiene {jugadores.Count} jugadores en plantilla\n";
        }
    }
}