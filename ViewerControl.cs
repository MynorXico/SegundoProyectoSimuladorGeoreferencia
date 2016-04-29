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
    public class ViewerControl
    {
        ArrayList[] alObjetos = new ArrayList[6];
        ArrayList alCarros;
        ArrayList alRestaurantes;
        ArrayList alHospitales;
        ArrayList alGasolineras;
        ArrayList alPolicia;
        ArrayList alBomberos;

        address adDireccionMunicipalidad = new address();

        public string[,] mapMatrix;
        public Edificio[,] buildingMatrix;
        public Vehiculo[,] avenueVehiclesMatrix;
        public Vehiculo[,] streetVehiclesMatrix;
        public Emergencia[,] avenueEmergencyMatrix;
        public Emergencia[,] streetEmergencyMatrix;
        public string[] nomenclaturaEdificios = {"M", "G", "H", "E", "R" };
        public string[] nomenclaturaVehiculos = {"V"};
        public string[] nomenclaturaEmergencia = { "P", "B" };


        public ViewerControl(DataGridView DataGridView, ArrayList[] al, int calleMax, int avenidaMax)
        {
            alObjetos = al;
            alCarros = alObjetos[0];
            alRestaurantes = alObjetos[1];
            alHospitales = alObjetos[2];
            alGasolineras = alObjetos[3];
            alPolicia = alObjetos[4];
            alBomberos = alObjetos[5];

            adDireccionMunicipalidad.intAvenida = 9;
            adDireccionMunicipalidad.intCalle = 9;
            Buildings.Municipalidad objMunicipalidad = new Buildings.Municipalidad(adDireccionMunicipalidad);

            #region Dibuja Restaurantes
            foreach (Buildings.Restaurante r in alRestaurantes)
            {
                DataGridView[(r.adDireccion.intAvenida - 1) * 6 + 5, (r.adDireccion.intCalle - 1) * 6 + 5].Value = r.imgImage;
                DataGridView[(r.adDireccion.intAvenida - 1) * 6 + 5, (r.adDireccion.intCalle - 1) * 6 + 5].ToolTipText = String.Format("Restaurant {0}", r.strNombre);
                DataGridView[(r.adDireccion.intAvenida - 1) * 6 + 5, (r.adDireccion.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorRestaurante;
            }
            #endregion
            #region Dibuja Hospitales
            foreach (Buildings.Hospital h in alHospitales)
            {
                DataGridView[(h.adDireccion.intAvenida - 1) * 6 + 5, (h.adDireccion.intCalle - 1) * 6 + 5].Value = h.imgImage;
                DataGridView[(h.adDireccion.intAvenida - 1) * 6 + 5, (h.adDireccion.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorHospital;
                DataGridView[(h.adDireccion.intAvenida - 1) * 6 + 5, (h.adDireccion.intCalle - 1) * 6 + 5].ToolTipText = String.Format("Hospital {0}", h.strNombre);
            }
            #endregion
            #region Dibuja Gasolineras
            foreach (Buildings.Gasolinera g in alGasolineras)
            {
                DataGridView[(g.adDireccion.intAvenida - 1) * 6 + 5, (g.adDireccion.intCalle - 1) * 6 + 5].Value = g.imgImage;
                DataGridView[(g.adDireccion.intAvenida - 1) * 6 + 5, (g.adDireccion.intCalle - 1) * 6 + 5].Style.BackColor = Colores.colorGasolinera;
                DataGridView[(g.adDireccion.intAvenida - 1) * 6 + 5, (g.adDireccion.intCalle - 1) * 6 + 5].ToolTipText = String.Format("Gasolinera {0}", g.strNombre);
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
                    DataGridView[(v.intAvenida - 1) * 6 + 3, (v.intCalle - 1) * 6 + 5].ToolTipText = String.Format("Carro #{0}", v.strPlaca);

                }
                else if (v.intCalleAvenida == 2 && DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3].Style.BackColor = Colores.colorCarro;
                    DataGridView[(v.intAvenida - 1) * 6 + 5, (v.intCalle - 1) * 6 + 3].ToolTipText = String.Format("Carro #{0}", v.strPlaca);
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
                    DataGridView[(p.intAvenida - 1) * 6 + 3, (p.intCalle - 1) * 6 + 5].ToolTipText = String.Format("Patrulla #{0}", p.strNombre);

                }
                else if (p.intCalleAvenida == 2 && DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3].Style.BackColor = Colores.colorPolicias;
                    DataGridView[(p.intAvenida - 1) * 6 + 5, (p.intCalle - 1) * 6 + 3].ToolTipText = String.Format("Patrulla #{0}", p.strNombre);


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
                    DataGridView[(a.intAvenida - 1) * 6 + 3, (a.intCalle - 1) * 6 + 5].ToolTipText = String.Format("Ambulancia #{0}", a.strNombre);
                }
                else if (a.intCalleAvenida == 2 && DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3].Value == null)
                {
                    DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3] = imgCell;
                    DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3].Style.BackColor = Colores.colorBomberos;
                    DataGridView[(a.intAvenida - 1) * 6 + 5, (a.intCalle - 1) * 6 + 3].ToolTipText = String.Format("Ambulancia #{0}", a.strNombre);
                }
            }
            #endregion


            DataGridView[(objMunicipalidad.adDireccion.intCalle - 1) * 6 + 5, (objMunicipalidad.adDireccion.intAvenida - 1) * 6 + 5].Value = objMunicipalidad.imgImage;
            DataGridView[(objMunicipalidad.adDireccion.intCalle - 1) * 6 + 5, (objMunicipalidad.adDireccion.intAvenida - 1) * 6 + 5].Style.BackColor = Colores.colorMunicipalidad;
            DataGridView[(objMunicipalidad.adDireccion.intCalle - 1) * 6 + 5, (objMunicipalidad.adDireccion.intAvenida - 1) * 6 + 5].ToolTipText = String.Format("{0}", objMunicipalidad.strLabel);



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

            mapMatrix = new string[DataGridView.Columns.Count, DataGridView.Rows.Count];
            buildingMatrix = new Edificio[(DataGridView.Columns.Count / 6) - 4 + 100, (DataGridView.Columns.Count / 6) - 4 + 100];
            avenueVehiclesMatrix = new Vehiculo[(DataGridView.Columns.Count / 6) - 4 + 100, (DataGridView.Columns.Count / 6) - 4 + 100];
            avenueEmergencyMatrix = new Emergencia[(DataGridView.Columns.Count / 6) - 4 + 100, (DataGridView.Columns.Count / 6) - 4 + 100];
            streetVehiclesMatrix = new Vehiculo[(DataGridView.Columns.Count / 6) - 4 + 100, (DataGridView.Columns.Count / 6) - 4 + 100];
            streetEmergencyMatrix = new Emergencia[(DataGridView.Columns.Count / 6) - 4 + 100, (DataGridView.Columns.Count / 6) - 4 + 100];

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
            #endregion
            #region Creación de Matriz para VehículosAvenida
            foreach(Vehiculo v in alCarros)
            {
                if(v.intCalleAvenida ==1)
                    avenueVehiclesMatrix[v.intCalle, v.intAvenida] = v;
            }
            #endregion
            #region Creación de Matriz para VehículosCalle
            foreach (Vehiculo v in alCarros)
            {
                if (v.intCalleAvenida == 2)
                    streetVehiclesMatrix[v.intCalle, v.intAvenida] = v;
            }
            #endregion
            #region Creación de Matriz para EmergenciasCalle
            foreach (Emergencia e in alPolicia)
            {
                if (e.intCalleAvenida == 2)
                    streetEmergencyMatrix[e.intCalle, e.intAvenida] = e;
            }
            foreach (Emergencia e in alBomberos)
            {
                if (e.intCalleAvenida == 2)
                    streetEmergencyMatrix[e.intCalle, e.intAvenida] = e;
            }
            #endregion
            #region Creación de Matriz para EmergenciasAvenida
            foreach (Emergencia e in alPolicia)
            {
                if (e.intCalleAvenida == 1)
                    avenueEmergencyMatrix[e.intCalle, e.intAvenida] = e;
            }
            foreach (Emergencia e in alBomberos)
            {
                if (e.intCalleAvenida == 1)
                    avenueEmergencyMatrix[e.intCalle, e.intAvenida] = e;
            }
            #endregion
            #region Creación de Matriz Edificios
            foreach (Edificio r in alRestaurantes)
            {
                buildingMatrix[r.adDireccion.intCalle, r.adDireccion.intAvenida] = r;
            }
            foreach (Edificio h in alHospitales)
            {
                buildingMatrix[h.adDireccion.intCalle, h.adDireccion.intAvenida] = h;
            }
            foreach (Edificio g in alGasolineras)
            {
                buildingMatrix[g.adDireccion.intCalle, g.adDireccion.intAvenida] = g;
            }
            buildingMatrix[objMunicipalidad.adDireccion.intCalle, objMunicipalidad.adDireccion.intAvenida] = objMunicipalidad;
            #endregion

            buildingMatrix[objMunicipalidad.adDireccion.intCalle, objMunicipalidad.adDireccion.intAvenida] = objMunicipalidad;
            /*
            for (int i = 0; i < streetVehiclesMatrix.GetLength(0); i++)
            {
                for(int j =0; j < streetVehiclesMatrix.GetLength(1); j++)
                {
                    if (streetVehiclesMatrix[i, j] != null)
                    {
                        Console.Write(streetVehiclesMatrix[i, j].strMarca);
                    }Console.WriteLine("\t");
                }Console.WriteLine();
            }*/
            
            /*
            #region Muestra matrices
            for (int i = 0; i < buildingMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < buildingMatrix.GetLength(1); j++)
                {
                    if (buildingMatrix[i, j] != null)
                    {
                        Console.Write(buildingMatrix[i, j].strLabel);
                    }
                    Console.Write("\t\t");
                }Console.WriteLine();
            }
            for (int i = 0; i < mapMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < mapMatrix.GetLength(0); j++)
                {
                    Console.Write("{0}", mapMatrix[j, i]);
                }
                Console.WriteLine();
            }
            #endregion
            */
        }


        public void cambiarPosicionVehiculo(Vehiculo v, int calleAntigua, int avenidaAntigua, int calleNueva, int avenidaNueva, int calleAvenida, DataGridView mapa)
        {
            if (calleAntigua == calleNueva && avenidaAntigua == avenidaNueva)
            {
                MessageBox.Show("El objeto permanecerá en ese lugar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (calleAvenida == 2 && ((streetEmergencyMatrix[calleNueva, avenidaNueva])!=null || (streetVehiclesMatrix[calleNueva, avenidaNueva] != null)))
                {
                    MessageBox.Show("El lugar ya lo ocupa un objeto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    v.intCalle = calleNueva;
                    v.intAvenida = avenidaNueva;
                    DataGridViewTextBoxCell celda = new DataGridViewTextBoxCell();
                    celda.Style.BackColor = Colores.colorCarretera;
                    mapa[6 * (avenidaAntigua - 1) + 5, 6 * (calleAntigua - 1)+3] = celda;

                    DataGridViewImageCell imgCelda = new DataGridViewImageCell();
                    imgCelda.Style.BackColor = Colores.colorCarretera;
                    imgCelda.Value = v.imgImage;
                    mapa[6 * (avenidaNueva - 1) + 5, 6 * (calleNueva - 1) + 3] = imgCelda;
                    streetVehiclesMatrix[calleNueva, avenidaNueva] = v;
                    streetVehiclesMatrix[calleAntigua, avenidaAntigua] = null;
                }

                if(calleAvenida == 1 && ((avenueEmergencyMatrix[calleNueva, avenidaNueva])!=null || (avenueVehiclesMatrix[calleNueva, avenidaNueva] != null)))
                {
                    MessageBox.Show("El lugar ya lo ocupa un objeto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    v.intCalle = calleNueva;
                    v.intAvenida = avenidaNueva;
                    v.intCalle = calleNueva;
                    v.intAvenida = avenidaNueva;
                    DataGridViewTextBoxCell celda = new DataGridViewTextBoxCell();
                    celda.Style.BackColor = Colores.colorCarretera;
                    mapa[6 * (avenidaAntigua - 1) + 5, 6 * (calleAntigua - 1) + 3] = celda;

                    DataGridViewImageCell imgCelda = new DataGridViewImageCell();
                    imgCelda.Style.BackColor = Colores.colorCarretera;
                    imgCelda.Value = v.imgImage;
                    mapa[6 * (avenidaNueva - 1) + 5, 6 * (calleNueva - 1) + 3] = imgCelda;
                    avenueVehiclesMatrix[calleNueva, avenidaNueva] = v;
                    avenueVehiclesMatrix[calleAntigua, avenidaAntigua] = null;
                }
            }
        }

        public void cambiarPosicionEmergencia(Emergencia v, int calleAntigua, int avenidaAntigua, int calleNueva, int avenidaNueva, int calleAvenida, DataGridView mapa)
        {
            if (calleAntigua == calleNueva && avenidaAntigua == avenidaNueva)
            {
                MessageBox.Show("El objeto permanecerá en ese lugar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (calleAvenida == 2 && ((streetEmergencyMatrix[calleNueva, avenidaNueva]) != null || (streetVehiclesMatrix[calleNueva, avenidaNueva] != null)))
                {
                    MessageBox.Show("El lugar ya lo ocupa un objeto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    v.intCalle = calleNueva;
                    v.intAvenida = avenidaNueva;
                    DataGridViewTextBoxCell celda = new DataGridViewTextBoxCell();
                    celda.Style.BackColor = Colores.colorCarretera;
                    mapa[6 * (avenidaAntigua - 1)+5, 6 * (calleAntigua - 1) + 3] = celda;

                    DataGridViewImageCell imgCelda = new DataGridViewImageCell();
                    imgCelda.Style.BackColor = Colores.colorCarretera;
                    imgCelda.Value = v.imgImage;
                    mapa[6 * (avenidaNueva - 1) + 5, 6 * (calleNueva - 1) + 3] = imgCelda;
                    streetEmergencyMatrix[calleNueva, avenidaNueva] = v;
                    streetEmergencyMatrix[calleAntigua, avenidaAntigua] = null;

                }

                if (calleAvenida == 1 && ((avenueEmergencyMatrix[calleNueva, avenidaNueva]) != null || (avenueVehiclesMatrix[calleNueva, avenidaNueva]) != null))
                {
                    MessageBox.Show("El lugar ya lo ocupa un objeto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    v.intCalle = calleNueva;
                    v.intAvenida = avenidaNueva;
                    v.intCalle = calleNueva;
                    v.intAvenida = avenidaNueva;
                    v.intCalle = calleNueva;
                    v.intAvenida = avenidaNueva;
                    DataGridViewTextBoxCell celda = new DataGridViewTextBoxCell();
                    celda.Style.BackColor = Colores.colorCarretera;
                    mapa[6 * (avenidaAntigua - 1) + 3, 6 * (calleAntigua - 1) + 5] = celda;

                    DataGridViewImageCell imgCelda = new DataGridViewImageCell();
                    imgCelda.Style.BackColor = Colores.colorCarretera;
                    imgCelda.Value = v.imgImage;
                    mapa[6 * (avenidaNueva - 1) + 3, 6 * (calleNueva - 1) + 5] = imgCelda;
                    avenueEmergencyMatrix[calleNueva, avenidaNueva] = v;
                    avenueEmergencyMatrix[calleAntigua, avenidaAntigua] = null;
                }
            }
        }

    }
}