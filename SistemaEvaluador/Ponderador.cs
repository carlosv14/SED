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
    public partial class Ponderador : Form
    {
        public SqlConnection con;
        public Ponderador(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            load_CBName();
        }

        private void Ponderador_Load(object sender, EventArgs e)
        {

        }

        public void load_CBName()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                //Llenar cb con Evaluaciones existentes
                DataTable dtEmpleados = new DataTable();
                SqlCommand cmdEvaluacion = new SqlCommand();
                cmdEvaluacion.Connection = con;
                cmdEvaluacion.CommandType = CommandType.Text;
                cmdEvaluacion.CommandText = "SELECT * FROM INFORME_INDICADORES";
                SqlDataAdapter daEmpleados = new SqlDataAdapter(cmdEvaluacion);
                DataSet dsEmpleados = new DataSet();
                daEmpleados.Fill(dsEmpleados);
                dtEmpleados = dsEmpleados.Tables[0];
                CBName.DataSource = dtEmpleados;
                CBName.DisplayMember = "NOMBRE";
                CBName.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();

                if (CBName.Items.Count > 0)
                {
                    CBName.Enabled = true;
                }
                else
                {
                    CBName.Enabled = false;
                }
            }
        }

        private void Ponderar_Button_Click(object sender, EventArgs e)
        {
            //AQUI CODIGO AL DARLE AL BOTON PONDERAR
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
