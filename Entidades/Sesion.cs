using PPAI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Sesion : ObjetoPersistente
    {
        public DateTime FechaHoraDesde { get; set; }
        public DateTime? FechaHoraHasta { get; set; }
        public virtual Usuario Usuario { get; set; }
    
        public Sesion(DateTime fechaHoraDesde, Usuario usuario)
        {
            this.FechaHoraDesde = fechaHoraDesde;
            this.FechaHoraHasta = null;
            this.Usuario = usuario;
        }

        public Sesion()
        {

        }
        public PersonalCientifico getCientificoEnSesion()
        {
            //retorna el cientifico que se encuentra utilizando el sistema.
            PersonalCientifico personal = this.Usuario.getCientifico(this.Usuario.oid);
            return personal;
        }
    }

}
