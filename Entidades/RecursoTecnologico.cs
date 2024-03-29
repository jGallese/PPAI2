﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI;
using PPAI.ADO;
using PPAI.Helpers;

namespace PPAI.Entidades
{
    public class RecursoTecnologico : ObjetoPersistente
    {
        //Propiedades
        public int numeroRT { get; set; }
        public DateTime fechaAlta { get; set; }
        public virtual List<Image> imagenes { get; set; }
        public DateTime periodicidadMantenimientoPrev { get; set; }
        public DateTime duracionMantPrev { get; set; }
        public TimeOnly fraccionHorariosTurnos { get; set; }

        public TipoRecurso tipoRecurso { get; set; }

        public Modelo modeloRT { get; set; }
        public  List<Mantenimiento>? ListaMantenimientos { get; set; }

        public List<Turno> ListaTurnos { get; set; }
        public List<CambioEstadoRT> ListaCambioEstadosRT { get; set; }

        //private CentroInvestigación centroInv { get; set; }


        //Constructor
        public RecursoTecnologico()
        {

        }
        public RecursoTecnologico(int numeroRT, DateTime fechaAlta, Image imagenes, DateTime periodicidadMantenimientoPrev, DateTime duracionMantPrev, TimeOnly fraccionHorariaTurno, TipoRecurso tipoRecurso, Modelo modeloRT)
        {
            this.numeroRT = numeroRT;
            this.fechaAlta = fechaAlta;
            this.imagenes = new List<Image>();
            this.periodicidadMantenimientoPrev = periodicidadMantenimientoPrev;
            this.duracionMantPrev = duracionMantPrev;
            this.fraccionHorariosTurnos = fraccionHorariaTurno;
            this.tipoRecurso = tipoRecurso;
            this.modeloRT = modeloRT;
            this.ListaMantenimientos = new List<Mantenimiento>();
            this.ListaTurnos = new List<Turno>();
            this.ListaCambioEstadosRT = new List<CambioEstadoRT>();

        }

        //Metodos
        public bool esTipoRT(TipoRecurso tipoRec)
        {//retorna true si el recurso es del tipo que se pasa por parametro(el seleccionado por el usuario)
            if (this.tipoRecurso.oid.Equals(tipoRec.oid))
            {
                return true;
            }
            return false;
        }

        public bool esActivo()
        {
            //busca por cada cambio de estado cual es el actual, y al actual le pregunta si es reservable
            //retorna true si es reservable el recurso, retorna false si el recurso no esta en estado reservable
            CambioEstadoRT actual = null;
            foreach (CambioEstadoRT cambioEstado in this.ListaCambioEstadosRT)
            {

                if (cambioEstado.EsActual())
                {
                    actual = cambioEstado;
                    break;

                }
            }
            if ((actual != null) && actual.EsReservable())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CentroInvestigación getNombreCI(List<CentroInvestigación> listaDeCentros)
        {//retorna el centro de investigacion al que pertenece el recurso
         //
            foreach (CentroInvestigación centro in listaDeCentros)
            {
                foreach (RecursoTecnologico recurso in centro.ListaRecursosTecnologicos)
                {
                    if (this.numeroRT.Equals(recurso.numeroRT))
                    {
                        return centro;
                    }
                }
            }
            return null;
        }

        public bool estaEnMiCI(List<CentroInvestigación> listaCentros, PersonalCientifico cientifLogueado)
            {
            /* devuelve true si el cientifico logueado pertenece al centro de investigacion 
                que contiene al recurso tecnologico seleccionado
             */
            CentroInvestigación miCentro = this.getNombreCI(listaCentros);
            return miCentro.esCientificoActivo(cientifLogueado);
            }
            
        public List<Turno> mostrarMisTurnos(DateTime fechaActual)
        {
            //busca los turnos posteriores a la fecha que se pasa como parametro(fecha actual del sistema) y retorna los mismos
            this.ListaTurnos = AD_Turnos.getTurnosDeRecurso(this.numeroRT);
            List<Turno> ListaTurs = new List<Turno>();
            foreach(Turno turno in this.ListaTurnos)
            {
                if (turno.esPosteriorFechaActual(fechaActual))
                {
                    ListaTurs.Add(turno.getDatos());
                }
            }
            return ListaTurs;
        }

        public string getDatos()
        {//muestra datos basicos del recurso 
            return "| Tipo Recurso: " + this.tipoRecurso.Nombre + "\n| Recurso Numero: " + this.numeroRT.ToString() + "\n| Modelo:" + this.modeloRT.nombre;
        }

        public void registrarReserva(DateTime fechaActual, Turno turnoSeleccionado)
        {//registra la reserva de un turno seleccionado por el usuario
            foreach (Turno turno in ListaTurnos)
            {
                if (turno.Equals(turnoSeleccionado))
                {
                    turno.reservar(fechaActual);
                    break;
                }
            }

        }
    }

    
}
