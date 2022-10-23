namespace pruebaPPAI.Entidades
{
    public class CambioEstadoTurno
    {
        public DateTime fechaHoraDesde{ get; set; }
        public DateTime? fechaHoraHasta { get; set; }
        public EstadoTurno estado{ get; set; }
        public CambioEstadoTurno(DateTime fechaHoraDesde, EstadoTurno estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = null;
            this.estado = estado;
        }

        public bool EsActual()
        {//es actual el cambio de estado que no tenga fecha de fin
            if (this.fechaHoraHasta == null)
            {
                return true;
            }
            return false;
        }

        public void setFechaHasta(DateTime fechaHoraHasta)
        {// le agrega una fecha de fin al cambio de estado
            this.fechaHoraHasta = fechaHoraHasta;

        }
    }
}