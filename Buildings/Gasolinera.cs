using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades.Buildings
{

    class Gasolinera : Edificio
    {
        #region Atributos
        // Declaración de atributos de la Clase
        private double _dblPrecio;
        #endregion
        #region Propiedades
        // Propiedades de la Clase
        public double dblPrecio
        {
            get
            {
                return _dblPrecio;
            }
            set
            {
                _dblPrecio = value;
            }
        }
        #endregion

        /// <summary>
        /// Método constructor de la clase Gasolinera
        /// </summary>
        /// <param name="unNombre">Nombre de la gasolinera</param>
        /// <param name="unaDireccion">Dirección de la gasolinera</param>
        /// <param name="unPrecio">Precio de la gasolina</param>
        public Gasolinera(string unNombre, address unaDireccion, double unPrecio){
            strNombre = unNombre;
            dblPrecio = unPrecio;
            adDireccion = unaDireccion;
            strLabel = "Gasolinera";
            imgImage = Properties.Resources.imgGas;
        }

        /// <summary>
        /// Método que modifica el método toString()
        /// </summary>
        /// <returns>Cadena con datos de la clase de una manera ordenada</returns>
        public override string ToString()
        {
            string informacion = string.Format("{0} {1}\nDirección: {2}ª Calle y {3}ª Avenida\nPrecio de la Gasolina: Q{4:0.00}", strLabel, strNombre, adDireccion.intCalle, adDireccion.intAvenida, dblPrecio);
            return informacion;
        }



    }
}
