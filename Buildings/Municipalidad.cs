using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    /// <summary>
    /// Clase Municipalidad -> Subclase de la clase Edificio
    /// </summary>
    class Municipalidad:Edificio
    {
        /// <summary>
        /// Método constructor de la clase Municipalidad
        /// </summary>
        /// <param name="unaDireccion"></param>
        public Municipalidad(address unaDireccion)
        {
            strNombre = "Municipalidad";
            strLabel = "Municipalidad";
            adDireccion = unaDireccion;
            imgImage = Properties.Resources.imgCityHall;
        }
        /// <summary>
        /// Modifica el método ToString() de la clase Municipalidad
        /// </summary>
        /// <returns>Cadena con información sobre la clase de manera ordenada</returns>
        public override string ToString()
        {
            string informacion = string.Format("{0}\nDirección: {1}ª Calle y {2}ª Avenida", strLabel, adDireccion.intCalle, adDireccion.intAvenida);
            return informacion;
        }
    }
}
