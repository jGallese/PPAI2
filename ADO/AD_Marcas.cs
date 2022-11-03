using PPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.ADO
{
    public class AD_Marcas
    {
        public static Marca getMarcaParticular(int oidModelo) 
        { 
            Marca marca = new Marca();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"SELECT M.nombre
                                    FROM MARCAS M JOIN MODELOS MM ON M.IDMARCA = MM.IDMARCA
                                    WHERE MM.IDMODELO = @idModelo";
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("@idModelo", oidModelo);

                cn.Open(); // abrir la conexion

                cmd.Connection = cn;


                DataTable tabla = new DataTable();
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                foreach (DataRow item in tabla.Rows)
                {
                    marca.Nombre = item["nombre"].ToString();
                    break;
                }
                
                return marca;

            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }




            return marca;

        }
    }
}
