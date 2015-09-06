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
            try
            {
                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = "SELECT * from EVALUACION";
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    idevals.Add(int.Parse( dt3.Rows[i]["ID"].ToString()));
                }
                comboBox1.DataSource = dt3;
                comboBox1.DisplayMember = "fecha_evaluacion";
              
                //comboBox1.ValueMember = "ID";
                datosGrafico();
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

                SqlCommand cmd = null;
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT g.NOMBRE, g.ID_IND FROM GRADOS g INNER JOIN EVALUACION e on g.ID = e.ID WHERE e.ID = " + idevals.ElementAt(comboBox1.SelectedIndex);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                int id_ind = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id_ind = int.Parse(dt.Rows[0][1].ToString());
                    if(id_ind == int.Parse(dt.Rows[i][1].ToString()))
                        grados.Add(dt.Rows[i][0].ToString());
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
            double[] xData = new double[] { 1 };
            double[] yData = new double[] {valor};
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
            for (int i = 0; i < barSeries.Points.Count; i++)
            {
                barSeries.Points[i].AxisLabel = "by";
            }
         
            barSeries.Points.DataBindXY(xData, yData);
            //Set the chart type, Bar; horizontal bars
            barSeries.ChartType = SeriesChartType.Bar;
            //Assign it to the required area
            barSeries.ChartArea = "First";
            //Add the series to the chart
            chart1.Series.Add(barSeries);
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = false;

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
                  
                    //el valor para el grafico esta en dt

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                comboBox1.Enabled = true;
                datosGrafico();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

          
        }
    }
}
