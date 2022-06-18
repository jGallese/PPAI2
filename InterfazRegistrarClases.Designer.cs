namespace pruebaPPAI
{
    partial class InterfazRegistrarClases
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Recursos = new pruebaPPAI.Helpers.GroupByGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiposRecursos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Recursos)).BeginInit();
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
            this.btn_reg_reserva.Location = new System.Drawing.Point(887, 73);
            this.btn_reg_reserva.Name = "btn_reg_reserva";
            this.btn_reg_reserva.Size = new System.Drawing.Size(315, 188);
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
            this.dgv_TiposRecursos.Location = new System.Drawing.Point(102, 73);
            this.dgv_TiposRecursos.Name = "dgv_TiposRecursos";
            this.dgv_TiposRecursos.ReadOnly = true;
            this.dgv_TiposRecursos.RowHeadersWidth = 62;
            this.dgv_TiposRecursos.RowTemplate.Height = 33;
            this.dgv_TiposRecursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TiposRecursos.Size = new System.Drawing.Size(483, 225);
            this.dgv_TiposRecursos.TabIndex = 1;
            this.dgv_TiposRecursos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionarTipoRecurso);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(193)))), ((int)(((byte)(168)))));
            this.panel2.Controls.Add(this.dgv_TiposRecursos);
            this.panel2.Controls.Add(this.btn_reg_reserva);
            this.panel2.Location = new System.Drawing.Point(93, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1468, 367);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.panel3.Controls.Add(this.dgv_Recursos);
            this.panel3.Location = new System.Drawing.Point(93, 427);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1468, 327);
            this.panel3.TabIndex = 3;
            // 
            // dgv_Recursos
            // 
            this.dgv_Recursos.AllowUserToAddRows = false;
            this.dgv_Recursos.AllowUserToDeleteRows = false;
            this.dgv_Recursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Recursos.Location = new System.Drawing.Point(110, 35);
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
            // InterfazRegistrarClases
            // 
            this.ClientSize = new System.Drawing.Size(1513, 763);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "InterfazRegistrarClases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiposRecursos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Recursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button btn_reg_reserva;
        private DataGridView dgv_TiposRecursos;
        private Panel panel2;
        private Panel panel3;
        private Helpers.GroupByGrid dgv_Recursos;
        //private DataGridView dgv_Recursos;
    }
}