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

        public void check_cEvaluacion()
        {

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                //Llenar cb con Evaluaciones existentes
                DataTable dtEmpleados = new DataTable();
                SqlCommand cmdEvaluacion = new SqlCommand();
                cmdEvaluacion.Connection = conn;
                cmdEvaluacion.CommandType = CommandType.Text;
                cmdEvaluacion.CommandText = "SELECT * FROM INFORME_INDICADORES";
                SqlDataAdapter daEmpleados = new SqlDataAdapter(cmdEvaluacion);
                DataSet dsEmpleados = new DataSet();
                daEmpleados.Fill(dsEmpleados);
                dtEmpleados = dsEmpleados.Tables[0];
                c_evaluacion.DataSource = dtEmpleados;
                c_evaluacion.DisplayMember = "NOMBRE";
                c_evaluacion.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                
                if (c_evaluacion.Items.Count > 0)
                {
                    c_evaluacion.Enabled = true;
                    delete_button.Enabled = true;
                }
                else
                {
                    c_evaluacion.Enabled = false;
                    c_evaluacion.Enabled = false;
                }
            }
        }

        public EvaluacionNombre(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.exiting = false;

            check_cEvaluacion();
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

        private void delete_button_Click(object sender, EventArgs e)
        {
            //AQUI VA LÓGICA BOTON BORRAR
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                //Llenar cb con Evaluaciones existentes
                //SP_BORRAR_EVALUACION_BASE
                SqlCommand cmd_delete = new SqlCommand();
                cmd_delete.Connection = conn;
                cmd_delete.CommandType = System.Data.CommandType.StoredProcedure;
                cmd_delete.CommandText = "SP_BORRAR_EVALUACION_BASE";
                cmd_delete.Parameters.Add("@EvaluacionID", SqlDbType.Int).Value = int.Parse(c_evaluacion.SelectedValue.ToString());
                cmd_delete.ExecuteNonQuery();
                cmd_delete.Dispose();

                MessageBox.Show("Se ha eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                check_cEvaluacion();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void c_evaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
