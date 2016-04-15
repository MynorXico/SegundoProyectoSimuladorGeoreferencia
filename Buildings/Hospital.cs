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
        string _strTipo;
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
        public string strTipo
        {
            get
            {
                return _strTipo;
            }
            set
            {
                _strTipo = value;
            }
        }
        #endregion

        public Hospital(string unNombre, address unaDireccion, bool esPublico)
        {
            imgImage = Properties.Resources.imgHospital;
            strNombre = unNombre;
            _bolEsPublico = esPublico;
            adDireccion = unaDireccion;

            if (esPublico)
            {
                strTipo = "Público";
            }
            else
            {
                strTipo = "False";
            }
        }
    }
}
