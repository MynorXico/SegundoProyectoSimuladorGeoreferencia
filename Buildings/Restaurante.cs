using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Restaurante(string unNombre, int unTipoAlimento, address unaDireccion)
        {
            strNombre = unNombre;
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
    }
}
