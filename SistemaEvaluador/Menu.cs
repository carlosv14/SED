
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        SqlConnection con;
        Login login;
         
        
     
        public Menu(SqlConnection con, Login login)
        {
            InitializeComponent();
            this.Enabled = true;
            this.con = con;
         
            this.login = login;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabStrip1_Click(object sender, EventArgs e)
        {

        }

        private void Departamentos_Click_1(object sender, EventArgs e)
        {
            Departamentos deptos = new Departamentos(con,false);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Departamentos deptos = new Departamentos(con,false);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Departamentos deptos = new Departamentos(con,true);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Departamentos deptos = new Departamentos(con,false);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();
        }

        private void Agregargestion_Click(object sender, EventArgs e)
        {
            GestiondePersonal gp = new GestiondePersonal(con,false);
            tabStrip1.MdiForm = this;
            gp.MdiParent = this;
            gp.Show();
        }

        private void indiadores_Click(object sender, EventArgs e)
        {
            EmpleadoNombre emp = new EmpleadoNombre(con);
            emp.label1.Visible = false;
            emp.textBox1.Visible = false;
            emp.ShowDialog();
            int id_eval = emp.id_eval;
            Editar_Indicadores ei = new Editar_Indicadores(con, id_eval);
            tabStrip1.MdiForm = this;
            ei.MdiParent = this;
            ei.Show();
            
        }

        private void Modificargestion_Click(object sender, EventArgs e)
        {
            GestiondePersonal gp = new GestiondePersonal(con,true);
            tabStrip1.MdiForm = this;
            gp.MdiParent = this;
            gp.Show();
        }

        private void Eliminargestion_Click(object sender, EventArgs e)
        {
            GestiondePersonal gp = new GestiondePersonal(con,true);
            tabStrip1.MdiForm = this;
            gp.MdiParent = this;
            gp.Show();
        }

        private void terminosyresultados_Click(object sender, EventArgs e)
        {
            Terminos_y_resultado tr = new Terminos_y_resultado();
            tabStrip1.MdiForm = this;
            tr.MdiParent = this;
            tr.Show();
        }

        private void grados_Click(object sender, EventArgs e)
        {
            EmpleadoNombre emp = new EmpleadoNombre(con);
            emp.label1.Visible = false;
            emp.textBox1.Visible = false;
            emp.ShowDialog();
            int id_eval = emp.id_eval;
            EditarGrados gr = new EditarGrados(con, id_eval);
            tabStrip1.MdiForm = this;
            gr.MdiParent = this;
            gr.Show();
            //gr.ShowDialog();


        }

        private void evaluacion_Click(object sender, EventArgs e)
        {
            Evaluacion eva = new Evaluacion(con);
            tabStrip1.MdiForm = this;
            eva.MdiParent = this;
            eva.Show();

          

          

            
        }

        private void evaluador_Click(object sender, EventArgs e)
        {
            Evaluador i = new Evaluador(con);
            tabStrip1.MdiForm = this;
            i.MdiParent = this;
            i.Show();
        }

        private void ribbonPanel4_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
            Reportes r = new Reportes(con);
            tabStrip1.MdiForm = this;
            r.MdiParent = this;
            r.Show();
            
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar8_ItemClick(object sender, EventArgs e)
        {
            Individual ind = new Individual(con);
            tabStrip1.MdiForm = this;
            ind.MdiParent = this;
            ind.Show();
        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            EvaluacionGrupal gru = new EvaluacionGrupal(con);
            tabStrip1.MdiForm = this;
            gru.MdiParent = this;
            gru.Show();
        }
    }
}
