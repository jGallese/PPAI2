using PPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.Entidades.EstadosConcretos;

namespace PPAI.ADO
{
    public class AD_Turnos
    {
        public static List<Turno> getTurnosDeRecurso(int nroRecurso)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);


            List<Turno> listaTurnos = new List<Turno>();
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = @"SELECT *
                                    FROM TURNOS T JOIN EstadosTurno ET ON T.IDESTADO=ET.IDESTADO
                                    WHERE nroRT = @numRecurso";

                cmd.Parameters.Clear(); // limpiar parametros
                cmd.Parameters.AddWithValue("@numRecurso", nroRecurso);
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

                    Turno turno = new Turno();
                    turno.oid = (int)row["idTurno"];
                    turno.FechaGeneracion = DateTime.Parse(row["fechaGeneracion"].ToString());
                    turno.DiaSemana = row["diaSemana"].ToString();
                    turno.fechaHoraInicio = DateTime.Parse(row["fechaHoraInicio"].ToString());
                    turno.fechaHoraFin = DateTime.Parse(row["fechaHoraFin"].ToString());
                    
                    if (row["nombre"].ToString().Equals("Reservado"))
                    {
                        turno.estado = new Reservado();
                        turno.estado.Nombre = "Reservado";

                    } 
                    else if (row["nombre"].ToString().Equals("Disponible"))
                    {
                        turno.estado = new Disponible();
                        turno.estado.Nombre = "Disponible";
                    } 
                    else
                    {
                        turno.estado = new PendienteDeConfirmacion();
                        turno.estado.Nombre = "PendienteDeConfirmacion";
                    }

                    turno.estado.oid = (int)row["idEstado"];
                    turno.estado.Descripcion = row["descripcion"].ToString();

                    listaTurnos.Add(turno);

                }

                return listaTurnos;
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

        public static bool reservarTurnoTransaccion(Turno turno, CambioEstadoTurno cambioEstadoNuevo, int idEstadoViejo, DateTime fechaHora)
        {
            //CREAR NUEVO CAMBIO DE ESTADO
            //MODIFICAR TURNO PARA CAMBIARLE EL ESTADO
            //MODIFICAR CAMBIOESTADO PARA PONERLE FECHA

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlTransaction objetotransaccion = null;
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = @"UPDATE TURNOS
                                    SET idEstado = @idEstado
                                    Where idTurno = @idTurno";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idEstado", turno.estado.oid);
                cmd.Parameters.AddWithValue("@idTurno", turno.oid);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;



                cn.Open();

                //antes de setear la transaccion se hace que el objeto transaccion sea igual al objetoConexion
                objetotransaccion = cn.BeginTransaction("AltaDeCurso"); //Se le asigna un nombre


                cmd.Transaction = objetotransaccion; // se tiene que asignar el ObjetoTransaccion al CMD, despues de hacer el begin transaction



                cmd.Connection = cn;

                cmd.ExecuteNonQuery();

                //una vez que se agrego el curso, se deben agergar los alumnos

                string consultaCEViejo = @"UPDATE CambiosEstadoTurno
                                    SET fechaHoraHasta = @fechaHora
            
                                    Where idTurno = @idTurno AND idEstado = @idEstadoViejo AND (fechaHoraHasta is NULL OR fechaHoraHasta = '')";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fechaHora", DateTime.Parse(fechaHora.ToString("yyyy-MM-dd")));
                cmd.Parameters.AddWithValue("@idTurno", turno.oid);
                cmd.Parameters.AddWithValue("@idEstadoViejo", idEstadoViejo);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consultaCEViejo;

                cmd.ExecuteNonQuery();


                string consultaCENuevo = @"INSERT INTO CambiosEstadoTurno (idEstado, idTurno, fechaHoraDesde)
                                           VALUES(@idEstado, @idTurno, @fechaHora)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idEstado", cambioEstadoNuevo.estado.oid);
                cmd.Parameters.AddWithValue("@fechaHora", DateTime.Parse(cambioEstadoNuevo.fechaHoraDesde.ToString("yyyy-MM-dd")));
                cmd.Parameters.AddWithValue("@idTurno", turno.oid);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consultaCENuevo;

                cmd.ExecuteNonQuery();


                objetotransaccion.Commit();

                return true;



            }
            catch (Exception ex)
            {

                objetotransaccion.Rollback();
                return false;
            }
            finally
            {
                cn.Close();
            }

            
        }
    }
}
