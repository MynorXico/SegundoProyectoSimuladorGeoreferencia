using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades
{

    class Gasolinera : Edificio
    {
        #region Atributos
        // Declaración de atributos de la Clase
        private double _dblPrecio;
        private Image _imgImage;
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
        #endregion

        // Método Constructor de la Clase
        public Gasolinera(string unNombre, double unPrecio, address unaDireccion){
            strNombre = unNombre;
            dblPrecio = unPrecio;
            adDireccion = unaDireccion;
            strLabel = "Gasolinera";
            _imgImage = Properties.Resources.imgGas;
        }
        

        
    }
}
