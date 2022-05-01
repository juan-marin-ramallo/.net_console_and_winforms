using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal class Database
    {
        private SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-4M1UU7M\\MSSQLSERVER2019;Initial Catalog=reserva_coches;Persist Security Info=True;User ID=reserva_coches;Password=reserva_coches");

        public SqlConnection abrirConexion() { 
            if(conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection cerrarConexion() { 
            if(conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
