namespace PPAI
{
    partial class PantallaRegistrarTurnos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_reg_reserva = new System.Windows.Forms.Button();
            this.dgv_TiposRecursos = new System.Windows.Forms.DataGridView();
            this.idTipoRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTipoRecurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionTipoRecurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Recursos = new PPAI.Helpers.GroupByGrid();
            this.Centro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreRecurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_Turnos_De_fecha = new System.Windows.Forms.DataGridView();
            this.dgv_Fechas = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnConfirmarReserva = new System.Windows.Forms.Button();
            this.btnCancelaReserva = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTiposNotificacion = new System.Windows.Forms.ComboBox();
            this.dataRecurso = new System.Windows.Forms.Label();
            this.dataTurno = new System.Windows.Forms.Label();
            this.FechaHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiposRecursos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Recursos)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Turnos_De_fecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Fechas)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(365, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 648);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 147);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_reg_reserva
            // 
            this.btn_reg_reserva.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_reg_reserva.Location = new System.Drawing.Point(901, 73);
            this.btn_reg_reserva.Name = "btn_reg_reserva";
            this.btn_reg_reserva.Size = new System.Drawing.Size(204, 55);
            this.btn_reg_reserva.TabIndex = 0;
            this.btn_reg_reserva.Text = "Registrar Reserva";
            this.btn_reg_reserva.UseVisualStyleBackColor = true;
            this.btn_reg_reserva.Click += new System.EventHandler(this.opcReservarTurno);
            // 
            // dgv_TiposRecursos
            // 
            this.dgv_TiposRecursos.AllowUserToAddRows = false;
            this.dgv_TiposRecursos.AllowUserToDeleteRows = false;
            this.dgv_TiposRecursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TiposRecursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoRT,
            this.nombreTipoRecurso,
            this.descripcionTipoRecurso});
            this.dgv_TiposRecursos.Location = new System.Drawing.Point(151, 73);
            this.dgv_TiposRecursos.Name = "dgv_TiposRecursos";
            this.dgv_TiposRecursos.ReadOnly = true;
            this.dgv_TiposRecursos.RowHeadersWidth = 62;
            this.dgv_TiposRecursos.RowTemplate.Height = 33;
            this.dgv_TiposRecursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TiposRecursos.Size = new System.Drawing.Size(500, 225);
            this.dgv_TiposRecursos.TabIndex = 1;
            this.dgv_TiposRecursos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarTipoRecurso);
            // 
            // idTipoRT
            // 
            this.idTipoRT.DataPropertyName = "idTipoRT";
            this.idTipoRT.HeaderText = "id";
            this.idTipoRT.MinimumWidth = 8;
            this.idTipoRT.Name = "idTipoRT";
            this.idTipoRT.ReadOnly = true;
            this.idTipoRT.Visible = false;
            this.idTipoRT.Width = 150;
            // 
            // nombreTipoRecurso
            // 
            this.nombreTipoRecurso.DataPropertyName = "nombre";
            this.nombreTipoRecurso.HeaderText = "Tipo Recurso";
            this.nombreTipoRecurso.MinimumWidth = 8;
            this.nombreTipoRecurso.Name = "nombreTipoRecurso";
            this.nombreTipoRecurso.ReadOnly = true;
            this.nombreTipoRecurso.Width = 150;
            // 
            // descripcionTipoRecurso
            // 
            this.descripcionTipoRecurso.DataPropertyName = "descripcion";
            this.descripcionTipoRecurso.HeaderText = "Descripcion";
            this.descripcionTipoRecurso.MinimumWidth = 8;
            this.descripcionTipoRecurso.Name = "descripcionTipoRecurso";
            this.descripcionTipoRecurso.ReadOnly = true;
            this.descripcionTipoRecurso.Width = 150;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnCancelarReserva);
            this.panel2.Controls.Add(this.dgv_TiposRecursos);
            this.panel2.Controls.Add(this.btn_reg_reserva);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1527, 394);
            this.panel2.TabIndex = 2;
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.BackColor = System.Drawing.Color.Red;
            this.btnCancelarReserva.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancelarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarReserva.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelarReserva.ForeColor = System.Drawing.Color.White;
            this.btnCancelarReserva.Location = new System.Drawing.Point(901, 148);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(204, 94);
            this.btnCancelarReserva.TabIndex = 2;
            this.btnCancelarReserva.Text = "Cancelar Reserva";
            this.btnCancelarReserva.UseVisualStyleBackColor = false;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.panel3.Controls.Add(this.dgv_Recursos);
            this.panel3.Location = new System.Drawing.Point(0, 453);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1500, 300);
            this.panel3.TabIndex = 3;
            // 
            // dgv_Recursos
            // 
            this.dgv_Recursos.AllowUserToAddRows = false;
            this.dgv_Recursos.AllowUserToDeleteRows = false;
            this.dgv_Recursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Recursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Centro,
            this.nombreRecurso,
            this.marcaRT,
            this.modeloRT,
            this.estadoRT});
            this.dgv_Recursos.Location = new System.Drawing.Point(153, 40);
            this.dgv_Recursos.MultiSelect = false;
            this.dgv_Recursos.Name = "dgv_Recursos";
            this.dgv_Recursos.ReadOnly = true;
            this.dgv_Recursos.RowHeadersWidth = 62;
            this.dgv_Recursos.RowTemplate.Height = 33;
            this.dgv_Recursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Recursos.Size = new System.Drawing.Size(1235, 211);
            this.dgv_Recursos.TabIndex = 0;
            this.dgv_Recursos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarRT);
            // 
            // Centro
            // 
            this.Centro.HeaderText = "CentroInv";
            this.Centro.MinimumWidth = 8;
            this.Centro.Name = "Centro";
            this.Centro.ReadOnly = true;
            this.Centro.Width = 150;
            // 
            // nombreRecurso
            // 
            this.nombreRecurso.HeaderText = "Recurso";
            this.nombreRecurso.MinimumWidth = 8;
            this.nombreRecurso.Name = "nombreRecurso";
            this.nombreRecurso.ReadOnly = true;
            this.nombreRecurso.Width = 150;
            // 
            // marcaRT
            // 
            this.marcaRT.HeaderText = "Marca";
            this.marcaRT.MinimumWidth = 8;
            this.marcaRT.Name = "marcaRT";
            this.marcaRT.ReadOnly = true;
            this.marcaRT.Width = 150;
            // 
            // modeloRT
            // 
            this.modeloRT.HeaderText = "Modelo ";
            this.modeloRT.MinimumWidth = 8;
            this.modeloRT.Name = "modeloRT";
            this.modeloRT.ReadOnly = true;
            this.modeloRT.Width = 150;
            // 
            // estadoRT
            // 
            this.estadoRT.HeaderText = "Estado";
            this.estadoRT.MinimumWidth = 8;
            this.estadoRT.Name = "estadoRT";
            this.estadoRT.ReadOnly = true;
            this.estadoRT.Width = 150;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Controls.Add(this.dgv_Turnos_De_fecha);
            this.panel4.Controls.Add(this.dgv_Fechas);
            this.panel4.Location = new System.Drawing.Point(0, 805);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1500, 276);
            this.panel4.TabIndex = 4;
            // 
            // dgv_Turnos_De_fecha
            // 
            this.dgv_Turnos_De_fecha.AllowUserToAddRows = false;
            this.dgv_Turnos_De_fecha.AllowUserToDeleteRows = false;
            this.dgv_Turnos_De_fecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Turnos_De_fecha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaHoraInicio,
            this.FechaHoraFin,
            this.EstadoTurno});
            this.dgv_Turnos_De_fecha.Location = new System.Drawing.Point(667, 23);
            this.dgv_Turnos_De_fecha.MultiSelect = false;
            this.dgv_Turnos_De_fecha.Name = "dgv_Turnos_De_fecha";
            this.dgv_Turnos_De_fecha.ReadOnly = true;
            this.dgv_Turnos_De_fecha.RowHeadersWidth = 62;
            this.dgv_Turnos_De_fecha.RowTemplate.Height = 25;
            this.dgv_Turnos_De_fecha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Turnos_De_fecha.Size = new System.Drawing.Size(662, 187);
            this.dgv_Turnos_De_fecha.TabIndex = 1;
            this.dgv_Turnos_De_fecha.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarTurno);
            // 
            // dgv_Fechas
            // 
            this.dgv_Fechas.AllowUserToAddRows = false;
            this.dgv_Fechas.AllowUserToDeleteRows = false;
            this.dgv_Fechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Fechas.Location = new System.Drawing.Point(135, 23);
            this.dgv_Fechas.MultiSelect = false;
            this.dgv_Fechas.Name = "dgv_Fechas";
            this.dgv_Fechas.ReadOnly = true;
            this.dgv_Fechas.RowHeadersWidth = 62;
            this.dgv_Fechas.RowTemplate.Height = 25;
            this.dgv_Fechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Fechas.Size = new System.Drawing.Size(472, 187);
            this.dgv_Fechas.TabIndex = 0;
            this.dgv_Fechas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarFecha);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.btnConfirmarReserva);
            this.panel5.Controls.Add(this.btnCancelaReserva);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cmbTiposNotificacion);
            this.panel5.Controls.Add(this.dataRecurso);
            this.panel5.Controls.Add(this.dataTurno);
            this.panel5.Location = new System.Drawing.Point(0, 1163);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1501, 400);
            this.panel5.TabIndex = 5;
            // 
            // btnConfirmarReserva
            // 
            this.btnConfirmarReserva.BackColor = System.Drawing.Color.SpringGreen;
            this.btnConfirmarReserva.FlatAppearance.BorderColor = System.Drawing.Color.SpringGreen;
            this.btnConfirmarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarReserva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmarReserva.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmarReserva.Location = new System.Drawing.Point(839, 114);
            this.btnConfirmarReserva.Name = "btnConfirmarReserva";
            this.btnConfirmarReserva.Size = new System.Drawing.Size(270, 50);
            this.btnConfirmarReserva.TabIndex = 7;
            this.btnConfirmarReserva.Text = "Confirmar Reserva";
            this.btnConfirmarReserva.UseVisualStyleBackColor = false;
            this.btnConfirmarReserva.Click += new System.EventHandler(this.confirmarReserva);
            // 
            // btnCancelaReserva
            // 
            this.btnCancelaReserva.BackColor = System.Drawing.Color.Red;
            this.btnCancelaReserva.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancelaReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelaReserva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelaReserva.ForeColor = System.Drawing.Color.White;
            this.btnCancelaReserva.Location = new System.Drawing.Point(838, 177);
            this.btnCancelaReserva.Name = "btnCancelaReserva";
            this.btnCancelaReserva.Size = new System.Drawing.Size(270, 50);
            this.btnCancelaReserva.TabIndex = 6;
            this.btnCancelaReserva.Text = "No Confirmar Reserva";
            this.btnCancelaReserva.UseVisualStyleBackColor = false;
            this.btnCancelaReserva.Click += new System.EventHandler(this.btnCancelaReserva_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(839, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Forma de Notificacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(230, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datos del Recurso Seleccionado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(230, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datos del Turno Seleccionado";
            // 
            // cmbTiposNotificacion
            // 
            this.cmbTiposNotificacion.FormattingEnabled = true;
            this.cmbTiposNotificacion.Items.AddRange(new object[] {
            "Email",
            "Whatsapp"});
            this.cmbTiposNotificacion.Location = new System.Drawing.Point(839, 56);
            this.cmbTiposNotificacion.Name = "cmbTiposNotificacion";
            this.cmbTiposNotificacion.Size = new System.Drawing.Size(270, 33);
            this.cmbTiposNotificacion.TabIndex = 2;
            this.cmbTiposNotificacion.Text = "Email";
            // 
            // dataRecurso
            // 
            this.dataRecurso.AutoSize = true;
            this.dataRecurso.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataRecurso.Location = new System.Drawing.Point(230, 183);
            this.dataRecurso.Name = "dataRecurso";
            this.dataRecurso.Size = new System.Drawing.Size(65, 28);
            this.dataRecurso.TabIndex = 1;
            this.dataRecurso.Text = "label1";
            // 
            // dataTurno
            // 
            this.dataTurno.AutoSize = true;
            this.dataTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataTurno.Location = new System.Drawing.Point(230, 75);
            this.dataTurno.Name = "dataTurno";
            this.dataTurno.Size = new System.Drawing.Size(65, 28);
            this.dataTurno.TabIndex = 0;
            this.dataTurno.Text = "label1";
            // 
            // FechaHoraInicio
            // 
            this.FechaHoraInicio.HeaderText = "Hora Inicio";
            this.FechaHoraInicio.MinimumWidth = 8;
            this.FechaHoraInicio.Name = "FechaHoraInicio";
            this.FechaHoraInicio.ReadOnly = true;
            this.FechaHoraInicio.Width = 200;
            // 
            // FechaHoraFin
            // 
            this.FechaHoraFin.HeaderText = "Hora Fin";
            this.FechaHoraFin.MinimumWidth = 8;
            this.FechaHoraFin.Name = "FechaHoraFin";
            this.FechaHoraFin.ReadOnly = true;
            this.FechaHoraFin.Width = 200;
            // 
            // EstadoTurno
            // 
            this.EstadoTurno.HeaderText = "Estado Turno";
            this.EstadoTurno.MinimumWidth = 8;
            this.EstadoTurno.Name = "EstadoTurno";
            this.EstadoTurno.ReadOnly = true;
            this.EstadoTurno.Width = 150;
            // 
            // PantallaRegistrarTurnos
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1503, 1105);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "PantallaRegistrarTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiposRecursos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Recursos)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Turnos_De_fecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Fechas)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Panel panel1;
        public Button button1;
        public Button btn_reg_reserva;
        public DataGridView dgv_TiposRecursos;
        public Panel panel2;
        public Panel panel3;
        public Helpers.GroupByGrid dgv_Recursos;
        public Panel panel4;
        public DataGridView dgv_Fechas;
        public DataGridView dgv_Turnos_De_fecha;
        public Button btnCancelarReserva;
        public Panel panel5;
        public ComboBox cmbTiposNotificacion;
        public Label dataRecurso;
        public Label dataTurno;
        public Label label1;
        public Label label3;
        public Label label2;
        public Button btnCancelaReserva;
        public Button btnConfirmarReserva;
        private DataGridViewTextBoxColumn idTipoRT;
        private DataGridViewTextBoxColumn nombreTipoRecurso;
        private DataGridViewTextBoxColumn descripcionTipoRecurso;
        private DataGridViewTextBoxColumn Centro;
        private DataGridViewTextBoxColumn nombreRecurso;
        private DataGridViewTextBoxColumn marcaRT;
        private DataGridViewTextBoxColumn modeloRT;
        private DataGridViewTextBoxColumn estadoRT;
        private DataGridViewTextBoxColumn FechaHoraInicio;
        private DataGridViewTextBoxColumn FechaHoraFin;
        private DataGridViewTextBoxColumn EstadoTurno;
        //private DataGridView dgv_Recursos;
    }
}