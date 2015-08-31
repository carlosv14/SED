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
    public partial class EmpleadoNombre : Form
    {
        public string id;
        SqlConnection con;
       public  int id_eval;
        public EmpleadoNombre(  SqlConnection con)
        {
            this.con = con;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            id_eval = int.Parse(comboBox1.SelectedValue.ToString());
            this.Close();
        }

        private void EmpleadoNombre_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = "SELECT * from INFORME_INDICADORES";
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];

                comboBox1.DataSource = dt3;
                comboBox1.DisplayMember = "NOMBRE";
                comboBox1.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
