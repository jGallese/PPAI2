namespace pruebaPPAI.Entidades
{
    public class Mantenimiento
    {
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime FechaInicioPrevista { get; set; }
        public string MotivoMantenimiento { get; set; }

        public Mantenimiento(DateTime fechaInicio, DateTime fechaInicioPrevista, string motivoMantenimiento)
        {
            this.FechaInicio = fechaInicio;
            this.FechaFin = null;
            this.FechaInicioPrevista = fechaInicioPrevista;
            this.MotivoMantenimiento = motivoMantenimiento;
        }

    }
}