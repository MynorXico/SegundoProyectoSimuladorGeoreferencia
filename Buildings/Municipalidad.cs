using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    class Municipalidad:Edificio
    {
        // Atributos de la clase
        private Image _imgImage;

        // Propiedades de los objetos
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

        
        // Método constructor de la clase
        public Municipalidad(address unaDireccion)
        {
            strNombre = "Municipalidad";
            strLabel = "Municipalidad";
            adDireccion = unaDireccion;
            _imgImage = Properties.Resources.imgCityHall;
        }
    }
}
