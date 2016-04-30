using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Vehicles
{
    /// <summary>
    /// Definición de la clase Policía -> Hereda de clase emergencia
    /// </summary>
    public class Policia:Emergencia
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="unNombre">Nombre del policia</param>
        /// <param name="unaCalle">Calle en la que se encuentra el policía</param>
        /// <param name="unaAvenida">Avenida en la que se encuentra el policía</param>
        /// <param name="unaCalleAvenida">Número que indica si el policía se encuentra en una calle o en una avenida</param>
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
        /// <summary>
        /// Modificación del método toString()
        /// </summary>
        /// <returns>Cadena de texto con información organizada sobre el objeto Policia</returns>
        public override string ToString()
        {
            string info = string.Format("Oficial {0}\nDirección: {1}ª Calle y {2}ª Avenida", strNombre, intCalle, intAvenida);

            return info;
        }
    }
}
