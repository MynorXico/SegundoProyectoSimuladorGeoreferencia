using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades
{
    public static class Colores
    {
        // Propiedades que definen distintos colores que se utilizan durante la ejecución del programa
        #region Propiedades
        public static Color colorCarretera
        {
            get
            {
                return Color.Gray;
            }
        }
        public static Color colorAcera
        {
            get
            {
                return Color.Orange;
            }
        }
        public static Color colorCamino
        {
            get
            {
                return Color.FromArgb(128,128, 129);
            }
        }
        public static Color colorHospital
        {
            get
            {
                return Color.FromArgb(41,128, 186);
            }
        }
        public static Color colorRestaurante {
            get
            {
                return Color.FromArgb(41, 128, 187);
            }
        }
        public static Color colorEdificios
        {
            get
            {
                return Color.FromArgb(19, 100, 191);
            }
        }
        public static Color colorGasolinera {
            get
            {
                return Color.FromArgb(41, 128, 188);
            }
        }
        public static Color colorMunicipalidad {
            get
            {
                return Color.FromArgb(41, 128, 189);
            }
        }
        public static Color colorPolicias {
            get
            {
                return Color.FromArgb(128, 128, 130);
            }
        }
        public static Color colorBomberos {
            get
            {
                return Color.FromArgb(128, 128, 131);
            }
        }
        public static Color colorCarro {
            get
            {
                return Color.FromArgb(128, 128, 132);
            }
        }
        public static Color colorTrazoPolicia
        {
            get
            {
                return Color.FromArgb(0, 0, 127);
            }
        }
        public static Color colorTrazoAmbulancia
        {
            get
            {
                return Color.OrangeRed;
            }
        }
        public static Color colorTrazoPersona
        {
            get
            {
                return Color.FromArgb(33,  150, 243);
            }
        }
        #endregion
    }
} 
