using Datos;
using Entidad;

namespace Controlador
{
    public class ClienteControlador
    {
        ClienteDatos clienteDatos;

        public ClienteControlador()
        {
            clienteDatos = new ClienteDatos();
        }

        public bool insertarCliente(ClienteEntidad cliente)
        {
            bool resultadoInsercion = false;

            try
            {
                //Object servicioSri = new Object();
                //bool resultadoValidacionSRI = servicioSri.validarDeudasPorCedula(cliente.Cedula);
                //if (resultadoValidacionSRI)
                resultadoInsercion = clienteDatos.insertarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - insertarCliente", ex);
            }

            return resultadoInsercion;
        }

        public bool actualizarCliente(ClienteEntidad cliente)
        {
            bool resultadoActualizacion = false;

            try
            {
                //Object servicioSri = new Object();
                //bool resultadoValidacionSRI = servicioSri.validarDeudasPorCedula(cliente.Cedula);
                //if (resultadoValidacionSRI)
                resultadoActualizacion = clienteDatos.actualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - actualizarCliente", ex);
            }

            return resultadoActualizacion;
        }

        public bool eliminarCliente(Int32 codCliente)
        {
            bool resultadoEliminacion = false;

            try
            {
                //Object servicioSri = new Object();
                //bool resultadoValidacionSRI = servicioSri.validarDeudasPorCedula(cliente.Cedula);
                //if (resultadoValidacionSRI)
                resultadoEliminacion = clienteDatos.eliminarCliente(codCliente);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - eliminarCliente", ex);
            }

            return resultadoEliminacion;
        }

        public ClienteEntidad? consultaClientePorCedula(String? cedula)
        {
            ClienteEntidad? cliente = null;

            try
            {
                cliente = clienteDatos.consultaClientePorCedula(cedula);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - consultarClientePorCedula", ex);
            }

            return cliente;
        }

        public ClienteEntidad? consultaClientePorCodigo(Int32? codCliente)
        {
            ClienteEntidad? cliente = null;

            try
            {
                cliente = clienteDatos.consultaClientePorCodigo(codCliente);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - consultarClientePorCodigo", ex);
            }

            return cliente;
        }

        public List<ClienteEntidad>? consultarTodosLosClientes()
        {
            List<ClienteEntidad>? listaTodosLosClientes = null;

            try
            {
                listaTodosLosClientes = clienteDatos.consultarTodosLosClientes();
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - consultarTodosLosClientes", ex);
            }

            return listaTodosLosClientes;
        }

        public List<ClienteEntidad>? consultarClientesPorGarante(Int32? codGarante)
        {
            List<ClienteEntidad>? listaClientesPorGarante = null;

            try
            {
                listaClientesPorGarante = clienteDatos.consultarClientesPorGarante(codGarante);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - consultarClientesPorGarante", ex);
            }

            return listaClientesPorGarante;
        }

        public List<ClienteEntidad> consultarGarantesDisponibles(Int32 codCliente)
        {
            List<ClienteEntidad>? listaGarantesDisponibles = null;

            try
            {
                listaGarantesDisponibles = clienteDatos.consultarGarantesDisponibles(codCliente);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error en la Capa Controlador - consultarGarantesDisponibles", ex);
            }

            return listaGarantesDisponibles!;
        }
    }
}