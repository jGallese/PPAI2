﻿using PPAI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PPAI.Entidades
{
    public class CentroInvestigación : ObjetoPersistente 
    {
        public String Nombre { get; set; }
        public String sigla { get; set; }
        public String direccion { get; set; }
        public String edificio { get; set; }
        public int piso { get; set; }
        public int coordenadas { get; set; }
        public String telefonoContacto { get; set; }
        public String correoElectronico { get; set; }
        public String caracteristicasGenerales { get; set; }

        public int numeroResolucion { get; set; }
        public DateTime fechaResolucionCreacion { get; set; }
        public String reglamento { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime tiempoAntelacionReserva { get; set; }
        public DateTime? fechaBaja { get; set; }
        public String? motivoBaja { get; set; }

        public virtual List<RecursoTecnologico> ListaRecursosTecnologicos { get; set; }

        public virtual List<AsignacionCientifico> AsignacionCientificos { get; set; }

        public CentroInvestigación()
        {

        }
        public CentroInvestigación(string nombre, string sigla, string direccion, string edificio, int piso, int coordenadas,
            string telefono, string correo, string caracteristicasGrales, int numeroResolucion, DateTime fechaResolucionCreacion, string reglamento,
            DateTime fechaAlta, DateTime tiempoAntelacionReserva)
        {
            this.Nombre = nombre;
            this.sigla = sigla;
            this.direccion = direccion;
            this.edificio = edificio;
            this.piso = piso;
            this.coordenadas = coordenadas;
            this.telefonoContacto = telefono;
            this.correoElectronico = correo;
            this.caracteristicasGenerales = caracteristicasGrales;
            this.numeroResolucion = numeroResolucion;
            this.fechaResolucionCreacion = fechaResolucionCreacion;
            this.reglamento = reglamento;
            this.fechaAlta = fechaAlta;
            this.tiempoAntelacionReserva = tiempoAntelacionReserva;
            this.ListaRecursosTecnologicos = new List<RecursoTecnologico>();
            this.AsignacionCientificos = new List<AsignacionCientifico>();
        }

        public void agregarRT(RecursoTecnologico recurso)
        {//agrega una recurso tecnologico a su lista de recursos. representa agregacion.
            this.ListaRecursosTecnologicos.Add(recurso);
        }

        internal bool esCientificoActivo(PersonalCientifico cientifLogueado)
        {//retorna true si el cientifico logueado pasado como parametro pertenece al centro 
            foreach (AsignacionCientifico asignacion in AsignacionCientificos)
            {
                if (cientifLogueado.Legajo.Equals(asignacion.personalCientifico.Legajo) && asignacion.esActivo())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
