using PPAI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class EstadoRecurso : ObjetoPersistente
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsReservable { get; set; }
        public bool EsCancelable { get; set; }

        public EstadoRecurso(string nombre, string descripcion, bool esReservable, bool esCancelable)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.EsReservable = esReservable;
            this.EsCancelable = esCancelable;
        }
        public EstadoRecurso()
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
    }
}
