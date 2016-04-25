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
            imgImage = Properties.Resources.imgPoliceCar;

            #region Cambio de Posición de Policía
            if (intCalleAvenida == 1)
            {
                strCalleAvenida = "Avenida";
                if (unaAvenida % 2 == 0)
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
                if (unaCalle % 2 != 0)
                {
                    imgImage.RotateFlip(RotateFlipType.Rotate180FlipY);

                }
            }
            #endregion
        }
    }
}
