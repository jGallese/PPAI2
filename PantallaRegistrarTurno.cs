using pruebaPPAI.Entidades;
using pruebaPPAI.Helpers;
using System.Reflection;

namespace pruebaPPAI
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
            dgv_TiposRecursos.AutoGenerateColumns = false;
            dgv_TiposRecursos.MultiSelect = false;
            dgv_Recursos.AutoGenerateColumns = false;
            dgv_Recursos.MultiSelect = false;
            
        }


        private void opcReservarTurno(object sender, EventArgs e)
        {//obtener lista de tipos de recursos, muestra y solicita que se seleccione un TR
            listaTR = ges.opcReservarTurno(this);
            dgv_TiposRecursos.DataSource = listaTR;
            dgv_TiposRecursos.Columns[0].Width = 200;
            dgv_TiposRecursos.Columns[1].Width = 200;

            solicitarSeleccionTR();

        }

        private void seleccionarTipoRecurso(object sender, DataGridViewCellEventArgs e)
        {
            //Toma seleccion de tipoRecurso, busca los recursos pertenecientes al tipoRecurso seleccionado y los muestra
            DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
            TipoRecurso trSel = clickedRow.DataBoundItem as TipoRecurso;
            ges.tomarSeleccionTipoRecurso(trSel);
            

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
            //Agregar Columnas a la tabla
            dgv_Recursos.ColumnCount = 5;

            dgv_Recursos.Columns[0].Name = "NombreCentro";
            dgv_Recursos.Columns[0].HeaderText = "NombreCentro";
            dgv_Recursos.Columns[0].DataPropertyName = "NombreCentro";
            dgv_Recursos.Columns[0].Width = 200;

            dgv_Recursos.Columns[1].HeaderText = "NumeroRT";
            dgv_Recursos.Columns[1].Name = "NumeroRT";
            dgv_Recursos.Columns[1].DataPropertyName = "NumeroRT";
            dgv_Recursos.Columns[1].Width = 200;

            dgv_Recursos.Columns[2].Name = "Marca";
            dgv_Recursos.Columns[2].HeaderText = "Marca";
            dgv_Recursos.Columns[2].DataPropertyName = "Marca";
            dgv_Recursos.Columns[2].Width = 200;

            dgv_Recursos.Columns[3].Name = "Modelo";
            dgv_Recursos.Columns[3].HeaderText = "Modelo";
            dgv_Recursos.Columns[3].DataPropertyName = "Modelo";
            dgv_Recursos.Columns[3].Width = 200;

            dgv_Recursos.Columns[4].Name = "Estado";
            dgv_Recursos.Columns[4].HeaderText = "Estado";
            dgv_Recursos.Columns[4].DataPropertyName = "Estado";
            dgv_Recursos.Columns[4].Width = 200;

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


                dgv_Recursos.Rows.Add(new string[] { rt.getNombreCI(bdd).Nombre, rt.numeroRT.ToString(), rt.modeloRT.getMarcaYModelo(bdd), rt.modeloRT.nombre, rtEstadoActual });


                
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
            //toma la seleccion de recurso tecnologico 

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
            ges.tomarSeleccionRT(recSeleccionado);

            panel4.Visible = true;
            presentarFechas(dgv_Recursos, e);

        }

        private void presentarFechas(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Seleccione una fecha por favor");
            dgv_Turnos_De_fecha.Visible = false;
            //llena la grilla con las fechas del recurso seleccionado, aplicando colores dependiendo de la cantidad
            ListaTurnos = ges.agruparYOrdenarTurnos();
            //setear la grilla con fechas

            dgv_Fechas.MultiSelect = false;
            dgv_Fechas.ColumnCount = 1;

            dgv_Fechas.Columns[0].Name = "Fecha";
            dgv_Fechas.Columns[0].Width = 150;
            dgv_Fechas.Width = 180;

            dgv_Fechas.Rows.Clear();

            for (int i = 21; i < 26; i++)
            {
                dgv_Fechas.Rows.Add(new string[] { new DateTime(2022, 6, i).ToShortDateString() });
            }

            //pintar fechas dependiendo de las distintas disponibilidades del turno
            for (int i = 0; i < dgv_Fechas.Rows.Count; i++)
            {
                // cada fecha del calendar

                DataGridViewCell currFila = dgv_Fechas.Rows[i].Cells[0];
                int contadorDispFecha = 0; // contador interno por fecha
                foreach (Turno tur in ListaTurnos) // recorro turnos
                {
                    if (tur.fechaHoraInicio.Date.ToShortDateString() == currFila.Value.ToString()) //turno de la misma fecha
                    {
                        foreach (CambioEstadoTurno ce in tur.CambioEstadoTurno) // conseguir CE actual
                        {
                            if (ce.EsActual())
                            {
                                if (ce.estado.Nombre == "Disponible") //si es disponible, agregar 1 al contador de fecha particular
                                {
                                    contadorDispFecha += 1;
                                }
                            }
                        }
                    }

                }
                if (contadorDispFecha == 0)
                {
                    currFila.Style.BackColor = Color.Red;
                }
                else { currFila.Style.BackColor = Color.LightBlue; }

            }       
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
        }


        private void presentarTurnos(DateTime fechaSeleccionada)
        {   //muestra los turnitos que coincidan con la fecha seleccionada por el cientifico
            List<Turno> listAuxTurn = new List<Turno>(); 

            foreach (Turno turno in ListaTurnos)
            { //busca de la lista de turnos total, los que coincidan con la fecha
                if (turno.fechaHoraInicio.ToLongDateString() == fechaSeleccionada.ToLongDateString())
                {
                    listAuxTurn.Add(turno);
                }
            }
            ListaTurnos = listAuxTurn;

            //crea la tabla
            dgv_Turnos_De_fecha.Rows.Clear();
            dgv_Turnos_De_fecha.ColumnCount = 3;

            dgv_Turnos_De_fecha.Columns[0].Name = "FechaHoraInicio";
            dgv_Turnos_De_fecha.Columns[0].HeaderText = "Hora Inicio";
            dgv_Turnos_De_fecha.Columns[0].Width = 200;

            dgv_Turnos_De_fecha.Columns[1].Name = "FechaHoraFin";
            dgv_Turnos_De_fecha.Columns[1].HeaderText = "Hora Fin";
            dgv_Turnos_De_fecha.Columns[1].Width = 200;
            
            dgv_Turnos_De_fecha.Columns[2].Name = "Estado";
            dgv_Turnos_De_fecha.Columns[2].HeaderText = "Estado Del Turno";
            dgv_Turnos_De_fecha.Columns[2].Width = 200;

            //llena la tabla
            foreach (Turno tt in listAuxTurn)
            {
                string ttEstadoActual = "";
                foreach (CambioEstadoTurno cambioEstado in tt.CambioEstadoTurno)
                {

                    if (cambioEstado.EsActual())
                    {
                        ttEstadoActual = cambioEstado.estado.Nombre;
                    }
                }


                dgv_Turnos_De_fecha.Rows.Add(new string[] { tt.fechaHoraInicio.ToShortTimeString(), tt.fechaHoraFin.ToShortTimeString(), ttEstadoActual });


                //por cada turno de la tabla, se fija en su estado y pinta la celda
                if (ttEstadoActual == "Disponible")
                {
                    dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.BackColor = Color.Blue;
                    dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.ForeColor = Color.White;
                }
                else if (ttEstadoActual == "Con reserva pendiente de confirmacion")
                {
                    dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.BackColor = Color.LightGray;

                }
                else if (ttEstadoActual == "Reservado")
                {
                    dgv_Turnos_De_fecha.Rows[listAuxTurn.IndexOf(tt)].Cells[2].Style.BackColor = Color.Red;
                }


            }


        }

        private void seleccionarTurno(object sender, DataGridViewCellEventArgs e)
        { //evento de seleccion de un turno
            DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
            

            if(clickedRow.Cells[2].Value.ToString() != "Disponible") //comprueba que el turno elegido sea disponible
            {
                MessageBox.Show("Este turno esta seleccionado, pruebe con otro");
            }
            else
            {
                string auxFecha = (this.fechaSelecc+" " + clickedRow.Cells[0].Value.ToString());
                DateTime fechaSelec = DateTime.Parse(auxFecha);

                Turno turnoSeleccionado = null;

                foreach (Turno turno in ListaTurnos)
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
            panel4.Visible = true;

            panel5.Visible = true;
            cmbTiposNotificacion.Visible = false;
            label3.Visible = false;

            //panel5.Location = new Point(0,0);
            dataTurno.Text = ges.TurnoReservado.mostrarTurno();
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