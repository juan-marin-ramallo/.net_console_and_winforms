using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ClienteEntidad
    {
        #region Atributos de la Clase
        private Int32 codCliente;
        private String cedula = String.Empty, nombre = String.Empty, direccion = String.Empty, telefono = String.Empty;
        private Byte edad;
        private Int32? codGarante;
        #endregion

        #region Propiedades de la Clase
        public int CodCliente { get => codCliente; set => codCliente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public byte Edad { get => edad; set => edad = value; }
        public int? CodGarante { get => codGarante; set => codGarante = value; }
        #endregion


    }
}
