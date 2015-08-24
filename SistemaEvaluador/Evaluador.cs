using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Evaluador : Form
    {
        private string id;
        public Evaluador()
        {
            InitializeComponent();
        }

        private void Evaluador_Load(object sender, EventArgs e)
        {
            EmpleadoNombre en = new EmpleadoNombre();
            en.ShowDialog();
            id = en.id;


            //Buscar el nombre en la base de datos, ya tenemos el ID
            label2.Text = id;

            //cargar de la base de datos los indicadores y los grados!! 
            //Temporal, solo como ejemplo

            dataGridView1.ColumnCount = 3;
            dataGridView1.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView1.Columns[0].Name = "Indicadores";
            dataGridView1.Columns[1].Name = "Bueno";
            dataGridView1.Columns[2].Name = "Excelente";
            


            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Puntaje punt = new Puntaje();
            punt.label2.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            punt.ShowDialog();

            dataGridView1.CurrentRow.Cells[punt.index].Value = "X";
        }
    }
}
