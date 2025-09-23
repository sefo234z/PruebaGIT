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

        public Baraja()
        {
            
        }

        public override string ToString()
        {
            string resultado = "=== BARAJA ===\n";

            foreach (var carta in Cartas)
            {
                resultado += carta + "\n";
            }

            resultado += "Total cartas: " + Cartas.Count;
            return resultado;
        }
    }
}