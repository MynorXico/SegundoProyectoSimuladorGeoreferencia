namespace Proyecto2_SimuladorCiudades.Forms
{
    partial class Navegacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTrazarRuta = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.elementoDestinoSeleccion = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.elementoPartidaSeleccion = new System.Windows.Forms.ComboBox();
            this.seleccionTipoPartida = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnTrazarRuta);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 215);
            this.panel1.TabIndex = 0;
            // 
            // btnTrazarRuta
            // 
            this.btnTrazarRuta.Location = new System.Drawing.Point(219, 182);
            this.btnTrazarRuta.Name = "btnTrazarRuta";
            this.btnTrazarRuta.Size = new System.Drawing.Size(85, 23);
            this.btnTrazarRuta.TabIndex = 4;
            this.btnTrazarRuta.Text = "Trazar Ruta";
            this.btnTrazarRuta.UseVisualStyleBackColor = true;
            this.btnTrazarRuta.Click += new System.EventHandler(this.btnTrazarRuta_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.elementoDestinoSeleccion);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(281, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 117);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Elemento de Destino";
            // 
            // elementoDestinoSeleccion
            // 
            this.elementoDestinoSeleccion.FormattingEnabled = true;
            this.elementoDestinoSeleccion.Location = new System.Drawing.Point(7, 75);
            this.elementoDestinoSeleccion.Name = "elementoDestinoSeleccion";
            this.elementoDestinoSeleccion.Size = new System.Drawing.Size(181, 26);
            this.elementoDestinoSeleccion.TabIndex = 1;
            this.elementoDestinoSeleccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.elementoDestinoSeleccion_KeyPress);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Vehículo",
            "Restaurante",
            "Hospital",
            "Gasolinera",
            "Policía",
            "Bombero"});
            this.comboBox2.Location = new System.Drawing.Point(7, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(181, 26);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox2_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.elementoPartidaSeleccion);
            this.groupBox1.Controls.Add(this.seleccionTipoPartida);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(52, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 117);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elemento de Partida";
            // 
            // elementoPartidaSeleccion
            // 
            this.elementoPartidaSeleccion.FormattingEnabled = true;
            this.elementoPartidaSeleccion.Location = new System.Drawing.Point(7, 75);
            this.elementoPartidaSeleccion.Name = "elementoPartidaSeleccion";
            this.elementoPartidaSeleccion.Size = new System.Drawing.Size(181, 26);
            this.elementoPartidaSeleccion.TabIndex = 1;
            this.elementoPartidaSeleccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.elementoPartidaSeleccion_KeyPress);
            // 
            // seleccionTipoPartida
            // 
            this.seleccionTipoPartida.FormattingEnabled = true;
            this.seleccionTipoPartida.Items.AddRange(new object[] {
            "Vehículo",
            "Restaurante",
            "Hospital",
            "Gasolinera",
            "Policía",
            "Bombero"});
            this.seleccionTipoPartida.Location = new System.Drawing.Point(7, 26);
            this.seleccionTipoPartida.Name = "seleccionTipoPartida";
            this.seleccionTipoPartida.Size = new System.Drawing.Size(181, 26);
            this.seleccionTipoPartida.TabIndex = 0;
            this.seleccionTipoPartida.SelectedIndexChanged += new System.EventHandler(this.seleccionTipoPartida_SelectedIndexChanged);
            this.seleccionTipoPartida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.seleccionTipoPartida_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(177, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Navegación por el Mapa";
            // 
            // Navegacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 217);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(536, 256);
            this.Name = "Navegacion";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "Navegacion en el mapa";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox seleccionTipoPartida;
        private System.Windows.Forms.ComboBox elementoPartidaSeleccion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox elementoDestinoSeleccion;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnTrazarRuta;
    }
}