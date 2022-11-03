using PPAI.ADO;
using PPAI.Helpers;

namespace PPAI.Entidades
{
    public class Usuario : ObjetoPersistente
    {
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public Usuario(string nombre, string password)
        {
            this.Nombre = nombre;
            this.Clave = password;
        }
        public Usuario()
        {

        }
        public PersonalCientifico getCientifico(int oidUsuario)
        { 
            //retorna el cientifico que se encuentre logueado en la base de datos
            return AD_Usuarios.getPersonalLogueado(oidUsuario);
            
        }

    }
}