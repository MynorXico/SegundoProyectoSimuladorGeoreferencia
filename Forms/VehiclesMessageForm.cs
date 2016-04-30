using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto2_SimuladorCiudades.Reference;
using Proyecto2_SimuladorCiudades.Forms;

namespace Proyecto2_SimuladorCiudades
{
    /// <summary>
    /// Definición del formulario vehiclesMessageForm
    /// </summary>
    public partial class VehiclesMessageForm : Form
    {
        // Atributos del formulario
        #region Atributos
        public int nuevaCalle;
        public int nuevaAvenida;
        public int callesMax;
        public int avenidasMax;
        #endregion

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        /// <param name="Texto">Texto de contenido del cuadro de diálogo</param>
        /// <param name="Titulo">Título del cuadro de diálogo</param>
        /// <param name="Botones">Botones que tendrá el cuadro de diálogo</param>
        /// <param name="Imagen">Imagen que tendrá el cuadro de diálogo</param>
        /// <param name="maxCalles">Cantidad máxima de calles permitidas al usuario</param>
        /// <param name="maxAvenidas">Cantidad máxima de avenidas permitidas al usuario</param>
        public VehiclesMessageForm(string Texto, string Titulo, eDialogButtons Botones, Image Imagen, int maxCalles, int maxAvenidas)
        {
            InitializeComponent();
            this.Text = Titulo;
            this.picImage.ErrorImage = Imagen;
            this.lblText.Text = Texto;
            Media.sp.Play();
            callesMax = maxCalles;
            avenidasMax = maxAvenidas;
        }
        /// <summary>
        /// Evento para que cuando se presione el botón OK se cierre el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento que sucede cuando se presiona el botón btnCambioPosición, generando un nuevo formulario para ingresar la nueva dirección del elemento en cuestión
        /// </summary>
        private void btnCambioPosicion_Click(object sender, EventArgs e)
        {
            frmCambioPosicion cambioPosicionForm = new frmCambioPosicion(callesMax, avenidasMax);
            cambioPosicionForm.ShowDialog(this);
            nuevaCalle = cambioPosicionForm.intNuevaCalle;
            nuevaAvenida = cambioPosicionForm.intNuevaAvenida;            
            this.Close();           
        }
    }
}

