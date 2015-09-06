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
    public partial class GraficoBarras : Form
    {
        private SqlConnection con;
        private int id_empleado;
       
        public GraficoBarras(SqlConnection con, int id_empleado)
        {
            InitializeComponent();
            this.con = con;
            this.id_empleado = id_empleado;
            this.Text=
            "GRAFICA";
            
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
                cmd3.Dispose();
                //el valor para el grafico esta en dt

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


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
            }
        }
    }
}
