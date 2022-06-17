using pruebaPPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPPAI
{
    internal class gestorReservarTurno
    {

        public TipoRecurso  TipoRecursoSeleccionado { get; set; }

        baseDeDatos bdd = new baseDeDatos();

        public List<TipoRecurso> opcReservarTurno( Form pant)
        {
            return this.buscarTipoRT(bdd);
        }

        public List<TipoRecurso> buscarTipoRT(baseDeDatos bdd)
        {
            return bdd.listaTiposRecursos;

        }
        public void tomarSeleccionTipoRecurso(TipoRecurso tipoRecurso)
        {
            this.TipoRecursoSeleccionado = tipoRecurso;
        }

        public List<RecursoTecnologico> buscarRTsDelTipo()
            //busca todos los recursos tecnologicos que correspondan al TipoRecurso seleccionado
        {
            List<RecursoTecnologico> listaRecursosDelTipo = new List<RecursoTecnologico>();

            foreach (RecursoTecnologico rt in bdd.listaRecursosTecnologicos)
            {
                if (rt.esTipoRT(this.TipoRecursoSeleccionado) && rt.esActivo())
                {
                    listaRecursosDelTipo.Add(rt);
                }
            }

            return listaRecursosDelTipo;
        }

        public void agruparPorCI(List<RecursoTecnologico> lista)
        {
            //List<>
            List<Tuple<CentroInvestigación, List<RecursoTecnologico>>> matrizCentros = new List<Tuple<CentroInvestigación, List<RecursoTecnologico>>>();
            foreach (RecursoTecnologico rt in lista)
            {
                //rt. VER COMO SE PUEDE AGRUPAR LA LISTA DE RECURSOS POR CENTRO DE INVESTIGACION
            }
        }
    }
}
