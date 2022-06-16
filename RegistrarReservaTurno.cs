
using pruebaPPAI.Entidades;
using pruebaPPAI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CU_23
{
    public partial class RegistrarReservaTurno : Form
    {

        public List<TipoRecurso> listaTR{ get; set; }

        public RegistrarReservaTurno()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e, gestorReservarTurno ges)
        {
            listaTR = ges.opcReservarTurno(this);
            dgv_TiposRecursos.DataSource = listaTR;

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void RegistrarReservaTurno_Load(object sender, EventArgs e)
        {

        }
    }
}
