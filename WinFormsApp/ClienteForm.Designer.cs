namespace WinFormsApp
{
    partial class ClienteForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.crearClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarClienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.chbTieneGarante = new System.Windows.Forms.CheckBox();
            this.cmbGarantesDisponibles = new System.Windows.Forms.ComboBox();
            this.dgwClientesGarantizados = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwClientesGarantizados)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(739, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteToolStripMenuItem,
            this.toolStripSeparator1,
            this.crearClienteToolStripMenuItem,
            this.actualizarClienteToolStripMenuItem1,
            this.eliminarClienteToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // nuevoClienteToolStripMenuItem
            // 
            this.nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            this.nuevoClienteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nuevoClienteToolStripMenuItem.Text = "Nuevo Cliente";
            this.nuevoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // crearClienteToolStripMenuItem
            // 
            this.crearClienteToolStripMenuItem.Name = "crearClienteToolStripMenuItem";
            this.crearClienteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.crearClienteToolStripMenuItem.Text = "Crear Cliente";
            this.crearClienteToolStripMenuItem.Click += new System.EventHandler(this.crearClienteToolStripMenuItem_Click);
            // 
            // actualizarClienteToolStripMenuItem1
            // 
            this.actualizarClienteToolStripMenuItem1.Name = "actualizarClienteToolStripMenuItem1";
            this.actualizarClienteToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.actualizarClienteToolStripMenuItem1.Text = "Actualizar Cliente";
            this.actualizarClienteToolStripMenuItem1.Click += new System.EventHandler(this.actualizarClienteToolStripMenuItem1_Click);
            // 
            // eliminarClienteToolStripMenuItem
            // 
            this.eliminarClienteToolStripMenuItem.Name = "eliminarClienteToolStripMenuItem";
            this.eliminarClienteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.eliminarClienteToolStripMenuItem.Text = "Eliminar Cliente";
            this.eliminarClienteToolStripMenuItem.Click += new System.EventHandler(this.eliminarClienteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cedula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Edad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Direccion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Telefono:";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(136, 64);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(125, 27);
            this.txtCedula.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(136, 107);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(329, 27);
            this.txtNombre.TabIndex = 7;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(136, 156);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(73, 27);
            this.txtEdad.TabIndex = 8;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(306, 156);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(158, 27);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(136, 217);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(329, 27);
            this.txtDireccion.TabIndex = 10;
            // 
            // chbTieneGarante
            // 
            this.chbTieneGarante.AutoSize = true;
            this.chbTieneGarante.Location = new System.Drawing.Point(48, 283);
            this.chbTieneGarante.Name = "chbTieneGarante";
            this.chbTieneGarante.Size = new System.Drawing.Size(90, 24);
            this.chbTieneGarante.TabIndex = 11;
            this.chbTieneGarante.Text = "Garante?";
            this.chbTieneGarante.UseVisualStyleBackColor = true;
            this.chbTieneGarante.CheckedChanged += new System.EventHandler(this.chbTieneGarante_CheckedChanged);
            // 
            // cmbGarantesDisponibles
            // 
            this.cmbGarantesDisponibles.FormattingEnabled = true;
            this.cmbGarantesDisponibles.Location = new System.Drawing.Point(136, 279);
            this.cmbGarantesDisponibles.Name = "cmbGarantesDisponibles";
            this.cmbGarantesDisponibles.Size = new System.Drawing.Size(329, 28);
            this.cmbGarantesDisponibles.TabIndex = 12;
            // 
            // dgwClientesGarantizados
            // 
            this.dgwClientesGarantizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwClientesGarantizados.Location = new System.Drawing.Point(63, 375);
            this.dgwClientesGarantizados.Name = "dgwClientesGarantizados";
            this.dgwClientesGarantizados.RowHeadersWidth = 51;
            this.dgwClientesGarantizados.RowTemplate.Height = 29;
            this.dgwClientesGarantizados.Size = new System.Drawing.Size(610, 253);
            this.dgwClientesGarantizados.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Lista de Clientes Garantizados:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(269, 64);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(86, 31);
            this.btnBuscarCliente.TabIndex = 15;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 648);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgwClientesGarantizados);
            this.Controls.Add(this.cmbGarantesDisponibles);
            this.Controls.Add(this.chbTieneGarante);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClienteForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ClienteForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwClientesGarantizados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gestionToolStripMenuItem;
        private ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem crearClienteToolStripMenuItem;
        private ToolStripMenuItem actualizarClienteToolStripMenuItem1;
        private ToolStripMenuItem eliminarClienteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCedula;
        private TextBox txtNombre;
        private TextBox txtEdad;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private CheckBox chbTieneGarante;
        private ComboBox cmbGarantesDisponibles;
        private DataGridView dgwClientesGarantizados;
        private Label label6;
        private Button btnBuscarCliente;
    }
}