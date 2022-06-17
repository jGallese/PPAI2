using pruebaPPAI.Entidades;

namespace pruebaPPAI
{
    public partial class InterfazRegistrarClases : Form
    {
        public List<TipoRecurso> listaTR { get; set; }
        private List<RecursoTecnologico> ListaRecs { get; set; }

        private gestorRegistrarTurno ges;
        baseDeDatos bdd = new baseDeDatos();
        public InterfazRegistrarClases()
        {
            InitializeComponent();
            ges = new gestorRegistrarTurno(); 
            ListaRecs = new List<RecursoTecnologico>();
            
            dgv_Recursos.Columns.Add("NombreCI", "NombreCI");
            dgv_Recursos.Columns.Add("NumeroRT", "Numero Recurso");
            dgv_Recursos.Columns.Add("Marca", "Marca");
            dgv_Recursos.Columns.Add("Modelo", "Modelo");
            dgv_Recursos.Columns.Add("Estado", "Estado");
        }

        private void Form1_Load(object sender, EventArgs e) //METODO HABILITAR PANTALLA, SI SE CAMBIA EL NOMBRE SE ROMPE
        {
            dgv_TiposRecursos.AutoGenerateColumns = false;
            dgv_TiposRecursos.MultiSelect = false;
            dgv_Recursos.AutoGenerateColumns = false;
            dgv_Recursos.MultiSelect = false;


        }


        private void opcReservarTurno(object sender, EventArgs e)
        {//obtener lista de tipos de recursos, muestra y solicita que se seleccione un TR
            listaTR = ges.opcReservarTurno(this);
            dgv_TiposRecursos.DataSource = listaTR;
            solicitarSeleccionTR();
            
        }

        private void seleccionarTipoRecurso(object sender, DataGridViewCellEventArgs e)
        {
            //Toma seleccion de tipoRecurso, busca los recursos pertenecientes al tipoRecurso seleccionado y los muestra
            TipoRecurso trSel = dgv_TiposRecursos.SelectedRows[0].DataBoundItem as TipoRecurso;

            ges.tomarSeleccionTipoRecurso(trSel);


            ListaRecs = ges.buscarRTsDelTipo();
            dgv_Recursos.Rows.Clear();
            foreach (RecursoTecnologico rt in ListaRecs)
            {
                dgv_Recursos.Rows.Add(new string[] { rt.getNombreCI(bdd).ToString(), rt.numeroRT.ToString(), rt.modeloRT.getMarca(bdd), rt.getMarcaYModelo(), rt.fechaAlta.ToString()  });
            }
            
            

        }

        private void solicitarSeleccionTR()
        {
            //Muestra ventana emergente que pide seleccion de un tipo de recurso
            MessageBox.Show("Por favor, seleccione un Tipo de Recurso");
        }

        private void seleccionarRT(object sender, DataGridViewCellEventArgs e)
        {
            RecursoTecnologico recSeleccionado = dgv_Recursos.SelectedRows[0].DataBoundItem as RecursoTecnologico;
        }
    }
}