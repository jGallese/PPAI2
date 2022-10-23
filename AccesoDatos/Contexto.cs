using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pruebaPPAI.Entidades;

namespace pruebaPPAI.AccesoDatos
{
    public class Contexto : DbContext
    {
        public Contexto()
        {

        }
        // ENTIDADES 

        public DbSet<RecursoTecnologico> RecursosTecnologicos { get; set; }
        public DbSet<Estado> Estados {get; set; }
        public DbSet<CambioEstadoRT> CambioEstadosRT { get; set; }
    }
}
