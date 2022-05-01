using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controlador;
using Entidad;

namespace ConsoleApp
{
    public class ClienteVista
    {
        ClienteControlador clienteControlador;

        public ClienteVista() { 
            clienteControlador = new ClienteControlador();  
        }

        public void mostrarOpciones() {
            Console.WriteLine("*************************CLIENTE VISTA************************");
            Console.WriteLine("(1) INGRESAR CLIENTE");
            Console.WriteLine("(2) ACTUALIZAR CLIENTE");
            Console.WriteLine("(3) ELIMINAR CLIENTE");
            Console.WriteLine("(4) CONSULTAR CLIENTE POR CEDULA");
            Console.WriteLine("(5) CONSULTAR TODOS LOS CLIENTES");
            Console.WriteLine("(6) CONSULTAR CLIENTES POR GARANTE");
            Console.WriteLine("(7) SALIR");

            Console.WriteLine("Ingrese una opcion valida del 1 al 7");

            try
            {
                int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());

                switch (opcionSeleccionada)
                {
                    case 1:
                        ingresarCliente();
                        break;
                    case 2:
                        actualizarCliente();
                        break;
                    case 3:
                        eliminarCliente();
                        break;
                    case 4:
                        consultarClientePorCedula();
                        break;
                    case 5:
                        consultarTodosLosClientes();
                        break;
                    case 6:
                        consultarClientesPorGarante();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa Vista - mostrarOpciones" + ex.Message);
            }
        }

        private void consultarClientesPorGarante()
        {
            List<ClienteEntidad>? clientesGarantizados;
            ClienteEntidad? garante;
            String? cedulaGarante;

            try
            {
                Console.WriteLine("*********************CONSULTAR CLIENTES POR GARANTE************************");
                Console.WriteLine("Ingrese la cedula del garante:");
                cedulaGarante = Console.ReadLine();

                garante = clienteControlador.consultaClientePorCedula(cedulaGarante);

                if (garante == null)
                {
                    Console.WriteLine("Garante no existe con esa cedula");
                }
                else {
                    clientesGarantizados = clienteControlador.consultarClientesPorGarante(garante.CodCliente);

                    if (clientesGarantizados!.Count == 0)
                        Console.WriteLine("El cliente no es garante de nadie");
                    else {
                        foreach (ClienteEntidad clienteGarantizado in clientesGarantizados)
                        {
                            Console.WriteLine("Cedula Cliente Garantizado: " + clienteGarantizado.Cedula);
                            Console.WriteLine("Nombre Cliente Garantizado: " + clienteGarantizado.Nombre);
                            Console.WriteLine("Edad Cliente Garantizado: " + clienteGarantizado.Edad);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa Vista - consultarTodosLosClientes" + ex.Message);
            }
        }

        private void consultarTodosLosClientes()
        {
            List<ClienteEntidad>? clientes, clientesGarantizados;
            ClienteEntidad? garante;

            try
            {
                Console.WriteLine("*********************CONSULTAR TODOS LOS CLIENTES************************");

                clientes = clienteControlador.consultarTodosLosClientes();

                foreach (ClienteEntidad cliente in clientes)
                {
                    Console.WriteLine("Nombre: " + cliente.Nombre);
                    Console.WriteLine("Edad: " + cliente.Edad);
                    Console.WriteLine("Direccion: " + cliente.Direccion);
                    Console.WriteLine("Telefono: " + cliente.Telefono);

                    if (cliente.CodGarante != null)
                    {
                        Console.WriteLine("Info Garante:");
                        garante = clienteControlador.consultaClientePorCodigo(cliente.CodGarante);
                        Console.WriteLine("---Cedula Garante:" + garante!.Cedula);
                        Console.WriteLine("---Nombre Garante:" + garante!.Nombre);
                    }

                    //Muestro informacion de los clientes que yo soy garante
                    clientesGarantizados = clienteControlador.consultarClientesPorGarante(cliente.CodCliente);

                    if (clientesGarantizados != null) {
                        foreach (ClienteEntidad clienteGarantizado in clientesGarantizados)
                        {
                            Console.WriteLine("Info Cliente Garantizado :" + clienteGarantizado.Cedula);
                            Console.WriteLine("---Nombre :" + clienteGarantizado!.Nombre);
                        }
                    }                    

                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa Vista - consultarTodosLosClientes" + ex.Message);
            }
        }

        private void consultarClientePorCedula()
        {
            String? cedula;
            ClienteEntidad? cliente,garante;
            List<ClienteEntidad>? clientesGarantizados;

            try
            {
                Console.WriteLine();
                Console.WriteLine("*********************CONSULTAR CLIENTE************************");
                Console.WriteLine("Ingrese la cedula del cliente que quiere consultar:");
                cedula = Console.ReadLine();

                cliente = clienteControlador.consultaClientePorCedula(cedula);

                if (cliente == null)
                {
                    Console.WriteLine("No existe cliente con esa cedula");
                }
                else {
                    Console.WriteLine("Nombre: " + cliente.Nombre);
                    Console.WriteLine("Edad: " + cliente.Edad);
                    Console.WriteLine("Direccion: " + cliente.Direccion);
                    Console.WriteLine("Telefono: " + cliente.Telefono);
                                        
                    if (cliente.CodGarante != null)
                    {
                        Console.WriteLine("Info Garante:");
                        garante = clienteControlador.consultaClientePorCodigo(cliente.CodGarante);
                        Console.WriteLine("---Cedula Garante:" + garante!.Cedula);
                        Console.WriteLine("---Nombre Garante:" + garante!.Nombre);
                    }

                    //Muestro informacion de los clientes que yo soy garante
                    clientesGarantizados = clienteControlador.consultarClientesPorGarante(cliente.CodCliente);

                    foreach (ClienteEntidad clienteGarantizado in clientesGarantizados)
                    {
                        Console.WriteLine("Info Cliente Garantizado :" + clienteGarantizado.Cedula);                        
                        Console.WriteLine("---Nombre :" + clienteGarantizado!.Nombre);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa Vista - mostrarOpciones" + ex.Message);
            }
        }

        private void eliminarCliente()
        {
            String? cedula;
            ClienteEntidad? clienteEliminar;

            try
            {
                Console.WriteLine();
                Console.WriteLine("*********************ELIMINAR CLIENTE************************");
                Console.WriteLine("Ingrese la cedula del cliente que quiere eliminar:");
                cedula = Console.ReadLine();

                clienteEliminar = clienteControlador.consultaClientePorCedula(cedula);

                if (clienteEliminar == null)
                {
                    Console.WriteLine("No existe cliente con esa cedula");
                }
                {
                    if (clienteControlador.eliminarCliente(clienteEliminar!.CodCliente))
                    {
                        Console.WriteLine("El cliente fue eliminado con exito");
                    }
                    else
                        Console.WriteLine("El cliente no pudo ser eliminado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa Vista - eliminarCliente" + ex.Message);
            }
        }

        private void actualizarCliente()
        {
            String? cedula, nombre, direccion, telefono;
            byte edad;
            Int32? codGarante = null;
            String? quiereGarante, quiereModificar;
            ClienteEntidad? clienteModificar;

            try
            {
                Console.WriteLine();
                Console.WriteLine("*********************ACTUALIZAR CLIENTE************************");
                Console.WriteLine("Ingrese la cedula del cliente que quiere actualizar:");
                cedula = Console.ReadLine();
                clienteModificar = clienteControlador.consultaClientePorCedula(cedula);

                //Valido si el cliente que quiero modificar su informacion existe en la BD
                if (clienteModificar == null)
                    Console.WriteLine("La cedula ingresada no existe");
                else {
                    //Pido los datos del cliente que el usuario quiere modificar

                    #region Modificar Cedula
                    Console.WriteLine("Desea modificar la cedula? (S/N)");
                    quiereModificar = Console.ReadLine()?.ToUpper();

                    if (quiereModificar!.Equals("S"))
                    {
                        Console.WriteLine("Cedula: ");
                        cedula = Console.ReadLine();
                    }
                    #endregion

                    #region Modificar Nombre
                    Console.WriteLine("Desea modificar el nombre? (S/N)");
                    quiereModificar = Console.ReadLine()?.ToUpper();

                    if (quiereModificar!.Equals("S"))
                    {
                        Console.WriteLine("Nombre: ");
                        nombre = Console.ReadLine();
                    }
                    else
                        nombre = clienteModificar.Nombre;
                    #endregion

                    #region Modificar Edad
                    Console.WriteLine("Desea modificar la edad? (S/N)");
                    quiereModificar = Console.ReadLine()?.ToUpper();

                    if (quiereModificar!.Equals("S"))
                    {
                        Console.WriteLine("Edad: ");
                        edad = Convert.ToByte(Console.ReadLine(), 16);
                    }
                    else
                        edad = clienteModificar.Edad;
                    #endregion

                    #region Modificar Direccion
                    Console.WriteLine("Desea modificar la direccion? (S/N)");
                    quiereModificar = Console.ReadLine()?.ToUpper();

                    if (quiereModificar!.Equals("S"))
                    {
                        Console.WriteLine("Direccion: ");
                        direccion = Console.ReadLine();
                    }
                    else
                        direccion = clienteModificar.Direccion;
                    #endregion

                    #region Modificar Telefono
                    Console.WriteLine("Desea modificar el telefono? (S/N)");
                    quiereModificar = Console.ReadLine()?.ToUpper();

                    if (quiereModificar!.Equals("S"))
                    {
                        Console.WriteLine("Telefono: ");
                        telefono = Console.ReadLine();
                    }
                    else
                        telefono = clienteModificar.Telefono;   
                    #endregion

                    #region Modificar Garante
                    //Escenario 1: Quiere dejar  el cliente tal como está
                    //Escenario 2: No tiene garante y quiere tener uno
                    //Escenario 3: Tiene garante y ya no quiere tener
                    //Escenario 4: Tiene garante y quiere cambiarlo
                    Console.WriteLine("Desea modificar un garante? (S/N)");
                    quiereModificar = Console.ReadLine()?.ToUpper();

                    if (quiereModificar!.Equals("S"))
                    {
                        if (clienteModificar.CodGarante == null)
                        {
                            //Cliente a modificar no tiene garante
                            Console.WriteLine("Por favor ingrese la cedula del cliente que quiere como garante");
                            String? cedulaGarante = Console.ReadLine();

                            ClienteEntidad? garante = clienteControlador.consultaClientePorCedula(cedulaGarante);

                            if (garante != null)
                                codGarante = garante.CodCliente;
                            else
                                Console.WriteLine("La cedula ingresada no existe");
                        }
                        else {
                            //Cliente a modificar  tiene garante
                            Console.WriteLine("Desea eliminar el garante que tiene? (S/N)");
                            String quiereEliminarGarante = Console.ReadLine()!.ToUpper();

                            if (quiereEliminarGarante.Equals("S"))
                            {
                                codGarante = null;
                            }
                            else {
                                Console.WriteLine("Desea modificar el garante que tiene? (S/N)");
                                String quiereModificarGarante = Console.ReadLine()!.ToUpper();

                                if (quiereModificarGarante.Equals("S")) {
                                    Console.WriteLine("Por favor ingrese la cedula del cliente que quiere como NUEVO garante");
                                    String? cedulaGarante = Console.ReadLine();

                                    ClienteEntidad? garante = clienteControlador.consultaClientePorCedula(cedulaGarante);

                                    if (garante != null)
                                        codGarante = garante.CodCliente;
                                    else
                                        Console.WriteLine("La cedula ingresada no existe");
                                }
                            }
                        }
                    }                    
                    #endregion

                    clienteModificar.Cedula = (cedula == null) ? String.Empty : cedula;
                    clienteModificar.Nombre = (nombre == null) ? String.Empty : nombre;
                    clienteModificar.Edad = edad;
                    clienteModificar.Direccion = (direccion == null) ? String.Empty : direccion;
                    clienteModificar.Telefono = (telefono == null) ? String.Empty : telefono;
                    clienteModificar.CodGarante = codGarante;

                    if (clienteControlador.actualizarCliente(clienteModificar))
                        Console.WriteLine("El cliente fue modificado con exito");
                    else
                        Console.WriteLine("No se pudo modificar el cliente");
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa Vista - modificarCliente" + ex.Message);
            }
        }

        private void ingresarCliente()
        {
            String? cedula, nombre, direccion, telefono;
            byte edad;
            Int32? codGarante = null;
            String? quiereGarante;

            try
            {
                Console.WriteLine();
                Console.WriteLine("*********************INGRESO CLIENTE************************");
                Console.WriteLine("Cedula: ");
                cedula = Console.ReadLine();
                Console.WriteLine("Nombre: ");
                nombre = Console.ReadLine();
                Console.WriteLine("Edad: ");
                edad = Convert.ToByte(Console.ReadLine(), 16);
                Console.WriteLine("Direccion: ");
                direccion = Console.ReadLine();
                Console.WriteLine("Telefono: ");
                telefono = Console.ReadLine();

                Console.WriteLine("Desea asignar un garante? (S/N)");
                quiereGarante = Console.ReadLine()?.ToUpper();

                if (quiereGarante!.Equals("S")) {
                    Console.WriteLine("Por favor ingrese la cedula del cliente que quiere como garante");
                    String? cedulaGarante = Console.ReadLine();
                        
                    ClienteEntidad? garante = clienteControlador.consultaClientePorCedula(cedulaGarante);

                    if (garante != null)
                        codGarante = garante.CodCliente;
                    else
                        Console.WriteLine("La cedula ingresada no existe");
                }



                ClienteEntidad? clienteNuevo = new ClienteEntidad();
                clienteNuevo.Cedula = (cedula == null) ? String.Empty : cedula;
                clienteNuevo.Nombre = (nombre == null) ? String.Empty : nombre;
                clienteNuevo.Edad = edad;
                clienteNuevo.Direccion = (direccion == null) ? String.Empty : direccion;
                clienteNuevo.Telefono = (telefono == null) ? String.Empty : telefono;
                clienteNuevo.CodGarante = codGarante;

                if (clienteControlador.insertarCliente(clienteNuevo))
                    Console.WriteLine("El cliente fue ingresado con exito");
                else
                    Console.WriteLine("No se pudo insertar el cliente");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa Vista - ingresarCliente" + ex.Message);
            }
        }

    }
}
