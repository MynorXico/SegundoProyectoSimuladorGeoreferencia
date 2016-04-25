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
            #region Cambio de Posición de Ambulancia
            if (intCalleAvenida == 1)
            {
                strCalleAvenida = "Avenida";
                if (unaAvenida % 2 != 0)
                {
                    imgImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                }
                else
                {
                    imgImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                }
            }
            else
            {
                strCalleAvenida = "Calle";
                if(unaCalle % 2 == 0)
                {
                    imgImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
            }
            #endregion
        }
    }
}   
