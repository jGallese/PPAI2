
namespace CU_23
{
    partial class RegistrarReservaTurno
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
            this.btn_reservarTurno = new System.Windows.Forms.Button();
            this.dgv_TiposRecursos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTipoRecurso = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiposRecursos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_reservarTurno
            // 
            this.btn_reservarTurno.Location = new System.Drawing.Point(766, 45);
            this.btn_reservarTurno.Name = "btn_reservarTurno";
            this.btn_reservarTurno.Size = new System.Drawing.Size(222, 85);
            this.btn_reservarTurno.TabIndex = 0;
            this.btn_reservarTurno.Text = "Reservar Turno";
            this.btn_reservarTurno.UseVisualStyleBackColor = true;
            // 
            // dgv_TiposRecursos
            // 
            this.dgv_TiposRecursos.ColumnHeadersHeight = 34;
            this.dgv_TiposRecursos.Location = new System.Drawing.Point(0, 0);
            this.dgv_TiposRecursos.Name = "dgv_TiposRecursos";
            this.dgv_TiposRecursos.RowHeadersWidth = 62;
            this.dgv_TiposRecursos.Size = new System.Drawing.Size(240, 150);
            this.dgv_TiposRecursos.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 150;
            // 
            // Descripcion
            // 
            this.Descripcion.MinimumWidth = 8;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 150;
            // 
            // panelTipoRecurso
            // 
            this.panelTipoRecurso.Location = new System.Drawing.Point(0, 0);
            this.panelTipoRecurso.Name = "panelTipoRecurso";
            this.panelTipoRecurso.Size = new System.Drawing.Size(200, 100);
            this.panelTipoRecurso.TabIndex = 0;
            // 
            // RegistrarReservaTurno
            // 
            this.ClientSize = new System.Drawing.Size(1252, 843);
            this.Name = "RegistrarReservaTurno";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiposRecursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_reservarTurno;
        private DataGridView dgv_TiposRecursos;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private Panel panelTipoRecurso;
    }
}

