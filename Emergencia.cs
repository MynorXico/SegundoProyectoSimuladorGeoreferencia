﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades
{
    class Emergencia
    {
        // Declaración de atributos
        private string _strNombre;
        private int _intCalle;
        private int _intAvenida;
        private int _intCalleAvenida;
        private string _strCalleAvenida;
        
        // Propiedades de la Clase
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
        public int intCalleAvenida
        {
            get
            {
                return _intCalleAvenida;
            }
            set
            {
                _intCalleAvenida = value;
            }
        }
        public string strCalleAvenida
        {
            get
            {
                return _strCalleAvenida;
            }
            set
            {
                _strCalleAvenida = value;
            }
        }
    }
}
