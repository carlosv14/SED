using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Individual : Form
    {
        private SqlConnection con;
        private int id_empleado;
        private List<int> id_Empleados; 
        public Individual(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            SqlCommand cmd = null;
            try
            {
                con.Open();
                id_Empleados = new List<int>();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM DEPARTAMENTOS";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "NOMBRE";
              
                
                DataTable dt1 = new DataTable();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "SELECT CONCAT(NOMBRES,' ',APELLIDOS) as NOMBRE, ID_EMPLEADO AS NOMBRE FROM EMPLEADOS WHERE ID_DEPTO = "+ (comboBox1.SelectedIndex+1);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[1].Visible = false;
                id_Empleados.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    id_Empleados.Add(int.Parse(dt1.Rows[0][1].ToString()));
                }


            }
            catch (Exception ene)
            {
                MessageBox.Show(ene.ToString());
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            
               
            }

        private void Individual_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           id_empleado=id_Empleados.ElementAt(e.RowIndex );
            GraficoBarras gb  = new GraficoBarras(con,id_empleado);
            gb.ShowDialog();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            DataTable dt1 = new DataTable();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "SELECT CONCAT(NOMBRES,' ',APELLIDOS) as NOMBRE, ID_EMPLEADO AS NOMBRE FROM EMPLEADOS WHERE ID_DEPTO = " + (comboBox1.SelectedIndex + 1);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];
                dataGridView1.DataSource = dt1;
               dataGridView1.Columns[1].Visible = true;
                id_Empleados.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    id_Empleados.Add(int.Parse(dt1.Rows[0][1].ToString()));
                }



                dataGridView1.DataSource = dt1;


        }
            catch (Exception ene)
            {
                MessageBox.Show(ene.ToString());
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

        }
    }
}
