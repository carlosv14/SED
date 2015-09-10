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
    public partial class GraficaDepto : Form
    {
        int id_depto;
        SqlConnection con;
        public GraficaDepto(SqlConnection con, int id_Depto)
        {
            InitializeComponent();
            this.id_depto = id_Depto;
            this.con = con;
        }

        private void GraficaDepto_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = "select ev.fecha_evaluacion from EVALUACION as ev, DEPARTAMENTOS as d, EMPLEADOS as e where e.ID_DEPTO=d.ID_DEPTO and e.ID_EMPLEADO=ev.ID_EMPLEADO and d.ID_DEPTO="+id_depto+" GROUP BY ev.fecha_evaluacion";
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    comboBox1.Items.Add(dt3.Rows[j]["fecha_evaluacion"].ToString());
                }

                //comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
               //comboBox1.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            try
            {

                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
cmd3.CommandText = "SELECT E.NOMBRES, EV.RESULTADO FROM EMPLEADOS AS E, DEPARTAMENTOS AS D, EVALUACION AS EV WHERE D.ID_DEPTO=E.ID_DEPTO AND E.ID_EMPLEADO=EV.ID_EMPLEADO AND D.ID_DEPTO="+id_depto+" AND EV.fecha_evaluacion='2015-09-10'";
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];
                List<double> valores = new List<double>();
                for (int h = 0; h < dt3.Rows.Count; h++)
                    valores.Add(Double.Parse(dt3.Rows[h]["RESULTADO"].ToString()));


                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add("draw");
                chart1.ChartAreas["draw"].AxisY.Minimum = 0;
                chart1.ChartAreas["draw"].AxisY.Maximum = 1;
                chart1.ChartAreas["draw"].AxisY.Interval = (double)1 / dt3.Rows.Count;
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
                for (int x = 0; x < valores.Count; x++)
                {
                    chart1.Series["MyFunc"].Points.AddXY(x + 1, Math.Round(valores.ElementAt(x), 2));
                }

                for (int i = 0; i < valores.Count; i++)
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(i + 1, i + 2, dt3.Rows[i][0].ToString());



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
