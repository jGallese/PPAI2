namespace pruebaPPAI.Entidades
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public Usuario(string nombre, string password)
        {
            this.Nombre = nombre;
            this.Clave = password;
        }

    }
}