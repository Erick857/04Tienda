using _04Tienda.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Tienda.Models
{
     class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        private ConexionBDD conexionBDD = new ConexionBDD();
        SqlCommand cmd = new SqlCommand();
        List<ClienteModel> listaClientes = new List<ClienteModel>();

        public List<ClienteModel> Todos()
        {
            string cadena = "SELECT * FROM Clientes";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexionBDD.AbrirConexion());
            DataTable data = new DataTable();
            adapter.Fill(data);
            foreach (DataRow fila in data.Rows)
            {
                ClienteModel cliente = new ClienteModel
                {
                    IdCliente = Convert.ToInt32(fila["IdCliente"]),
                    Nombre = fila["Nombres"].ToString(),
                    Direccion = fila["Apellidos"].ToString(), 

                };
                listaClientes.Add(cliente);
            }
            conexionBDD.CerrarConexion();
            return listaClientes;
        }

        public string Insertar(ClienteModel cliente)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "INSERT INTO Clientes(Nombre, Direccion) VALUES ('" + cliente.Nombre + "', '" + cliente.Direccion + "')";
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }

        public string Editar(ClienteModel cliente)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "UPDATE Clientes SET Nombre = '" + cliente.Nombre + "', Direccion = '" + cliente.Direccion + "' WHERE IdCliente = " + cliente.IdCliente;
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }

        public string Eliminar(ClienteModel cliente)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "DELETE FROM Clientes WHERE IdCliente = " + cliente.IdCliente;
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }
    }
}
