using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades
{
    internal class CambioEstadoRT
    {
        public DateTime FechaHoraDesde { get; set; }
        public DateTime? FechaHoraHasta { get; set; }
        public Estado Estado { get; set; }
        public CambioEstadoRT(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Estado estado)
        {
            this.FechaHoraDesde = fechaHoraDesde;
            this.FechaHoraHasta = fechaHoraHasta;
            this.Estado = estado;
        }

        public bool EsActual()
        {
            if (this.FechaHoraHasta.Equals(null))
            {
                return true;
            }
            return false;
        }

        internal bool EsReservable()
        {
            if (this.Estado.EsReservable)
            {
                return true;
            }
            return false;
        }
    }
}
