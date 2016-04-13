using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades
{
    public partial class Viewer : Form
    {
        IngresoDatos DI;
        DateTime dtFecha;
        

        public Viewer(int calles, int avenidas, DateTime unaFecha, IngresoDatos objIngresoDatos)
        {
            InitializeComponent();
            timer1.Start();
            dibujarGrid(mapDGV, calles, avenidas);
            DI = objIngresoDatos;
            dtFecha = unaFecha;
            ViewerControl vc = new ViewerControl(mapDGV);
        }

        private void dibujarGrid(DataGridView dg, int columnas, int filas)
        {
            // Ajusta color a blanco
            dg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            columnas -= 1;
            filas -= 1;
            #region Dibuja la cuadrícula
            #region Dibuja las Columnas
            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dg.Columns.Add("", "");
                }
            }
            #endregion Dibuja las Columnas            
            #region Dibuja las Filas
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dg.Rows.Add("", "");
                }
            }
            #endregion
            for (int i = 0; i < 3; i++)
            {
                dg.Columns.Add("", "");
                dg.Rows.Add("", "");
            }
            #endregion
            #region Ajusta los espacios
            #region Ajusta columnas
            for (int i = 0; i < (columnas * 4)+3; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        dg.Columns[i].Width = 20;
                        break;
                    case 1:
                        dg.Columns[i].Width = 50;
                        break;
                    case 2:
                        dg.Columns[i].Width = 20;
                        break;
                    case 3:
                        dg.Columns[i].Width = 60;
                        break;
                }
            }
            #endregion
            #region Ajusta las Filas
            for (int i = 0; i < (filas * 4)+3; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        dg.Rows[i].Height = 20;
                        break;
                    case 1:
                        dg.Rows[i].Height = 50;
                        break;
                    case 2:
                        dg.Rows[i].Height = 20;
                        break;
                    case 3:
                        dg.Rows[i].Height = 60;
                        break;
                }
            }
            #endregion
            #endregion
            #region Pinta los edificios
            for(int i=0; i < (columnas*4)+3; i++)
            {
                for(int j=0; j < (filas*4)+3; j++)
                {
                    // Cuadros que corresponden a edificios
                    #region Dibujo de edificios
                    if (i%4 == 3 || i%4 == 3)
                    {
                        if(j%4 == 3 || j%4 == 3)
                        {
                            dg[i, j].Style.BackColor = System.Drawing.Color.RoyalBlue;
                        }
                    }
                    #endregion

                    // Cuadros que corresponden a la carretera
                    #region Dibujo de carretera
                    if (i%4 == 1 )
                    {
                        dg[i, j].Style.BackColor = System.Drawing.Color.Gray;
                    }
                    if(i%4 == 2)
                    {
                        if (j%4 == 1)
                        {
                            dg[i, j].Style.BackColor = System.Drawing.Color.Gray;

                        }
                    }
                    if (i % 4 == 0)
                    {
                        if(j%4 == 1)
                        {
                            dg[i, j].Style.BackColor = System.Drawing.Color.Gray;
                        }
                    }
                    if(i%4 == 3)
                    {
                        if (j%4 == 1)
                        {
                            dg[i, j].Style.BackColor = System.Drawing.Color.Gray;
                        }
                    }
                    #endregion

                    // Cuadros que corresponden a la acera
                    #region Dibujo de acera
                    if (i%4 == 0 || i % 4 == 2)
                    {
                        if(j%4 != 1)
                        {
                            dg[i, j].Style.BackColor = System.Drawing.Color.Yellow;
                        }
                    }
                    if (i%4 == 3)
                    {
                        if (j % 4 == 0 || j%4 == 2)
                        {
                            dg[i, j].Style.BackColor = System.Drawing.Color.Yellow;
                        }
                    }
                    #endregion
                }
            }
            #endregion
        }
        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            DI.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            dtFecha = dtFecha.AddMilliseconds(6000);
            int intAño = dtFecha.Year;
            int intMes = dtFecha.Month;
            int intDia = dtFecha.Day;
            int intHora = dtFecha.Hour;
            int intMinuto = dtFecha.Minute;
            int intSegundo = dtFecha.Second;
            string strDia = string.Format("{0: ddd}", dtFecha);
            string strMes = string.Format("{0: MMM}", dtFecha);
            string tt = dtFecha.ToString("tt", CultureInfo.InvariantCulture);
            lblHora.Text = string.Format("{0}:{1}:{2} {3}", intHora.ToString("D2"), intMinuto.ToString("D2"), intSegundo.ToString("D2"), tt);
            lblFecha.Text = string.Format("{0:ddd} {1}/{2}/{3}", strDia, intDia, strMes, intAño);
        }


    }
}
