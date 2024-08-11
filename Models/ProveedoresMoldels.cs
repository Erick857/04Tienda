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
    class ProveedorModel
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        private ConexionBDD conexionBDD = new ConexionBDD();

        SqlCommand cmd = new SqlCommand();
        List<ProveedorModel> listaProveedores = new List<ProveedorModel>();

        public List<ProveedorModel> Todos()
        {
            string cadena = "SELECT * FROM Proveedores";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexionBDD.AbrirConexion());
            DataTable data = new DataTable();
            adapter.Fill(data);
            foreach (DataRow fila in data.Rows)
            {
                ProveedorModel proveedor = new ProveedorModel
                {
                    IdProveedor = Convert.ToInt32(fila["IdProveedor"]),
                    Direccion = fila["Direccion"].ToString(),
                };
                listaProveedores.Add(proveedor);
            }
            conexionBDD.CerrarConexion();
            return listaProveedores;
        }

        public string Insertar(ProveedorModel proveedor)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "INSERT INTO Proveedores(Nombre, Direccion) VALUES ('" + proveedor.Nombre + "', '" + proveedor.Direccion + "')";
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

        public string Editar(ProveedorModel proveedor)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "UPDATE Proveedores SET Nombre = '" + proveedor.Nombre + "', Direccion = '" + proveedor.Direccion + "' WHERE IdProveedor = " + proveedor.IdProveedor;
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

        public string Eliminar(ProveedorModel proveedor)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "DELETE FROM Proveedores WHERE IdProveedor = " + proveedor.IdProveedor;
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