using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    class Restaurante:Edificio
    {
        // Declaración de atributos de la Clase
        private string _strTipoAlimento;

        // Propiedades de la Clase
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

        // Método constructor de la Clase
        public Restaurante(string unNombre, address unaDireccion, int unTipoAlimento)
        {
            strNombre = unNombre;
            imgImage = Properties.Resources.imgRestaurant;
            adDireccion = unaDireccion;
            strLabel = "Restaurante";
            #region Definir tipo de alimento
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
            #endregion
        }

        public override string ToString()
        {
            string informacion = string.Format("{0} {1}\nDirección: {2}ª Calle y {3}ª Avenida\nTipo de Venta: {4}", strLabel, strNombre, adDireccion.intCalle, adDireccion.intAvenida, strTipoAlimento);
            return informacion;
        }
    }
}
