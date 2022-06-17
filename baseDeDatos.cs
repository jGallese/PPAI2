using pruebaPPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI
{
    public class baseDeDatos
    {
        public List<TipoRecurso> listaTiposRecursos;
        public List<RecursoTecnologico> listaRecursosTecnologicos { get; set; }
        public List<Estado> listaEstados { get; set; }
        public List<Modelo> listaModelos { get; set; }

        public List<CentroInvestigación> ListaCentros { get; set; }

        //tiporecurso tr = new("1", "asv");

        public baseDeDatos()
        {
            listaTiposRecursos = new List<TipoRecurso>();
            listaTiposRecursos.Add(new("Balanza", "esto pesa"));
            listaTiposRecursos.Add(new("Microscopio", "para ver cosas chiquitas"));
            listaTiposRecursos.Add(new("Generador de particulas atomicas", "peligro"));

            listaModelos = new List<Modelo>();
            listaModelos.Add(new("abc"));

            Estado reservable = new Estado("Disponible", "este es estado creado","Recurso" ,true, false);
            Estado enBaja = new Estado("enBaja", "este es estado enBaja","Recurso" ,false, false);


            listaRecursosTecnologicos = new List<RecursoTecnologico>();
            listaRecursosTecnologicos.Add(new(1, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(2, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(4, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[1], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(5, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[1], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(6, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[2], listaModelos[0] ));
            listaRecursosTecnologicos[0].ListaCambioEstadosRT.Add(new(DateTime.Now, enBaja));
            listaRecursosTecnologicos[1].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));
            listaRecursosTecnologicos[2].ListaCambioEstadosRT.Add(new(DateTime.Now, enBaja));
            listaRecursosTecnologicos[3].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));
            listaRecursosTecnologicos[4].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));
            //listaRecursosTecnologicos[5].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));
        }

    }

    
}
