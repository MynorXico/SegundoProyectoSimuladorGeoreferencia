using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades
{
    // Definición de clase validador
    public static class Validador
    {
        /// <summary>
        /// Comprueba que un número sea entero
        /// </summary>
        /// <returns>Verdadero o Falso</returns>
        public static bool esEntero(string s)
        {
            try
            {
                int.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Comprueba si el número ingresado corresponde a una calle válida
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool calleValida(string s)
        {
            try
            {
                int i = int.Parse(s);
                if ((i >= 10 && i <= 50) && i % 2 == 0)
                    return true;
                MessageBox.Show("El número de calles debe estar dentro del rango de 10 y 50 y el número debe ser par", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {

            }
            return false;

        }
        /// <summary>
        ///  Comprueba si el número ingresado corresponde a una avenida válida
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool avenidaValida(string s)
        {
            try
            {
                int i = int.Parse(s);
                if ((i >= 10 && i <= 100) && i % 2 == 0)
                    return true;
                MessageBox.Show("El número de avenidas debe estar dentro del rango de 10 y 100 y el número debe ser par", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {

            }
            return false;
        }
    }
}
