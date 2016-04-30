using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades.Forms
{
    // Definición del formulario frmCambioPosición
    public partial class frmCambioPosicion : Form
    {
        // Atributos de la clase
        #region Atributos
        string _strNuevaCalle;
        string _strNuevaAvenida;
        #endregion
        // Propiedades de la clase
        #region Propiedades
        public string strNuevaCalle
        {
            get
            {
                return _strNuevaCalle;
            }
        }
        public string strNuevaAvenida
        {
            get
            {
                return _strNuevaAvenida;
            }
        }
        int maxCalles;
        int maxAvenidas;
        public int intNuevaCalle = -1;
        public int intNuevaAvenida = -1;
        #endregion

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        /// <param name="callesMax">Cantidad máxima de calles permitida</param>
        /// <param name="avenidasMax">Cantidad máxima de avenidas permitida</param>
        public frmCambioPosicion(int callesMax, int avenidasMax)
        {
            InitializeComponent();
            maxCalles = callesMax;
            maxAvenidas = avenidasMax;
        }
        /// <summary>
        /// Evento para el cambio de posición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(nuevaCalle.Text) > maxCalles || int.Parse(nuevaCalle.Text) <= 0 || int.Parse(nuevaAvenida.Text) <= 0 || int.Parse(nuevaAvenida.Text) > maxAvenidas)
                {
                    MessageBox.Show("La dirección ingresada no es válida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    intNuevaCalle = int.Parse(nuevaCalle.Text);
                    intNuevaAvenida = int.Parse(nuevaAvenida.Text);
                }
            }
            catch
            {
                MessageBox.Show("No ingresó datos válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
