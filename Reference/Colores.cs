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
                return Color.Green;
            }
        }
        public static Color colorHospital = Color.Red;
        public static Color colorRestaurante = Color.Yellow;
        public static Color colorEdificios = Color.Black;
        public static Color colorGasolinera = Color.Beige;
        public static Color colorMunicipalidad = Color.Aqua;
        public static Color colorPolicias = Color.AliceBlue;
        public static Color colorBomberos = Color.AntiqueWhite;
        public static Color colorCarro = Color.Aquamarine;
    }
}
