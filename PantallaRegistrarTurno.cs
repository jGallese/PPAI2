using PPAI;

using PPAI.Entidades;
using PPAI.Helpers;
using System.ComponentModel;
using System.Reflection;

namespace PPAI
{
    public partial class PantallaRegistrarTurnos : Form
    {
        
        public List<TipoRecurso> listaTR { get; set; }
        public List<RecursoTecnologico> ListaRecs { get; set; }

        public List<Turno> ListaTurnos{ get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                  public string fechaSelecc { get; set; }
        private gestorRegistrarTurno ges;

        baseDeDatos bdd = new baseDeDatos();
        public PantallaRegistrarTurnos()
        {
            InitializeComponent();
            ges = new gestorRegistrarTurno(); 
            ListaRecs = new List<RecursoTecnologico>();
            panel5.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;


        }
        

        private void Form1_Load(object sender, EventArgs e) //METODO HABILITAR PANTALLA, SI SE CAMBIA EL NOMBRE SE ROMPE
        {
            //dgv_TiposRecursos.AutoGenerateColumns = false;
            //dgv_TiposRecursos.MultiSelect = false;
            //dgv_Recursos.AutoGenerateColumns = false;
            //dgv_Recursos.MultiSelect = false;
            opcReservarTurno(this, e);
        }


        private void opcReservarTurno(object sender, EventArgs e)
        {//obtener lista de tipos de recursos, muestra y solicita que se seleccione un TR
            ges.opcReservarTurno(this);
            dgv_TiposRecursos.Visible = true;
            btnCancelarReserva.Text = "Cancelar Reserva";



            solicitarSeleccionTR();

        }

        private void seleccionarTipoRecurso(object sender, DataGridViewCellEventArgs e)
        {
            //Toma seleccion de tipoRecurso, busca los recursos pertenecientes al tipoRecurso seleccionado y los muestra
            int indice = e.RowIndex;
            DataGridViewRow filaSeleccionada = dgv_TiposRecursos.Rows[indice];

            TipoRecurso trSeleccionado = new TipoRecurso();
            trSeleccionado.oid = (int)filaSeleccionada.Cells[0].Value;
            trSeleccionado.Nombre = filaSeleccionada.Cells[1].Value.ToString();
            trSeleccionado.Descripcion = filaSeleccionada.Cells[2].Value.ToString();


            ges.tomarSeleccionTipoRecurso(trSeleccionado, this);
            

            ges.agruparPorCI(this);
        }

        public void solicitarSeleccionTR()
        {
            //Muestra ventana emergente que pide seleccion de un tipo de recurso
            MessageBox.Show("Por favor, seleccione un Tipo de Recurso");
        }
        public void solicitarSeleccionRT()
        {
            panel3.Visible = true;
            //Muestra ventana emergente que pide seleccion de un tipo de recurso
            MessageBox.Show("Por favor, seleccione un Recurso Tecnológico de \n " + this.ges.TipoRecursoSeleccionado.GetTipoRecurso());
            

        }

        
        private void seleccionarRT(object sender, DataGridViewCellEventArgs e)
        {
            //toma la seleccion de recurso tecnologico 
            int indice = e.RowIndex;
            DataGridViewRow filaSeleccionada = dgv_Recursos.Rows[indice];

            int nroRecurso = Int32.Parse(filaSeleccionada.Cells[1].Value.ToString());

            
            ges.tomarSeleccionRT(nroRecurso);

            panel4.Visible = true;
            presentarFechas(dgv_Recursos, e);

        }

        private void presentarFechas(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Seleccione una fecha por favor");
            dgv_Turnos_De_fecha.Visible = false;
            //llena la grilla con las fechas del recurso seleccionado, aplicando colores dependiendo de la cantidad
            ges.agruparYOrdenarTurnos(this);
            //setear la grilla con fechas

                  
        }

        private void seleccionarFecha(object sender, DataGridViewCellEventArgs e)
        {
            //Toma la seleccion de una fecha
            DataGridViewRow clickedFecha = (sender as DataGridView).Rows[e.RowIndex];
            

            this.fechaSelecc = "";


                if (clickedFecha.Cells[0].Style.BackColor == Color.LightBlue)
                {
                    this.fechaSelecc = clickedFecha.Cells[0].Value.ToString();
                    MessageBox.Show("Ha seleccionado una fecha para la cual hay disponibilidad de turnos \nAhora, por favor, seleccione un turno");

                    
                    presentarTurnos(DateTime.Parse(this.fechaSelecc));
                    
                

            }
                else
                {
                    MessageBox.Show("Ha seleccionado una fecha para la cual no hay disponibilidad de turnos \nPor favor, seleccione una fecha valida");
                }

            
                dgv_Turnos_De_fecha.Visible = true;
                label7.Visible = true;
        }

        private void presentarTurnos(DateTime fechaSeleccionada)
        {   //muestra los turnitos que coincidan con la fecha seleccionada por el cientifico

            ges.CargarGrillaTurnos(this, fechaSeleccionada);
            


        }

        private void seleccionarTurno(object sender, DataGridViewCellEventArgs e)
        { //evento de seleccion de un turno
            DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
            

            if(clickedRow.Cells[2].Value.ToString() != "Disponible") //comprueba que el turno elegido sea disponible
            {
                MessageBox.Show("Parece que este turno esta seleccionado, pruebe con otro");
            }
            else
            {
                string auxFecha = (this.fechaSelecc+" " + clickedRow.Cells[0].Value.ToString());
                DateTime fechaSelec = DateTime.Parse(auxFecha);

                Turno turnoSeleccionado = null;

                foreach (Turno turno in ges.listaTurnos)
                {
                    if (turno.fechaHoraInicio == fechaSelec)
                    {
                        turnoSeleccionado = turno;
                        MessageBox.Show(turnoSeleccionado.mostrarTurno());
                        break;
                    }
                }

                ges.tomarSeleccionTurno(turnoSeleccionado);
                solicitarConfirmarReserva();
            }

            

        }

        private void solicitarConfirmarReserva()
        { //pide al cientifico que confirme su reserva
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            panel5.Visible = true;
            cmbTiposNotificacion.Visible = false;
            label3.Visible = false;

            panel5.Location = new Point(0,0);
            dataTurno.Text = ges.TurnoSeleccionado.mostrarTurno();
            dataRecurso.Text = ges.RTSeleccionado.getDatos();
        }

        private void confirmarReserva(object sender, EventArgs e)
        {   //evento de confirmacion de la reserva
            ges.tomarConfirmacion(this);
           
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {//cancelacion del caso de uso
            MessageBox.Show("Volviendo a menu principal");
            this.Close();
        }

        private void btnCancelaReserva_Click(object sender, EventArgs e)
        {//no se confirma la reserva
            
           PantallaRegistrarTurnos nuevo = new PantallaRegistrarTurnos();
            nuevo.Show();
            this.Hide();
        }

        public void solicitarTipoNotificacion()
        {
            //pide al cientifico que seleccione el tipo de notificacion
            cmbTiposNotificacion.Visible = true;
            label3.Visible = true;
            MessageBox.Show("Ahora, por favor, seleccione una forma de notificacion");
            cmbTiposNotificacion.SelectedIndex = -1;
            cmbTiposNotificacion.SelectedIndexChanged += new System.EventHandler(seleccionarTipoNotificacion);
        }

        private void seleccionarTipoNotificacion(object sender, EventArgs e)
        {
                //evento de seleccion del tipo de notificacion.
            string stringIndex = (cmbTiposNotificacion.SelectedIndex.ToString());
            int index = int.Parse(stringIndex);
            string a = cmbTiposNotificacion.Items[index].ToString();
            ges.tomarTipoNotificacion(a);
            
        }

    }
}