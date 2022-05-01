using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;


namespace Datos
{
    public class ClienteDatos
    {
        private Database conexionDB;
        private SqlCommand comandoSQL;
        private SqlDataReader comandoDataReader;

        public ClienteDatos()
        {
            conexionDB = new Database();
            comandoSQL = new SqlCommand();
        }

        public bool insertarCliente(ClienteEntidad cliente) { 
            bool resultadoInsercion = false;

            //Escribo el codigo para insertar el cliente en la BD
            //Si la insercion es correcta entonces resultadoInsercion sera verdadero
            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spInsertarCliente";
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Clear();
                comandoSQL.Parameters.AddWithValue("@cedula", cliente.Cedula);
                comandoSQL.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comandoSQL.Parameters.AddWithValue("@edad", cliente.Edad);
                comandoSQL.Parameters.AddWithValue("@direccion", cliente.Direccion);
                comandoSQL.Parameters.AddWithValue("@telefono", cliente.Telefono);

                if (cliente.CodGarante == null)
                    comandoSQL.Parameters.AddWithValue("@codGarante", DBNull.Value);
                else
                    comandoSQL.Parameters.AddWithValue("@codGarante", cliente.CodGarante);

                //Trato de ejecutar el sp de Insertar Cliente con los parametros 
                comandoSQL.ExecuteNonQuery();

                resultadoInsercion = true;
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - InsertarCliente", ex);
            }
            finally {
                conexionDB.cerrarConexion();
            }

            return resultadoInsercion;
        }

        public bool actualizarCliente(ClienteEntidad cliente)
        {
            bool resultadoActualizacion = false;

            //Escribo el codigo para actualizar el cliente en la BD
            //Si la actualizacion es correcta entonces resultadoInsercion sera verdadero
            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spActualizarCliente";
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Clear();
                comandoSQL.Parameters.AddWithValue("@codCliente", cliente.CodCliente);
                comandoSQL.Parameters.AddWithValue("@cedula", cliente.Cedula);
                comandoSQL.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comandoSQL.Parameters.AddWithValue("@edad", cliente.Edad);
                comandoSQL.Parameters.AddWithValue("@direccion", cliente.Direccion);
                comandoSQL.Parameters.AddWithValue("@telefono", cliente.Telefono);

                if (cliente.CodGarante == null)
                    comandoSQL.Parameters.AddWithValue("@codGarante", DBNull.Value);
                else
                    comandoSQL.Parameters.AddWithValue("@codGarante", cliente.CodGarante);

                //Trato de ejecutar el sp de Actualizar Cliente con los parametros 
                comandoSQL.ExecuteNonQuery();

                resultadoActualizacion = true;
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - ActualizarCliente", ex);
            }
            finally
            {
                conexionDB.cerrarConexion();
            }

            return resultadoActualizacion;
        }

        public bool eliminarCliente(Int32 codCliente)
        {
            bool resultadoEliminacion = false;

            //Escribo el codigo para eliminar el cliente en la BD
            //Si la eliminacion es correcta entonces resultadoInsercion sera verdadero
            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spEliminarCliente";
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Clear();
                comandoSQL.Parameters.AddWithValue("@codCliente", codCliente);
            
                //Trato de ejecutar el sp de Eliminar Cliente con los parametros 
                comandoSQL.ExecuteNonQuery();

                resultadoEliminacion = true;
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - EliminarCliente", ex);
            }
            finally
            {
                conexionDB.cerrarConexion();
            }

            return resultadoEliminacion;
        }

        public ClienteEntidad? consultaClientePorCedula(String? cedula) {
            ClienteEntidad? cliente = null;

            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spConsultarClientePorCedula";
                comandoSQL.CommandType = CommandType.StoredProcedure;

                comandoSQL.Parameters.Clear();
                comandoSQL.Parameters.AddWithValue("@cedula", cedula);

                comandoDataReader = comandoSQL.ExecuteReader();

                if (comandoDataReader.Read()) { 
                    cliente = new ClienteEntidad();
                    cliente.CodCliente = comandoDataReader.GetInt32("codCliente");
                    cliente.Cedula = comandoDataReader.GetString("cedula");
                    cliente.Nombre = comandoDataReader.GetString("nombre");
                    if (!comandoDataReader.IsDBNull("edad"))
                        cliente.Edad = comandoDataReader.GetByte("edad");
                    if (!comandoDataReader.IsDBNull("direccion"))
                        cliente.Direccion = comandoDataReader.GetString("direccion");
                    if (!comandoDataReader.IsDBNull("telefono"))
                        cliente.Telefono = comandoDataReader.GetString("telefono");

                    if (!comandoDataReader.IsDBNull("codGarante"))
                        cliente.CodGarante = comandoDataReader.GetInt32("codGarante");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - consultaClientePorCedula", ex);
            }
            finally { 
                comandoDataReader.Close();
                conexionDB.cerrarConexion();
            }

            return cliente;
        }


        public ClienteEntidad? consultaClientePorCodigo(Int32? codCliente)
        {
            ClienteEntidad? cliente = null;

            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spConsultarClientePorCodigo";
                comandoSQL.CommandType = CommandType.StoredProcedure;

                comandoSQL.Parameters.Clear();
                comandoSQL.Parameters.AddWithValue("@codCliente", codCliente);

                comandoDataReader = comandoSQL.ExecuteReader();

                if (comandoDataReader.Read())
                {
                    cliente = new ClienteEntidad();
                    cliente.CodCliente = comandoDataReader.GetInt32("codCliente");
                    cliente.Cedula = comandoDataReader.GetString("cedula");
                    cliente.Nombre = comandoDataReader.GetString("nombre");
                    if (!comandoDataReader.IsDBNull("edad"))
                        cliente.Edad = comandoDataReader.GetByte("edad");
                    if (!comandoDataReader.IsDBNull("direccion"))
                        cliente.Direccion = comandoDataReader.GetString("direccion");
                    if (!comandoDataReader.IsDBNull("telefono"))
                        cliente.Telefono = comandoDataReader.GetString("telefono");

                    if (!comandoDataReader.IsDBNull("codGarante"))
                        cliente.CodGarante = comandoDataReader.GetInt32("codGarante");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - consultaClientePorCodigo", ex);
            }
            finally
            {
                comandoDataReader.Close();
                conexionDB.cerrarConexion();
            }

            return cliente;
        }

        public List<ClienteEntidad>? consultarTodosLosClientes() {
            List<ClienteEntidad>? listaTodosLosClientes = null;

            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spConsultarTodosLosClientes";
                comandoSQL.CommandType = CommandType.StoredProcedure;

                comandoSQL.Parameters.Clear();

                comandoDataReader = comandoSQL.ExecuteReader();

                if (comandoDataReader.HasRows)
                    listaTodosLosClientes = new List<ClienteEntidad>(); 

                while (comandoDataReader.Read())
                {
                    ClienteEntidad cliente = new ClienteEntidad();
                    cliente.CodCliente = comandoDataReader.GetInt32("codCliente");
                    cliente.Cedula = comandoDataReader.GetString("cedula");
                    cliente.Nombre = comandoDataReader.GetString("nombre");
                    if (!comandoDataReader.IsDBNull("edad"))
                        cliente.Edad = comandoDataReader.GetByte("edad");
                    if (!comandoDataReader.IsDBNull("direccion"))
                        cliente.Direccion = comandoDataReader.GetString("direccion");
                    if (!comandoDataReader.IsDBNull("telefono"))
                        cliente.Telefono = comandoDataReader.GetString("telefono");

                    if (!comandoDataReader.IsDBNull("codGarante"))
                        cliente.CodGarante = comandoDataReader.GetInt32("codGarante");

                    listaTodosLosClientes?.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - consultaTodosLosClientes", ex);
            }
            finally {
                comandoDataReader.Close();
                conexionDB.cerrarConexion();
            }

            return listaTodosLosClientes;
        }

        public List<ClienteEntidad>? consultarClientesPorGarante(Int32? codGarante)
        {
            List<ClienteEntidad>? listaClientesPorGarante = null;

            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spConsultarClientePorGarante";
                comandoSQL.CommandType = CommandType.StoredProcedure;

                comandoSQL.Parameters.Clear();
                comandoSQL.Parameters.AddWithValue("@codGarante",codGarante);

                comandoDataReader = comandoSQL.ExecuteReader();

                if (comandoDataReader.HasRows)
                    listaClientesPorGarante = new List<ClienteEntidad>();

                while (comandoDataReader.Read())
                {
                    ClienteEntidad cliente = new ClienteEntidad();
                    cliente.CodCliente = comandoDataReader.GetInt32("codCliente");
                    cliente.Cedula = comandoDataReader.GetString("cedula");
                    cliente.Nombre = comandoDataReader.GetString("nombre");
                    if (!comandoDataReader.IsDBNull("edad"))
                        cliente.Edad = comandoDataReader.GetByte("edad");
                    if (!comandoDataReader.IsDBNull("direccion"))
                        cliente.Direccion = comandoDataReader.GetString("direccion");
                    if (!comandoDataReader.IsDBNull("telefono"))
                        cliente.Telefono = comandoDataReader.GetString("telefono");

                    if (!comandoDataReader.IsDBNull("codGarante"))
                        cliente.CodGarante = comandoDataReader.GetInt32("codGarante");

                    listaClientesPorGarante?.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - consultaClientesPorGarante", ex);
            }
            finally
            {
                comandoDataReader.Close();
                conexionDB.cerrarConexion();
            }

            return listaClientesPorGarante;
        }

        public List<ClienteEntidad> consultarGarantesDisponibles(Int32 codCliente) {
            List<ClienteEntidad>? listaGarantesDisponibles = null;

            try
            {
                comandoSQL.Connection = conexionDB.abrirConexion();
                comandoSQL.CommandText = "spConsultarGarantesDisponibles";
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Clear();
                comandoSQL.Parameters.AddWithValue("@codCliente", codCliente);

                comandoDataReader = comandoSQL.ExecuteReader();

                if (comandoDataReader.HasRows)
                    listaGarantesDisponibles = new List<ClienteEntidad>();

                while (comandoDataReader.Read()) {
                    ClienteEntidad cliente = new ClienteEntidad();
                    cliente.CodCliente = comandoDataReader.GetInt32("codCliente");
                    cliente.Cedula = comandoDataReader.GetString("cedula");
                    cliente.Nombre = comandoDataReader.GetString("nombre");
                    if (!comandoDataReader.IsDBNull("edad"))
                        cliente.Edad = comandoDataReader.GetByte("edad");
                    if (!comandoDataReader.IsDBNull("direccion"))
                        cliente.Direccion = comandoDataReader.GetString("direccion");
                    if (!comandoDataReader.IsDBNull("telefono"))
                        cliente.Telefono = comandoDataReader.GetString("telefono");

                    if (!comandoDataReader.IsDBNull("codGarante"))
                        cliente.CodGarante = comandoDataReader.GetInt32("codGarante");

                    listaGarantesDisponibles?.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("Error en Capa de Datos - consultarGarantesDisponibles", ex);
            }
            finally
            {
                comandoDataReader.Close();
                conexionDB.cerrarConexion();
            }

            return listaGarantesDisponibles!;
        }
    }
}
