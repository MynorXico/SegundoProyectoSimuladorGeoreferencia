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
                c representa carretera
                a representa acera
                *
            */

            string[,] mapMatrix = new string[DataGridView.Rows.Count, DataGridView.Columns.Count];
            for (int i = 0; i < mapMatrix.GetLength(0); i++ )
            {
                for (int j = 0; j < mapMatrix.GetLength(1); j++)
                {
                    if (DataGridView[j, i].Style.BackColor == System.Drawing.Color.Gray)
                    {
                        mapMatrix[i, j] = "c";
                    }else if (DataGridView[j, i].Style.BackColor == System.Drawing.Color.Yellow)
                    {
                        mapMatrix[i, j] = "a";
                    }
                    else
                    {
                        mapMatrix[i, j] = "*";
                    }
                }
            }

            for (int i = 0; i < mapMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < mapMatrix.GetLength(1); j++)
                {
                    Console.Write(mapMatrix[i, j]);
                }Console.WriteLine();
            }

        }
    }
}
