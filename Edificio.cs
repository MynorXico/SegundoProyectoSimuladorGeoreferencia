using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades
{
    // Struct para definir la dirección
    struct address
    {
        // Variables de Address
        private int _intCalle;
        private int _intAvenida;

        // Propiedades del struct
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
    }

    class Edificio
    {
        // Atributos de la clase
        private address _adDireccion;
        private string _strNombre;
        private string _strLabel;
        private Image _imgImage;

        // Propiedades de la Clase
        public address adDireccion
        {
            get
            {
                return _adDireccion;
            }
            set
            {
                _adDireccion = value;
            }
        }
        public string strNombre
        {
            get
            {
                return _strNombre;
            }
            set
            {
                _strNombre = value;
            }
        }
        public string strLabel
        {
            get
            {
                return _strLabel;
            }
            set
            {
                _strLabel = value;
            }
        }
        public Image imgImage
        {
            get
            {
                return _imgImage;
            }
            set
            {
                _imgImage = value;
            }
        }

    }
}
