namespace pruebaPPAI.Entidades
{
    public class Modelo
    {
        public string nombre { get; set; }
        public Modelo(string nombre)
        {
            this.nombre = nombre;
        }

        public String getMarca(baseDeDatos bdd)
        {
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