using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Proyecto2_SimuladorCiudades.Properties;

namespace Proyecto2_SimuladorCiudades.Forms
{
    public partial class Emergencia : Form
    {
        Servicio servicio;
        private int _intCalles;
        private int _intAvenidas;
        private int _intCalleEmergencia;
        private int _intAvenidaEmergencia;
        private string _strMensajeEmergencia;

        public int intCalleEmergencia
        {
            get
            {
                return _intCalleEmergencia;
            }
            set
            {
                _intCalleEmergencia = value;
            }
        }
        public int intAvenidaEmergencia
        {
            get
            {
                return _intAvenidaEmergencia;
            }
            set
            {
                _intAvenidaEmergencia = value;
            }
        }
        public int intCalles
        {
            get
            {
                return _intAvenidas;
            }
            set
            {
                _intAvenidas = value;
            }
        }
        public int intAvenidas
        {
            get
            {
                return _intAvenidas;
            }
            set
            {
                _intAvenidas = value;
            }
        }
        public string strMensajeEmergencia
        {
            get
            {
                return _strMensajeEmergencia;
            }
            set
            {
                _strMensajeEmergencia = value;
            }
        }
        public string strServicioSolicitado;

        public Emergencia(Servicio s, int calles, int avenidas)
        {
            InitializeComponent();
            intCalles = calles;
            intAvenidas = avenidas;
            servicio = s;
            this.setImage();
        }
        private void setImage()
        {
            switch (servicio)
            {
                case Servicio.Policía:
                    this.imgServicio.Image = Properties.Resources.imgPoliceman;
                    this.Text = "Policía";
                    this.txtServicio.Text = "Servicio de Policía";
                    break;
                case Servicio.Bomberos:
                    this.imgServicio.Image = Properties.Resources.imgAmbulance;
                    this.Text = "Bomberos";
                    this.txtServicio.Text = "Servicio de Bomberos";
                    break;
            }
        }

        private void currentStreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Restringe el ingreso de caracteres no numéricos
            #region Restricción            
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
            if (currentStreet.Text.Length >= 2)
            {
                e.Handled = true;
            }
            #endregion
        }

        private void currentAvenue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Restringe el ingreso de caracteres no numéricos
            #region Restricción            
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
            if (currentAvenue.Text.Length >= 2)
            {
                e.Handled = true;
            }
            #endregion
        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {
            if (int.Parse(currentStreet.Text) > intCalles || int.Parse(currentAvenue.Text) > intAvenidas)
            {
                if(int.Parse(currentStreet.Text) > intCalles)
                {
                    currentStreet.Clear();
                }
                if(int.Parse(currentAvenue.Text)>intCalles)
                {
                    currentAvenue.Clear();
                }
                MessageBox.Show("Por favor ingrese una dirección válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (rtxtEmergency.Text == "")
            {
                MessageBox.Show("Por favor escriba una breve descripción de la emergencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBoxPersonalizado.Show(string.Format("Se creó un mensaje de emergencia para la {0}ª calle y {1}ª avenida\nLa emergencia es la siguiente:\n\t{2}", currentStreet.Text, currentAvenue.Text, rtxtEmergency.Text), "Mensaje Recibido", eDialogButtons.OK, Properties.Resources.Siren);
                intCalleEmergencia = int.Parse(currentStreet.Text);
                intAvenidaEmergencia = int.Parse(currentAvenue.Text);
                strMensajeEmergencia = rtxtEmergency.Text;
                this.Close();
            }            
        }
    }

    public enum Servicio
    {
        Policía,
        Bomberos
    }
}
