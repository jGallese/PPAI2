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
            Estado disponible = new Estado("Disponible", "este es estado creado", "Recurso", true, false);
            Estado enMantenimiento = new Estado("En Mantenimiento", "este es estado creado", "Recurso", true, false);
            Estado inicioMantCorr = new Estado("Inicio Mantenimiento Correctivo", "este es estado creado", "Recurso", true, false);
            Estado enBaja = new Estado("enBaja", "este es estado enBaja", "Recurso", false, false);

            Estado disponibleTurno = new Estado("Disponible", "este es estado creado", "Turno", true, true); //azul
            Estado resPendiente = new Estado("Con reserva pendiente de confirmacion", "este es estado creado", "Turno", false, true); //gris
            Estado reservado = new Estado("Reservado", "este es estado creado", "Turno", false, true); //rojo

            //Lista Recursos
            listaRecursosTecnologicos = new List<RecursoTecnologico>();
            listaRecursosTecnologicos.Add(new(0, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[0] ));
            listaRecursosTecnologicos.Add(new(1, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[1] ));
            listaRecursosTecnologicos.Add(new(2, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[2] ));
            listaRecursosTecnologicos.Add(new(3, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[3] ));
            listaRecursosTecnologicos.Add(new(4, DateTime.Now, null, DateTime.Today, DateTime.Today, TimeOnly.Parse("00:20:00"), listaTiposRecursos[0], listaModelos[1] ));
            listaRecursosTecnologicos[0].ListaCambioEstadosRT.Add(new(DateTime.Now, inicioMantCorr));
            listaRecursosTecnologicos[1].ListaCambioEstadosRT.Add(new(DateTime.Now, disponible));
            listaRecursosTecnologicos[2].ListaCambioEstadosRT.Add(new(DateTime.Now, disponible));
            listaRecursosTecnologicos[3].ListaCambioEstadosRT.Add(new(DateTime.Now, disponible));
            listaRecursosTecnologicos[4].ListaCambioEstadosRT.Add(new(DateTime.Now, enMantenimiento));
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
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Lunes",new DateTime(2022, 6, 20, 10, 00, 00), new DateTime(2022, 6, 20, 11, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 11, 00, 01), new DateTime(2022, 6, 20, 12, 00, 00))); 
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 12, 00, 01), new DateTime(2022, 6, 20, 13, 00, 00))); 
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 13, 00, 01), new DateTime(2022, 6, 20, 14, 00, 00))); 
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 14, 00, 01), new DateTime(2022, 6, 20, 15, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 10, 00, 00), new DateTime(2022, 6, 21, 11, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 11, 00, 01), new DateTime(2022, 6, 21, 12, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 12, 00, 01), new DateTime(2022, 6, 21, 13, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 13, 00, 01), new DateTime(2022, 6, 21, 14, 00, 00)));
            ListaTurnos1.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 14, 00, 01), new DateTime(2022, 6, 21, 15, 00, 00)));
            foreach (Turno turno in ListaTurnos1)
            {
                turno.CambioEstadoTurno.Add(new CambioEstadoTurno(DateTime.Now, disponibleTurno));
            }
            listaRecursosTecnologicos[0].ListaTurnos = ListaTurnos1;

            //List<Turno> ListaTurnos2 = new List<Turno>();
            List<Turno> ListaTurnos2 = new List<Turno>();
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 10, 00, 00), new DateTime(2022, 6, 20, 11, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 11, 00, 01), new DateTime(2022, 6, 20, 12, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 12, 00, 01), new DateTime(2022, 6, 20, 13, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 13, 00, 01), new DateTime(2022, 6, 20, 14, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Lunes", new DateTime(2022, 6, 20, 14, 00, 01), new DateTime(2022, 6, 20, 15, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 10, 00, 00), new DateTime(2022, 6, 21, 11, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 11, 00, 01), new DateTime(2022, 6, 21, 12, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 12, 00, 01), new DateTime(2022, 6, 21, 13, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 13, 00, 01), new DateTime(2022, 6, 21, 14, 00, 00)));
            ListaTurnos2.Add(new Turno(DateTime.MinValue, "Martes", new DateTime(2022, 6, 21, 14, 00, 01), new DateTime(2022, 6, 21, 15, 00, 00)));

            //List<Turno> ListaTurnos3 = new List<Turno>();
            //Turno turno31 = new Turno();
            //Turno turno32 = new Turno();
            //Turno turno33 = new Turno();
            //Turno turno34 = new Turno();
            //Turno turno35 = new Turno();



        }

    }

    
}
