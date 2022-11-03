using PPAI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Marca : ObjetoPersistente
    {
        public string Nombre { get; set; }
        public virtual List<Modelo> modelos { get; set; }

        public Marca()
        {

        }
        public Marca(string nombre)
        {
            Nombre = nombre;
            this.modelos = new List<Modelo>();
        }
    }
}
