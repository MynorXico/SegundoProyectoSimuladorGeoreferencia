using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Proyecto2_SimuladorCiudades
{
    public partial class IngresoDatos : Form
    {
        ArrayList[] alObjetos = new ArrayList[6];

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
                    Viewer v1 = new Viewer(intCalles, intAvenidas, dtpFechaHora.Value, this, alObjetos);
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

            ManejoDatos.lecturadearchivo(txtAddress, lbObjects, progressBar1, alObjetos, int.Parse(txtCalles.Text), int.Parse(txtAvenidas.Text));
            btnAbrirArchivo.Visible = false;   
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int intCalles = -1;
            int intAvenidas = -1;
            if (Validador.esEntero(txtAvenidas.Text))
            {
                intCalles = int.Parse(txtAvenidas.Text);
            }
            if (Validador.esEntero(txtCalles.Text))
            {
                intAvenidas = int.Parse(txtCalles.Text);
            }
            if (intCalles != -1 && intCalles != -1)
            {
                if (intCalles < 10 || intCalles > 50)
                {
                    MessageBox.Show("La cantidad de calles debe estar entre 10 y 50.", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAvenidas.Text = "";
                }
                else if (intAvenidas < 10 || intAvenidas > 100)
                {
                    MessageBox.Show("La cantidad de calles debe estar entre 10 y 50.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAvenidas.Text = "";
                }
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Por favor realice la carga de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAvenidas.Text = "";
                }
                else if(intCalles%2 != 0 || intAvenidas % 2 !=0)
                {
                    MessageBox.Show("El número de calles y avenidas debe ser un número par", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Console.WriteLine(dtpFechaHora.ToString());
                    Viewer v1 = new Viewer(intCalles, intAvenidas, dtpFechaHora.Value, this, alObjetos);
                    v1.ShowDialog();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar datos válidos", "***ERROR***", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.MapMaker;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.Cursor = Cursors.Arrow;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.MapMaker4;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.MapMaker3;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.Cursor = Cursors.Hand;
        }

        private void txtAvenidas_Leave(object sender, EventArgs e)
        {
            if (!Validador.avenidaValida(txtAvenidas.Text))
            {
                txtAvenidas.Clear();
            }
            else
            {
                if(txtCalles.Text != "" && txtAvenidas.Text != "")
                {
                    btnAbrirArchivo.Visible = true;
                }
                else
                {
                    btnAbrirArchivo.Visible = false;
                }
            }
        }

        private void txtCalles_Leave(object sender, EventArgs e)
        {
            if (!Validador.calleValida(txtCalles.Text))
            {
                txtCalles.Clear();
            }
            else
            {
                if (txtCalles.Text != "" && txtAvenidas.Text != "")
                {
                    btnAbrirArchivo.Visible = true;
                }
                else
                {
                    btnAbrirArchivo.Visible = false;
                }
            }
        }
    }
}
