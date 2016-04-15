using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Vehicles
{
    class Policia:Emergencia
    {
        public Policia(string unNombre, int unaCalle, int unaAvenida, int unaCalleAvenida)
        {
            strNombre = unNombre;
            intCalle = unaCalle;
            intAvenida = unaAvenida;
            intCalleAvenida = unaCalleAvenida;
            if(intCalleAvenida == 1)
            {
                strCalleAvenida = "Avenida";
            }
            else
            {
                strCalleAvenida = "Calle";
            }
            imgImage = Properties.Resources.imgPoliceCar;
            if(unaCalleAvenida == 1)
            {
                imgImage.RotateFlip(RotateFlipType.Rotate90FlipX);
            }
        }
    }
}
