using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.Helpers;

namespace PPAI.ADO
{
    public class AD_Asignaciones
    {
        public static DataTable getAsignaciones()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = @"SELECT A.*, PC.*, U.*
                                    FROM AsignacionesCientificos A 
                                    JOIN PersonalesCientificos PC ON A.idPersonalCientifico=PC.legajo
                                    JOIN Usuarios U ON PC.legajo=U.legajo";

                cmd.Parameters.Clear(); // limpiar parametros
                cmd.CommandType = CommandType.Text; // asignar que el tipo de comando es de texto. Significa que se va a escribir a mano el comando que se va a usar
                cmd.CommandText = consulta; //el texto del comando es la consulta que se escribio antes


                cn.Open(); // abrir la conexion

                cmd.Connection = cn; // asignar al objeto command la conexion abierta

                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd); //le pasa al da la consulta. Ejecuta la consulta y carga en la tabla
                da.Fill(tabla); // el da llena la tabla especificada con los datos de la consulta

                return tabla;



            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
