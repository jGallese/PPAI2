using PPAI.ADO;
using PPAI.Entidades;
using PPAI.Entidades.EstadosConcretos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI
{
    public class gestorRegistrarTurno
    { // TODO: realizar cambios:
            // gestor no debe pasar objetos ni listas a la interfaz, solamente debe pasar strings
            //modificar metodos para que cada uno envie una lista de strings para rellenar 
            //grillas de la interfaz
        public TipoRecurso TipoRecursoSeleccionado { get; set; }

        public List<RecursoTecnologico> listaRecursos = new List<RecursoTecnologico>();

        public RecursoTecnologico RTSeleccionado { get; set; }
        public Turno TurnoSeleccionado { get; set; }

        public Usuario UsuarioLogueado { get; set; }
        public DateTime FechaActual { get; set; }
        public EstadoTurno EstadoReservado { get; set; }

        public List<Turno> listaTurnos{ get; set; }
        public CambioEstadoTurno CambioEstadoActual{ get; set; }

        public List<CentroInvestigación> ListaCentrosInvestigacion = AD_Centros.GetCentroInvestigacion();

        


        public void opcReservarTurno(PantallaRegistrarTurnos pantalla)
        {
            //comienza la reserva del caso de uso
            DataTable dTable = buscarTipoRT();
            pantalla.dgv_TiposRecursos.DataSource = dTable;
        }

        public DataTable buscarTipoRT()
        {//retorna la lista de tipos recursos 

            return ADO.AD_TiposRecursos.getTiposRecursos(); //mensaje *getTipoRecurso

        }
        public void tomarSeleccionTipoRecurso(TipoRecurso tipoRecurso, PantallaRegistrarTurnos pantalla)
        {//guarda el tipo de recurso seleccionado por el cliente y busca los recursos del tipo seleccionado por el cliente
            this.TipoRecursoSeleccionado = tipoRecurso;
            this.listaRecursos = buscarRTsDelTipo();

            //LLENAR LA DGV DE LA PANTALLA
            foreach (RecursoTecnologico rt in listaRecursos)
            {
                string rtEstadoActual = "";
                foreach (CambioEstadoRT cambioEstado in rt.ListaCambioEstadosRT)
                {

                    if (cambioEstado.EsActual())
                    {
                        rtEstadoActual = cambioEstado.estadoRecurso.Nombre;
                    }
                }


                pantalla.dgv_Recursos.Rows.Add(new string[] { rt.getNombreCI(ListaCentrosInvestigacion).Nombre, rt.numeroRT.ToString(), rt.modeloRT.getMarcaYModelo(), rt.modeloRT.nombre, rtEstadoActual });



                if (rtEstadoActual == "Disponible")
                {
                    pantalla.dgv_Recursos.Rows[listaRecursos.IndexOf(rt)].Cells[4].Style.BackColor = Color.Blue;
                    pantalla.dgv_Recursos.Rows[listaRecursos.IndexOf(rt)].Cells[4].Style.ForeColor = Color.White;
                }
                else if (rtEstadoActual == "En Mantenimiento")
                {
                    pantalla.dgv_Recursos.Rows[listaRecursos.IndexOf(rt)].Cells[4].Style.BackColor = Color.Green;
                    pantalla.dgv_Recursos.Rows[listaRecursos.IndexOf(rt)].Cells[4].Style.ForeColor = Color.White;
                }
                else
                {
                    pantalla.dgv_Recursos.Rows[listaRecursos.IndexOf(rt)].Cells[4].Style.BackColor = Color.LightGray;
                }


            }


        }

        public List<RecursoTecnologico> buscarRTsDelTipo()
        //busca todos los recursos tecnologicos que correspondan al TipoRecurso seleccionado
        // y esten disponibles para aceptar reservas (no esta en baja tecnica o mant preventivo)
        {
            //TODO: tendria que traer todos los recursos de la base, con los cambios de estados y los estados, despues crear los objetos

            List<RecursoTecnologico> recursosDisponibles = AD_RTs.getRecursosTecnologicosObjetos();
            List<RecursoTecnologico> listaRecursosReservables = new List<RecursoTecnologico>();

            foreach (RecursoTecnologico rt in recursosDisponibles)
            {
                if (rt.esTipoRT(this.TipoRecursoSeleccionado)/*pertenece a TR*/ && rt.esActivo()) /*acepta reserva*/
                {
                    listaRecursosReservables.Add(rt);

                    

                }
            }

            return listaRecursosReservables;
        }

        public void agruparPorCI(PantallaRegistrarTurnos pant)
        {//Llama a metodo de solicitar seleccion de recursos, los rts se agrupan solos en la tabla
            pant.solicitarSeleccionRT();
        }

        public void tomarSeleccionRT(int nroRecurso)
        {
            

            foreach (RecursoTecnologico recurso in listaRecursos)
            {
                if (recurso.numeroRT == nroRecurso)
                {
                    this.RTSeleccionado = recurso;
                    break;
                }
            }
            //obtiene el recurso seleccionado por el cientifico
            
            bool cientifico = verificarCientificoEnCi(AD_Sesiones.getSesion()); //me trae la sesion actual
        }

        public bool verificarCientificoEnCi(Sesion sesion)
        {
            //verifica que cientifico logueado pertenezca al centro del recurso que se selecciono anteriormente.

            PersonalCientifico cientificoLogueado = sesion.getCientificoEnSesion(); // obtiene cientifico que se encuentra en la sesion activa del sistema
            bool resultado = RTSeleccionado.estaEnMiCI(ListaCentrosInvestigacion, cientificoLogueado); //realiza validacion

            //muestra resultados dependiendo de si pertenece o no
            if (resultado)
            {
                MessageBox.Show("Científico Pertenenciente al Centro de Investigacion del recurso seleccionado");
            }
            else { MessageBox.Show("Científico NO Pertenenciente al Centro de Investigacion del recurso seleccionado"); }
            return resultado;
        }

        public DateTime getFechaActual()
        {
            //obtiene la fecha actual del sistema y guarda en la variable FechaActual
            return this.FechaActual = DateTime.Now;
        }

        public void agruparYOrdenarTurnos(PantallaRegistrarTurnos pantalla)
        {
            //trae todos los turnos del recurso seleccionado, comprobando que sean posteriores a la fecha actual del sistema.
            this.listaTurnos = new List<Turno>();
            this.listaTurnos = RTSeleccionado.mostrarMisTurnos(getFechaActual());

            pantalla.dgv_Fechas.MultiSelect = false;
            pantalla.dgv_Fechas.ColumnCount = 1;

            pantalla.dgv_Fechas.Columns[0].Name = "Fecha";
            //pantalla.dgv_Fechas.Columns[0].Width = 150;
            //pantalla.dgv_Fechas.Width = 200;

            pantalla.dgv_Fechas.Rows.Clear();

            List<string> fechas = new List<string>();
            foreach (Turno turno in listaTurnos)
            {
                string fechaTurno = turno.fechaHoraInicio.ToShortDateString();
                if (!(fechas.Contains(fechaTurno)))
                {
                    fechas.Add(fechaTurno);
                }
            }

            //Lista para ver las fechas que hay que agregar al dgv
            foreach (string fecha in fechas)
            {
                pantalla.dgv_Fechas.Rows.Add(new string[] { fecha });
            }


            
            
            


            //pintar fechas dependiendo de las distintas disponibilidades del turno
            for (int i = 0; i < pantalla.dgv_Fechas.Rows.Count; i++)
            {
                // cada fecha del calendar

                DataGridViewCell currFila = pantalla.dgv_Fechas.Rows[i].Cells[0];
                int contadorDispFecha = 0; // contador interno por fecha
                
                foreach (Turno tur in listaTurnos) // recorro turnos
                {
                    if (tur.fechaHoraInicio.Date.ToShortDateString() == currFila.Value.ToString()) //turno de la misma fecha
                    {
                        if (tur.estado.Nombre.Equals("Disponible") )
                        {
                            contadorDispFecha += 1;
                        }
                        //foreach (CambioEstadoTurno ce in tur.CambioEstadoTurno) // conseguir CE actual
                        //{
                        //    if (ce.EsActual())
                        //    {
                        //        if (ce.estado.Nombre == "Disponible") //si es disponible, agregar 1 al contador de fecha particular
                        //        {
                                    
                        //        }
                        //    }
                        //}
                    }

                }
                if (contadorDispFecha == 0)
                {
                    currFila.Style.BackColor = Color.Red;
                }
                else { currFila.Style.BackColor = Color.LightBlue; }

            }
        }


        public void CargarGrillaTurnos(PantallaRegistrarTurnos pantalla, DateTime fechaSeleccionada)
        {
            List<Turno> listAuxTurn = new List<Turno>();

            foreach (Turno turno in this.listaTurnos)
            { //busca de la lista de turnos total, los que coincidan con la fecha
                if (turno.fechaHoraInicio.ToLongDateString() == fechaSeleccionada.ToLongDateString())
                {
                    listAuxTurn.Add(turno);
                }
            }
            this.listaTurnos = listAuxTurn;

            //crea la tabla
            pantalla.dgv_Turnos_De_fecha.Rows.Clear();


            //llena la tabla
            foreach (Turno tt in listAuxTurn)
            {
                string ttEstadoActual = tt.estado.Nombre;




                pantalla.dgv_Turnos_De_fecha.Rows.Add(new string[] { tt.fechaHoraInicio.ToShortTimeString(), tt.fechaHoraFin.ToShortTimeString(), ttEstadoActual });


                //por cada turno de la tabla, se fija en su estado y pinta la celda
                if (ttEstadoActual == "Disponible")
                {
                    pantalla.dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.BackColor = Color.Blue;
                    pantalla.dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.ForeColor = Color.White;
                }
                else if (ttEstadoActual == "Con reserva pendiente de confirmacion")
                {
                    pantalla.dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.BackColor = Color.LightGray;

                }
                else if (ttEstadoActual == "Reservado")
                {
                    pantalla.dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.BackColor = Color.Red;
                }


            }
        }
        public void tomarSeleccionTurno(Turno turnoSeleccionado)
        {            //obtiene el turno seleccionado por el cientifico

            this.TurnoSeleccionado = turnoSeleccionado;
            //this.CambioEstadoActual = turnoSeleccionado.CambioEstadoTurno.FirstOrDefault();
        }

        public void tomarConfirmacion(PantallaRegistrarTurnos interfaz)
        {   //una vez confirmada la reserva del turno, llama a solicitar tipo de notificacion

            interfaz.solicitarTipoNotificacion();
            
        }

        internal void tomarTipoNotificacion(string a)
        {            //obtiene el tipo de notificacion seleccinado por el cientifico

            MessageBox.Show("Los datos de su reserva serán enviados por " + a);
            //EMPEXAR APLICACION DEL PATRON
            RTSeleccionado.registrarReserva(this.FechaActual, this.TurnoSeleccionado);
            InterfazEmail interfaz = new InterfazEmail();
            generarNotificacion(interfaz);
        }

        

        private void generarNotificacion(InterfazEmail email)
        {   //le envia al objeto de interfaz email el mensaje para que envie la notificacion.

            email.enviarNotificacion();
            finCU();

        }

        private void finCU()
        {//termina el caso de uso. No es mucho, pero es trabajo honesto.
            MessageBox.Show("Se generó la notificacion de la reserva del turno confirmado previamente\n" +
                "Le llegará la notificacion por el medio seleccionado");
        }
    }
}
