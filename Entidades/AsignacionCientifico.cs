using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades
{
    public class AsignacionCientifico
    {
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public PersonalCientifico PersonalCientifico { get; set; }

        public List<Turno> Turnos { get; set; }

        public AsignacionCientifico(DateTime fechaDesde, PersonalCientifico personalCientifico)
        {
            this.FechaDesde = fechaDesde;
            this.FechaHasta = null;
            this.PersonalCientifico = personalCientifico;
            this.Turnos = new List<Turno>();

        }

        public bool esActivo()
        { //retorna true si la fechaHasta de asignacion es nula, por lo tanto el cientif sigue activo.
            if(this.FechaHasta == null) { return true; }
            return false;
        }
    }
}
