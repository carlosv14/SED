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
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaEvaluador
{
    public partial class GraficoBarras : Form
    {
        private SqlConnection con;
        private int id_empleado;
        private int evaluacion;
        private List<int> idevals;
        private List<string> grados;  
        public GraficoBarras(SqlConnection con, int id_empleado)
        {
            InitializeComponent();
            this.con = con;
            grados = new List<string>();
            evaluacion = 0;
            this.id_empleado = id_empleado;
            this.Text=
            "GRAFICA";
            idevals = new List<int>();
            
        }

        private void GraficoBarras_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            try
            {
                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = "SELECT * from EVALUACION where ID_EMPLEADO= "+id_empleado;
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    idevals.Add(int.Parse( dt3.Rows[i]["ID"].ToString()));
                }
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    comboBox1.Items.Add(dt3.Rows[j]["fecha_evaluacion"].ToString());
                }

                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                datosGrafico();
                //comboBox1.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datosGrafico()
        {
            double valor = 0;
            try
            {
                con.Open();
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                cmd3.CommandText = "sp_employee_results";
                cmd3.Parameters.Add("@eval_date", SqlDbType.Date).Value =
                    DateTime.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));

                cmd3.Parameters.Add("@id_empleado", SqlDbType.Int).Value = id_empleado;
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];

                valor = (double) (float.Parse(dt3.Rows[0][0].ToString()));
                cmd3.Dispose();

                grados.Clear();
                SqlCommand cmd = null;
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText =
                    "SELECT DISTINCT g.NOMBRE, g.ID_IND,g.VALOR FROM GRADOS g INNER JOIN EVALUACION e on g.ID = e.ID WHERE e.ID = " +
                    idevals.ElementAt(comboBox1.SelectedIndex) +" ORDER BY(g.VALOR)";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                int id_ind = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id_ind = int.Parse(dt.Rows[0][1].ToString());
                    if (id_ind == int.Parse(dt.Rows[i][1].ToString()))
                        grados.Add(dt.Rows[i][0].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(con.State!=ConnectionState.Closed)
                    con.Close();
            }
            double[] xData = new double[] { 1 };
            double[] yData = new double[] {Math.Round(valor,2)};
            //Horizontal bar chart
            //Create a chart area and add it to the chart
            ChartArea area = new ChartArea("First");
            
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 1;
            area.AxisY.Interval = (double)1/grados.Count;
            area.AxisX.Maximum = 2;
            area.AxisX.Minimum = 0;
      
            area.Position = new ElementPosition(0,0,100,100);
            
           
            chart1.ChartAreas.Add(area);

           //Create a series using the data
            Series barSeries = new Series();
           
         

            barSeries.Points.DataBindXY(xData, yData);
            //Set the chart type, Bar; horizontal bars
            barSeries.ChartType = SeriesChartType.Bar;
            //Assign it to the required area
        
            //Add the series to the chart
            chart1.Series.Add(barSeries);

            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0]["BarLabelStyle"] = "Center";
            //chart1.Series[0].Points[0].label = "First Point";
            //chart1.Series[0].Points[1].AxisLabel = "Second Point";

           
            for(int i = 0; i<grados.Count;i++)
            chart1.ChartAreas[0].AxisY.CustomLabels.Add((Math.Round((double)i/grados.Count,2)), Math.Round((double)(i+1)/ grados.Count, 2), grados.ElementAt(i));
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = false;
                button1.Visible = true;
                try
                {
                  
                    DataTable dt3 = new DataTable();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = con;
                    cmd3.CommandType = System.Data.CommandType.Text;

                    cmd3.CommandText = "SELECT resultado from EVALUACION WHERE ID_EMPLEADO ="+ id_empleado;
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    dt3 = ds3.Tables[0];
                    List<double> valores=  new List<double>();
                    for(int h = 0; h<dt3.Rows.Count;h++)
                            valores.Add(Double.Parse(dt3.Rows[h]["resultado"].ToString()));
                   

                    chart1.Series.Clear();
                    chart1.ChartAreas.Clear();
                    chart1.ChartAreas.Add("draw");
                    chart1.ChartAreas["draw"].AxisY.Minimum = 0;
                    chart1.ChartAreas["draw"].AxisY.Maximum =1;
                    chart1.ChartAreas["draw"].AxisY.Interval = (double)1/grados.Count;
                    chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
                    chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas["draw"].AxisX.Minimum = 0;
                    chart1.ChartAreas["draw"].AxisX.Interval = 1;
                    chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
                    chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                    chart1.ChartAreas["draw"].BackColor = Color.White;

                   
                    chart1.Series.Add("MyFunc");
                         
                    chart1.Series["MyFunc"].ChartType = SeriesChartType.Line;
                 
                    chart1.Series["MyFunc"].Color = Color.LightGreen;
                    chart1.Series["MyFunc"].BorderWidth = 3;
                    chart1.Series["MyFunc"].IsValueShownAsLabel = true;
                    for (int x = 0; x < valores.Count; x ++)
                    {
                        chart1.Series["MyFunc"].Points.AddXY(x+1,Math.Round(valores.ElementAt(x),2));
                    }

                    for (int i = 0; i < valores.Count; i++)
                        chart1.ChartAreas[0].AxisX.CustomLabels.Add(i+1, i+2,comboBox1.Items[i].ToString().Split(' ')[0]);



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                comboBox1.Enabled = true;
                button1.Visible = false;
                datosGrafico();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            datosGrafico();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Meta met = new Meta(con);
            met.ShowDialog();
        }
    }
}
