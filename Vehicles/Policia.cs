using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades.Vehicles
{
    class Policia:Emergencia
    {
        public Policia(string unNombre, string unaDireccion)
        {
            strNombre = unNombre;
            strDireccion = unaDireccion;
        }
    }
}
