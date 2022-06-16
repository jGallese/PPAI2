using pruebaPPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI
{
    internal class baseDeDatos
    {
        public List<TipoRecurso> listaTiposRecursos;
        public List<RecursoTecnologico> listaRecursosTecnologicos { get; set; }
        public List<Estado> listaEstados { get; set; }
        public List<Modelo> listaModelos { get; set; }
        //tiporecurso tr = new("1", "asv");

        public baseDeDatos()
        {
            listaTiposRecursos = new List<TipoRecurso>();
            listaTiposRecursos.Add(new("1", "asv"));
            listaTiposRecursos.Add(new("2", "acv"));
            listaTiposRecursos.Add(new("3", "abd"));

            listaModelos = new List<Modelo>();
            listaModelos.Add(new("abc"));



            listaRecursosTecnologicos = new List<RecursoTecnologico>();
            listaRecursosTecnologicos.Add(new(1, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(2, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(3, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[1], listaModelos[0] ));

        }

    }

    
}
