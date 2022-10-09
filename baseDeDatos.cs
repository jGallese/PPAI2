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

        public List<PersonalCientifico> ListaCientificos { get; set; }

        public List<Usuario> ListaUsuarios{ get; set; }

        public Sesion sesionActual { get; set; }

        public List<AsignacionCientifico> ListaAsignaciones { get; set; }

        public InterfazEmail email = new();

        public baseDeDatos()
        {
            //Lista Tipos Recursos
            listaTiposRecursos = new List<TipoRecurso>();
            listaTiposRecursos.Add(new("Balanza", "Objeto para pesar"));
            listaTiposRecursos.Add(new("Microscopio", "Analizar particulas pequeñas"));
            listaTiposRecursos.Add(new("Centrifugador", "Centrifuga sustancias"));


            //Lista Modelos
            listaModelos = new List<Modelo>();
            listaModelos.Add(new("iPesadora"));
            listaModelos.Add(new("iPesadora Pro"));
            listaModelos.Add(new("Galaxy Weight"));
            listaModelos.Add(new("iMicroscopio"));
            listaModelos.Add(new("Galaxy Microscopic"));
            listaModelos.Add(new("iCentrif"));
            listaModelos.Add(new("Gcentrif"));


            //Lista Marcas
            ListaMarcas = new List<Marca>();
            ListaMarcas.Add(new("Apple"));
            ListaMarcas.Add(new("Samsung"));
            ListaMarcas[0].modelos.Add(listaModelos[0]);
            ListaMarcas[0].modelos.Add(listaModelos[1]);
            ListaMarcas[1].modelos.Add(listaModelos[2]);
            ListaMarcas[0].modelos.Add(listaModelos[3]);
            ListaMarcas[1].modelos.Add(listaModelos[4]);
            ListaMarcas[0].modelos.Add(listaModelos[5]);
            ListaMarcas[1].modelos.Add(listaModelos[6]);




            //Lista Estados
            listaEstados = new List<Estado>();
            listaEstados.Add(new Estado("Disponible", "Recurso disponible", "Recurso", true, false));
            listaEstados.Add(new Estado("En Mantenimiento", "Recurso en mantenimiento", "Recurso", true, false));
            listaEstados.Add(new Estado("Inicio Mantenimiento Correctivo", "Recurso en mantenimiento correctivo", "Recurso", true, false));
            listaEstados.Add(new Estado("enBaja", "Recurso esta en Baja", "Recurso", false, false));

            listaEstados.Add(new Estado("Disponible", "este es estado creado", "Turno", true, true));
            listaEstados.Add(new Estado("Con reserva pendiente de confirmacion", "este es estado creado", "Turno", false, true));
            listaEstados.Add(new Estado("Reservado", "este es estado creado", "Turno", false, true));

            

            //Lista Recursos
            listaRecursosTecnologicos = new List<RecursoTecnologico>();
            listaRecursosTecnologicos.Add(new(0, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("01:00:00"), listaTiposRecursos[0], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(1, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("01:00:00"), listaTiposRecursos[0], listaModelos[1] ));
            listaRecursosTecnologicos.Add(new(2, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("01:00:00"), listaTiposRecursos[0], listaModelos[2] ));
            listaRecursosTecnologicos.Add(new(3, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("01:00:00"), listaTiposRecursos[0], listaModelos[3] ));
            listaRecursosTecnologicos.Add(new(4, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("01:00:00"), listaTiposRecursos[0], listaModelos[1] ));
            listaRecursosTecnologicos.Add(new(5, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("01:00:00"), listaTiposRecursos[0], listaModelos[1] ));
            listaRecursosTecnologicos.Add(new(6, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("01:00:00"), listaTiposRecursos[1], listaModelos[1] ));
            listaRecursosTecnologicos[0].ListaCambioEstadosRT.Add(new(DateTime.Now, listaEstados[0]));
            listaRecursosTecnologicos[1].ListaCambioEstadosRT.Add(new(DateTime.Now, listaEstados[0]));
            listaRecursosTecnologicos[2].ListaCambioEstadosRT.Add(new(DateTime.Now, listaEstados[1]));
            listaRecursosTecnologicos[3].ListaCambioEstadosRT.Add(new(DateTime.Now, listaEstados[3]));
            listaRecursosTecnologicos[4].ListaCambioEstadosRT.Add(new(DateTime.Now, listaEstados[0]));
            listaRecursosTecnologicos[5].ListaCambioEstadosRT.Add(new(DateTime.Now, listaEstados[1]));
            listaRecursosTecnologicos[6].ListaCambioEstadosRT.Add(new(DateTime.Now, listaEstados[2]));
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
            ListaCentros[0].agregarRT(listaRecursosTecnologicos[4]);
            ListaCentros[1].agregarRT(listaRecursosTecnologicos[3]);
            ListaCentros[1].agregarRT(listaRecursosTecnologicos[5]);
            ListaCentros[1].agregarRT(listaRecursosTecnologicos[6]);

            //ListaCentros[2].agregarRT(listaRecursosTecnologicos[6]);

            //Lista de usuarios
            ListaUsuarios = new List<Usuario>();
            for (int i = 0; i < 5; i++)
            {
                Usuario usu = new Usuario("Usuario" + i.ToString(), "***");
                ListaUsuarios.Add(usu);
            }


            //Lista de PersonalCientifico
            ListaCientificos = new List<PersonalCientifico>();
            for (int i = 0; i < 5; i++)
            {
                PersonalCientifico cientif = new PersonalCientifico(i, "Cientifico:" + i.ToString(), "PEPE", i, "correoInst@gmail.com", "correoPers@gmail.com", 
                    i, ListaUsuarios[i]);
                ListaCientificos.Add(cientif);
            }

            //Lista de Asignaciones
            ListaAsignaciones = new List<AsignacionCientifico>();
            for (int i = 0; i < 5; i++)
            {
                AsignacionCientifico asignacion = new AsignacionCientifico(DateTime.Now, ListaCientificos[i]);
                ListaAsignaciones.Add(asignacion);
            }
            ListaCentros[0].AsignacionCientificos.Add(ListaAsignaciones[0]);
            ListaCentros[0].AsignacionCientificos.Add(ListaAsignaciones[1]);
            ListaCentros[0].AsignacionCientificos.Add(ListaAsignaciones[2]);
            ListaCentros[1].AsignacionCientificos.Add(ListaAsignaciones[3]);
            ListaCentros[1].AsignacionCientificos.Add(ListaAsignaciones[4]);

            

            sesionActual = new Sesion(DateTime.Now, ListaUsuarios[0]);

            //ListaTurnos
            List<Turno> ListaTurnos1 = new List<Turno>();
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 10, 00, 00), new DateTime(2022, 6, 21, 11, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 11, 00, 00), new DateTime(2022, 6, 21, 12, 00, 00))); 
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 12, 00, 00), new DateTime(2022, 6, 21, 13, 00, 00))); 
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 13, 00, 00), new DateTime(2022, 6, 21, 14, 00, 00))); 
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 14, 00, 00), new DateTime(2022, 6, 21, 15, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 15, 00, 00), new DateTime(2022, 6, 21, 16, 00, 00)));
            

            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 10, 00, 00), new DateTime(2022, 6, 22, 11, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 11, 00, 00), new DateTime(2022, 6, 22, 12, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 12, 00, 00), new DateTime(2022, 6, 22, 13, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 13, 00, 00), new DateTime(2022, 6, 22, 14, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 14, 00, 00), new DateTime(2022, 6, 22, 15, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 15, 00, 00), new DateTime(2022, 6, 22, 16, 00, 00)));
            

            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 10, 00, 00), new DateTime(2022, 6, 23, 11, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 11, 00, 00), new DateTime(2022, 6, 23, 12, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 12, 00, 00), new DateTime(2022, 6, 23, 13, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 13, 00, 00), new DateTime(2022, 6, 23, 14, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 14, 00, 00), new DateTime(2022, 6, 23, 15, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 15, 00, 00), new DateTime(2022, 6, 23, 16, 00, 00)));
            
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Viernes", new DateTime(2022, 6, 24, 10, 00, 00), new DateTime(2022, 6, 24, 11, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Viernes", new DateTime(2022, 6, 24, 11, 00, 00), new DateTime(2022, 6, 24, 12, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Viernes", new DateTime(2022, 6, 24, 12, 00, 00), new DateTime(2022, 6, 24, 13, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Viernes", new DateTime(2022, 6, 24, 13, 00, 00), new DateTime(2022, 6, 24, 14, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Viernes", new DateTime(2022, 6, 24, 14, 00, 00), new DateTime(2022, 6, 24, 15, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Viernes", new DateTime(2022, 6, 24, 15, 00, 00), new DateTime(2022, 6, 24, 16, 00, 00)));
            
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Sabado", new DateTime(2022, 6, 25, 10, 00, 00), new DateTime(2022, 6, 25, 11, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Sabado", new DateTime(2022, 6, 25, 11, 00, 00), new DateTime(2022, 6, 25, 12, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Sabado", new DateTime(2022, 6, 25, 12, 00, 00), new DateTime(2022, 6, 25, 13, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Sabado", new DateTime(2022, 6, 25, 13, 00, 00), new DateTime(2022, 6, 25, 14, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Sabado", new DateTime(2022, 6, 25, 14, 00, 00), new DateTime(2022, 6, 25, 15, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Sabado", new DateTime(2022, 6, 25, 15, 00, 00), new DateTime(2022, 6, 25, 16, 00, 00)));

            for (int i = 0; i < ListaTurnos1.Count; i++)
            {
                if ((i%2)==0 )
                {
                    ListaTurnos1[i].CambioEstadoTurno.Add(new CambioEstadoTurno(ListaTurnos1[i].fechaHoraInicio, listaEstados[4]));
                } else
                {
                    ListaTurnos1[i].CambioEstadoTurno.Add(new CambioEstadoTurno(ListaTurnos1[i].fechaHoraInicio, listaEstados[6]));
                }
            }
            listaRecursosTecnologicos[0].ListaTurnos = ListaTurnos1;
            listaRecursosTecnologicos[1].ListaTurnos = ListaTurnos1;
            
            
            listaRecursosTecnologicos[4].ListaTurnos = ListaTurnos1;


            //List<Turno> ListaTurnos2 = new List<Turno>();
            List<Turno> ListaTurnos2 = new List<Turno>();
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 10, 00, 00), new DateTime(2022, 6, 21, 11, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 11, 00, 00), new DateTime(2022, 6, 21, 12, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 12, 00, 00), new DateTime(2022, 6, 21, 13, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 13, 00, 00), new DateTime(2022, 6, 21, 14, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 14, 00, 00), new DateTime(2022, 6, 21, 15, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 15, 00, 00), new DateTime(2022, 6, 21, 16, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 10, 00, 00), new DateTime(2022, 6, 22, 11, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 11, 00, 00), new DateTime(2022, 6, 22, 12, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 12, 00, 00), new DateTime(2022, 6, 22, 13, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 13, 00, 00), new DateTime(2022, 6, 22, 14, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 14, 00, 00), new DateTime(2022, 6, 22, 15, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Miercoles", new DateTime(2022, 6, 22, 15, 00, 00), new DateTime(2022, 6, 22, 16, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 10, 00, 00), new DateTime(2022, 6, 23, 11, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 11, 00, 00), new DateTime(2022, 6, 23, 12, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 12, 00, 00), new DateTime(2022, 6, 23, 13, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 13, 00, 00), new DateTime(2022, 6, 23, 14, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 14, 00, 00), new DateTime(2022, 6, 23, 15, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Jueves", new DateTime(2022, 6, 23, 15, 00, 00), new DateTime(2022, 6, 23, 16, 00, 00)));

            //for (int i = 0; i < ListaTurnos1.Count; i++)
            //{
            //    if ((i % 2) == 0)
            //    {
            //        ListaTurnos2[i].CambioEstadoTurno.Add(new CambioEstadoTurno(DateTime.Now, listaEstados[4]));
            //    }
            //    else
            //    {
            //        ListaTurnos2[i].CambioEstadoTurno.Add(new CambioEstadoTurno(DateTime.Now, listaEstados[6]));
            //    }
            //}
            //listaRecursosTecnologicos[1].ListaTurnos = ListaTurnos2;
            //List<Turno> ListaTurnos3 = new List<Turno>();
            //Turno turno31 = new Turno();
            //Turno turno32 = new Turno();
            //Turno turno33 = new Turno();
            //Turno turno34 = new Turno();
            //Turno turno35 = new Turno();



        }

    }

    
}
