using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class AsignacionDirector
    {
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public PPAI.Entidades.PersonalCientifico personalCientifico { get; set; }
        
        public AsignacionDirector()
        {

        }
        public AsignacionDirector(DateTime fechaDesde, PersonalCientifico personalCientifico)
        {
            this.FechaDesde = fechaDesde;
            this.FechaHasta = null;
            this.personalCientifico = personalCientifico;
        }

    }
}
