namespace Proyecto2_SimuladorCiudades.Forms
{
    partial class Emergencia
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
            this.btnEmergency = new System.Windows.Forms.Button();
            this.rtxtEmergency = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.currentAvenue = new System.Windows.Forms.TextBox();
            this.currentStreet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServicio = new System.Windows.Forms.Label();
            this.imgServicio = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEmergency);
            this.panel1.Controls.Add(this.rtxtEmergency);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.currentAvenue);
            this.panel1.Controls.Add(this.currentStreet);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtServicio);
            this.panel1.Controls.Add(this.imgServicio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 268);
            this.panel1.TabIndex = 0;
            // 
            // btnEmergency
            // 
            this.btnEmergency.Location = new System.Drawing.Point(215, 229);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(94, 23);
            this.btnEmergency.TabIndex = 9;
            this.btnEmergency.Text = "Enviar Solicitud";
            this.btnEmergency.UseVisualStyleBackColor = true;
            this.btnEmergency.Click += new System.EventHandler(this.btnEmergency_Click);
            // 
            // rtxtEmergency
            // 
            this.rtxtEmergency.AcceptsTab = true;
            this.rtxtEmergency.AutoWordSelection = true;
            this.rtxtEmergency.BulletIndent = 2;
            this.rtxtEmergency.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtEmergency.Location = new System.Drawing.Point(143, 141);
            this.rtxtEmergency.Name = "rtxtEmergency";
            this.rtxtEmergency.Size = new System.Drawing.Size(225, 82);
            this.rtxtEmergency.TabIndex = 8;
            this.rtxtEmergency.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(140, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Breve descripción de la emergencia";
            // 
            // currentAvenue
            // 
            this.currentAvenue.Location = new System.Drawing.Point(284, 85);
            this.currentAvenue.Name = "currentAvenue";
            this.currentAvenue.Size = new System.Drawing.Size(25, 20);
            this.currentAvenue.TabIndex = 6;
            this.currentAvenue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.currentAvenue_KeyPress);
            // 
            // currentStreet
            // 
            this.currentStreet.Location = new System.Drawing.Point(182, 85);
            this.currentStreet.Name = "currentStreet";
            this.currentStreet.Size = new System.Drawing.Size(25, 20);
            this.currentStreet.TabIndex = 5;
            this.currentStreet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.currentStreet_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(224, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Avenida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Calle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese su Dirección Actual";
            // 
            // txtServicio
            // 
            this.txtServicio.AutoSize = true;
            this.txtServicio.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServicio.Location = new System.Drawing.Point(168, 19);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(164, 23);
            this.txtServicio.TabIndex = 1;
            this.txtServicio.Text = "solicitudBomberos";
            // 
            // imgServicio
            // 
            this.imgServicio.Location = new System.Drawing.Point(25, 90);
            this.imgServicio.Name = "imgServicio";
            this.imgServicio.Size = new System.Drawing.Size(96, 96);
            this.imgServicio.TabIndex = 0;
            this.imgServicio.TabStop = false;
            // 
            // Emergencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 268);
            this.Controls.Add(this.panel1);
            this.Name = "Emergencia";
            this.Text = "Title";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox currentAvenue;
        private System.Windows.Forms.TextBox currentStreet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtServicio;
        private System.Windows.Forms.PictureBox imgServicio;
        private System.Windows.Forms.RichTextBox rtxtEmergency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEmergency;
    }
}