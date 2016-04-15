using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades
{
    class ViewerControl
    {
        ArrayList[] alObjetos = new ArrayList[6];
        ArrayList alCarros;
        ArrayList alRestaurantes;
        ArrayList alHospitales;
        ArrayList alGasolineras;
        ArrayList alPolicia;
        ArrayList alBomberos;

        address adDireccionMunicipalidad = new address();

        public ViewerControl(DataGridView DataGridView, ArrayList[] al)
        {
            alObjetos = al;
            alCarros = alObjetos[0];
            alRestaurantes = alObjetos[1];
            alHospitales = alObjetos[2];
            alGasolineras = alObjetos[3];
            alPolicia = alObjetos[4];
            alBomberos = alObjetos[5];


            adDireccionMunicipalidad.intAvenida = 2;
            adDireccionMunicipalidad.intCalle = 2;
            Buildings.Municipalidad objMunicipalidad = new Buildings.Municipalidad(adDireccionMunicipalidad);

            #region Dibuja Restaurantes
            foreach (Buildings.Restaurante r in alRestaurantes)
            {
                DataGridView[(r.adDireccion.intAvenida - 1) * 6 + 5, (r.adDireccion.intCalle - 1) * 6 + 5].Value = r.imgImage;
            }
            #endregion
            #region Dibuja Hospitales
            foreach (Buildings.Hospital h in alHospitales)
            {
                DataGridView[(h.adDireccion.intAvenida - 1) * 6 + 5, (h.adDireccion.intCalle - 1) * 6 + 5].Value = h.imgImage;
            }
            #endregion
            #region Dibuja Gasolineras
            foreach (Buildings.Gasolinera g in alGasolineras)
            {
                DataGridView[(g.adDireccion.intAvenida - 1) * 6 + 5, (g.adDireccion.intCalle - 1) * 6 + 5].Value = g.imgImage;
            }
            #endregion

            #region Dibuja Carros
            foreach (Vehiculo v in alCarros)
            {
                DataGridViewImageCell imgCell = new DataGridViewImageCell();
                imgCell.Value = v.imgImage;
                if (v.intCalleAvenida == 1 && DataGridView[(v.intAvenida - 1) * 6 + 3, (v.intCalle - 1) * 6 + 5].Value == null)
                {
                    DataGridView[(v.intAvenida - 1) * 6 + 3, (v.intCalle - 1) * 6 + 5] = imgCell;
                    DataGridView[(v.intAvenida - 1) * 6 + 3, (v.intCalle - 1) * 6 + 5].Style.BackColor = System.Drawing.Color.Gray;
                }
                else if (v.intCalleAvenida == 2 && DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3].Style.BackColor = System.Drawing.Color.Gray;
                }
            }
            #endregion
            #region Dibuja Patrullas
            foreach (Vehicles.Policia p in alPolicia)
            {
                DataGridViewImageCell imgCell = new DataGridViewImageCell();
                imgCell.Value = p.imgImage;
                if (p.intCalleAvenida == 1 && DataGridView[(p.intAvenida - 1) * 6 + 3, (p.intCalle - 1) * 6 + 5].Value == null)
                {
                    DataGridView[(p.intAvenida - 1) * 6 + 3, (p.intCalle - 1) * 6 + 5] = imgCell;
                    DataGridView[(p.intAvenida - 1) * 6 + 3, (p.intCalle - 1) * 6 + 5].Style.BackColor = System.Drawing.Color.Gray;
                }
                else if (p.intCalleAvenida == 2 && DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3].Style.BackColor = System.Drawing.Color.Gray;
                }
            }
            #endregion
            #region Dibuja Ambulancias
            foreach (Vehicles.Ambulancia a in alBomberos)
            {
                DataGridViewImageCell imgCell = new DataGridViewImageCell();
                imgCell.Value = a.imgImage;
                if (a.intCalleAvenida == 1 && DataGridView[(a.intAvenida - 1) * 6 + 3, (a.intCalle - 1) * 6 + 5].Value == null)
                {
                    DataGridView[(a.intAvenida - 1) * 6 + 3, (a.intCalle - 1) * 6 + 5] = imgCell;
                    DataGridView[(a.intAvenida - 1) * 6 + 3, (a.intCalle - 1) * 6 + 5].Style.BackColor = System.Drawing.Color.Gray;

                }
                else if (a.intCalleAvenida == 2 && DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3].Style.BackColor = System.Drawing.Color.Gray;
                }
            }
            #endregion


            DataGridView[(objMunicipalidad.adDireccion.intCalle - 1) * 6 + 5, (objMunicipalidad.adDireccion.intAvenida - 1) * 6 + 5].Value = objMunicipalidad.imgImage;



            /*
                Nomenclatura para creación de matriz
                ╔        ╦                        ╗  
                ║Símbolo ║Significado             ║
                ║    c   ║Carretera               ║ 
                ║    a   ║Acera                   ║
                ║    *   ║Edificio                ║
                ║    |   ║Espacio entre carretera;║
                                                  ╝               
            */

            string[,] mapMatrix = new string[DataGridView.Rows.Count, DataGridView.Columns.Count];

            #region Creación de la matriz
            // Creación de la matriz
            for (int i = 0; i < mapMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < mapMatrix.GetLength(1); j++)
                {
                    if (DataGridView[j, i].Style.BackColor == System.Drawing.Color.Gray)
                    {
                        mapMatrix[i, j] = "c";
                    }
                    else if (DataGridView[j, i].Style.BackColor == System.Drawing.Color.Orange)
                    {
                        mapMatrix[i, j] = "a";
                    }
                    else if (DataGridView[j, i].Style.BackColor == System.Drawing.Color.LightBlue)
                    {
                        mapMatrix[i, j] = "*";
                    }
                    else
                    {
                        mapMatrix[i, j] = "|";
                    }
                }
            }

            for (int i = 0; i < mapMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < mapMatrix.GetLength(1); j++)
                {
                    Console.Write("{0}", mapMatrix[i, j]);
                }
                Console.WriteLine();
            }
            #endregion
        }
        public void dibujarMapa()
        {

        }
    }
}
