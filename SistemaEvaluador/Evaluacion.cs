using Microsoft.Office.Interop.Excel;
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
using Excel = Microsoft.Office.Interop.Excel; 

namespace SistemaEvaluador
{
    public partial class Evaluacion : Form
    {
        int id;
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
            grados = new Gradosindicadores(con);
            gradosInsert = new List<grados_Arr>();
            id = 0;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Editar_Indicadores ed = new Editar_Indicadores(con,13);
           ed.ShowDialog();
        }

        private void Evaluacion_Load(object sender, EventArgs e)
        {
            EvaluacionNombre Evanom= new EvaluacionNombre(con);
            Evanom.ShowDialog();
            Nombre.Text = Evanom.nombreEvaluacion;
            Fecha.Text = DateTime.Today.ToString();
            System.Data.DataTable dt = new System.Data.DataTable();
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
                id = int.Parse(dt.Rows[0][0].ToString());
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
            indicador = new Indicadores(con, gradosInsert);

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            
            dataGridView1.ColumnCount = gradosLista.Count()+1;
            dataGridView1.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
           columnHeaderStyle.Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView1.Columns[0].Name = "Indicadores";
            for (int i = 0; i < gradosLista.Count(); i++)
            {
                dataGridView1.Columns[i+1].Name = gradosLista.ElementAt(i);
            }
            


           AddIndicadoresDataGrid();
          }

        private void AddIndicadoresDataGrid()
        {
            string[] rows= new string[gradosLista.Count()];
            for (int i = 0; i < indicadores.Count(); i++)
            {
                //Agregar indicador General, luego un for para el especifico de este
                rows[0] = indicadores.ElementAt(i).descp;
                dataGridView1.Rows.Add(rows);
                    for(int x=0;x<indicadores.ElementAt(i).IndicadoresEspecificos.Count();x++)
                    {
                        rows[0] = "   ------"+indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(x).descp;
                        dataGridView1.Rows.Add(rows);
                    }
            }
        }

        private void guardarEvaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application Excel = new Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = true;
            ws.Cells[1, 1] = "Indicadores";
            for(int i=0;i<gradosLista.Count();i++)
            {
                ws.Cells[1, i+2] = gradosLista.ElementAt(i);
            }

            for(int i=0;i<=dataGridView1.Rows.Count;i++)
            {
                for(int x=0;x<gradosLista.Count()+1;x++)
                {
                    ws.Cells[i+2,x+1] = dataGridView1.Rows[i].Cells[x].Value;
                }
            }
        }

    }
}
