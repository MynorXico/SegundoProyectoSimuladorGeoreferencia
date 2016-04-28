using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Proyecto2_SimuladorCiudades.Buildings;
using Proyecto2_SimuladorCiudades.Vehicles;

namespace Proyecto2_SimuladorCiudades.Forms
{
    public partial class Navegacion : Form
    {
        ArrayList[] alObjetos;
        ArrayList alVehiculos;
        ArrayList alRestaurantes;
        ArrayList alHospitales;
        ArrayList alGasolinera;
        ArrayList alPatrullas;
        ArrayList alAmbulancias;

        private int _intCalleOrigen;
        private int _intAvenidaOrigen;
        private int _intCalleDestino;
        private int _intAvenidaDestino;
        private address _adAddressOrigen;
        private address _adAddressDestino;

        public int intCalleOrigen
        {
            get
            {
                return _intCalleOrigen;
            }
        }
        public int intAvenidaOrigen
        {
            get
            {
                return _intAvenidaOrigen;
            }
        }
        public int intCalleDestino
        {
            get
            {
                return _intCalleDestino;
            }
        }
        public int intAvenidaDestino
        {
            get
            {
                return _intAvenidaDestino;
            }
        }
        public address adAddressOrigen;
        public address adAddressDestino;

        public Navegacion(ArrayList[] anObjectsArrayList)
        {
            InitializeComponent();
            alObjetos = anObjectsArrayList;
            alVehiculos = alObjetos[0];
            alRestaurantes = alObjetos[1];
            alHospitales = alObjetos[2];
            alGasolinera = alObjetos[3];
            alPatrullas = alObjetos[4];
            alAmbulancias = alObjetos[5];
        }

        private void seleccionTipoPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            elementoPartidaSeleccion.Items.Clear();
            elementoPartidaSeleccion.Text = "";
            switch (seleccionTipoPartida.Text)
            {
                case "Vehículo":
                    foreach (Vehiculo v in alVehiculos)
                    {
                        if (elementoDestinoSeleccion.Text != (v.strPlaca))
                            elementoPartidaSeleccion.Items.Add(String.Format("{0}", v.strPlaca));
                    }
                    break;
                case "Restaurante":
                    foreach (Restaurante r in alRestaurantes)
                    {
                        if (elementoDestinoSeleccion.Text != (r.strNombre))
                            elementoPartidaSeleccion.Items.Add(String.Format("{0}", r.strNombre));
                    }
                    break;
                case "Hospital":
                    foreach (Hospital h in alHospitales)
                    {
                        if (elementoDestinoSeleccion.Text != (h.strNombre))
                            elementoPartidaSeleccion.Items.Add(String.Format("{0}", h.strNombre));
                    }
                    break;
                case "Gasolinera":
                    foreach (Gasolinera g in alGasolinera)
                    {
                        if (elementoDestinoSeleccion.Text != (g.strNombre))
                            elementoPartidaSeleccion.Items.Add(String.Format("{0}", g.strNombre));
                    }
                    break;
                case "Policía":
                    foreach (Policia p in alPatrullas)
                    {
                        if (elementoDestinoSeleccion.Text != (p.strNombre))
                            elementoPartidaSeleccion.Items.Add(String.Format("{0}", p.strNombre));
                    }
                    break;
                case "Bombero":
                    foreach (Ambulancia a in alAmbulancias)
                    {
                        if (elementoDestinoSeleccion.Text != (a.strNombre))
                            elementoPartidaSeleccion.Items.Add(String.Format("{0}", a.strNombre));
                    }
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            elementoDestinoSeleccion.Items.Clear();
            elementoDestinoSeleccion.Text = "";
            switch (comboBox2.Text)
            {
                case "Vehículo":
                    foreach (Vehiculo v in alVehiculos)
                    {
                        if(elementoPartidaSeleccion.Text != (v.strPlaca))
                            elementoDestinoSeleccion.Items.Add(String.Format("{0}", v.strPlaca));
                    }
                    break;
                case "Restaurante":
                    foreach (Restaurante r in alRestaurantes)
                    {
                        if (elementoPartidaSeleccion.Text != (r.strNombre))
                            elementoDestinoSeleccion.Items.Add(String.Format("{0}", r.strNombre));
                    }
                    break;
                case "Hospital":
                    foreach (Hospital h in alHospitales)
                    {
                        if (elementoPartidaSeleccion.Text != (h.strNombre))
                            elementoDestinoSeleccion.Items.Add(String.Format("{0}", h.strNombre));
                    }
                    break;
                case "Gasolinera":
                    foreach (Gasolinera g in alGasolinera)
                    {
                        if (elementoPartidaSeleccion.Text != (g.strNombre))
                            elementoDestinoSeleccion.Items.Add(String.Format("{0}", g.strNombre));
                    }
                    break;
                case "Policía":
                    foreach (Policia p in alPatrullas)
                    {
                        if (elementoPartidaSeleccion.Text != (p.strNombre))
                            elementoDestinoSeleccion.Items.Add(String.Format("{0}", p.strNombre));
                    }
                    break;
                case "Bombero":
                    foreach (Ambulancia a in alAmbulancias)
                    {
                        if (elementoPartidaSeleccion.Text != (a.strNombre))
                            elementoDestinoSeleccion.Items.Add(String.Format("{0}", a.strNombre));
                    }
                    break;
            }
        }

        private void btnTrazarRuta_Click(object sender, EventArgs e)
        {
            #region Selecciona elemento de partida
            if (seleccionTipoPartida.Text == "Vehículo")
            {
                foreach (Vehiculo v in alVehiculos)
                {
                    if (elementoPartidaSeleccion.Text == v.strPlaca)
                    {
                        _intCalleOrigen = v.intCalle;
                        _intAvenidaOrigen = v.intAvenida;
                    }
                }
            }
            if (seleccionTipoPartida.Text == "Restaurante")
            {
                foreach (Restaurante r in alRestaurantes)
                {
                    if (elementoPartidaSeleccion.Text == r.strNombre)
                    {
                        _intCalleOrigen = r.adDireccion.intCalle;
                        _intAvenidaOrigen = r.adDireccion.intAvenida;
                    }
                }
            }
            if (seleccionTipoPartida.Text == "Hospital")
            {
                foreach (Hospital h in alHospitales)
                {
                    if (elementoPartidaSeleccion.Text == h.strNombre)
                    {
                        _intCalleOrigen = h.adDireccion.intCalle;
                        _intAvenidaOrigen = h.adDireccion.intAvenida;
                    }
                }
            }
            if (seleccionTipoPartida.Text == "Gasolinera")
            {
                foreach (Gasolinera g in alGasolinera)
                {
                    if (elementoPartidaSeleccion.Text == g.strNombre)
                    {
                        _intCalleOrigen = g.adDireccion.intCalle;
                        _intAvenidaOrigen = g.adDireccion.intAvenida;
                    }
                }
            }
            if (seleccionTipoPartida.Text == "Policía")
            {
                foreach (Policia p in alPatrullas)
                {
                    if (elementoPartidaSeleccion.Text == p.strNombre)
                    {
                        _intCalleOrigen = p.intCalle;
                        _intAvenidaOrigen = p.intAvenida;
                    }
                }
            }
            if (seleccionTipoPartida.Text == "Bombero")
            {
                foreach (Ambulancia a in alAmbulancias)
                {
                    if (elementoPartidaSeleccion.Text == a.strNombre)
                    {
                        _intCalleOrigen = a.intCalle;
                        _intAvenidaOrigen = a.intAvenida;
                    }
                }
            }
            #endregion Finaliza selección de partida
            #region Selecciona elemento de destino
            if (comboBox2.Text == "Vehículo")
            {
                foreach (Vehiculo v in alVehiculos)
                {
                    if (elementoDestinoSeleccion.Text == v.strPlaca)
                    {
                        _intCalleDestino = v.intCalle;
                        _intAvenidaDestino = v.intAvenida;
                    }
                }
            }
            if (comboBox2.Text == "Restaurante")
            {
                foreach (Restaurante r in alRestaurantes)
                {
                    if (elementoDestinoSeleccion.Text == r.strNombre)
                    {
                        _intCalleDestino = r.adDireccion.intCalle;
                        _intAvenidaDestino = r.adDireccion.intAvenida;

                    }
                }
            }
            if (comboBox2.Text == "Hospital")
            {
                foreach (Hospital h in alHospitales)
                {
                    if (elementoDestinoSeleccion.Text == h.strNombre)
                    {
                        _intCalleDestino = h.adDireccion.intCalle;
                        _intAvenidaDestino = h.adDireccion.intAvenida;
                    }
                }
            }
            if (comboBox2.Text == "Gasolinera")
            {
                foreach (Gasolinera g in alGasolinera)
                {
                    if (elementoDestinoSeleccion.Text == g.strNombre)
                    {
                        _intCalleDestino = g.adDireccion.intCalle;
                        _intAvenidaDestino = g.adDireccion.intAvenida;
                    }
                }
            }
            if (comboBox2.Text == "Policía")
            {
                foreach (Policia p in alPatrullas)
                {
                    if (elementoDestinoSeleccion.Text == p.strNombre)
                    {
                        _intCalleDestino = p.intCalle;
                        _intAvenidaDestino = p.intAvenida;
                    }
                }
            }
            if (comboBox2.Text == "Bombero")
            {
                foreach (Ambulancia a in alAmbulancias)
                {
                    if (elementoDestinoSeleccion.Text == a.strNombre)
                    {
                        _intCalleDestino = a.intCalle;
                        _intAvenidaDestino = a.intAvenida;
                    }
                }
            }
            #endregion Finaliza selección de destino
            adAddressDestino.intCalle = intCalleDestino;
            adAddressDestino.intAvenida = intAvenidaDestino;
            adAddressOrigen.intCalle = intCalleOrigen;
            adAddressOrigen.intAvenida = intAvenidaOrigen;
            this.Close();
        }

        private void seleccionTipoPartida_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void elementoPartidaSeleccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void elementoDestinoSeleccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
