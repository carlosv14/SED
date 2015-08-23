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
        public List<Grados_Arr> grados;
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
            if (float.Parse(Peso.Text)>pesos)
            {
                MessageBox.Show("Excede el peso disponible");
                return;
            }
            label3.Text = "(Peso disponible por agregar " + (pesos -= float.Parse(Peso.Text)) + "%)";
            Grados_Arr grado = new Grados_Arr(Nombre.Text, float.Parse(Peso.Text));
            grados.Add(grado);
            grados.Sort();
            listView1.Items.Clear();
            foreach(Grados_Arr grad in grados)
            {
                ListViewItem item = new ListViewItem(grad.descp);
                item.SubItems.Add(grad.peso.ToString());
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
