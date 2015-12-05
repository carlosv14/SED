﻿
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

        private void Departamentos_Click_1(object sender, EventArgs e)
        {
            limpiar();
            Departamentos deptos = new Departamentos(con, false);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            limpiar();
            Departamentos deptos = new Departamentos(con, false);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            limpiar();
            Departamentos deptos = new Departamentos(con, true);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            limpiar();
            Departamentos deptos = new Departamentos(con, false);
            tabStrip1.MdiForm = this;
            deptos.MdiParent = this;
            deptos.Show();
        }

        private void Agregargestion_Click(object sender, EventArgs e)
        {
            limpiar();
            GestiondePersonal gp = new GestiondePersonal(con, false);
            tabStrip1.MdiForm = this;
            gp.MdiParent = this;
            gp.Show();
        }

        private void indiadores_Click(object sender, EventArgs e)
        {
            limpiar();
            EmpleadoNombre emp = new EmpleadoNombre(con);
            emp.label1.Visible = false;
            emp.ShowDialog();
            int id_eval = emp.id_eval;
            limpiar();
            Editar_Indicadores ei = new Editar_Indicadores(con, id_eval);
            tabStrip1.MdiForm = this;
            ei.MdiParent = this;
            ei.Show();
        }

        private void Modificargestion_Click(object sender, EventArgs e)
        {
            limpiar();
            GestiondePersonal gp = new GestiondePersonal(con, true);
            tabStrip1.MdiForm = this;
            gp.MdiParent = this;
            gp.Show();
        }

        private void Eliminargestion_Click(object sender, EventArgs e)
        {
            limpiar();
            GestiondePersonal gp = new GestiondePersonal(con, true);
            tabStrip1.MdiForm = this;
            gp.MdiParent = this;
            gp.Show();
        }        

        private void grados_Click(object sender, EventArgs e)
        {
            limpiar();
            EmpleadoNombre emp = new EmpleadoNombre(con);
            emp.label1.Visible = false;
            emp.ShowDialog();
            int id_eval = emp.id_eval;
            limpiar();
            EditarGrados gr = new EditarGrados(con, id_eval);
            tabStrip1.MdiForm = this;
            gr.MdiParent = this;
            gr.Show();
            //gr.ShowDialog();
        }

        private void limpiar()
        {
            Colorcito c = new Colorcito();
            tabStrip1.MdiForm = this;
            c.MdiParent = this;
            c.Show();
        }

        private void evaluacion_Click(object sender, EventArgs e)
        {
            limpiar();
            Evaluacion eva = new Evaluacion(con);
            tabStrip1.MdiForm = this;
            eva.MdiParent = this;
            eva.Show();
        }

        private void evaluador_Click(object sender, EventArgs e)
        {
            limpiar();
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

        private void ribbonBar8_ItemClick(object sender, EventArgs e)
        {
            limpiar();
            Individual ind = new Individual(con);
            tabStrip1.MdiForm = this;
            ind.MdiParent = this;
            ind.Show();
        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            limpiar();
            EvaluacionGrupal gru = new EvaluacionGrupal(con);
            tabStrip1.MdiForm = this;
            gru.MdiParent = this;
            gru.Show();
        }
        
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //Console.WriteLine("Addio!");
                con.Close();
                this.Dispose();
                this.Close();
                login.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
