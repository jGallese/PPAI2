namespace pruebaPPAI.Entidades
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }

        public Usuario(string nombre, string password)
        {
            Nombre = nombre;
            Password = password;
        }

    }
}