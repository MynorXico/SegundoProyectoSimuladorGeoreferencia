using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades.Buildings
{
    class Hospital:Edificio
    {
        // Declaración de atibutos
        private bool _bolEsPublico;

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

        public Hospital(string unNombre, bool esPublico, address unaDireccion)
        {
            strNombre = unNombre;
            _bolEsPublico = esPublico;
            adDireccion = unaDireccion;
        }
    }
}
