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
    public static class TrazoDeRutas
    {
        public static double trazarRutaEmergencia(DataGridView dgvMapa, address inicio, address final, eMedio emergencia, Viewer viewer)
        {  

            double EDA = 0;
            double ETA = 0;
            Color colorTrazo = Color.Transparent;
            DataGridViewImageCell celdaImagen = new DataGridViewImageCell();
            celdaImagen.Value = Properties.Resources.SirenaEncendida;
            switch (emergencia)
            {
                case eMedio.Policía:
                    colorTrazo = Colores.colorTrazoPolicia;
                    break;
                case eMedio.Ambulancia:
                    colorTrazo = Colores.colorTrazoAmbulancia;
                    break;
                case eMedio.Caminando:
                    colorTrazo = Colores.colorTrazoPersona;
                    break;
            }
            inicio.intCalle = 6*(inicio.intCalle-1)+2;
            inicio.intAvenida = 6 * (inicio.intAvenida-1) + 2;
            final.intCalle = 6 * (final.intCalle-1) + 2;
            final.intAvenida = 6 * (final.intAvenida-1) + 2;            

            dgvMapa[inicio.intAvenida+1, inicio.intCalle + 1] = celdaImagen;
            dgvMapa[inicio.intAvenida+1, inicio.intCalle+1].Style.BackColor = Color.DarkRed;
            while(inicio.intCalle != final.intCalle || inicio.intAvenida != final.intAvenida)
            {
                if(inicio.intCalle < final.intCalle)
                {
                    while(inicio.intCalle < final.intCalle)
                    {
                        inicio.intCalle += 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
                else if(inicio.intCalle > final.intCalle)
                {
                    while(inicio.intCalle > final.intCalle)
                    {
                        inicio.intCalle -= 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
                if(inicio.intAvenida > final.intAvenida)
                {
                    while(inicio.intAvenida > final.intAvenida)
                    {
                        inicio.intAvenida -= 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
                else if(inicio.intAvenida < final.intAvenida)
                {
                    while(inicio.intAvenida < final.intAvenida)
                    {
                        inicio.intAvenida += 1;
                        EDA += 100 / 6;
                        ETA += Tiempo(viewer.dtFecha, 100 / 6, emergencia);
                        dgvMapa[inicio.intAvenida, inicio.intCalle].Style.BackColor = colorTrazo;
                    }
                }
            }
            return Math.Round(ETA*60, 2);
        }
        public static Vehicles.Policia buscarPoliciaCercano(ArrayList policias, address address)
        {
            ArrayList alDiferenciaPosicion = new ArrayList();

            foreach (Vehicles.Policia p in policias)
            {
                alDiferenciaPosicion.Add(Math.Abs(Math.Abs(address.intCalle - p.intCalle) + Math.Abs(address.intAvenida - p.intAvenida)));
                
            }


            foreach (Vehicles.Policia p in policias)
            {
                if(Math.Abs(Math.Abs(address.intCalle - p.intCalle) + Math.Abs(address.intAvenida) - p.intAvenida) == (int) alDiferenciaPosicion.ToArray().Min())
                {
                    return p;
                }

            }return (Vehicles.Policia)policias[0];
        }
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
                else if (dtHoraFecha.Hour > 20 && dtHoraFecha.Hour <= 10)
                {
                    tiempo = distance / 30;
                }
            }else if(medio == eMedio.Ambulancia || medio == eMedio.Caminando || medio == eMedio.Policía)
            {
                tiempo = distance / 3;
            }

            return tiempo;
        }
        public static void trazarRutaVehiculo(DataGridView dgvMapa, address inicio, address final, Viewer viewer)
        {
            int intCalleOrigen = (inicio.intCalle-1)*6+2;
            int intAvenidaOrigen = (inicio.intAvenida-1)*6+2;
            int intCalleDestino = (final.intCalle-1)*6+2;
            int intAvenidaDestino = (final.intAvenida-1)*6+2;
            while (intCalleOrigen != intCalleDestino || intAvenidaOrigen != intAvenidaDestino)
            {
                if (intCalleOrigen == intCalleDestino && intAvenidaOrigen > intAvenidaDestino && esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen == intCalleDestino && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                        intAvenidaOrigen += 1;
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen > intCalleDestino && !esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intAvenidaOrigen == intAvenidaDestino && intCalleOrigen < intCalleDestino && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }

                else if (intCalleOrigen > intCalleDestino && !esCallePar(intAvenidaDestino) && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intCalleOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen > intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen < intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen < intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }


                else if (intCalleOrigen > intCalleDestino && !esCallePar(intCalleDestino) && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen < intCalleDestino && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen > intCalleDestino && esCallePar(intCalleDestino) && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen < intCalleDestino && intAvenidaOrigen > intAvenidaDestino && esCallePar(intCalleDestino) && esCallePar(intAvenidaOrigen))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen > intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen < intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen < intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen > intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen > intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if (intCalleOrigen > intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen < intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intCalleOrigen>intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen>intAvenidaDestino && esCallePar(intAvenidaOrigen) && esCallePar(intAvenidaDestino))
                {
                    for(int i=0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intCalleOrigen<intCalleDestino && !esCallePar(intCalleOrigen) && intAvenidaOrigen<intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for(int i= 0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intCalleOrigen<intCalleDestino && esCallePar(intCalleOrigen) && intAvenidaOrigen>intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intAvenidaDestino))
                {
                    for(int i= 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intCalleOrigen==intCalleDestino && intAvenidaOrigen<intAvenidaDestino && esCallePar(intCalleOrigen) && esCallePar(intAvenidaOrigen))
                {
                    for(int i= 0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intAvenidaOrigen==intAvenidaDestino  && intCalleOrigen>intCalleDestino && esCallePar(intAvenidaOrigen) && !esCallePar(intCalleOrigen))
                {
                    for(int i=0; i<6; i++)
                    {
                        intAvenidaOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intAvenidaOrigen==intAvenidaDestino && intCalleOrigen<intCalleDestino && !esCallePar(intAvenidaOrigen) && esCallePar(intCalleOrigen))
                {
                    for(int i=0; i<6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intCalleOrigen==intCalleDestino && intAvenidaOrigen<intAvenidaDestino && esCallePar(intCalleOrigen) && !esCallePar(intAvenidaOrigen))
                {
                    for(int i=0; i <6; i++)
                    {
                        intCalleOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intCalleOrigen==intCalleDestino && intAvenidaOrigen>intAvenidaDestino && !esCallePar(intCalleOrigen) && esCallePar(intAvenidaOrigen))
                {
                    for(int i=0; i < 6; i++)
                    {
                        intCalleOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }else if(intAvenidaOrigen==intAvenidaDestino && intCalleOrigen<intCalleDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intCalleOrigen))
                {
                    for(int i=0; i < 6; i++)
                    {
                        intAvenidaOrigen += 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else if(intAvenidaOrigen==intAvenidaDestino && intCalleOrigen>intCalleDestino && esCallePar(intAvenidaOrigen) && intCalleOrigen % 2 == 0)
                {
                    for(int i= 0; i < 6; i++)
                    {
                        intAvenidaOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }else if(intCalleOrigen == intCalleDestino && intAvenidaOrigen>intAvenidaDestino && !esCallePar(intAvenidaOrigen) && !esCallePar(intCalleOrigen))
                {
                    for(int i=0; i < 6; i++)
                    {
                        intCalleOrigen -= 1;
                        dgvMapa[intAvenidaOrigen, intCalleOrigen].Style.BackColor = Colores.colorAcera;
                    }
                }
                else
                {
                    Console.WriteLine("No se pudo calcular la ruta :'(");
                    break;
                }
            }
        }

        static bool esCallePar(double i)
        {
            if (((i+4)/6)%2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public enum eMedio{
            Policía,
            Ambulancia,
            Caminando,
            Vehículo
        }   


    }
}
