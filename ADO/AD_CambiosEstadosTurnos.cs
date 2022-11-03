using PPAI.Entidades.EstadosConcretos;
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
    public class AD_CambiosEstadosTurnos
    {
        public static List<CambioEstadoTurno> getCambiosEstadoDeTurno(int idTurno)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);


            List<CambioEstadoTurno> listaCambioEstadosTurno= new List<CambioEstadoTurno>();
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = @"SELECT CE.*, E.*
                                    FROM CambiosEstadoTurno CE JOIN EstadosTurno E ON CE.idEstado=E.idEstado
                                    WHERE CE.idTurno = @idTurno";

                cmd.Parameters.Clear(); // limpiar parametros
                cmd.Parameters.AddWithValue("@idTurno", idTurno);
                cmd.CommandType = CommandType.Text; // asignar que el tipo de comando es de texto. Significa que se va a escribir a mano el comando que se va a usar
                cmd.CommandText = consulta; //el texto del comando es la consulta que se escribio antes


                cn.Open(); // abrir la conexion

                cmd.Connection = cn; // asignar al objeto command la conexion abierta

                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd); //le pasa al da la consulta. Ejecuta la consulta y carga en la tabla
                da.Fill(tabla); // el da llena la tabla especificada con los datos de la consulta

                /*return tabla*/




                foreach (DataRow row in tabla.Rows)
                {
                    CambioEstadoTurno CE = new CambioEstadoTurno();
                    CE.fechaHoraDesde = DateTime.Parse(row["fechaHoraDesde"].ToString());
                    if (row["fechaHoraHasta"].ToString() == "")
                    {
                        CE.fechaHoraHasta = null;
                    }
                    else
                    {
                        CE.fechaHoraHasta = DateTime.Parse(row["fechaHoraHasta"].ToString());
                    }
                    if (row["nombre"].ToString().Equals("Reservado"))
                    {
                        CE.estado = new Reservado();
                        CE.estado.Nombre = "Reservado";

                    }
                    else if (row["nombre"].ToString().Equals("Disponible"))
                    {
                        CE.estado = new Disponible();
                        CE.estado.Nombre = "Disponible";
                    }
                    else
                    {
                        CE.estado = new PendienteDeConfirmacion();
                        CE.estado.Nombre = "PendienteDeConfirmacion";
                    }

                    CE.estado.oid = (int)row["idEstado"];
                    CE.estado.Descripcion = row["descripcion"].ToString();
                    listaCambioEstadosTurno.Add(CE);

                    

                    

                }

                return listaCambioEstadosTurno;
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
