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
        public ViewerControl(DataGridView DataGridView)
        {
            /*
                Nomenclatura para creación de matriz
                ╔        ╦                        ╗  
                ║Símbolo ║Significado             ║
                ║c       ║Carretera               ║ 
                ║a       ║Acera                   ║
                ║*       ║Edificio                ║
                ║        ║Espacio entre carretera;║
                                                  ╝
                c representa carretera
                a representa acera
                * representa edificio
                / espacio entre carretera;
            */

            string[,] mapMatrix = new string[DataGridView.Rows.Count, DataGridView.Columns.Count];

            #region Creación de la matriz
            // Creación de la matriz
            for (int i = 0; i < mapMatrix.GetLength(0); i++ )
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
                    else if (DataGridView[j, i].Style.BackColor == System.Drawing.Color.DarkBlue)
                    {
                        mapMatrix[i, j] = "*";
                    }
                    else
                    {
                        mapMatrix[i, j] = "|";
                    }
                }
            }
            #endregion



        }
    }
}
