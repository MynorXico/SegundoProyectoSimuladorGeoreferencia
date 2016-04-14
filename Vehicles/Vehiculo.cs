using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades
{
    class Vehiculo
    {
        #region Atritubos
        // Atributos de la clase
        private string _strPlaca;
        private int _intCalle;
        private int _intAvenida;
        private int _intCalleAvenida;
        private string _strMarca;
        #endregion
        #region Propiedades
        // Propiedades de la clase
        public string strPlaca
        {
            get
            {
                return _strPlaca;
            }
            set
            {
                _strPlaca = value;
            }
        }
        public int intCalle
        {
            get
            {
                return _intCalle;
            }
            set
            {
                _intCalle = value;
            }
        }
        public int intAvenida
        {
            get
            {
                return _intAvenida;
            }
            set
            {
                _intAvenida = value;
            }
        }
        public int intCalleAvenida
        {
            get
            {
                return _intCalleAvenida;
            }
            set
            {
                _intCalleAvenida = value;
            }
        }
        public string strMarca
        {
            get
            {
                return _strMarca;
            }
            set
            {
                _strMarca = value;
            }
        }
        #endregion

        //Constructor
        public Vehiculo(string unaPlaca, int unaCalle, int unaAvenida, int unaCalleAvenida, string unaMarca)
        {
            strPlaca = unaPlaca;
            intCalle = unaCalle;
            intAvenida = unaAvenida;
            intCalleAvenida = unaCalleAvenida;
            strMarca = unaMarca;
        }

    }
}
