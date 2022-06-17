using System;
using System.Collections.Generic;
using System.Text;

namespace pruebaPPAI.Entidades
{
    public class PersonalCientifico
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public string CorreoElectronicoInstitucional { get; set; }
        public string CorreoElectronicoPersonal { get; set; }
        public int TelefonoCelular { get; set; }
        public Usuario Usuario { get; set; }
    }
}

