namespace pruebaPPAI.Entidades
{
    public class CambioEstadoTurno
    {
        public DateTime fechaHoraDesde{ get; set; }
        public DateTime? fechaHoraHasta { get; set; }
        public Estado estado{ get; set; }
        public CambioEstadoTurno(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = null;
            this.estado = estado;
        }
    }
}