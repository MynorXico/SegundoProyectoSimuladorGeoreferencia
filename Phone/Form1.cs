using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Media;
using System.Globalization;
using Proyecto2_SimuladorCiudades.Forms;

namespace Proyecto2_SimuladorCiudades
{
    /// <summary>
    /// Definición de formulario Phone
    /// </summary>
    public partial class Phone : Form
    {
        // Atributos del formulario
        #region Atributos
        Timer timer = new Timer();
        SoundPlayer sonidoMenu = new SoundPlayer(Properties.Resources._200469__callum_sharp279__menu_scroll_selection_sound);
        int _intCalles;
        int _intAvenidas;
        int _intCallesEmergencia;
        int _intAvenidasEmergencia;
        string _strMensajeEmergencia;
        string _strSolicitudServicio;
        DateTime dtFecha;
        #endregion
        // Propiedades del formulario
        #region Propiedades
        public SoundPlayer sound;
        public int intCalles
        {
            get
            {
                return _intCalles;
            }
            set
            {
                _intCalles = value;
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
        public int intCalleEmergencia
        {
            get
            {
                return _intCallesEmergencia;
            }
            set
            {
                _intCallesEmergencia = value;
            }
        }
        public int intAvenidaEmergencia
        {
            get
            {
                return _intAvenidasEmergencia;
            }
            set
            {
                _intAvenidasEmergencia = value;
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
        public string strSolicitudServicio
        {
            get
            {
                return _strSolicitudServicio;
            }
            set
            {
                _strSolicitudServicio = value;
            }
        }
        #endregion
        /// <summary>
        /// Método constructor del formulario PHone
        /// </summary>
        /// <param name="dt">Fecha para el teléfono</param>
        /// <param name="calles">Calles permitidas para la llamada de emergencia</param>
        /// <param name="avenidas">Avenidas permitidas para la llamada de emergencia</param>
        public Phone(DateTime dt, int calles, int avenidas)
        {
            intCalles = calles;
            intAvenidas = avenidas;
            dtFecha = dt;
            InitializeComponent();
            timer.Interval = 1;
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
        }
        /// <summary>
        /// Actualiza la etiqueta de la fecha 60 veces más rápido de lo normal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender,EventArgs e)
        {//Obtener la hora actual

            dtFecha = dtFecha.AddMilliseconds(1000);
            int intAño = dtFecha.Year;
            int intMes = dtFecha.Month;
            int intDia = dtFecha.Day;
            int intHora = dtFecha.Hour;
            int intMinuto = dtFecha.Minute;
            int intSegundo = dtFecha.Second;
            string strDia = string.Format("{0: dddd}", dtFecha);
            string strMes = string.Format("{0: MMM}", dtFecha);
            string tt = dtFecha.ToString("tt", CultureInfo.InvariantCulture);
            label1.Text = string.Format("{0}:{1}:{2} {3}", intHora.ToString("D2"), intMinuto.ToString("D2"), intSegundo.ToString("D2"), tt);
            label2.Text = string.Format("{0}", strDia);
        }
        /// <summary>
        /// Evento que ocurre cuando se presiona la pictureBox pictureBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources._13450054841457633298glossy_blue_circle_button_md_hi;
            label1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label2.Visible = true;           
        }
        /// <summary>
        /// Evento que ocurre cuando se sostiene el cursor sobre la pictureBox pictureBox1
        /// </summary>
        private void pictureBox2_MouseHover(object sender,EventArgs e)
        {
            sonidoMenu.Play();
            pictureBox2.Image = Properties.Resources.policeman_512;
        }
        /// <summary>
        /// Evento que sucede cuando el cursor abandona la pictureBox pictureBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.officer_512;
        }
        /// <summary>
        /// Evento que sucede cuando el cursor se sostiene sobre la pictureBox pictureBox3
        /// </summary>
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            sonidoMenu.Play();
            pictureBox3.Image = Properties.Resources.firefigther1;
            
        }
        /// <summary>
        /// Evento que sucede cuando el cursor abandona la pictureBox pictureBox3
        /// </summary>
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.fireman_512;
            
        }
        /// <summary>
        /// Evento que ocurre cuando el cursor se sostiene sobre la pictureBox pictureBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseHover(object sender,EventArgs e)
        {
           
        }
        /// <summary>
        /// Evento que se ejecuta cuando se hace doble clic en el botón principal del teléfono
        /// </summary>
        private void botonEncendido_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento que se ejecuta cuando se presiona la pictureBox pictureBox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Forms.Emergencia dialogEmergencia = new Forms.Emergencia(Forms.Servicio.Policía, intCalles, intAvenidas);
            dialogEmergencia.ShowDialog(this);
            intCalleEmergencia = dialogEmergencia.intCalleEmergencia;
            intAvenidaEmergencia = dialogEmergencia.intAvenidaEmergencia;
            strMensajeEmergencia = dialogEmergencia.strMensajeEmergencia;
            strSolicitudServicio = "Policia";
            sound= new SoundPlayer(Properties.Resources.policeSound);
            this.Close();

        }
        /// <summary>
        /// Evento que se ejecuta cuando se presiona la pictureBox pictureBox3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Forms.Emergencia dialogEmergencia = new Forms.Emergencia(Forms.Servicio.Bomberos, intCalles, intAvenidas);
            dialogEmergencia.ShowDialog(this);
            intCalleEmergencia = dialogEmergencia.intCalleEmergencia;
            intAvenidaEmergencia = dialogEmergencia.intAvenidaEmergencia;
            strMensajeEmergencia = dialogEmergencia.strMensajeEmergencia;
            strSolicitudServicio = dialogEmergencia.strServicioSolicitado;
            strSolicitudServicio = "Bombero";
            sound = new SoundPlayer(Properties.Resources.sndAmbulance);
            this.Close();        
        }
    }
}
