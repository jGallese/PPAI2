using PPAI.ADO;
using PPAI.Helpers;

namespace PPAI.Entidades
{
    public class Modelo : ObjetoPersistente
    {
        public string nombre { get; set; }
        public Modelo(string nombre)
        {
            this.nombre = nombre;
        }
        public Modelo()
        {

        }
        public String getMarcaYModelo()
        {//busca en la base de datos la marca correspondiente al modelo. y retorna su nombre
            string res = AD_Marcas.getMarcaParticular(this.oid).Nombre;
           
            return res;
        }
    }
    

        
}