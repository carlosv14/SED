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
        public bool exiting;

        public EvaluacionNombre(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.exiting = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {           
            nombreEvaluacion = textBox1.Text;
            SqlCommand cmd = null;
            try
            {

                if (conn.State != ConnectionState.Open)
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
        
        private void bVolver_Click(object sender, EventArgs e)
        {
            this.exiting = true;
            this.Close();
        }
    }
}
