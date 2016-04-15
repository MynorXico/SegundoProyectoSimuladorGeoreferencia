using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades.Vehicles
{
    class Ambulancia:Emergencia
    {
        public Ambulancia(string unNombre, int unaCalle, int unaAvenida, int unaCalleAvenida)
        {
            strNombre = unNombre;
            intCalle = unaCalle;
            intAvenida = unaAvenida;
            intCalleAvenida = unaCalleAvenida;
            imgImage = Properties.Resources.imgAmbulanceCar;
            if (intCalleAvenida == 1)
            {
                strCalleAvenida = "Avenida";
            }
            else
            {
                strCalleAvenida = "Calle";
            }
            if (unaCalleAvenida == 1)
            {
                imgImage.RotateFlip(RotateFlipType.Rotate90FlipX);
            }
        }
    }
}
