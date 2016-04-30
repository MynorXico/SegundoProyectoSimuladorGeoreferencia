using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    /// <summary>
    /// Clase Restaurante -> Subclase de la clase Edificio
    /// </summary>
    class Restaurante:Edificio
    {
        // Declaración de atributos de la Clase
        #region Atributos
        private string _strTipoAlimento;
        #endregion
        // Propiedades de la Clase
        #region Propiedades
        public string strTipoAlimento
        {
            get
            {
                return _strTipoAlimento;
            }
            set
            {
                _strTipoAlimento = value;
            }
        }
        #endregion
        /// <summary>
        /// Método 
        /// </summary>
        /// <param name="unNombre">Nombre del objeto Edificio</param>
        /// <param name="unaDireccion">Dirección en calles y avenidas del objeto Edificio</param>
        /// <param name="unTipoAlimento">Define el tipo de alimento que sirve determinado restaurante</param>
        public Restaurante(string unNombre, address unaDireccion, int unTipoAlimento)
        {
            strNombre = unNombre;
            imgImage = Properties.Resources.imgRestaurant;
            adDireccion = unaDireccion;
            strLabel = "Restaurante";
            // Define el tipo de comida que se sirve en el restaurante en base a su propiedad unTipoAlimento
            switch (unTipoAlimento)
            {
                case 1:
                    strTipoAlimento = "Comida Rápida";
                    break;
                case 2:
                    strTipoAlimento = "Pizzería";
                    break;
                case 3:
                    strTipoAlimento = "Comida gourmet";
                    break;
            }
        }
        /// <summary>
        /// Método que modifica el método ToString() de la clase Restaurante
        /// </summary>
        /// <returns>Cadena de texto con información organizada de un objeto Restaurante</returns>
        public override string ToString()
        {
            string informacion = string.Format("{0} {1}\nDirección: {2}ª Calle y {3}ª Avenida\nTipo de Venta: {4}", strLabel, strNombre, adDireccion.intCalle, adDireccion.intAvenida, strTipoAlimento);
            return informacion;
        }
    }
}
