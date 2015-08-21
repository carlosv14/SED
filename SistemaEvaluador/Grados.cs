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
    public partial class Gradosindicadores : Form
    {
        private SqlConnection con = new SqlConnection();
        public Gradosindicadores(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;

            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT *FROM INDICADORES";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                Indicador.DataSource = dt;
                Indicador.DisplayMember = "NOMBRE";



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

        private void Grados_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {


                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_GRADO";

                cmd.Parameters.Add("@ID_IND", SqlDbType.Int).Value = Indicador.SelectedIndex + 1;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Descripcion.Text;
                cmd.Parameters.Add("@Ri", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                cmd.Parameters.Add("@Rf", SqlDbType.Int).Value = int.Parse(textBox2.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Se Agrego Exitosamente");
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
