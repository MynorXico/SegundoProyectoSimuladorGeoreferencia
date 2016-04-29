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
    public partial class VehiclesMessageForm : Form
    {
        public int nuevaCalle;
        public int nuevaAvenida;
        public int callesMax;
        public int avenidasMax;


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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

