using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades
{
    public class RecursoTecnologico
    {
        //Propiedades
        public int numeroRT { get; set; }
        public DateTime fechaAlta { get; set; }
        public Image imagenes { get; set; }
        public DateTime periodicidadMantenimientoPrev { get; set; }
        public DateTime duracionMantPrev { get; set; }
        public TimeOnly fraccionHorariaTurno { get; set; }

        public TipoRecurso tipoRecurso { get; set; }

        public Modelo modeloRT { get; set; }
        public List<Mantenimiento> ListaMantenimientos { get; set; }

        public List<Turno> ListaTurnos { get; set; }
        public List<CambioEstadoRT> ListaCambioEstadosRT { get; set; }

        //Constructor

        public RecursoTecnologico(int numeroRT, DateTime fechaAlta, Image imagenes, DateTime periodicidadMantenimientoPrev, DateTime duracionMantPrev, TimeOnly fraccionHorariaTurno, TipoRecurso tipoRecurso, Modelo modeloRT)
        {
            this.numeroRT = numeroRT;
            this.fechaAlta = fechaAlta;
            this.imagenes = imagenes;
            this.periodicidadMantenimientoPrev = periodicidadMantenimientoPrev;
            this.duracionMantPrev = duracionMantPrev;
            this.fraccionHorariaTurno = fraccionHorariaTurno;
            this.tipoRecurso = tipoRecurso;
            this.modeloRT = modeloRT;
            this.ListaMantenimientos = new List<Mantenimiento>();
            this.ListaTurnos = new List<Turno>();
            this.ListaCambioEstadosRT = new List<CambioEstadoRT>();

        }

        //Metodos
        public bool esTipoRT(TipoRecurso tipoRec)
        {
            if (this.tipoRecurso.Equals(tipoRec))
            {
                return true;
            }
            return false;
        }

        public bool esActivo()
        {
            //busca por cada cambio de estado cual es el actual, y al actual le pregunta si es reservable
            //retorna true si es reservable el recurso, retorna false si el recurso no esta en estado reservable
            CambioEstadoRT actual = null;
            foreach (CambioEstadoRT cambioEstado in this.ListaCambioEstadosRT)
            {

                if (cambioEstado.EsActual())
                {
                    actual = cambioEstado;

                }
            }
            if (actual.EsReservable())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool estaEnMiCI()
            {
                /*TODO: devuelve true si el cientifico logueado pertenece al centro de investigacion 
                    que contiene al recurso tecnologico seleccionado
                 */
                return true;
            }
            
        

    }

    
}
