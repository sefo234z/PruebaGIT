using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGIT
{
        public enum ePosicion
        {
            POR,
            DEF,
            CEN,
            DEL
        }
        public class Jugador
        {
            private String nombre;
            private ePosicion posicion;
            private int dorsal;
            private string nombreEquipo;

        public ePosicion Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string NombreEquipo
        {
            get { return nombreEquipo; }
            set { nombreEquipo = value; }
        }

        public int Dorsal
        {
            get { return dorsal; }
            set { dorsal = value; }
        }
        public Jugador()
        {

        }

        public Jugador(ePosicion posicion,string nombre ,int dorsal, string equipo)
        {
             this.posicion = posicion;
             this.nombre = nombre;
             this.dorsal = dorsal;
             this.nombreEquipo = equipo;
             
        }
        public override string ToString()
        {
             return $"{nombre} con dorsal {dorsal} juega en la posicion {posicion} y en el equipo {nombreEquipo}. ";
        }
        }
    }