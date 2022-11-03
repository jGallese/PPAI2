namespace PPAI.Entidades
{
    public class TipoRecurso : Helpers.ObjetoPersistente
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoRecurso(string nombre, string desc) 
        { 
            this.Nombre = nombre; 
            this.Descripcion = desc; 
        }
        public TipoRecurso()
        {

        }
        public string GetTipoRecurso()
        {//muestra el tipo recurso
            return "Tipo Recurso:" + this.Nombre + ". Descripcion:" + this.Descripcion;
        }
    }
}