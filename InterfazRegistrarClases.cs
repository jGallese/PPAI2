using pruebaPPAI.Entidades;
using System.Reflection;

namespace pruebaPPAI
{
    public partial class InterfazRegistrarClases : Form
    {
        public List<TipoRecurso> listaTR { get; set; }
        public List<RecursoTecnologico> ListaRecs { get; set; }

        private gestorRegistrarTurno ges;
        baseDeDatos bdd = new baseDeDatos();
        public InterfazRegistrarClases()
        {
            InitializeComponent();
            ges = new gestorRegistrarTurno(); 
            ListaRecs = new List<RecursoTecnologico>();
            
            
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
            DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
            TipoRecurso trSel = clickedRow.DataBoundItem as TipoRecurso;
            ges.tomarSeleccionTipoRecurso(trSel);

            solicitarSeleccionRT();
        }

        private void solicitarSeleccionTR()
        {
            //Muestra ventana emergente que pide seleccion de un tipo de recurso
            MessageBox.Show("Por favor, seleccione un Tipo de Recurso");
        }
        private void solicitarSeleccionRT()
        {
            //Muestra ventana emergente que pide seleccion de un tipo de recurso
            MessageBox.Show("Por favor, seleccione un Recurso Tecnológico de \n " + this.ges.TipoRecursoSeleccionado.GetTipoRecurso());

            //Muestra Los distintos recursos tecnologicos, para el tipo de recurso seleccionado

            //Agregar Columnas a la tabla
            dgv_Recursos.ColumnCount = 5;

            dgv_Recursos.Columns[0].Name = "NombreCentro";
            dgv_Recursos.Columns[0].HeaderText = "NombreCentro";
            dgv_Recursos.Columns[0].DataPropertyName = "NombreCentro";

            dgv_Recursos.Columns[1].HeaderText = "NumeroRT";
            dgv_Recursos.Columns[1].Name = "NumeroRT";
            dgv_Recursos.Columns[1].DataPropertyName = "NumeroRT";

            dgv_Recursos.Columns[2].Name = "Marca";
            dgv_Recursos.Columns[2].HeaderText = "Marca";
            dgv_Recursos.Columns[2].DataPropertyName = "Marca";

            dgv_Recursos.Columns[3].Name = "Modelo";
            dgv_Recursos.Columns[3].HeaderText = "Modelo";
            dgv_Recursos.Columns[3].DataPropertyName = "Modelo";

            dgv_Recursos.Columns[4].Name = "Estado";
            dgv_Recursos.Columns[4].HeaderText = "Estado";
            dgv_Recursos.Columns[4].DataPropertyName = "Estado";

            //traer datos del recursos tecnologicos que cumplan las condiciones
            ListaRecs = ges.buscarRTsDelTipo();
            dgv_Recursos.Rows.Clear();
            //llenar la grilla

            

            foreach (RecursoTecnologico rt in ListaRecs)
            {
                string rtEstadoActual = "";
                foreach (CambioEstadoRT cambioEstado in rt.ListaCambioEstadosRT)
                {

                    if (cambioEstado.EsActual())
                    {
                        rtEstadoActual = cambioEstado.Estado.Nombre;
                    }
                }


                dgv_Recursos.Rows.Add(new string[] { rt.getNombreCI(bdd).Nombre, rt.numeroRT.ToString(), rt.modeloRT.getMarca(bdd), rt.getMarcaYModelo(), rtEstadoActual });


                
                if (rtEstadoActual == "Disponible")
                {
                    dgv_Recursos.Rows[ListaRecs.IndexOf(rt)].Cells[4].Style.BackColor = Color.Blue;
                    dgv_Recursos.Rows[ListaRecs.IndexOf(rt)].Cells[4].Style.ForeColor = Color.White;
                } else if (rtEstadoActual == "En Mantenimiento")
                {
                    dgv_Recursos.Rows[ListaRecs.IndexOf(rt)].Cells[4].Style.BackColor = Color.Green;
                    dgv_Recursos.Rows[ListaRecs.IndexOf(rt)].Cells[4].Style.ForeColor = Color.White;
                } else
                {
                    dgv_Recursos.Rows[ListaRecs.IndexOf(rt)].Cells[4].Style.BackColor = Color.LightGray;
                }


            }

        }

        private void seleccionarRT(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow clickedRow = (sender as Helpers.GroupByGrid).Rows[e.RowIndex];
            string numeroAux = clickedRow.Cells[1].Value.ToString();

            int numeroAyuda = Int32.Parse(numeroAux);

            RecursoTecnologico recSeleccionado = null;

            foreach (RecursoTecnologico recurso in bdd.listaRecursosTecnologicos)
            {
                if (recurso.numeroRT == numeroAyuda)
                {
                    recSeleccionado = recurso;
                }
            }
            //RecursoTecnologico recSeleccionado = dgv_Recursos.SelectedRows[0].DataBoundItem as RecursoTecnologico;
            ges.tomarSeleccionRT(recSeleccionado);
        }

        private void presentarFechas(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Fechas.ColumnCount = 1;

            dgv_Fechas.Columns[0].Name = "Fecha";
            dgv_Fechas.Columns[0].DataPropertyName = "FechaHoraInicio";


        }
        
        private void presentarTurnos(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}