using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades.Vehicles
{
    /// <summary>
    /// Definición de clase Ambulancia -> SubClase de clase Emergencia
    /// </summary>
    public class Ambulancia:Emergencia
    {
        /// <summary>
        /// Constructor de la clase Ambulancia
        /// </summary>
        /// <param name="unNombre">Nombre de la ambulancia</param>
        /// <param name="unaCalle">calle de la ambulancia</param>
        /// <param name="unaAvenida">Avenida en la que se ubica la ambulancia</param>
        /// <param name="unaCalleAvenida">Indica si la ambulancia se encuentra sobre calle o sobre avenida</param>
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
                if (unaCalle % 2 == 0)
                {
                    imgImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
            }
            #endregion
        }
        /// <summary>
        /// Modifica el método ToString() de la clase
        /// </summary>
        /// <returns>Cadena de texto con información ordenada de un objeto Ambulancia</returns>
        public override string ToString()
        {
            string info = string.Format("Bombero {0}\nDirección: {1}ª Calle y {2}ª Avenida\n", strNombre, intCalle, intAvenida);
            return info;
        }    
    }
}   
