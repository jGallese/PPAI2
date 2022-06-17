using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades
{
    public class CambioEstadoRT
    {
        public DateTime FechaHoraDesde { get; set; }
        public DateTime? FechaHoraHasta { get; set; }
        public Estado Estado { get; set; }
        public CambioEstadoRT(DateTime fechaHoraDesde, Estado estado)
        {
            this.FechaHoraDesde = fechaHoraDesde;
            this.FechaHoraHasta = null;
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
