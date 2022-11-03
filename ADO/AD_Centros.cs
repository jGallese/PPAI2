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
    public class AD_Centros
    {
        public static List<CentroInvestigación> GetCentroInvestigacion()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            DataTable dtAsignaciones = AD_Asignaciones.getAsignaciones();


            List<RecursoTecnologico> listaRecs = AD_RTs.getRecursosTecnologicosObjetos();
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = @"SELECT CI.*
                                    FROM CENTROSINVESTIGACION CI";

                cmd.Parameters.Clear(); // limpiar parametros
                cmd.CommandType = CommandType.Text; // asignar que el tipo de comando es de texto. Significa que se va a escribir a mano el comando que se va a usar
                cmd.CommandText = consulta; //el texto del comando es la consulta que se escribio antes


                cn.Open(); // abrir la conexion

                cmd.Connection = cn; // asignar al objeto command la conexion abierta

                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd); //le pasa al da la consulta. Ejecuta la consulta y carga en la tabla
                da.Fill(tabla); // el da llena la tabla especificada con los datos de la consulta


                List<CentroInvestigación> listaCentros = new List<CentroInvestigación>();
                foreach (DataRow row in tabla.Rows)
                {
                    //PARA CADA CENTRO DE INVESTIGACION

                    CentroInvestigación centro= new CentroInvestigación();
                    centro.oid = (int)row["idCentro"];
                    centro.Nombre = row["nombre"].ToString();
                    centro.sigla = row["sigla"].ToString();
                    centro.direccion = row["direccion"].ToString();
                    centro.edificio = row["edificio"].ToString();
                    centro.piso = (int)row["piso"];
                    centro.coordenadas = (int)row["coordenadas"];
                    centro.telefonoContacto = row["telefonoContacto"].ToString();
                    centro.correoElectronico = row["correoElectronico"].ToString();
                    centro.caracteristicasGenerales = row["caracteristicasGenerales"].ToString();
                    centro.numeroResolucion = (int)row["numeroResolucion"];
                    centro.fechaResolucionCreacion = DateTime.Parse(row["fechaResolucionCreacion"].ToString());
                    centro.reglamento = row["reglamento"].ToString();
                    centro.fechaAlta = DateTime.Parse(row["fechaAlta"].ToString());
                    centro.tiempoAntelacionReserva = DateTime.Parse(row["tiempoAntelacionReserva"].ToString());
                    centro.AsignacionCientificos = new List<AsignacionCientifico>();
                    centro.ListaRecursosTecnologicos = new List<RecursoTecnologico>();


                    foreach (DataRow rowAsig in dtAsignaciones.Rows)
                    { 
                        // PARA CADA ASIGNACION QUE VAYA EN EL CENTRO DE INVESTIGACION

                        if (row["idCentro"].Equals(rowAsig["idCentro"]))
                        {
                            AsignacionCientifico asignacion = new AsignacionCientifico();
                            asignacion.oid = (int)rowAsig["idAsignacion"];
                            asignacion.FechaDesde = (DateTime)rowAsig["fechaDesde"];
                            if (rowAsig["fechaHasta"].ToString() == "")
                            {
                                asignacion.FechaHasta = null;
                            }
                            else
                            {
                                asignacion.FechaHasta = (DateTime)rowAsig["fechaHoraHasta"];
                            }


                            asignacion.personalCientifico = new PersonalCientifico((int)rowAsig["legajo"], 
                                                                                        rowAsig["nombre"].ToString(), 
                                                                                        rowAsig["apellido"].ToString(), 
                                                                                        (int)rowAsig["nroDocumento"],
                                                                                        rowAsig["correoInstitucional"].ToString(),
                                                                                        rowAsig["correoPersonal"].ToString(),
                                                                                        rowAsig["telefonoCelular"].ToString(),
                                                                                        usuario: new Usuario(rowAsig["nombreUsuario"].ToString(), 
                                                                                                             rowAsig["contraseña"].ToString())
                                                                                        );
                            asignacion.personalCientifico.Usuario.oid = (int)rowAsig["idUsuario"];
                                
                            

                            centro.AsignacionCientificos.Add(asignacion);
                        }
                    }

                    foreach (RecursoTecnologico recurso in listaRecs)
                    {
                        if (recurso.oid.Equals(centro.oid))
                        {
                            centro.ListaRecursosTecnologicos.Add(recurso);
                        }

                    }
                    listaCentros.Add(centro);

                }

                return listaCentros;
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
