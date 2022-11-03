
using PPAI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{

    
    public class AsignacionCientifico : ObjetoPersistente
    {
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public PersonalCientifico personalCientifico { get; set; }

        public virtual IList<Turno> Turnos { get; set; }

        public AsignacionCientifico()
        {

        }
        public AsignacionCientifico(DateTime fechaDesde, PersonalCientifico personalCientifico)
        {
            this.FechaDesde = fechaDesde;
            this.FechaHasta = null;
            this.personalCientifico = personalCientifico;
            this.Turnos = new List<Turno>();

        }


        public bool esActivo()
        { //retorna true si la fechaHasta de asignacion es nula, por lo tanto el cientif sigue activo.
            if(this.FechaHasta == null) { return true; }
            return false;
        }
    }
}
