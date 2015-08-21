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
    public partial class Indicadores : Form
    {
        SqlConnection con;
        public Indicadores()
        {
            InitializeComponent();
            this.con = con;
        }

        private void GeneralRadioB_CheckedChanged(object sender, EventArgs e)
        {
            if (GeneralRadioB.Checked)
                indicadoresEspecificos.Enabled = true;
        }

        private void EspecificoRadioB_CheckedChanged(object sender, EventArgs e)
        {
            if (EspecificoRadioB.Checked)
                indicadoresEspecificos.Enabled = false;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_INDICADORES";
                cmd.Parameters.Add("@ID_INF", SqlDbType.Int).Value = (Evaluacion.SelectedIndex + 1);
                if (EspecificoRadioB.Checked)
                {
                    cmd.Parameters.Add("@INDICADORES_ID", SqlDbType.Int).Value = (Evaluacion.SelectedIndex + 1);
                    cmd.Parameters.Add("@ID_GEN", SqlDbType.Int).Value = (indicadoresEspecificos.SelectedIndex + 1);
                }
                else
                {
                    cmd.Parameters.Add("@INDICADORES_ID", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@ID_GEN", SqlDbType.Int).Value = DBNull.Value;

                }
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Nombre.Text;
                cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = float.Parse(Peso.Text);
                cmd.Parameters.Add("@PUNTAJE", SqlDbType.Int).Value = 0;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Se agrego correctamente");
                this.Close();
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

        private void Indicadores_Load(object sender, EventArgs e)
        {
            GeneralRadioB.Checked = true;
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM INFORME_INDICADORES";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                Evaluacion.DataSource = dt;
                Evaluacion.DisplayMember = "NOMBRE";




                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT * FROM INDICADORES";
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dt2 = ds2.Tables[0];
                indicadoresEspecificos.DataSource = dt;
                indicadoresEspecificos.DisplayMember = "NOMBRE";



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
