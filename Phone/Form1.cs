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





namespace Proyecto2_SimuladorCiudades
{
    public partial class Phone : Form
    {
        Timer timer = new Timer();
        SoundPlayer sonidoMenu = new SoundPlayer(Proyecto2_SimuladorCiudades.Properties.Resources._200469__callum_sharp279__menu_scroll_selection_sound);
    
        public Phone()
        {
            InitializeComponent();
            timer.Interval = 10;
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //se define los intervalos del timer
          
        }
        //timer eventHandler
        private void timer_Tick(object sender,EventArgs e)
        {//Obtener la hora actual
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            string dy = DateTime.Today.DayOfWeek.ToString();
            label2.Text = dy;
        

            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            //Actualizar labael
            label1.Text = time;
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Proyecto2_SimuladorCiudades.Properties.Resources._13450054841457633298glossy_blue_circle_button_md_hi;
            label1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label2.Visible = true;
           
            
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_MouseHover(object sender,EventArgs e)
        {
            sonidoMenu.Play();
            pictureBox2.Image = Properties.Resources.policeman_512;
        }
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.officer_512;
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            sonidoMenu.Play();
            pictureBox3.Image = Properties.Resources.firefigther1;
            
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.fireman_512;
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseHover(object sender,EventArgs e)
        {
           
        }
      

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
