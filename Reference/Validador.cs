using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_SimuladorCiudades
{
    public static class Validador
    {
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
    }
}
