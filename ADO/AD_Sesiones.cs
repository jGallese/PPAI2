using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.Entidades;

namespace PPAI.ADO
{
    public class AD_Sesiones
    {
        static public Sesion getSesion()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            Sesion ses = new Sesion();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT S.*, U.*
                                    FROM SESIONES S JOIN USUARIOS U ON S.idUsuario=U.idUsuario 
                                    WHERE (FECHAHORAFIN is null or FECHAHORAFIN = '')";
                cmd.Parameters.Clear();


                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                
                foreach (DataRow dataRow in dt.Rows)
                {
                    ses.oid = (int)dataRow["idSesion"];
                    ses.FechaHoraDesde = (DateTime)dataRow["fechaHoraInicio"];
                    ses.Usuario = new Usuario(dataRow["nombreUsuario"].ToString(), dataRow["contraseña"].ToString());
                    ses.Usuario.oid = (int)dataRow["idUsuario"];
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return ses;
        }
    }
}
