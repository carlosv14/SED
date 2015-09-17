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
    public partial class Login : Form
    {
        private static SqlConnection con = new SqlConnection();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setKey(string user, string pass)
        {
            con.ConnectionString = "Data Source=localhost;Initial Catalog=SISTEMA_EVALUADOR;User Id=" + user + ";Password=" + pass + ";";

        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            //setKey(usuario.Text, contrasena.Text);
            setKey("Josselyn", "12345");
            try
            {
                con.Open();
               con.Close();
                Menu menu = new Menu(con, this);
                this.Hide();
                menu.ShowDialog();
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
