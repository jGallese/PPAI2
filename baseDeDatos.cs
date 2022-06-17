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
        public List<Marca> ListaMarcas { get; set; }


        //tiporecurso tr = new("1", "asv");

        public baseDeDatos()
        {
            //Lista Tipos Recursos
            listaTiposRecursos = new List<TipoRecurso>();
            listaTiposRecursos.Add(new("Balanza", "esto pesa"));
            listaTiposRecursos.Add(new("Microscopio", "para ver cosas chiquitas"));
            listaTiposRecursos.Add(new("Generador de particulas atomicas", "peligro"));


            //Lista Modelos
            listaModelos = new List<Modelo>();
            listaModelos.Add(new("1"));
            listaModelos.Add(new("2"));
            listaModelos.Add(new("3"));
            listaModelos.Add(new("4"));


            //Lista Marcas
            ListaMarcas = new List<Marca>();
            ListaMarcas.Add(new("Apple"));
            ListaMarcas.Add(new("Samsung"));
            ListaMarcas[0].modelos.Add(listaModelos[0]);
            ListaMarcas[0].modelos.Add(listaModelos[1]);
            ListaMarcas[1].modelos.Add(listaModelos[2]);
            ListaMarcas[1].modelos.Add(listaModelos[3]);



            //Lista Estados
            Estado reservable = new Estado("Disponible", "este es estado creado","Recurso" ,true, false);
            Estado enBaja = new Estado("enBaja", "este es estado enBaja","Recurso" ,false, false);


            //Lista Recursos
            listaRecursosTecnologicos = new List<RecursoTecnologico>();
            listaRecursosTecnologicos.Add(new(1, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(2, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[1] ));
            listaRecursosTecnologicos.Add(new(4, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[2] ));
            listaRecursosTecnologicos.Add(new(5, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[3] ));
            listaRecursosTecnologicos.Add(new(6, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[1] ));
            listaRecursosTecnologicos[0].ListaCambioEstadosRT.Add(new(DateTime.Now, enBaja));
            listaRecursosTecnologicos[1].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));
            listaRecursosTecnologicos[2].ListaCambioEstadosRT.Add(new(DateTime.Now, enBaja));
            listaRecursosTecnologicos[3].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));
            listaRecursosTecnologicos[4].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));
            //listaRecursosTecnologicos[5].ListaCambioEstadosRT.Add(new(DateTime.Now, reservable));

            //Lista Centros 
            ListaCentros = new List<CentroInvestigación>();
            for (int i = 0; i < 5; i++)
            {
                CentroInvestigación centro = new CentroInvestigación("Centro: " + i.ToString(), "C" + i.ToString(), "abc",
                    i.ToString(), i, i, i.ToString() + i.ToString() + i.ToString(), i.ToString() + "@gmail", "caracteristica", i,
                    DateTime.Now, "reglamento", DateTime.Now, DateTime.Now, DateTime.Now, "motivoBaja");
                ListaCentros.Add(centro);
            }

            ListaCentros[0].agregarRT(listaRecursosTecnologicos[0]);
            ListaCentros[0].agregarRT(listaRecursosTecnologicos[1]);
            ListaCentros[0].agregarRT(listaRecursosTecnologicos[2]);
            ListaCentros[1].agregarRT(listaRecursosTecnologicos[3]);
            ListaCentros[1].agregarRT(listaRecursosTecnologicos[4]);
            //ListaCentros[2].agregarRT(listaRecursosTecnologicos[6]);


        
        
        }

    }

    
}
