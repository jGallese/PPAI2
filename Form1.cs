using pruebaPPAI.Entidades;

namespace pruebaPPAI
{
    public partial class Form1 : Form
    {
        public List<TipoRecurso> listaTR { get; set; }
        private List<RecursoTecnologico> ListaRecs { get; set; }

        private gestorReservarTurno ges;
        public Form1()
        {
            InitializeComponent();
            ges = new gestorReservarTurno(); 
            ListaRecs = new List<RecursoTecnologico>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv_TiposRecursos.AutoGenerateColumns = false;
            dgv_TiposRecursos.MultiSelect = false;
            dgv_Recursos.AutoGenerateColumns = false;
            dgv_Recursos.MultiSelect = false;

        }


        private void opcionRegistrarReserva(object sender, EventArgs e)
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


            this.ListaRecs = ges.buscarRTsDelTipo();
            dgv_Recursos.DataSource = ListaRecs;
            

        }

        private void solicitarSeleccionTR()
        {
            MessageBox.Show("Por favor, seleccione un Tipo de Recurso");
        }

        private void seleccionarRT(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}