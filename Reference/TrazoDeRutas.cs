using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace Proyecto2_SimuladorCiudades.Reference
{
    // Definición de clase estática TrazoDeRutas
    public static class TrazoDeRutas
    {
        /// <summary>
        /// Método que traza la ruta de emergencia
        /// </summary>
        /// <param name="dgvMapa">Mapa sobre el cual se dibuja</param>
        /// <param name="inicio">En donde inicia el trazo</param>
        /// <param name="final">En donde finaliza el trazo</param>
        /// <param name="emergencia">El servicio que se solicita</param>
        /// <param name="viewer">La ventana principal en la cual se muestran los resultados</param>
        /// <param name="direcciones">Arreglo que cuarda cada una de las posiciones a seguir para alcanzar el objetivo</param>
        /// <returns></returns>
        public static double trazarRutaEmergencia(DataGridView dgvMapa, address inicio, address final, eMedio emergencia, Viewer viewer, ArrayList direcciones)
        {
            if (direcciones != null)
            {
                foreach(DataGridViewCell celdaPorPintar in direcciones)
                {
                    celdaPorPintar.Style.BackColor = Colores.colorCamino;
                    if(celdaPorPintar is DataGridViewImageCell)
                    {
                        dgvMapa[celdaPorPintar.ColumnIndex, celdaPorPintar.RowIndex].Value = Properties.Resources.transparencia;
                    }
                }
            }
            direcciones.Clear();
            double EDA = 0;
            double ETA = 0;
            Color colorTrazo = Color.Orange;
            DataGridViewImageCell celdaImagen = new DataGridViewImageCell();
            celdaImagen.Value = Properties.Resources.FireAlarm;
            
            switch (emergencia)
            {
                case eMedio.Policía:
                    colorTrazo = Colores.colorTrazoPolicia;
                    celdaImagen.Value = Properties.Resources.Google_Alerts;
                    break;
                case eMedio.Ambulancia:
                    colorTrazo = Colores.colorTrazoAmbulancia;
                    celdaImagen.Value = Properties.Resources.FireAlarm;
                    break;
                case eMedio.Caminando:
                    colorTrazo = Colores.colorTrazoPersona;
                    celdaImagen.Value = Properties.Resources.GPS;
                    break;
            }
            inicio.intCalle = 6 * (inicio.intCalle - 1) + 2;
            inicio.intAvenida = 6 * (inicio.intAvenida - 1) + 2;
            final.intCalle = 6 * (final.intCalle - 1) + 2;
            final.intAvenida = 6 * (final.intAvenida - 1) + 2;

            dgvMapa[inicio.intAvenida + 1, inicio.intCalle + 1] = celdaImagen;
            direcciones.Add(dgvMapa[inicio.intAvenida + 1, inicio.intCalle + 1]);
            //direcciones.Add(dgvMapa[inicio.intAvenida + 1, inicio.intCalle + 1]);


            dgvMapa[inicio.intAvenida + 1, inicio.intCalle + 1].Style.BackColor = Color.DarkRed;
            while (inicio.intCalle != final.intCalle || inicio.intAvenida != final.intAvenida)
            {
                if (inicio.intCalle < final.intCalle)
                {
                    while (inicio.intCalle < final.intCalle)
                    {
                        inicio.intCalle += 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        direcciones.Add(dgvMapa[inicio.intAvenida, inicio.intCalle]);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
                else if (inicio.intCalle > final.intCalle)
                {
                    while (inicio.intCalle > final.intCalle)
                    {
                        inicio.intCalle -= 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        direcciones.Add(dgvMapa[inicio.intAvenida, inicio.intCalle]);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
                if (inicio.intAvenida > final.intAvenida)
                {
                    while (inicio.intAvenida > final.intAvenida)
                    {
                        inicio.intAvenida -= 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        direcciones.Add(dgvMapa[inicio.intAvenida, inicio.intCalle]);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
                else if (inicio.intAvenida < final.intAvenida)
                {
                    while (inicio.intAvenida < final.intAvenida)
                    {
                        inicio.intAvenida += 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        direcciones.Add(dgvMapa[inicio.intAvenida, inicio.intCalle]);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
            }
            return Math.Round(ETA * 60, 2);
        }
        /// <summary>
        /// Función que devuelve al policía más cercano en base a su posición
        /// </summary>
        /// <param name="policias"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static Vehicles.Policia buscarPoliciaCercano(ArrayList policias, address address)
        {
            ArrayList alDiferenciaPosicion = new ArrayList();

            foreach (Vehicles.Policia p in policias)
            {
                alDiferenciaPosicion.Add(Math.Abs(Math.Abs(address.intCalle - p.intCalle) + Math.Abs(address.intAvenida - p.intAvenida)));

            }
            foreach (Vehicles.Policia p in policias)
            {
                if ((Math.Abs(Math.Abs(address.intCalle - p.intCalle) + Math.Abs(address.intAvenida - p.intAvenida))) == (int)alDiferenciaPosicion.ToArray().Min())
                {
                    return p;
                }
            }
            return (Vehicles.Policia)policias[0];
        }
        /// <summary>
        /// Función que devuelve la ambulancia más cercana en base a su posición
        /// </summary>
        /// <returns>Ambulancia más cercana</returns>
        public static Vehicles.Ambulancia buscarAmbulanciaCercana(ArrayList operadores, address address)
        {

            ArrayList alDiferenciaPosicion = new ArrayList();

            foreach (Vehicles.Ambulancia a in operadores)
            {
                alDiferenciaPosicion.Add(Math.Abs(Math.Abs(address.intCalle - a.intCalle) + Math.Abs(address.intAvenida - a.intAvenida)));

            }


            foreach (Vehicles.Ambulancia a in operadores)
            {
                if (Math.Abs(Math.Abs(address.intCalle - a.intCalle) + Math.Abs(address.intAvenida) - a.intAvenida) == (int)alDiferenciaPosicion.ToArray().Min())
                {
                    return a;
                }

            }
            return (Vehicles.Ambulancia)operadores[0];
        }
        /// <summary>
        /// Calcula el tiempo con base al medio en el que se viaja y el horario en el que se ejecuta la instrucción
        /// </summary>
        /// <returns>EL tiempo que tarda determinado objeto en llegar a determinar a determinada posición</returns>
        private static double Tiempo(DateTime dtHoraFecha, double distanceM, eMedio medio)
        {
            double distance = distanceM / 1000;
            double tiempo = 0;

            if (medio == eMedio.Vehículo)
            {
                if (dtHoraFecha.DayOfWeek == DayOfWeek.Sunday || dtHoraFecha.DayOfWeek == DayOfWeek.Saturday)
                {
                    tiempo += distance / 40;
                }
                else if (dtHoraFecha.Hour > 22 && dtHoraFecha.Hour <= 24 || dtHoraFecha.Hour >= 0 && dtHoraFecha.Hour <= 5)
                {
                    tiempo = distance / 40;
                }
                else if (dtHoraFecha.Hour > 5 && dtHoraFecha.Hour <= 6)
                {
                    tiempo = distance / 20;
                }
                else if (dtHoraFecha.Hour > 6 && dtHoraFecha.Hour <= 9)
                {
                    tiempo = distance / 5;
                }
                else if (dtHoraFecha.Hour > 9 && dtHoraFecha.Hour <= 13)
                {
                    tiempo = distance / 30;
                }
                else if (dtHoraFecha.Hour > 13 && dtHoraFecha.Hour <= 15)
                {
                    tiempo = distance / 15;
                }
                else if (dtHoraFecha.Hour > 15 && dtHoraFecha.Hour <= 17)
                {
                    tiempo = distance / 20;
                }
                else if (dtHoraFecha.Hour > 17 && dtHoraFecha.Hour <= 20)
                {
                    tiempo = distance / 5;
                }
                else if (dtHoraFecha.Hour > 20 && dtHoraFecha.Hour <= 22)
                {
                    tiempo = distance / 30;
                }
            }
            else if (medio == eMedio.Ambulancia || medio == eMedio.Caminando || medio == eMedio.Policía)
            {
                tiempo = distance / 3;
            }

            return tiempo;
        }
        /// <summary>
        /// Traza la ruta más corta si se maneja en vehículo
        /// </summary>
        public static void trazarRutaVehiculo(DataGridView dgvMapa, address inicio, address final, Viewer viewer, ArrayList direcciones)
        {
            if (direcciones != null)
            {
                foreach (DataGridViewCell celdaPorPintar in direcciones)
                {
                    celdaPorPintar.Style.BackColor = Colores.colorCamino;
                    if (celdaPorPintar is DataGridViewImageCell)
                    {
                        dgvMapa[celdaPorPintar.ColumnIndex, celdaPorPintar.RowIndex].Value = Properties.Resources.transparencia;
                    }
                }
            }
            direcciones.Clear();

            double ETA = 0;
            int intCalleOrigen = (inicio.intCalle - 1) * 6 + 2;
            int intAvenidaOrigen = (inicio.intAvenida - 1) * 6 + 2;
            int intCalleDestino = (final.intCalle - 1) * 6 + 2;
            int intAvenidaDestino = (final.intAvenida - 1) * 6 + 2;
            while (intCalleOrigen != intCalleDestino || intAvenidaOrigen != intAvenidaDestino)
            {
                if (intCalleOrigen == intCalleDestino && intAvenidaOrigen > intAvenidaDestino && esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen == intCalleDestino && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen > intCalleDestino && !esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen < intCalleDestino && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);

                    }
                }

                else if (intCalleOrigen > intCalleDestino && !esCallePar(intAvenidaDestino) && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);

                    }
                }
                else if (intCalleOrigen > intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen < intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen < intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }

                else if (intCalleOrigen > intCalleDestino && !esCallePar(intCalleDestino) && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen < intCalleDestino && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen > intCalleDestino && esCallePar(intCalleDestino) && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen < intCalleDestino && intAvenidaOrigen > intAvenidaDestino && esCallePar(intCalleDestino) && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen > intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen < intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen < intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen > intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen > intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen > intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);

                    }
                }
                else if (intCalleOrigen < intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen < intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen == intCalleDestino && intAvenidaOrigen < intAvenidaDestino && esCallePar(intCalleOrigen) && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen > intCalleDestino && esCallePar(intAvenidaOrigen) && !esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen < intCalleDestino && !esCallePar(intAvenidaOrigen) && esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen == intCalleDestino && intAvenidaOrigen < intAvenidaDestino && esCallePar(intCalleOrigen) && !esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen == intCalleDestino && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intCalleOrigen) && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen < intCalleDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen > intCalleDestino && esCallePar(intAvenidaOrigen) && esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else if (intCalleOrigen == intCalleDestino && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        direcciones.Add(dgvMapa[intAvenidaOrigen, intCalleOrigen]);
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, eMedio.Vehículo);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error y no se pudo calcular la ruta más corta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

            }
                MessageBox.Show(String.Format("El tiempo estimado de llegada es de {0} minutos", Math.Round(ETA*60, 2)), "Tiempo estimado de llegada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Evalua si un número de columna del grid corresponde a un número par o impar de calle o avenida
        /// </summary>
        /// <param name="i">Número de columna o avenida del grid</param>
        /// <returns></returns>
        static bool esCallePar(double i)
        {
            if (((i + 4) / 6) % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Enum con el listado de posibles medio en los cuáles puede viajarse
        /// </summary>
        public enum eMedio
        {
            Policía,
            Ambulancia,
            Caminando,
            Vehículo
        }


    }
}
