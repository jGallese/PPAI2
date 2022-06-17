using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI.Entidades
{
    public class AsignacionCientifico
    {
        public DateTime FechaHoraDesde { get; set; }
        public DateTime FechaHoraHasta { get; set; }
        public PersonalCientifico PersonalCientifico { get; set; }

        public List<Turno> Turnos { get; set; }

        public AsignacionCientifico(DateTime fechaHoraDesde, DateTime fechaHoraHasta, PersonalCientifico personalCientifico)
        {
            this.FechaHoraDesde = fechaHoraDesde;
            this.FechaHoraHasta = fechaHoraHasta;
            this.PersonalCientifico = personalCientifico;
            this.Turnos = new List<Turno>();

        }
    }
}
