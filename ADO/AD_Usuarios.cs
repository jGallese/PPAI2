using PPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.ADO
{
    public class AD_Usuarios
    {
        static public PersonalCientifico getPersonalLogueado(int oidUsuario)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            PersonalCientifico pers = new PersonalCientifico();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = @"SELECT PC.*, U.*
                                    FROM USUARIOS U JOIN PERSONALESCIENTIFICOS PC ON PC.LEGAJO=U.LEGAJO
                                    WHERE U.IDUSUARIO = @idUsuario";
                
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idUsuario", oidUsuario);


                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);


                foreach (DataRow dataRow in dt.Rows)
                {
                    pers.Legajo = (int)dataRow["legajo"];
                    pers.NumeroDocumento = (int)dataRow["nroDocumento"];
                    pers.Apellido = dataRow["apellido"].ToString();
                    pers.Nombre = dataRow["nombre"].ToString();
                    pers.TelefonoCelular = dataRow["telefonoCelular"].ToString();
                    pers.CorreoElectronicoPersonal = dataRow["correoPersonal"].ToString();
                    pers.CorreoElectronicoInstitucional = dataRow["correoInstitucional"].ToString();
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

            return pers;
        }
    }
}
