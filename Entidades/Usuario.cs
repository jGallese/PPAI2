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

        public PersonalCientifico getCientifico(baseDeDatos bdd)
        { 
            //retorna el cientifico que se encuentre logueado en la base de datos
            foreach (PersonalCientifico cientif in bdd.ListaCientificos)
            {
                
                    if (this.Nombre.Equals(cientif.Usuario.Nombre))
                    {
                        return cientif;
                    }
            }
            return null;
            
        }

    }
}