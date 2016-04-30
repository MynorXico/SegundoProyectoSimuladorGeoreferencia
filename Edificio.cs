using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades
{
    // Struct para definir direcciones
    public struct address
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

    public class Edificio
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

        // Cambia la función toString para mostrar la información del edificio
        public override string ToString()
        {
            string informacion = string.Format("{0} {1}\nDirección: {2}a. Calle {3}a. Avenida", strLabel, strNombre, adDireccion.intCalle, adDireccion.intAvenida);
            return informacion;
        }
    }
}
