namespace pruebaPPAI.Entidades
{
    public class EstadoTurno
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsReservable { get; set; }
        public bool EsCancelable { get; set; }

        public EstadoTurno(string nombre, string descripcion, bool esReservable, bool esCancelable)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.EsReservable = esReservable;
            this.EsCancelable = esCancelable;
        }
        public EstadoTurno()
        {

        }

        //public bool EsAmbitoTurno()
        //{ //retorna true si el ambito del estado es turno. El estado corresponde a objetos turno/
        //    return this.Ambito == "Turno";
        //}

        public virtual bool EsReservado()
        {//retorna true si el estado es reservado.
            return this.Nombre == "Reservado";
        }

        public virtual bool esReservable() { return true; }
         
        public virtual void crearProxCambioEstado() { } // ver valor de retorno, puede ser CambioEstadoTurno

        public virtual void reservar(DateTime fechaActual, CambioEstadoTurno cambioEActual, Turno turno) { }

        public virtual void registrarInicioTurno() { }
        public virtual void cancelarTurno() { }
        public virtual void registrarFinTurno() {//podria tener funcionalidad
                                                 }
        public virtual bool estaReservado() { return true; } //en DiagClase esta como void, CHECKEAR

        public virtual void registrarTurnoNoUsado() { }

        public virtual void registrarTurnoNoReservado() { }
        public virtual void registrarPeticionTurno() { }
        public virtual void confirmarTurno() { }
        public virtual void rechazarTurno() { }

        public virtual void cancelarTurnoPorMantCorrectivo() { }

    }

    

}