namespace pruebaPPAI.Entidades
{
    public class TipoRecurso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoRecurso(string nombre, string desc) 
        { 
            this.Nombre = nombre; 
            this.Descripcion = desc; 
        }

        public string GetTipoRecurso()
        {
            return "Tipo Recurso:" + this.Nombre + ". Descripcion:" + this.Descripcion;
        }
    }
}