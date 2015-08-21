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
    public partial class Departamentos : Form
    {
        SqlConnection con;
        int buttonx = 424;
        int buttony = 148;
        public bool modificar = false;
        public Departamentos(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void Departamentos_Load(object sender, EventArgs e)
        {
            Agregar.Visible = false;
            button1.Visible = false;
            this.Size = new Size(774, 585);
            dataGridView1.Visible = false;
            if (modificar)
            {
                button1.Location = new Point(buttonx, buttony);
                button1.Visible = true;
                this.Size = new Size(774, 585);
                this.Refresh();
                dataGridView1.Visible = true;
            }
            else
            {
                Agregar.Location = new Point(buttonx, buttony);
                Agregar.Visible = true;
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_DEPTO";
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Departamento.Text;
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
    }
}
