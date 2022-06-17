namespace pruebaPPAI.Entidades
{
    public class Turno
    {
        public DateTime FechaGeneracion { get; set; }
        public string DiaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public List<CambioEstadoTurno> CambioEstadoTurno { get; set; }

        public Turno(DateTime fechaGeneracion, string diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            this.FechaGeneracion = fechaGeneracion;
            this.DiaSemana = diaSemana;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.CambioEstadoTurno = new List<CambioEstadoTurno>();
        }

        public string mostrarTurno()
        {
            return "Desde" + this.fechaHoraInicio + "Hasta" + this.fechaHoraFin;
        }

        //public bool estoyDisponible()
        //{
        //    if (this.CambioEstadoTurno.estado.Equals("disponible")) { return true; };
        //    return false;
        //}

    }
}