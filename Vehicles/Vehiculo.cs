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
            string strCalleAvenida;
            Random objRandom = new Random();
            int imgNumber = objRandom.Next() % 4;
            imgImage = arrImages[imgNumber];
            System.Threading.Thread.Sleep(1);
            if (imgNumber == 3)
                imgImage.RotateFlip(RotateFlipType.Rotate180FlipY);

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
