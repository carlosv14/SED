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
    public partial class Evaluacion : Form
    {
        Indicadores indicador;
        Gradosindicadores grados;
        private SqlConnection con;
        public Evaluacion(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            indicador = new Indicadores(con);
            grados = new Gradosindicadores(con);
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indicador.ShowDialog();
        }

        private void Evaluacion_Load(object sender, EventArgs e)
        {
            EvaluacionNombre Evanom= new EvaluacionNombre();
            Evanom.ShowDialog();
            Nombre.Text = Evanom.nombreEvaluacion;
            Fecha.Text = DateTime.Today.ToString();

            GradosInicio grad = new GradosInicio();
            grad.ShowDialog();
        }
    }
}
