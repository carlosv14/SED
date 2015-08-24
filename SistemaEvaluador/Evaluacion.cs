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
        List<grados_Arr> gradosInsert;
        public Evaluacion(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            indicador = new Indicadores(con,gradosInsert);
            grados = new Gradosindicadores(con);
            gradosInsert = new List<grados_Arr>();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indicador.ShowDialog();
        }

        private void Evaluacion_Load(object sender, EventArgs e)
        {
            EvaluacionNombre Evanom= new EvaluacionNombre(con);
            Evanom.ShowDialog();
            Nombre.Text = Evanom.nombreEvaluacion;
            Fecha.Text = DateTime.Today.ToString();
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT COUNT(*) from INFORME_INDICADORES";
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
               
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            GradosInicio grad = new GradosInicio();
            grad.ShowDialog();
            gradosLista = grad.grados;
            for (int i = 0; i < gradosLista.Count; i++)
            {
                gradosInsert.Add(new grados_Arr( 0, int.Parse(dt.Rows[0][0].ToString()), gradosLista.ElementAt(i), i + 1));
            }
            Indicadores ind = new Indicadores(con,gradosInsert);
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
