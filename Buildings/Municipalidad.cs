using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    class Municipalidad:Edificio
    {
        // Método constructor de la clase
        public Municipalidad(address unaDireccion)
        {
            strNombre = "Municipalidad";
            strLabel = "Municipalidad";
            adDireccion = unaDireccion;
        }
    }
}
