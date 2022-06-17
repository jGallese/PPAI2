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
        public Estado  EstadoReservado { get; set; }


        baseDeDatos bdd = new baseDeDatos();


        public List<TipoRecurso> opcReservarTurno( Form pant)
        {
            return this.buscarTipoRT(bdd);
        }

        public List<TipoRecurso> buscarTipoRT(baseDeDatos bdd)
        {
            return bdd.listaTiposRecursos; //mensaje *getTipoRecurso

        }
        public void tomarSeleccionTipoRecurso(TipoRecurso tipoRecurso)
        {
            this.TipoRecursoSeleccionado = tipoRecurso;
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
            //List<>
            List<Tuple<CentroInvestigación, List<RecursoTecnologico>>> matrizCentros = new List<Tuple<CentroInvestigación, List<RecursoTecnologico>>>();
            
            foreach (RecursoTecnologico rt in lista)
            {
                //rt. VER COMO SE PUEDE AGRUPAR LA LISTA DE RECURSOS POR CENTRO DE INVESTIGACION
            }
        }
    }
}
