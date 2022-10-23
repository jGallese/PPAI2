using pruebaPPAI.Entidades.EstadosConcretos;

namespace pruebaPPAI.Entidades
{
    public class Turno
    {
        public DateTime FechaGeneracion { get; set; }
        public string DiaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public List<CambioEstadoTurno> CambioEstadoTurno { get; set; }

        public EstadoTurno estado { get; set; }

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

        public void reservar(DateTime fechaActual, CambioEstadoTurno cambioEActual)
        {
            //LLAMAR AL OBJETO ESTADO DISPONIBLE, LA OPERACION RESERVAR, APLICANDO DELEGACION
            Disponible eDisponible = new Disponible();
            eDisponible.reservar(fechaActual, cambioEActual, this);

            CambioEstadoTurno.Add(new CambioEstadoTurno(fechaActual, estReservado));

        }

        public void agregarCambioEstado(CambioEstadoTurno nuevo) 
        {
            this.CambioEstadoTurno.Add(nuevo);
        }

        public void setEstado(EstadoTurno e)
        {
            this.estado = e;
        }


    }
}