using PPAI.ADO;
using PPAI.Entidades.EstadosConcretos;
using PPAI.Helpers;
using System.Runtime.CompilerServices;

namespace PPAI.Entidades
{
    public class Turno : ObjetoPersistente
    {
        public DateTime FechaGeneracion { get; set; }
        public string DiaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public virtual List<CambioEstadoTurno> CambioEstadoTurno { get; set; }

        public virtual EstadoTurno estado { get; set; }
        public Turno()
        {
            this.CambioEstadoTurno = new List<CambioEstadoTurno>();
        }
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

        public void reservar(DateTime fechaActual)
        {
            //LLAMAR AL OBJETO ESTADO DISPONIBLE, LA OPERACION RESERVAR, APLICANDO DELEGACION
            this.estado.reservarTurno(fechaActual, this);
            
            //CambioEstadoTurno.Add(new CambioEstadoTurno(fechaActual, estaReservado));         DESCOMENTAR

        }

        public void agregarCambioEstado(CambioEstadoTurno nuevo) 
        {
            this.CambioEstadoTurno.Add(nuevo);
        }

        public void setEstado(EstadoTurno e)
        {
            this.estado = e;
        }

        public List<CambioEstadoTurno> getCambiosEstadoDeTurno()
        {
            return AD_CambiosEstadosTurnos.getCambiosEstadoDeTurno(this.oid);
        }


    }
}