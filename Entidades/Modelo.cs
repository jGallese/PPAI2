namespace pruebaPPAI.Entidades
{
    public class Modelo
    {
        public string nombre { get; set; }
        public Modelo(string nombre)
        {
            this.nombre = nombre;
        }

        public String getMarcaYModelo(baseDeDatos bdd)
        {//busca en la base de datos la marca correspondiente al modelo. y retorna su nombre
            foreach (Marca marca in bdd.ListaMarcas)
            {
                foreach (Modelo mod in marca.modelos)
                {
                    if (this.nombre.Equals(mod.nombre))
                    {
                        return marca.Nombre;
                    }
                }
            }
            return "";
        }
    }
    

        
}