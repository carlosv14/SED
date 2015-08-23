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
    public partial class EvaluacionNombre : Form
    {
        public string nombreEvaluacion;
        public SqlConnection conn;
        public EvaluacionNombre(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombreEvaluacion = textBox1.Text;
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;
            try
            {

                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_INFORME_INDICADORES";
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = DateTime.Today;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value =nombreEvaluacion;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Se agrego correctamente");

              

                cmd2.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ene)
            {
                MessageBox.Show(ene.ToString());
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }

            this.Close();
        }

        private void EvaluacionNombre_Load(object sender, EventArgs e)
        {

        }
    }
}
