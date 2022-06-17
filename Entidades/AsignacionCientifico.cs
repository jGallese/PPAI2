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
        public DateTime FechaHasta { get; set; }
        public PersonalCientifico PersonalCientifico { get; set; }

        public List<Turno> Turnos { get; set; }

        public AsignacionCientifico(DateTime fechaDesde, DateTime fechaHasta, PersonalCientifico personalCientifico)
        {
            this.FechaDesde = fechaDesde;
            this.FechaHasta = fechaHasta;
            this.PersonalCientifico = personalCientifico;
            this.Turnos = new List<Turno>();

        }
    }
}
