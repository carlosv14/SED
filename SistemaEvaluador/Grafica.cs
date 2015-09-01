using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Grafica : Form
    {
        private float resx1;
        private float resx2;
        private float resx3;
        private float inx;
        private bool solucion;
        private Boolean reverse;

        private List<float> puntas;
        Timer timer = new Timer();
        private List<string> grados; 
        private int i = 0;
        private bool lastLine;
        private int cantidadGrados;
        private List<Label> labels; 
        public Grafica(int cantidadGrados, float x, float y, float z, List<string> grados)
        {
            InitializeComponent();
            resx1 = x;
            solucion = false;
            labels = new List<Label>();
            this.grados = grados;
            //for (int i = 0; i < grados.Count; i++)
            //{
            //    Label l = new Label();
            //    l.Text = grados[i];
            //    if(i == 0)
            //    l.Location = new Point(i/(grados.Count-1)*pictureBox1.Size.Width,0);
            //    else
            //        l.Location = new Point(i / (grados.Count - 1) * pictureBox1.Size.Width-45, 0);
            //    l.Size = new Size(55,50);
            //    this.Controls.Add(l);
            //}
            puntas = new List<float>();
            label1.BackColor = Color.Red;
            label2.BackColor = Color.Blue;
            label3.BackColor = Color.Green;
            label4.BackColor = Color.Yellow;
            label5.BackColor = Color.Orange;
            label6.BackColor = Color.Purple;
            label7.BackColor = Color.DeepPink;
            label8.BackColor = Color.Crimson;
            label9.BackColor= Color.Coral;
            label10.BackColor=Color.DarkGoldenrod;
            label11.BackColor = Color.Brown;




            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            for (int i = 0; i < labels.Count; i++)
            {
                labels.ElementAt(i).Visible = false;
            }

            for (int j = 0; j < grados.Count; j++)
            {
                labels.ElementAt(j).Visible = true;
                labels.ElementAt(j).Text = grados[j];
                labels.ElementAt(j).Width = 55;
            }
            resx2 = y;
            resx3 = z;
            reverse = false;
            this.cantidadGrados = cantidadGrados;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 300;
            timer.Enabled = false;
            inx = 0;
            lastLine = false;


        }
        private void picturebox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs p)
        {
            int inz = i;
            if (reverse)
                inz += 2;

            Pen cPen = null;
            switch (inz)
            {
                case 0:
                    cPen = new Pen(Color.Red, 2f);
                    break;
                case 2:
                    cPen = new Pen(Color.Blue, 2f);
                    break;
                case 4:
                    cPen = new Pen(Color.Green, 2f);
                    break;
                case 6:
                    cPen = new Pen(Color.Yellow, 2f);
                    break;
                case 8:
                    cPen = new Pen(Color.Orange, 2f);
                    break;
                case 10:
                    cPen = new Pen(Color.Purple, 2f);
                    break;
                case 12:
                    cPen = new Pen(Color.DeepPink, 2f);
                    break;
                case 14:
                    cPen = new Pen(Color.Crimson, 2f);
                    break;
                case 16:
                    cPen = new Pen(Color.Coral, 2f);
                    break;
                case 18:
                    cPen = new Pen(Color.DarkGoldenrod, 2f);
                    break;
                case 20:
                    cPen = new Pen(Color.Brown, 2f);
                    break;

                default:
                    cPen = new Pen(Color.PowderBlue, 2f);
                    break;
            }
            Graphics e = pictureBox1.CreateGraphics();
            IList<PointF> P;
            if (lastLine)
            {
                e.DrawLine(
                    cPen,
                     new PointF(inx * pictureBox1.Size.Width, 0),
                     new PointF(inx * pictureBox1.Size.Width, pictureBox1.Size.Height ));
                lastLine = false;
                solucion = true;
                return;
            }
            if (solucion)
            {
                List<float>distancias = new List<float>();
                for (int j = 0; j < puntas.Count; j++)
                {
                    distancias.Add(Math.Abs(resx2 - puntas.ElementAt(j)));
                }
                string nearest = "";
                distancias.Sort();
                for (int w = 0; w < grados.Count; w++)
                {
                    float valor = (float)w / (grados.Count-1);
                    if (valor - distancias.ElementAt(0) == resx2 ||
                        valor + distancias.ElementAt(0) == resx2)
                    {
                        nearest = grados[w];
                        break;
                    }
                }
               Label l = new Label();
                l.Text =  nearest+ " "+resx2.ToString();
                l.Left =(int)(resx2*pictureBox1.Size.Width-45);
               this.Controls.Add(l);
                e.DrawLine(
                    new Pen(Color.Black, 3f),
                    new PointF(resx1 * pictureBox1.Size.Width, pictureBox1.Size.Height ), new PointF(resx2 * pictureBox1.Size.Width, 0));
                e.DrawLine(
                        new Pen(Color.Black, 3f),
                        new PointF(resx2 * pictureBox1.Size.Width, 0), new PointF(resx3 * pictureBox1.Size.Width, pictureBox1.Size.Height));
                timer.Enabled = false;
                return;
            }
            if (!reverse)
            {
                P = calcular_puntos(cantidadGrados);

            }
            else
            {
                P = calcular_puntos_reverse(cantidadGrados);
            }

            e.DrawLine(
                    cPen,
                    new PointF(P.ElementAt(i).X * pictureBox1.Size.Width, P.ElementAt(i).Y * pictureBox1.Size.Height ), new PointF((float)P.ElementAt(i + 1).X * pictureBox1.Size.Width, P.ElementAt(i + 1).Y * pictureBox1.Size.Height ));


            i += 2;
            if (i >= P.Count)
            {
                if (reverse)
                {

                    lastLine = true;
                    i -= 2;
                    return;

                }
                inx = (float)P.ElementAt(P.Count - 1).X;
                reverse = true;

                i = 0;
            }




        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.DrawLine(
            new Pen(Color.Red, 2f),
            new Point(0, 0),
            new Point(0, pictureBox1.Size.Height));
            e.Graphics.DrawLine(
               new Pen(Color.Black, 2f),
               new Point(0, pictureBox1.Size.Height),
               new Point(pictureBox1.Size.Width, pictureBox1.Size.Height));
            timer.Enabled = true;

        }

        private IList<PointF> calcular_puntos(int n_indicadores)
        {
            IList<PointF> puntos = new List<PointF>();

            for (int i = 0; i < n_indicadores - 1; i++)
            {

                if (i == 0)
                {
                    puntos.Add(new PointF(0, 0));
                }
                else
                {
                    puntos.Add(new PointF((float)i /(n_indicadores-1), 0));
                }
                puntos.Add(new PointF((float)(i + 1) / (n_indicadores-1), 1));
               
            }
           
            return puntos;
        }

        private IList<PointF> calcular_puntos_reverse(int n_indicadores)
        {
            IList<PointF> puntos = new List<PointF>();
            puntas.Add(0);
            for (int i = 1; i < n_indicadores; i++)
            {

                puntos.Add(new PointF((float)i / (n_indicadores-1), 0));
               
                    if (puntas.ElementAt(puntas.Count-1) != (float)i / (n_indicadores - 1)) 
                      puntas.Add((float) i/(n_indicadores - 1));
                
                puntos.Add(new PointF((float)(i - 1) / (n_indicadores-1), 1));

            }
            return puntos;
        }


        private void Grafica_Load(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                // Draw next line and...

                g.DrawLine(new Pen(Color.Red, 2f), new Point(0, 0), new Point(pictureBox1.Size.Width, pictureBox1.Size.Height));

            }
        }


    }
}
