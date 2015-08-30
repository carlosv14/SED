using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;


namespace SistemaEvaluador
{
    public partial class Evaluador : Form
    {
        SqlConnection con;
        private string id;
        int id_eval;
        private DataTable gradosesp;
        List<string> cols = new List<string>();
        List<Indicadores_Arr> indicadores = new List<Indicadores_Arr>();
        public Evaluador(SqlConnection con)
        {
            this.con = con;
            InitializeComponent();
            gradosesp = new DataTable();
        }

        private void Evaluador_Load(object sender, EventArgs e)
        {
           
            EmpleadoNombre en = new EmpleadoNombre(con);
            en.ShowDialog();
            id = en.id;
            id_eval = en.id_eval;
           
            try
            {
                con.Open();
                DataTable dt1 = new DataTable();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "SELECT CONCAT(NOMBRES,' ',APELLIDOS) FROM EMPLEADOS WHERE ID_EMPLEADO = " + this.id;
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];


                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = "select g.NOMBRE,I.NOMBRE as n from INDICADORES I INNER JOIN GRADOS g on I.ID_IND = g.ID_IND WHERE I.ID = "+ id_eval;
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);


                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];
                gradosesp = dt3;
                dataGridView1.Columns.Add("Indicadores","Indicadores");
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (cols.Count == 0)
                        cols.Add(dt3.Rows[0][0].ToString());
                    else
                    for (int j = 0; j < cols.Count; j++)
                    {
                        if (cols.ElementAt(j) == dt3.Rows[i][0].ToString())
                                break;
                        if (cols.ElementAt(j) != dt3.Rows[i][0].ToString() && j == cols.Count-1)
                            cols.Add(dt3.Rows[i][0].ToString());
                    }
                }

                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "Grado";
                cmb.Name = "Grado";
                dataGridView1.Columns.Add(cmb);

                //for (int i = 0; i <  cols.Count; i++)
                //{


                //        dataGridView1.Rows.Add();
                //        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value = cols.ElementAt(i);



                //}



                //Buscar el nombre en la base de datos, ya tenemos el ID

                label2.Text = id;
            Nombre.Text = dt1.Rows[0][0].ToString();
            //cargar de la base de datos los indicadores y los grados!! 
            //Temporal, solo como ejemplo

            
            dataGridView1.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

          
           
            
               
                DataTable dt = new DataTable();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT I.NOMBRE,I.PESO, IE.NOMBRE, IE.PESO,I.ID_IND,IE.ID_IND from INDICADORES I INNER JOIN INDICADORES IE ON I.ID_IND = IE.ID_GEN WHERE I.ID = " + id_eval;
                SqlDataAdapter da = new SqlDataAdapter(cmd2);

                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                string n_gen = "";
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    if (dt.Rows[i][0].ToString() != n_gen)
                    {
                        n_gen = dt.Rows[i][0].ToString();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["Indicadores"].Value = n_gen;
                       
                    indicadores.Add(new Indicadores_Arr(n_gen, float.Parse(dt.Rows[i][1].ToString()), int.Parse(dt.Rows[i][4].ToString()),null));
                    
                    }
                    if (dt.Rows[i][0].ToString() == n_gen)
                    {
                        dataGridView1.Rows.Add();

                        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["Indicadores"].Value = " ---" + dt.Rows[i][2].ToString();
                        cell = new DataGridViewComboBoxCell();
                        for (int l = 0; l < gradosesp.Rows.Count; l++)
                        {
                           
                            if (dt.Rows[i][2].ToString() == gradosesp.Rows[l][1].ToString())
                            {

                                cell.Items.Add(gradosesp.Rows[l][0].ToString());

                            }

                            
                        }
                        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["Grado"] = cell;
                        indicadores.ElementAt(indicadores.Count - 1).IndicadoresEspecificos.Add(new Indicadores_Arr(dt.Rows[i][2].ToString(), float.Parse(dt.Rows[i][3].ToString()), int.Parse(dt.Rows[i][4].ToString()),null));
                    }

                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Puntaje punt = new Puntaje();
            punt.label2.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            punt.ShowDialog();

            dataGridView1.CurrentRow.Cells[punt.index].Value = "X";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Indicadores_Calc_arr> indicadoresCalc = new List<Indicadores_Calc_arr>();
                Indicadores_Arr indicador = null;
                Indicadores_Arr indicador_esp = null;
                for (int i = 0; i < indicadores.Count; i++)
                {
                    for (int j = 0; j < indicadores.ElementAt(i).IndicadoresEspecificos.Count; j++)
                    {
                        indicador = indicadores.ElementAt(i);
                        indicador_esp = indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(j);
                        indicadoresCalc.Add(new Indicadores_Calc_arr(indicador_esp, 1, indicador.id_gen, 0, cols.Count));
                    }
                }

                Evaluador_Calculos ec = new Evaluador_Calculos(indicadoresCalc);
                List<Resultado_Indicadores_Generales> resul = new List<Resultado_Indicadores_Generales>();


                ec.Calcular_Indicador();
                float suma = 0;
                for (int i = 0; i < indicadores.Count; i++)
                {
                    for (int j = 0; j < ec.calculos.Count; j++)
                    {
                        if (indicadores.ElementAt(i).id_gen == ec.calculos.ElementAt(j).indicador.id_gen)
                        {
                            suma += ec.calculos.ElementAt(j).respuesta;
                        }

                    }
                    resul.Add(new Resultado_Indicadores_Generales(indicadores.ElementAt(i).descp, suma));
                    suma = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatoEvaluadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            string strfilename;
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                String filename = fd.FileName.ToString();
                Excel.Application ex = new Excel.Application();
                Excel.Workbook wb = ex.Workbooks.Open(filename);
                ex.Visible = true;
              

            }
        }
    }
}
