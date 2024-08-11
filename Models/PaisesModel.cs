using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//librerias de la conexion
using System.Data;
using System.Data.SqlClient;
using _04Tienda.Config;
namespace _04Tienda.Models
{
    class PaisesModel
    {
        public int IdPais { get; set; }
        public string Detalle { get; set; }

        private ConexionBDD conexionBDD = new ConexionBDD();

        //lector Sqldatareader
        //SqlDataReader lector;
        List<PaisesModel> listaPaises = new List<PaisesModel>();
        SqlCommand cmd = new SqlCommand();
       
        public List<PaisesModel> Todos()
        {

            string cadena = "select * from paises";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena,conexionBDD.AbrirConexion());
            DataTable data = new DataTable();  
            adapter.Fill(data);
            foreach (DataRow fila in data.Rows)
            {
                PaisesModel pais = new PaisesModel
                {
                    IdPais = Convert.ToInt32(fila["IdPais"]),
                    Detalle = fila["Detalle"].ToString()
                };
                listaPaises.Add(pais);
            }
            conexionBDD.CerrarConexion();
            return listaPaises;
        }



        public string insertar(PaisesModel pais)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "insert into Paises(Detalle) values ('" + pais.Detalle + "')";
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
        public string editar(PaisesModel pais)
        {
            try
            {
                cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "update paises set detalle = '" + pais.Detalle + "' where IdPais = " + pais.IdPais;
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
        public string eliminar(PaisesModel pais)
        {
            try
            {
                Console.WriteLine("delete from paises where IdPais=" + pais.IdPais);
;               cmd.Connection = conexionBDD.AbrirConexion();
                cmd.CommandText = "delete from paises where IdPais=" + pais.IdPais; 
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
