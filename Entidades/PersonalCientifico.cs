namespace PPAI.Entidades
{

    public class PersonalCientifico
    {   
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public string CorreoElectronicoInstitucional { get; set; }
        public string CorreoElectronicoPersonal { get; set; }
        public string TelefonoCelular { get; set; }
        public Usuario Usuario { get; set; }


        public PersonalCientifico(int legajo, string nombre, string apellido, int numeroDocumento, string correoElectronicoInstitucional, string correoElectronicoPersonal, string telefonoCelular, Usuario usuario)
        {
            this.Legajo = legajo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NumeroDocumento = numeroDocumento;
            this.CorreoElectronicoInstitucional = correoElectronicoInstitucional;
            this.CorreoElectronicoPersonal = correoElectronicoPersonal;
            this.TelefonoCelular = telefonoCelular;
            this.Usuario = usuario;
        }

        public PersonalCientifico()
        {

        }
    }

        
}

