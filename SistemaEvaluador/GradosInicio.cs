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
    public partial class GradosInicio : Form
    {
        List<Grados_Arr> grados;
        float pesos = 100;
        public GradosInicio()
        {
            InitializeComponent();
            grados = new List<Grados_Arr>();
        }

        private void GradosInicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grados_Arr grado = new Grados_Arr(Nombre.Text, float.Parse(Peso.Text));
            grados.Add(grado);
            IEnumerable<Grados_Arr> temp = grados.OrderByDescending(x=>x.peso);
            listView1.Items.Clear();
            foreach(Grados_Arr grad in temp)
            {
                listView1.Items.Add(grad.descp);
            }
        }
    }
}
