using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

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
                DataGridView[(r.adDireccion.intAvenida - 1) * 6 + 5, (r.adDireccion.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorRestaurante;
            }
            #endregion
            #region Dibuja Hospitales
            foreach (Buildings.Hospital h in alHospitales)
            {
                DataGridView[(h.adDireccion.intAvenida - 1) * 6 + 5, (h.adDireccion.intCalle - 1) * 6 + 5].Value = h.imgImage;
                DataGridView[(h.adDireccion.intAvenida - 1) * 6 + 5, (h.adDireccion.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorHospital;
            }
            #endregion
            #region Dibuja Gasolineras
            foreach (Buildings.Gasolinera g in alGasolineras)
            {
                DataGridView[(g.adDireccion.intAvenida - 1) * 6 + 5, (g.adDireccion.intCalle - 1) * 6 + 5].Value = g.imgImage;
                DataGridView[(g.adDireccion.intAvenida - 1) * 6 + 5, (g.adDireccion.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorGasolinera;

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
                    DataGridView[(v.intAvenida - 1) * 6 + 3, (v.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorCarro;

                }
                else if (v.intCalleAvenida == 2 && DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3].Style.BackColor = Colores.colorCarro;

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
                    DataGridView[(p.intAvenida - 1) * 6 + 3, (p.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorPolicias;

                }
                else if (p.intCalleAvenida == 2 && DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3].Style.BackColor = Colores.colorPolicias;

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
                    DataGridView[(a.intAvenida - 1) * 6 + 3, (a.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorBomberos;

                }
                else if (a.intCalleAvenida == 2 && DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3].Style.BackColor = Colores.colorBomberos;

                }

            }
            #endregion


            DataGridView[(objMunicipalidad.adDireccion.intCalle - 1) * 6 + 5, (objMunicipalidad.adDireccion.intAvenida - 1) * 6 + 5].Value = objMunicipalidad.imgImage;
            DataGridView[(objMunicipalidad.adDireccion.intCalle - 1) * 6 + 5, (objMunicipalidad.adDireccion.intAvenida - 1) * 6 + 5].Style.BackColor = Colores.colorMunicipalidad;


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

            string[,] mapMatrix = new string[DataGridView.Columns.Count, DataGridView.Rows.Count];

            #region Creación de la matriz
            // Creación de la matriz
            for (int i = 0; i < mapMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < mapMatrix.GetLength(1); j++)
                {
                    if (DataGridView[i, j].Style.BackColor == Colores.colorCarretera)
                    {
                        mapMatrix[i, j] = "c";
                    }
                    else if ((DataGridView[i, j].Style.BackColor == Colores.colorCamino) && (i % 12 == 2))
                    {
                        mapMatrix[i, j] = "^";
                    }
                    else if ((i % 12 == 8) && (DataGridView[i, j].Style.BackColor == Colores.colorCamino))
                    {
                        mapMatrix[i, j] = "v";
                    }                    
                    else if((DataGridView[i, j].Style.BackColor == Colores.colorCamino) && (j%12 == 2))
                    {
                        mapMatrix[i, j] = ">";
                    }else if((DataGridView[i, j].Style.BackColor == Colores.colorCamino) && (j % 12 == 8))
                    {
                        mapMatrix[i, j] = "<";
                    }
                    else if (DataGridView[i, j].Style.BackColor == Colores.colorAcera)
                    {
                        mapMatrix[i, j] = "a";
                    }
                    else if(DataGridView[i, j].Style.BackColor == Colores.colorRestaurante)
                    {
                        mapMatrix[i, j] = "R";
                    }
                    else if (DataGridView[i, j].Style.BackColor == Colores.colorEdificios)
                    {
                        mapMatrix[i, j] = "E";
                    }
                    else if (DataGridView[i, j].Style.BackColor == Colores.colorHospital)
                    {
                        mapMatrix[i, j] = "H";
                    }
                    else if (DataGridView[i, j].Style.BackColor == Colores.colorGasolinera)
                    {
                        mapMatrix[i, j] = "G";
                    }
                    else if (DataGridView[i, j].Style.BackColor == Colores.colorMunicipalidad)
                    {
                        mapMatrix[i, j] = "M";
                    }
                    else
                    {
                        mapMatrix[i, j] = " ";
                    }


                    if (DataGridView[i, j].Style.BackColor == Colores.colorPolicias)
                    {
                        mapMatrix[i, j] = "P";
                    }
                    if (DataGridView[i, j].Style.BackColor == Colores.colorBomberos)
                    {
                        mapMatrix[i, j] = "B";
                    }
                    if (DataGridView[i, j].Style.BackColor == Colores.colorCarro)
                    {
                        mapMatrix[i, j] = "V";
                    }
                }
            }

            for (int i = 0; i < mapMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < mapMatrix.GetLength(0); j++)
                {
                    Console.Write("{0}", mapMatrix[j,i]);
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
