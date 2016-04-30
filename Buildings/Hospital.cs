using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    // Clase hospital -> Subclase de clase Edificio
    class Hospital:Edificio                 
    {        
        // Declaración de atibutos
        #region Atributos
        private bool _bolEsPublico;
        string _strTipo;
        #endregion
        // Propiedades de la Clase
        #region Propiedades
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

        /// <summary>
        /// Método constructor de la clase hospital
        /// </summary>
        /// <param name="unNombre">Nombre del objeto hospital</param>
        /// <param name="unaDireccion">Dirección en calles y avenidas del hospitl</param>
        /// <param name="esPublico">Indica si el hospital es privado o es público</param>
        public Hospital(string unNombre, address unaDireccion, bool esPublico)
        {
            imgImage = Properties.Resources.imgHospital;
            strNombre = unNombre;
            _bolEsPublico = esPublico;
            adDireccion = unaDireccion;
            strLabel = "Hospital";
            // Determina si el objeto es público con base en la propiedad esPublico
            if (esPublico)
            {
                strTipo = "Público";
            }
            else
            {
                strTipo = "Privado";
            }
        }
        /// <summary>
        /// Modifica el método ToString() de la clase hospital
        /// </summary>
        /// <returns>Devuelve la información de un objeto hospital de manera ordenada</returns>
        public override string ToString()
        {
            string informacion = string.Format("{0} {1}\nDirección: {2}ª Calle y {3}ª Avenida\nTipo de Hospital: {4}", strLabel, strNombre, adDireccion.intCalle, adDireccion.intAvenida, strTipo);
            return informacion;
        }
    }
}
