using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Dependientes : Form
    {
        public List<DependientesEmpleados> hijos;
        
        public Dependientes()
        {
            InitializeComponent();
            hijos = new List<DependientesEmpleados>();
        }

        private void Dependientes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DependientesEmpleados depen = new DependientesEmpleados(nombredependiente.Text, textBox1.Text);
            hijos.Add(depen);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
