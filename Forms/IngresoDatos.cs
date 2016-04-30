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
    /// <summary>
    /// Definición de formulario para el primer ingreso de datos y carga de archivo
    /// </summary>
    public partial class IngresoDatos : Form
    {
        // Arreglo en el que se almacenarán los objbetos
        ArrayList[] alObjetos = new ArrayList[6];

        /// <summary>
        /// Construtor del formulario IngresoDatos
        /// </summary>
        public IngresoDatos()
        {
            InitializeComponent();
            dtpFechaHora.Value = DateTime.Now;
        }
        /// <summary>
        /// Evento utilizado para evitar que no se puedan ingresar caracteres no numéricos en el campo textBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento utilizado para validar que el número de calles y avenidas se encuentre dentro del rango establecido
        /// </summary>
        private void button1_MouseClick(object sender, MouseEventArgs e)
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
                    MessageBox.Show("La cantidad de calles debe estar entre 10 y 50.", "***ERROR***", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAvenidas.Text = "";
                }
                else if (intAvenidas < 10 || intCalles > 100)
                {
                    MessageBox.Show("La cantidad de avenidas debe estar entre 10 y 50.", "***ERROR***", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// <summary>
        /// Evento utilizado para abrir el OpenDialog y buscar el archivo para la carga
        /// </summary>
        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {

            ManejoDatos.lecturadearchivo(txtAddress, lbObjects, progressBar1, alObjetos, int.Parse(txtAvenidas.Text), int.Parse(txtCalles.Text));
            btnAbrirArchivo.Visible = false;   
        }
        /// <summary>
        /// Evento utilizado para abrir el segundo formulario -> generar el mapa con los datos ingresados previamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Por favor realice la carga de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Console.WriteLine(dtpFechaHora.ToString());
                Viewer v1 = new Viewer(intCalles, intAvenidas, dtpFechaHora.Value, this, alObjetos);
                v1.ShowDialog();
                this.Hide();
            }
        }
        /// <summary>
        /// Evento utilizado para cambiar la apariencia del pictureBox cuando el usuario abandona el elemento con el mouse
        /// </summary>
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.MapMaker;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.Cursor = Cursors.Arrow;
        }
        /// <summary>
        /// Evento utilizado para cambiar la apariencia del pictureBox cuando el usuario presiona la pictureBox
        /// </summary>
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.MapMaker4;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }
        /// <summary>
        /// Evento utilizado para cambiar la apariencia del pictureBox cuando el usuario entra al pictureBox con el mouse
        /// </summary>
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.MapMaker3;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.Cursor = Cursors.Hand;
        }
        /// <summary>
        /// Evento utilizado para validar y restringir la cantidad de avenidas que pueden ser ingresadas
        /// </summary>
        private void txtAvenidas_Leave(object sender, EventArgs e)
        {
            if (!Validador.avenidaValida(txtAvenidas.Text))
            {
                txtAvenidas.Clear();
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
        /// <summary>
        /// Evento utilizado para validar y restringir la cantidad de calles que pueden ser ingresadas
        /// </summary>
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
