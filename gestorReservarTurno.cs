using pruebaPPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI
{
    internal class gestorRegistrarTurno
    {

        public TipoRecurso TipoRecursoSeleccionado { get; set; }

        public RecursoTecnologico RTSeleccionado { get; set; }
        public Turno TurnoReservado { get; set; }

        public Usuario UsuarioLogueado { get; set; }
        public DateTime FechaActual { get; set; }
        public Estado EstadoReservado { get; set; }


        baseDeDatos bdd = new baseDeDatos();


        public List<TipoRecurso> opcReservarTurno(Form pant)
        {
            return this.buscarTipoRT(bdd);
        }

        public List<TipoRecurso> buscarTipoRT(baseDeDatos bdd)
        {
            return bdd.listaTiposRecursos; //mensaje *getTipoRecurso

        }
        public List<RecursoTecnologico> tomarSeleccionTipoRecurso(TipoRecurso tipoRecurso)
        {
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

        public void agruparPorCI(List<RecursoTecnologico> lista)
        {
        }

        public void tomarSeleccionRT(RecursoTecnologico recurso)
        {
            this.RTSeleccionado = recurso;
            verificarCientificoEnCi(bdd.sesionActual);
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
            listaTurnos = RTSeleccionado.mostrarMisTurnos(FechaActual);
            return listaTurnos;
        }
    }
}
