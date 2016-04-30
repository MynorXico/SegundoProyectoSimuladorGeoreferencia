using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto2_SimuladorCiudades
{
    public static class MessageBoxPersonalizado
    {
        // Creación de método Show para un objeto MessageBoxPersonalizado
        public static DialogResult Show(string Texto, string Titulo, eDialogButtons Botones, Image Imagen)
        {
            // Crea un nuevo MessageForm()
            MessageForm message = new MessageForm();
            // Asigna al objeto MessageForm los atributos pasados en el constructor
            message.Text = Titulo;
            message.picImage.ErrorImage = Imagen;
            message.lblText.Text = Texto;
            switch (Botones)
            {
                case eDialogButtons.OK:
                message.btnOK.Location = message.btnOK.Location;
                break;
            }

            if (message.lblText.Height > 64)
                message.Height = (message.lblText.Top + message.lblText.Height) + 78;
            
            return message.ShowDialog();
        }

    }

    /// <summary>
    /// Enumeración con posibles opciones de botones
    /// </summary>
    public enum eDialogButtons
    {
        OK
    }
}
