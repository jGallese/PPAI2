namespace pruebaPPAI.Entidades
{
    public class Estado
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ambito { get; set; }
        public bool EsReservable { get; set; }
        public bool EsCancelable { get; set; }

        public Estado(string nombre, string descripcion, string ambito, bool esReservable, bool esCancelable)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Ambito = ambito;
            this.EsReservable = esReservable;
            this.EsCancelable = esCancelable;
        }

        public bool EsAmbitoTurno()
        { //retorna true si el ambito del estado es turno. El estado corresponde a objetos turno/
            return this.Ambito == "Turno";
        }

        public bool EsReservado()
        {//retorna true si el estado es reservado.
            return this.Nombre == "Reservado";
        }
    }

    

}