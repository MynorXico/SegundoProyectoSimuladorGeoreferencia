using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades
{
    /*
        Universidad Rafael Landívar
        Simulador de Ciudades
        Segundo Proyecto del Curso: Introducción a la Programación
        Lenguaje de Desarrollo: C#
        Autores: David Alejando Munguia Américas
                 Mynor Ottoniel Xico Tzian
        Fecha de Reevisión: 30042016
        Versión: 1.00
    */

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IngresoDatos());
        }

    }
}
