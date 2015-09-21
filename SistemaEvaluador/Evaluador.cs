﻿using System;
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
using DevComponents.DotNetBar;


namespace SistemaEvaluador
{
    public partial class Evaluador : Form
    {

        SqlConnection con;
        private string id;
        public List<CoordenadaTriangular> nbts; 
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
            List<string> bloquear = new List<string>();
            en.ShowDialog();
            id = en.id;
            id_eval = en.id_eval;
            Fecha.Text = DateTime.Now.ToString();
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
                        bloquear.Add(n_gen);
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["Indicadores"].Value = n_gen;
                        
                    indicadores.Add(new Indicadores_Arr(n_gen, float.Parse(dt.Rows[i][1].ToString()), int.Parse(dt.Rows[i][4].ToString()),null));
                    
                    }
                    //ver aca
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

                
                //========= CHECKBOX

                DataTable dt4 = new DataTable();
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = con;
                cmd4.CommandType = System.Data.CommandType.Text;
                cmd4.CommandText = "SELECT NOMBRE FROM GRADOS WHERE ID_IND= (SELECT TOP 1 ID_IND FROM INDICADORES WHERE ID='"+id_eval+"' AND ID_GEN IS NULL)";
                SqlDataAdapter da4 = new SqlDataAdapter(cmd4);

                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                dt4 = ds4.Tables[0];
               for(int i=0;i<dt4.Rows.Count;i++)
               {
                   DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                   col.Name = dt4.Rows[i][0].ToString();
                   col.DataPropertyName = dt4.Rows[i][0].ToString();
                   col.HeaderText = dt4.Rows[i][0].ToString();
                   dataGridView1.Columns.Add(col);
               }
                for(int i=0;i<bloquear.Count;i++)
                {
                    for(int x=0;x<dataGridView1.Rows.Count-1;x++)
                    {
                       if(dataGridView1.Rows[x].Cells[0].Value.Equals(bloquear.ElementAt(i)))
                        {
                            for(int c=2;c<dataGridView1.Columns.Count;c++)
                            {
                                dataGridView1.Rows[x].Cells[c] = new DataGridViewTextBoxCell();
                                dataGridView1.Rows[x].Cells[c].ReadOnly = true;
                                
                            }
                            break;
                        }
                    }
                }

                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains("---"))
                        {

                            
                           DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];
                           int k = 0;
                               
                                for (int h = 2; h < dataGridView1.Columns.Count; h++)
                                {
                                    DataGridViewCheckBoxCell cellbox =
                                        (DataGridViewCheckBoxCell) dataGridView1.Rows[i].Cells[h];
                                    if (
                                        cb.Items[k].ToString() !=
                                        dataGridView1.Columns[h].HeaderText)
                                    {
                                        dataGridView1.Rows[i].Cells[h] = new DataGridViewTextBoxCell();
                                        dataGridView1.Rows[i].Cells[h].ReadOnly = true;
                                        //cellbox.ReadOnly = true;

                                    }
                                    else
                                    {

                                        cellbox.ReadOnly = false;
                                        if(k<cb.Items.Count-1)
                                            k++;
                                    }
                                    
                                   
                                
                                
                               
                        }
                    }
                }

          dataGridView1.Columns[1].Visible = false;
               
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
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            nbts = new List<CoordenadaTriangular>();
            try
            {
                int CANTIDAD = 0;
                List<string> GradosNombres = new List<string>();
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    CANTIDAD = dataGridView1.Columns.Count - 2;
                    string valor;
                    DataGridViewComboBoxCell currentCell = (DataGridViewComboBoxCell) dataGridView1.Rows[i].Cells[1];
                    for (int j = 0; j < currentCell.Items.Count; j++)
                    {
                        valor=currentCell.Items[j].ToString();
                     GradosNombres.Add(currentCell.Items[j].ToString());  
                        
                    }
                    CoordenadaTriangular ct =
                          new CoordenadaTriangular(GradosNombres,
                              CANTIDAD,dataGridView1.Rows[i].Cells[0].Value.ToString(),cols);
                    if(dataGridView1.Rows[i].Cells[0].Value.ToString().Contains("---"))
                        nbts.Add(ct);
                   
                    GradosNombres.Clear();
                }

                List<NumeroTriangular> resultado  =new List<NumeroTriangular>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (!dataGridView1.Rows[i].Cells[0].Value.ToString().Contains("---"))
                    {
                        continue;
                    }
                    NumeroTriangular nt = new NumeroTriangular();
                    for (int j = 0; j < indicadores.Count; j++)
                      {

                        for (int k = 0; k < indicadores.ElementAt(j).IndicadoresEspecificos.Count; k++)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == " ---"+
                                indicadores.ElementAt(j).IndicadoresEspecificos.ElementAt(k).descp)
                            {
                               int pos = ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1]).Items.IndexOf(dataGridView1.Rows[i].Cells[1].Value.ToString());

                                for (int w = 0; w < nbts.Count; w++)
                                {
                                    if (nbts[w].Indicador ==
                                        " ---" + indicadores.ElementAt(j).IndicadoresEspecificos.ElementAt(k).descp)
                                    {
                                        nt.x = (indicadores.ElementAt(j).IndicadoresEspecificos.ElementAt(k).peso)/(100)*
                                               (indicadores.ElementAt(j).peso)/(100)*
                                               nbts[w].NumeroBorrosoTriangular.ElementAt(pos).x;
                                        nt.y = (indicadores.ElementAt(j).IndicadoresEspecificos.ElementAt(k).peso)/(100)*
                                               (indicadores.ElementAt(j).peso)/(100)*
                                               nbts[w].NumeroBorrosoTriangular.ElementAt(pos).y;
                                        nt.z = (indicadores.ElementAt(j).IndicadoresEspecificos.ElementAt(k).peso)/(100)*
                                               (indicadores.ElementAt(j).peso)/(100)*
                                               nbts[w].NumeroBorrosoTriangular.ElementAt(pos).z;
                                        resultado.Add(nt);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                  
                }

                NumeroTriangular resultante = new NumeroTriangular();
                resultante.x = 0;
                resultante.y = 0;
                resultante.z = 0;
                for (int i = 0; i < resultado.Count; i++)
                {
                    resultante.x += resultado.ElementAt(i).x;
                    resultante.y += resultado.ElementAt(i).y;
                    resultante.z += resultado.ElementAt(i).z;
                }
                con.Open();
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = con;
                cmd4.CommandType = System.Data.CommandType.StoredProcedure;
                cmd4.CommandText = "SP_INSERT_EVALUACION";
                cmd4.Parameters.Add("@ID_EMPLEADO", SqlDbType.Int).Value = int.Parse(label2.Text);
                cmd4.Parameters.Add("@ID", SqlDbType.Int).Value =int.Parse(id_eval.ToString());
                cmd4.Parameters.Add("@FECHA_EVAL", SqlDbType.Date).Value = DateTime.Now ;
                cmd4.Parameters.Add("@RESUL", SqlDbType.Float).Value = resultante.y;
                cmd4.ExecuteNonQuery();
                cmd4.Dispose();

               
               Grafica gf = new Grafica(cols.Count,resultante.x,resultante.y,resultante.z,cols);
               this.Hide();
               gf.ShowDialog();
               this.Show();
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

        private void gradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void indicadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                          
               
        
        }



        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs anError)
        {
          // MessageBox.Show("Error tipo:  " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
               // bool isChecked = (bool)dataGridView1[e.RowIndex, e.ColumnIndex].EditedFormattedValue;
                if (e.ColumnIndex > 1 && e.ColumnIndex <= dataGridView1.Columns.Count)
                {
                    //if(isChecked)
                    ((DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1]).Value = dataGridView1.Columns[e.ColumnIndex].Name;

                }

            }
        }
    }
}
