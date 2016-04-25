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
using System.Collections;

namespace Proyecto2_SimuladorCiudades
{
    
    public partial class Viewer : Form
    {
        IngresoDatos DI;
        DateTime dtFecha;
        ArrayList[] alObjetos = new ArrayList[6];
        ViewerControl vc;

        public Viewer(int avenidas, int calles, DateTime unaFecha, IngresoDatos objIngresoDatos, ArrayList[] al)
        {
            alObjetos = al;
            InitializeComponent();
            timer1.Start();
            dibujarGrid(mapDGV, calles, avenidas);
            DI = objIngresoDatos;
            dtFecha = unaFecha;
            vc = new ViewerControl(mapDGV, al);
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
                for (int j = 0; j < 6; j++)
                {
                    dg.Columns.Add("", "");
                }
            }
            #endregion Dibuja las Columnas            
            #region Dibuja las Filas
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dg.Rows.Add("", "");
                }
            }
            #endregion
            for (int i = 0; i < 5; i++)
            {
                dg.Columns.Add("", "");
                dg.Rows.Add("", "");
            }
            #endregion
            #region Ajusta los espacios
            #region Ajusta columnas
            for (int i = 0; i < (columnas * 6) + 5; i++)
            {
                switch (i % 6)
                {
                    case 0:
                        dg.Columns[i].Width = 15;
                        break;
                    case 1:
                        dg.Columns[i].Width = 35;
                        break;
                    case 2:
                        dg.Columns[i].Width = 5;
                        break;
                    case 3:
                        dg.Columns[i].Width = 35;
                        break;
                    case 4:
                        dg.Columns[i].Width = 15;
                        break;
                    case 5:
                        dg.Columns[i].Width = 95;
                        break;
                }
            }
            #endregion
            #region Ajusta las Filas
            for (int i = 0; i < (filas * 6) + 5; i++)
            {
                switch (i % 6)
                {
                    case 0:
                        dg.Rows[i].Height = 15;
                        break;
                    case 1:
                        dg.Rows[i].Height = 35;
                        break;
                    case 2:
                        dg.Rows[i].Height = 5;
                        break;
                    case 3:
                        dg.Rows[i].Height = 35;
                        break;
                    case 4:
                        dg.Rows[i].Height = 15;
                        break;
                    case 5:
                        dg.Rows[i].Height = 95;
                        break;
                }
            }
            #endregion
            #endregion
            #region Pinta los edificios
            for (int i = 0; i < (columnas * 6) + 5; i++)
            {
                for (int j = 0; j < (filas * 6) + 5; j++)
                {
                    // Cuadros que corresponden a edificios
                    #region Dibujo de edificios
                    if (i % 6 == 5 && j % 6 == 5)
                    {
                        DataGridViewImageCell imgCell = new DataGridViewImageCell();
                        imgCell.Value = Properties.Resources.imgBuilding;
                        dg[i, j] = imgCell;
                        dg[i, j].Style.BackColor = Colores.colorEdificios;
                    }
                    #endregion
                    // Cuadros que corresponden a la carretera
                    #region Dibujo de carretera
                    else if (i % 6 == 1 || i % 6 == 3)
                    {
                        if (j % 6 != 2)
                        {
                            dg[i, j].Style.BackColor = Colores.colorCarretera;
                        }
                    }
                    else if (i % 6 == 0 || i % 6 == 4)
                    {
                        if (j % 6 == 1 || j % 6 == 2 || j % 6 == 3)
                        {
                            dg[i, j].Style.BackColor = Colores.colorCarretera;
                        }
                    }
                    else if (i % 6 == 5)
                    {
                        if (j % 6 == 3 || j % 6 == 1)
                        {
                            dg[i, j].Style.BackColor = Colores.colorCarretera;
                        }
                    }
                    else if (i % 6 == 2)
                    {
                        if (j % 2 == 0)
                        {
                            dg[i, j].Style.BackColor = Colores.colorCarretera;
                        }
                    }
                    #endregion
                    // Cuadros que corresponden a la acera
                    #region Dibujo de Acera
                    if (i % 6 == 0 || i % 6 == 4)
                    {
                        if (j % 6 == 0 || j % 6 == 5 || j % 6 == 4)
                        {
                            dg[i, j].Style.BackColor = Colores.colorAcera;
                        }
                    }
                    if (i % 6 == 5)
                    {
                        if (j % 6 == 0 || j % 6 == 4)
                        {
                            dg[i, j].Style.BackColor = Colores.colorAcera;
                        }
                    }

                    #endregion
                    // Cuadros que corresponden al espacio entre carriles
                    if (i%6 == 2 || j%6 == 2)
                    {
                        dg[i, j].Style.BackColor = Colores.colorCamino;
                    }
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

        private void mapDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mapDGV[e.ColumnIndex, e.RowIndex].Style.BackColor = mapDGV[e.ColumnIndex, e.RowIndex].Style.BackColor;
            mapDGV.CurrentCell = mapDGV[2, 2];
            Console.WriteLine("Map: \nColumn: {0}\nRnow: {1}\nCell Value: {2}", e.ColumnIndex, e.RowIndex, vc.mapMatrix[e.ColumnIndex, e.RowIndex]);
            int calle = (e.RowIndex+1) / 6;
            int avenida = (e.ColumnIndex+1) / 6;
            if (calle < vc.buildingMatrix.GetLength(0) && avenida < vc.buildingMatrix.GetLength(1))
            {
                Console.WriteLine("Building: \nColumn: {0}\nRow: {1}\nCell Value: {2}", calle, avenida, vc.buildingMatrix[calle, avenida]);
                if (vc.nomenclatura.Contains(vc.mapMatrix[e.ColumnIndex, e.RowIndex]) && vc.buildingMatrix[calle, avenida] != null)
                {
                    MessageBoxPersonalizado.Show(vc.buildingMatrix[calle, avenida].ToString(), "Información", eDialogButtons.OK, vc.buildingMatrix[calle, avenida].imgImage);

                }
            }
        }

        private void mapDGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("Map: \nColumn: {0}\nRnow: {1}\nCell Value: {2}", e.ColumnIndex, e.RowIndex, vc.mapMatrix[e.ColumnIndex, e.RowIndex]);
            int calle = (e.RowIndex + 1) / 6;
            int avenida = (e.ColumnIndex + 1) / 6;
            if (calle < vc.buildingMatrix.GetLength(0) && avenida < vc.buildingMatrix.GetLength(1))
            {
                Console.WriteLine("Building: \nColumn: {0}\nRow: {1}\nCell Value: {2}", calle, avenida, vc.buildingMatrix[calle, avenida]);
                if (vc.nomenclatura.Contains(vc.mapMatrix[e.ColumnIndex, e.RowIndex]) && vc.buildingMatrix[calle, avenida] != null)
                {
                    mapDGV.Cursor = Cursors.Hand;
                }
            }
        }

        private void mapDGV_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("Map: \nColumn: {0}\nRnow: {1}\nCell Value: {2}", e.ColumnIndex, e.RowIndex, vc.mapMatrix[e.ColumnIndex, e.RowIndex]);
            int calle = (e.RowIndex + 1) / 6;
            int avenida = (e.ColumnIndex + 1) / 6;
            if (calle < vc.buildingMatrix.GetLength(0) && avenida < vc.buildingMatrix.GetLength(1))
            {
                Console.WriteLine("Building: \nColumn: {0}\nRow: {1}\nCell Value: {2}", calle, avenida, vc.buildingMatrix[calle, avenida]);
                if (vc.nomenclatura.Contains(vc.mapMatrix[e.ColumnIndex, e.RowIndex]) && vc.buildingMatrix[calle, avenida] != null)
                {
                    mapDGV.Cursor = Cursors.Arrow;
                }
            }
        }
    }
}

