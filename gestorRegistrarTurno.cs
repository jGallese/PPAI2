using pruebaPPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI
{
    public class gestorRegistrarTurno
    { // TODO: realizar cambios:
            // gestor no debe pasar objetos ni listas a la interfaz, solamente debe pasar strings
            //modificar metodos para que cada uno envie una lista de strings para rellenar 
            //grillas de la interfaz
        public TipoRecurso TipoRecursoSeleccionado { get; set; }

        public RecursoTecnologico RTSeleccionado { get; set; }
        public Turno TurnoReservado { get; set; }

        public Usuario UsuarioLogueado { get; set; }
        public DateTime FechaActual { get; set; }
        public EstadoTurno EstadoReservado { get; set; }

        public CambioEstadoTurno CambioEstadoActual{ get; set; }


        baseDeDatos bdd = new baseDeDatos();

        


        public List<TipoRecurso> opcReservarTurno(Form pant)
        {
            //comienza la reserva del caso de uso
            return this.buscarTipoRT(bdd);
        }

        public List<TipoRecurso> buscarTipoRT(baseDeDatos bdd)
        {//retorna la lista de tipos recursos 
            return bdd.listaTiposRecursos; //mensaje *getTipoRecurso

        }
        public List<RecursoTecnologico> tomarSeleccionTipoRecurso(TipoRecurso tipoRecurso)
        {//guarda el tipo de recurso seleccionado por el cliente y busca los recursos del tipo seleccionado por el cliente
            this.TipoRecursoSeleccionado = tipoRecurso;
            List<RecursoTecnologico> lista = buscarRTsDelTipo();
            return lista;
        }

        public List<RecursoTecnologico> buscarRTsDelTipo()
        //busca todos los recursos tecnologicos que correspondan al TipoRecurso seleccionado
        // y esten disponibles para aceptar reservas (no esta en baja tecnica o mant preventivo)
        {
            List<RecursoTecnologico> listaRecursosReservables = new List<RecursoTecnologico>();

            foreach (RecursoTecnologico rt in bdd.listaRecursosTecnologicos)
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

        public void tomarSeleccionRT(RecursoTecnologico recurso)
        {
            //obtiene el recurso seleccionado por el cientifico
            this.RTSeleccionado = recurso;
            bool cientifico = verificarCientificoEnCi(bdd.sesionActual);
        }

        public bool verificarCientificoEnCi(Sesion sesion)
        {
            //verifica que cientifico logueado pertenezca al centro del recurso que se selecciono anteriormente.

            PersonalCientifico cientificoLogueado = sesion.getCientificoEnSesion(bdd); // obtiene cientifico
            bool resultado = RTSeleccionado.estaEnMiCI(bdd, cientificoLogueado); //realiza validacion

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

        public List<Turno> agruparYOrdenarTurnos()
        {
            //trae todos los turnos del recurso seleccionado, comprobando que sean posteriores a la fecha actual del sistema.
            List<Turno> listaTurnos = new List<Turno>();
            listaTurnos = RTSeleccionado.mostrarMisTurnos(getFechaActual());
            return listaTurnos;
        }

        public void tomarSeleccionTurno(Turno turnoSeleccionado)
        {            //obtiene el turno seleccionado por el cientifico

            this.TurnoReservado = turnoSeleccionado;
            this.CambioEstadoActual = turnoSeleccionado.
        }

        public void tomarConfirmacion(PantallaRegistrarTurnos interfaz)
        {   //una vez confirmada la reserva del turno, llama a solicitar tipo de notificacion

            interfaz.solicitarTipoNotificacion();
            
        }

        internal void tomarTipoNotificacion(string a)
        {            //obtiene el tipo de notificacion seleccinado por el cientifico

            MessageBox.Show("Los datos de su reserva serán enviados por " + a);
            obtenerEstadoReservado();
        }

        private void obtenerEstadoReservado()
        { //busca en la bdd el estado de turno con nombre reservado
            //foreach (EstadoTurno estado in bdd.listaEstados)
            //{
            //    if (estado.EsAmbitoTurno())
            //    {
            //        if (estado.EsReservado())
            //        {
            //            this.EstadoReservado = estado;
            //            break;
            //        }
            //    }
                
            //} NO LO HACE PORQUE TIENE QUE TRAER EL ESTADO RESERVADO
            TurnoReservado.reservar(FechaActual, CambioEstadoActual);

            generarNotificacion(bdd.email);
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
