namespace Proyecto2_SimuladorCiudades
{
    partial class Viewer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mapDGV = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.browsingGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.walkingBrowsingButton = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DrivingBrowsingButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emergencyButton = new System.Windows.Forms.PictureBox();
            this.PathCleaner = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnBorrarRuta = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapDGV)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.browsingGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.walkingBrowsingButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrivingBrowsingButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emergencyButton)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrarRuta)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.mapDGV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PathCleaner, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.17809F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.82192F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 733);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mapDGV
            // 
            this.mapDGV.AllowUserToAddRows = false;
            this.mapDGV.AllowUserToDeleteRows = false;
            this.mapDGV.AllowUserToResizeColumns = false;
            this.mapDGV.AllowUserToResizeRows = false;
            this.mapDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mapDGV.ColumnHeadersVisible = false;
            this.mapDGV.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mapDGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.mapDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapDGV.Location = new System.Drawing.Point(6, 6);
            this.mapDGV.MultiSelect = false;
            this.mapDGV.Name = "mapDGV";
            this.mapDGV.ReadOnly = true;
            this.mapDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.mapDGV.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.mapDGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.mapDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mapDGV.Size = new System.Drawing.Size(1065, 567);
            this.mapDGV.TabIndex = 0;
            this.mapDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mapDGV_CellClick);
            this.mapDGV.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.mapDGV_CellMouseEnter);
            this.mapDGV.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.mapDGV_CellMouseLeave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.browsingGroup, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1080, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 483F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(183, 567);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha y Hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(6, 52);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(151, 26);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "ddd dd/MM/AA";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Candara", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(6, 19);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(161, 33);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "hh:mm:ss XX";
            // 
            // browsingGroup
            // 
            this.browsingGroup.Controls.Add(this.label3);
            this.browsingGroup.Controls.Add(this.walkingBrowsingButton);
            this.browsingGroup.Controls.Add(this.label2);
            this.browsingGroup.Controls.Add(this.DrivingBrowsingButton);
            this.browsingGroup.Controls.Add(this.label1);
            this.browsingGroup.Controls.Add(this.emergencyButton);
            this.browsingGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.browsingGroup.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browsingGroup.Location = new System.Drawing.Point(3, 87);
            this.browsingGroup.Name = "browsingGroup";
            this.browsingGroup.Size = new System.Drawing.Size(177, 432);
            this.browsingGroup.TabIndex = 1;
            this.browsingGroup.TabStop = false;
            this.browsingGroup.Text = "Botones de Navegación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11F);
            this.label3.Location = new System.Drawing.Point(6, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Navegación sin vehículo";
            // 
            // walkingBrowsingButton
            // 
            this.walkingBrowsingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.walkingBrowsingButton.Image = global::Proyecto2_SimuladorCiudades.Properties.Resources.Walking;
            this.walkingBrowsingButton.Location = new System.Drawing.Point(37, 298);
            this.walkingBrowsingButton.Name = "walkingBrowsingButton";
            this.walkingBrowsingButton.Size = new System.Drawing.Size(100, 100);
            this.walkingBrowsingButton.TabIndex = 4;
            this.walkingBrowsingButton.TabStop = false;
            this.walkingBrowsingButton.Click += new System.EventHandler(this.walkingBrowsingButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11F);
            this.label2.Location = new System.Drawing.Point(14, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Navegación con Vehículo";
            // 
            // DrivingBrowsingButton
            // 
            this.DrivingBrowsingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrivingBrowsingButton.Image = global::Proyecto2_SimuladorCiudades.Properties.Resources.imgSteeringWheel;
            this.DrivingBrowsingButton.Location = new System.Drawing.Point(37, 156);
            this.DrivingBrowsingButton.Name = "DrivingBrowsingButton";
            this.DrivingBrowsingButton.Size = new System.Drawing.Size(100, 100);
            this.DrivingBrowsingButton.TabIndex = 2;
            this.DrivingBrowsingButton.TabStop = false;
            this.DrivingBrowsingButton.Click += new System.EventHandler(this.DrivingBrowsingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11F);
            this.label1.Location = new System.Drawing.Point(16, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Llamada de Emergencia";
            // 
            // emergencyButton
            // 
            this.emergencyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emergencyButton.Image = global::Proyecto2_SimuladorCiudades.Properties.Resources.Siren;
            this.emergencyButton.Location = new System.Drawing.Point(37, 19);
            this.emergencyButton.Name = "emergencyButton";
            this.emergencyButton.Size = new System.Drawing.Size(100, 100);
            this.emergencyButton.TabIndex = 0;
            this.emergencyButton.TabStop = false;
            this.emergencyButton.Click += new System.EventHandler(this.emergencyButton_Click);
            // 
            // PathCleaner
            // 
            this.PathCleaner.Location = new System.Drawing.Point(1080, 582);
            this.PathCleaner.Name = "PathCleaner";
            this.PathCleaner.Size = new System.Drawing.Size(183, 103);
            this.PathCleaner.TabIndex = 2;
            this.PathCleaner.Text = "LimpiarRutas";
            this.PathCleaner.UseVisualStyleBackColor = true;
            this.PathCleaner.Click += new System.EventHandler(this.PathCleaner_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnBorrarRuta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1065, 145);
            this.panel1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnBorrarRuta
            // 
            this.btnBorrarRuta.BackgroundImage = global::Proyecto2_SimuladorCiudades.Properties.Resources.Erase_104;
            this.btnBorrarRuta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBorrarRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarRuta.Location = new System.Drawing.Point(27, 13);
            this.btnBorrarRuta.Name = "btnBorrarRuta";
            this.btnBorrarRuta.Size = new System.Drawing.Size(100, 100);
            this.btnBorrarRuta.TabIndex = 6;
            this.btnBorrarRuta.TabStop = false;
            this.btnBorrarRuta.Click += new System.EventHandler(this.btnBorrarRuta_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11F);
            this.label4.Location = new System.Drawing.Point(35, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Borrar Ruta";
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1269, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Viewer";
            this.Text = "Simulador de Georeferencia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapDGV)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.browsingGroup.ResumeLayout(false);
            this.browsingGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.walkingBrowsingButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrivingBrowsingButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emergencyButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrarRuta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView mapDGV;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox browsingGroup;
        private System.Windows.Forms.PictureBox emergencyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox DrivingBrowsingButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox walkingBrowsingButton;
        private System.Windows.Forms.Button PathCleaner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnBorrarRuta;
    }
}