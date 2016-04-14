using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades
{
    public partial class IngresoDatos : Form
    {
        public IngresoDatos()
        {
            InitializeComponent();
            dtpFechaHora.Value = DateTime.Now;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            int intCalles = -1;
            int intAvenidas = -1;
            if (Validador.esEntero(txtAvenidas.Text)){
                intCalles = int.Parse(txtAvenidas.Text);
            }
            if (Validador.esEntero(txtCalles.Text)){
                intAvenidas = int.Parse(txtCalles.Text);
            }
            if (intCalles != -1 && intCalles != -1)
            {
                if (intCalles < 10 || intCalles > 50)
                {
                    MessageBox.Show("La cantidad de calles debe estar entre 10 y 50.", "***ERROR***", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAvenidas.Text = "";
                }
                else if (intAvenidas < 10 || intCalles > 100)
                {
                    MessageBox.Show("La cantidad de calles debe estar entre 10 y 50.", "***ERROR***", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAvenidas.Text = "";
                }
                else
                {
                    Console.WriteLine(dtpFechaHora.ToString());
                    Viewer v1 = new Viewer(intCalles, intAvenidas, dtpFechaHora.Value, this);
                    v1.ShowDialog();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar datos válidos", "***ERROR***", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            ManejoDatos.lecturadearchivo(txtAddress, lbObjects, progressBar1);        
        }
    }
}
