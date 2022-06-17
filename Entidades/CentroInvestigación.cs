using System;
using System.Collections.Generic;
using System.Text;

namespace pruebaPPAI.Entidades
{
    public class CentroInvestigación
    {
        public String Nombre { get; set; }
        public String sigla { get; set; }
        public String direccion { get; set; }
        public String edificio { get; set; }
        public int piso { get; set; }
        public int coordenadas { get; set; }
        public String telefonoContacto { get; set; }
        public String correoElectronico { get; set; }
        public int numeroResolucion { get; set; }
        public DateTime fechaResolucionCreacion { get; set; }
        public String reglamento { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime tiempoAntelacionReserva { get; set; }
        public DateTime fechaBaja { get; set; }
        public String motivoBaja { get; set; }

        public List<RecursoTecnologico> ListaRecursosTecnologicos { get; set; }

        public List<AsignacionCientifico> AsignacionCientificos { get; set; }

        public CentroInvestigación(string nombre, string sigla, string direccion, string edificio, int piso, int coordenadas,
            string telefono, string correo, int numeroResolucion, DateTime fechaResolucionCreacion, string reglamento,
            DateTime fechaAlta, DateTime tiempoAntelacionReserva, DateTime fechaBaja, string motivoBaja)
        {
            this.Nombre = nombre;
            this.sigla = sigla;
            this.direccion = direccion;
            this.edificio = edificio;
            this.piso = piso;
            this.coordenadas = coordenadas;
            this.telefonoContacto = telefono;
            this.correoElectronico = correo;
            this.numeroResolucion = numeroResolucion;
            this.fechaResolucionCreacion = fechaResolucionCreacion;
            this.reglamento = reglamento;
            this.fechaAlta = fechaAlta;
            this.tiempoAntelacionReserva = tiempoAntelacionReserva;
            this.fechaBaja = fechaBaja;
            this.motivoBaja = motivoBaja;
            this.ListaRecursosTecnologicos = new List<RecursoTecnologico>();
            this.AsignacionCientificos = new List<AsignacionCientifico>();
        }

        public void agregarRT(RecursoTecnologico recurso)
        {
            this.ListaRecursosTecnologicos.Add(recurso);
        }
    }
}
