using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades.Vehicles
{
    class Ambulancia:Emergencia
    {
        public Ambulancia(string unNombre, int unaCalle, int unaAvenida, int unaCalleAvenida)
        {
            strNombre = unNombre;
            intCalle = unaCalle;
            intAvenida = unaAvenida;
            intCalleAvenida = unaCalleAvenida;
            if (intCalleAvenida == 1)
            {
                strCalleAvenida = "Avenida";
            }
            else
            {
                strCalleAvenida = "Calle";
            }
        }
    }
}
