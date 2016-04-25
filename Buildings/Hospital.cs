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
            strLabel = "Hospital";

            if (esPublico)
            {
                strTipo = "Público";
            }
            else
            {
                strTipo = "Privado";
            }
        }

        public override string ToString()
        {
            string informacion = string.Format("{0} {1}\nDirección: {2}ª Calle y {3}ª Avenida\nTipo de Hospital: {4}", strLabel, strNombre, adDireccion.intCalle, adDireccion.intAvenida, strTipo);
            return informacion;
        }
    }
}
