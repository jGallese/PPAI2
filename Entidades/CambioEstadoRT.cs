using PPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class CambioEstadoRT
    {
        public DateTime FechaHoraDesde { get; set; }
        public DateTime? FechaHoraHasta { get; set; }
        public virtual EstadoRecurso estadoRecurso { get; set; }

        public CambioEstadoRT()
        {

        }
        public CambioEstadoRT(DateTime fechaHoraDesde, EstadoRecurso estadoRecurso)
        {
            this.FechaHoraDesde = fechaHoraDesde;
            this.FechaHoraHasta = null;
            this.estadoRecurso = estadoRecurso;
        }

        public bool EsActual()
        {//retorna true si el cambio de estado es el actual (fechafin es nula)
            if (this.FechaHoraHasta.Equals(null))
            {
                return true;
            }
            return false;
        }

        internal bool EsReservable()
        { // retorna true si el estado asociado alcambio de estado es reservable
            if (this.estadoRecurso.EsReservable)
            {
                return true;
            }
            return false;
        }
    }
}
