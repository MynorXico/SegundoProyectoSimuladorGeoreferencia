using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    class Hospital:Edificio
    {
        #region Atributos
        // Declaración de atibutos
        private bool _bolEsPublico;
        private Image _imgImage;
        #endregion
        #region Propiedades
        // Propiedades de la Clase
        public bool boolEsPublico
        {
            get
            {
                return _bolEsPublico;
            }
            set
            {
                _bolEsPublico = value;
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
                value = _imgImage;
            }
        }
        #endregion

        public Hospital(string unNombre, bool esPublico, address unaDireccion)
        {
            strNombre = unNombre;
            _bolEsPublico = esPublico;
            adDireccion = unaDireccion;
            _imgImage = Properties.Resources.imgHospital;
        }
    }
}
