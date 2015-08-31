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
    public partial class EditarGrados : Form
    {
        SqlConnection con;
        int id_eva;
        public EditarGrados(SqlConnection con, int id_eva)
        {
            InitializeComponent();
            this.con = con;
            this.id_eva = id_eva;
        }

        private void EditarGrados_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "select NOMBRE from GRADOS where ID="+id_eva+" group by NOMBRE;";
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

                //this.Close();


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
