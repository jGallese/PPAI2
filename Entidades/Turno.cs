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
        {//muestra datos del turno
            return "Desde " + this.fechaHoraInicio + "\nHasta " + this.fechaHoraFin;
        }

        public bool esPosteriorFechaActual(DateTime fechaActual)
        {//retorna true si el turno es posterior a la fecha actual tomada por el sistema.
            if (this.fechaHoraInicio >= fechaActual)
            {
                return true;
            };
            return false;
        }

        public Turno getDatos()
        {//retorna el turno como un objeto
            return this;
            
        }

        public void reservar(DateTime fechaActual, Estado estReservado)
        {//buscar cambioEstadoActual, para setearle la fecha de fin. Crear un cambio estado nuevo y pasarle como estado el que se encuentra en el gestor.

            foreach (CambioEstadoTurno cambioEstado in CambioEstadoTurno)
            {
                if (cambioEstado.EsActual())
                {
                    cambioEstado.setFechaHasta(fechaActual);        
                }
            }

            CambioEstadoTurno.Add(new CambioEstadoTurno(fechaActual, estReservado));

        }


    }
}