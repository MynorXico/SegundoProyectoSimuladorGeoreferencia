using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades
{

    class Gasolinera : Edificio
    {
        // Declaración de atributos de la Clase
        private double _dblPrecio;

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

        // Método Constructor de la Clase
        public Gasolinera(string unNombre, double unPrecio, address unaDireccion){
            strNombre = unNombre;
            dblPrecio = unPrecio;
            adDireccion = unaDireccion;
            strLabel = "Gasolinera";
        }
        

        
    }
}
