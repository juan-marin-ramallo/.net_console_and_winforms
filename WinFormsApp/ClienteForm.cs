using Controlador;
using Entidad;

namespace WinFormsApp
{
    public partial class ClienteForm : Form
    {
        ClienteControlador clienteControlador;
        ClienteEntidad? cliente, garante;
        List<ClienteEntidad>? clientesGarantizados, posiblesGarantes;

        public ClienteForm()
        {
            InitializeComponent();

            clienteControlador = new ClienteControlador();

            
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            cargarComboConTodosLosClientes();

            inicializarFormuario();
        }

        private void cargarComboConTodosLosClientes() {
            try
            {
                posiblesGarantes = clienteControlador.consultarTodosLosClientes();

                cmbGarantesDisponibles.DataSource = posiblesGarantes;
                cmbGarantesDisponibles.DisplayMember = "nombre";
                cmbGarantesDisponibles.ValueMember = "codCliente";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento problema al cargar clientes " + ex.Message,"Mensaje de Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cargarComboConGarantesDisponibles(Int32 codCliente)
        {
            try
            {
                posiblesGarantes = clienteControlador.consultarGarantesDisponibles(codCliente);

                cmbGarantesDisponibles.DataSource = posiblesGarantes;
                cmbGarantesDisponibles.DisplayMember = "nombre";
                cmbGarantesDisponibles.ValueMember = "codCliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento problema al cargar garantes disponibles " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crearClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCedula.Text.Equals(""))
                    MessageBox.Show("Por favor ingrese la cedula", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (txtNombre.Text.Equals(""))
                    MessageBox.Show("Por favor ingrese el nombre", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (txtEdad.Text.Equals(""))
                    MessageBox.Show("Por favor ingrese la edad", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    cliente = new ClienteEntidad();
                    cliente.Cedula = txtCedula.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Edad = Byte.Parse(txtEdad.Text);

                    if (!txtDireccion.Equals(""))
                        cliente.Direccion = txtDireccion.Text;

                    if (!txtTelefono.Equals(""))
                        cliente.Telefono = txtTelefono.Text;

                    if (chbTieneGarante.Checked)
                    {
                        garante = (ClienteEntidad)cmbGarantesDisponibles.SelectedItem;
                        cliente.CodGarante = garante.CodCliente;
                    }

                    if (clienteControlador.insertarCliente(cliente))
                        MessageBox.Show("Cliente ingresado con exito", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Cliente NO pudo ser ingresado", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    inicializarFormuario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento problema al crear cliente " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inicializarFormuario();
            txtCedula.Focus();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCedula.Text.Equals(""))
                    MessageBox.Show("Por favor ingrese la cedula", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else { 
                    cliente = clienteControlador.consultaClientePorCedula(txtCedula.Text);

                    if (cliente == null)
                        MessageBox.Show("No existe cliente con esa cedula", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        #region Datos personales cliente
                        txtNombre.Text = cliente.Nombre;
                        txtCedula.Text = cliente.Cedula;    
                        txtEdad.Text = cliente.Edad.ToString();
                        txtDireccion.Text = cliente.Direccion ?? "";
                        txtTelefono.Text = cliente.Telefono ?? "";
                        #endregion

                        #region Informacion Garante
                        cargarComboConGarantesDisponibles(cliente.CodCliente);

                        if (cliente.CodGarante != null)
                        {
                            chbTieneGarante.Checked = true;
                            garante = clienteControlador.consultaClientePorCodigo(cliente.CodGarante);

                            cmbGarantesDisponibles.SelectedIndex = cmbGarantesDisponibles.FindString(garante?.Nombre);
                        }
                        #endregion

                        #region Informacion clientes garantizados
                        clientesGarantizados = clienteControlador.consultarClientesPorGarante(cliente.CodCliente);

                        if (clientesGarantizados?.Count > 0)
                        {
                            dgwClientesGarantizados.DataSource = clientesGarantizados;
                            dgwClientesGarantizados.Columns["CodCliente"].Visible = false;
                            dgwClientesGarantizados.Columns["CodGarante"].Visible = false;
                        }
                        else
                            dgwClientesGarantizados.DataSource = null;

                        dgwClientesGarantizados.Refresh();  
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento problema al buscar cliente " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cliente == null)
                    MessageBox.Show("Por favor consulte primero el cliente a eliminar ", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else {
                    clientesGarantizados = clienteControlador.consultarClientesPorGarante(cliente.CodCliente);

                    if (clientesGarantizados?.Count > 0)
                        MessageBox.Show("Cliente no puede ser eliminado porque es garante", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else {
                        if (clienteControlador.eliminarCliente(cliente.CodCliente))
                            MessageBox.Show("Cliente eliminado con exito", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Cliente no pudo ser eliminado", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                                        
                    inicializarFormuario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento problema al eliminar cliente " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cliente == null)
                    MessageBox.Show("Por favor consulte primero el cliente a modificar ", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else {
                    if (txtCedula.Text.Equals(""))
                        MessageBox.Show("Por favor ingresar la cedula", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtNombre.Text.Equals(""))
                        MessageBox.Show("Por favor ingresar el nombre", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtEdad.Text.Equals(""))
                        MessageBox.Show("Por favor ingresar la edad", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else {
                        cliente.Cedula = txtCedula.Text;
                        cliente.Nombre = txtNombre.Text;
                        cliente.Direccion = txtDireccion.Text;
                        cliente.Edad = Byte.Parse(txtEdad.Text);

                        if (chbTieneGarante.Checked)
                        {
                            garante = (ClienteEntidad) cmbGarantesDisponibles.SelectedItem;
                            cliente.CodGarante = garante.CodCliente;
                        }
                        else
                            cliente.CodGarante= null;

                        if(clienteControlador.actualizarCliente(cliente))
                            MessageBox.Show("Cliente actualizado con exito", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Cliente no pudo ser actualizado", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        inicializarFormuario();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento problema al actualizar cliente " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chbTieneGarante_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTieneGarante.Checked)
            {
                cmbGarantesDisponibles.Enabled = true;
            }
            else
                cmbGarantesDisponibles.Enabled = false;
        }

        private void inicializarFormuario() {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";

            chbTieneGarante.Checked = false;
            cmbGarantesDisponibles.Enabled = false;

            dgwClientesGarantizados.DataSource = null;
            dgwClientesGarantizados.Refresh();

            cliente = null;
            garante = null;
            clientesGarantizados = null;
            posiblesGarantes = null;

            cargarComboConTodosLosClientes();
        }
    }
}