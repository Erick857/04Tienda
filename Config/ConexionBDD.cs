using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// librerias de sql libreria de Data
using System.Data.SqlClient;
using System.Data;

namespace _04Tienda.Config
{
    class ConexionBDD
    {

        private SqlConnection con = new SqlConnection("Server=DESKTOP-BUUJ9LF\\SQLEXPRESS01;Database=Cuarto;User Id=sa;Password=erick;");


        public SqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)           
                con.Open();
            return con;          
           
        }
        public SqlConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }


    }
}
