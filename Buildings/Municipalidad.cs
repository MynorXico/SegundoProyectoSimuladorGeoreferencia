﻿using System;
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

        // Propiedades de los objetos

        
        // Método constructor de la clase
        public Municipalidad(address unaDireccion)
        {
            strNombre = "Municipalidad";
            strLabel = "Municipalidad";
            adDireccion = unaDireccion;
            imgImage = Properties.Resources.imgCityHall;
        }
    }
}
