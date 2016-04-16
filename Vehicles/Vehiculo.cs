using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades
{
    class Vehiculo
    {
        #region Atritutos
        // Atributos de la clase
        private string _strPlaca;
        private int _intCalle;
        private int _intAvenida;
        private int _intCalleAvenida;
        private string _strMarca;
        private Image[] arrImages = {Properties.Resources.imgBlueCar, Properties.Resources.imgBlueCar2, Properties.Resources.imgPurpleCar, Properties.Resources.imgWhiteCar};
        private Image _imgImage;
        #endregion
        #region Propiedades
        // Propiedades de la clase
        public string strPlaca
        {
            get
            {
                return _strPlaca;
            }
            set
            {
                _strPlaca = value;
            }
        }
        public int intCalle
        {
            get
            {
                return _intCalle;
            }
            set
            {
                _intCalle = value;
            }
        }
        public int intAvenida
        {
            get
            {
                return _intAvenida;
            }
            set
            {
                _intAvenida = value;
            }
        }
        public int intCalleAvenida
        {
            get
            {
                return _intCalleAvenida;
            }
            set
            {
                _intCalleAvenida = value;
            }
        }
        public string strMarca
        {
            get
            {
                return _strMarca;
            }
            set
            {
                _strMarca = value;
            }
        }
        public Image imgImage
        {
            get
            {
                return _imgImage;
            }
            set
            {
                _imgImage = value;
            }
        }
        #endregion

        //Constructor
        public Vehiculo(string unaPlaca, int unaCalle, int unaAvenida, int unaCalleAvenida, string unaMarca)
        {
            strPlaca = unaPlaca;
            intCalle = unaCalle;
            intAvenida = unaAvenida;
            intCalleAvenida = unaCalleAvenida;
            strMarca = unaMarca;
            Random objRandom = new Random();
            imgImage = arrImages[objRandom.Next()%4];
            System.Threading.Thread.Sleep(1);
            if (unaCalleAvenida == 1)
            {
                imgImage.RotateFlip(RotateFlipType.Rotate90FlipX);
            }
            
        }

    }
}
