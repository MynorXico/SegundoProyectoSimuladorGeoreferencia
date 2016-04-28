using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades
{
    public static class Validador
    {
        // Comprueba que un número sea entero
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
        // Comprueba texto válido en textBox
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
