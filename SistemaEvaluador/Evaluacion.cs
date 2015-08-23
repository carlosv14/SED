using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Evaluacion : Form
    {
        Indicadores indicador;
        Gradosindicadores grados;
        private SqlConnection con;
        List<String> gradosLista;
        List<Indicadores_Arr> indicadores;
        public Evaluacion(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            indicador = new Indicadores();
            grados = new Gradosindicadores(con);
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indicador.ShowDialog();
        }

        private void Evaluacion_Load(object sender, EventArgs e)
        {
            EvaluacionNombre Evanom= new EvaluacionNombre();
            Evanom.ShowDialog();
            Nombre.Text = Evanom.nombreEvaluacion;
            Fecha.Text = DateTime.Today.ToString();

            GradosInicio grad = new GradosInicio();
            grad.ShowDialog();
            gradosLista = grad.grados;

            Indicadores ind = new Indicadores();
            ind.ShowDialog();
            indicadores = ind.indicadoresEspecificos;

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            
            dataGridView1.ColumnCount = gradosLista.Count()+1;
            dataGridView1.ColumnHeadersVisible = true;

            
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView1.Columns[0].Name = "Indicadores";
            for (int i = 0; i < gradosLista.Count(); i++)
            {
                dataGridView1.Columns[i+1].Name = gradosLista.ElementAt(i);
            }

           // AddIndicadoresDataGrid();
          }

        private void AddIndicadoresDataGrid()
        {
            for (int i = 0; i < indicadores.Count(); i++)
            {
                dataGridView1.Rows.Add(i);
            }
        }

    }
}
