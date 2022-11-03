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
    public class AD_RTs
    {
        public static DataTable getRecursosTecnologicosParaTabla()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = @"SELECT RT.*, M.nombre as 'nombreModelo', Marca.nombre, 
                                    from RecursosTecnologicos RT JOIN Modelos M ON RT.idModelo = M.idModelo
                                    ";


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

        public static List<RecursoTecnologico> getRecursosTecnologicosObjetos()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            DataTable dtCERT = AD_CestadoRT.getCambiosEstados();
            

            List<RecursoTecnologico> listaRecs = new List<RecursoTecnologico>();
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = @"SELECT RT.*, M.nombre as 'nombreModelo', M.idModelo, TR.nombre as 'nombreTipoRecurso', TR.descripcion as 'descripcionTR'
                                    from RecursosTecnologicos RT JOIN Modelos M ON RT.idModelo = M.idModelo
                                    JOIN TIPOSRECURSOTECNOLOGICO TR ON RT.idTipoRT = TR.idTipoRT";

                cmd.Parameters.Clear(); // limpiar parametros
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
                    RecursoTecnologico recurso = new RecursoTecnologico();
                    recurso.numeroRT = int.Parse(row["numeroRT"].ToString());
                    recurso.oid = (int)row["idCentro"];
                    recurso.fechaAlta = DateTime.Parse(row["fechaAlta"].ToString());
                    recurso.modeloRT = new Modelo(row["nombreModelo"].ToString());
                    recurso.modeloRT.oid = (int)row["idModelo"];
                    recurso.tipoRecurso = new TipoRecurso(row["nombreTipoRecurso"].ToString(), row["descripcionTR"].ToString());
                    recurso.tipoRecurso.oid = (int)row["idTipoRT"];
                    recurso.fraccionHorariosTurnos = TimeOnly.Parse(row["fraccionHorarioTurno"].ToString());
                    recurso.duracionMantPrev = DateTime.Parse(row["duracionMantenimientoPreventivo"].ToString());
                    recurso.periodicidadMantenimientoPrev = DateTime.Parse(row["periodicidadMantenimientoPreventivo"].ToString());
                    recurso.ListaCambioEstadosRT = new List<CambioEstadoRT>();

                    foreach (DataRow rowCE in dtCERT.Rows)
                    {
                        if (row["numeroRT"].Equals(rowCE["nroRecTec"]))
                        {
                            CambioEstadoRT ce = new CambioEstadoRT();
                            ce.FechaHoraDesde = (DateTime)rowCE["fechaHoraDesde"];
                            if (rowCE["fechaHoraHasta"].ToString() == "")
                            {
                                ce.FechaHoraHasta = null;
                            }else
                            {
                                ce.FechaHoraHasta = (DateTime)rowCE["fechaHoraHasta"];
                            }


                            ce.estadoRecurso = new EstadoRecurso(rowCE["nombre"].ToString(), rowCE["descripcion"].ToString(), (bool)rowCE["esReservable"], (bool)rowCE["esCancelable"] );
                            ce.estadoRecurso.oid = (int)rowCE["idEstado"];

                            recurso.ListaCambioEstadosRT.Add(ce);
                        }
                    }
                    listaRecs.Add(recurso);

                }

                return listaRecs;
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
