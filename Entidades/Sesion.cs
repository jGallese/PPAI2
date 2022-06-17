using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades
{
    public class Sesion
    {
        public DateTime FechaHoraDesde { get; set; }
        public DateTime FechaHoraHasta { get; set; }
        public Usuario? Usuario { get; set; }
    
        public Sesion(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Usuario usuario)
        {
            this.FechaHoraDesde = fechaHoraDesde;
            this.FechaHoraHasta = fechaHoraHasta;
            this.Usuario = usuario;
        }
    }

}
