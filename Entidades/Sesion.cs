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
        public DateTime? FechaHoraHasta { get; set; }
        public Usuario Usuario { get; set; }
    
        public Sesion(DateTime fechaHoraDesde, Usuario usuario)
        {
            this.FechaHoraDesde = fechaHoraDesde;
            this.FechaHoraHasta = null;
            this.Usuario = usuario;
        }

        public PersonalCientifico getCientificoEnSesion(baseDeDatos bdd)
        {
            //retorna el cientifico que se encuentra utilizando el sistema.
            PersonalCientifico personal = this.Usuario.getCientifico(bdd);
            return personal;
        }
    }

}
