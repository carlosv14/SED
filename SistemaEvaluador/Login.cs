using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

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

        private void setKey(string user, string pass)
        {
            con.ConnectionString = "Data Source=localhost;Initial Catalog=SISTEMA_EVALUADOR;User Id="
                + user + ";Password=" + pass + ";";
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            setKey(usuario.Text, contrasena.Text);

            try
            {
                con.Open();
                con.Close();
                Menu menu = new Menu(con, this);
                this.Hide();
                menu.ShowDialog();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            /**catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }**/
        }
    }
}
