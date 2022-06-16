namespace pruebaPPAI.Entidades
{
    public class Turno
    {
        public DateTime FechaGeneracion { get; set; }
        public string DiaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public CambioEstadoTurno CambioEstadoTurno { get; set; }

        public Turno(DateTime fechaGeneracion, string diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin, CambioEstadoTurno cambioEstadoTurno)
        {
            this.FechaGeneracion = fechaGeneracion;
            this.DiaSemana = diaSemana;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.CambioEstadoTurno = cambioEstadoTurno;
        }

        public string mostrarTurno()
        {
            return "Desde" + this.fechaHoraInicio + "Hasta" + this.fechaHoraFin;
        }

        public bool estoyDisponible()
        {
            if (this.CambioEstadoTurno.estado.Equals("disponible")) { return true; };
            return false;
        }

    }
}