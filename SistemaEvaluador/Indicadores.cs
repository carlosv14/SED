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
    public partial class Indicadores : Form
    {
     
        public List<Indicadores_Arr>indicadoresEspecificos;
        private float peso = 100;
        private int indicador = 0;
        private bool indEspecificos;
        public Indicadores()
        {
            InitializeComponent();

          indicadoresEspecificos=new List<Indicadores_Arr>();
          indEspecificos = false;
        }

        private void EspecificoRadioB_CheckedChanged(object sender, EventArgs e)
        {
            //if (EspecificoRadioB.Checked)
                //indicadoresEspecificos.Enabled = false;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
           /* 
            * Guardar Indicadores en la base de datos
            * SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_INDICADOR";
                //cmd.Parameters.Add("@ID", SqlDbType.Int).Value = (Evaluacion.SelectedIndex + 1);
                if (EspecificoRadioB.Checked)
                {
                   // cmd.Parameters.Add("@INDICADORES_ID", SqlDbType.Int).Value = (Evaluacion.SelectedIndex + 1);
                    cmd.Parameters.Add("@ID_GEN", SqlDbType.Int).Value = (indicadoresEspecificos.SelectedIndex + 1);
                }
                else
                {
                    cmd.Parameters.Add("@INDICADORES_ID", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@ID_GEN", SqlDbType.Int).Value = DBNull.Value;

                }
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Nombre.Text;
                cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = float.Parse(Peso.Text);
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
            }*/
            if (float.Parse(Peso.Text) > peso)
                return;
            Indicadores_Arr ind = new Indicadores_Arr(Nombre.Text, float.Parse(Peso.Text));

            if (!indEspecificos)
            {
                indicadoresEspecificos.Add(ind);
                indicadoresEspecificos.Sort();
                listView1.Items.Clear();
                foreach (Indicadores_Arr id in indicadoresEspecificos)
                {
                    ListViewItem item = new ListViewItem(id.descp);
                    item.SubItems.Add(id.peso.ToString());
                    listView1.Items.Add(item);
                }

                label2.Text = "(Peso disponible " + (peso -= float.Parse(Peso.Text)) + "%)";

                if (peso == 0)
                {
                    button1.Enabled = true;
                    agregar.Enabled = false;
                    indEspecificos = true;
                }
            }
            else
            {
                indicadoresEspecificos.ElementAt(indicador).IndicadoresEspecificos.Add(ind);
                indicadoresEspecificos.ElementAt(indicador).IndicadoresEspecificos.Sort();
                listView1.Items.Clear();
                foreach (Indicadores_Arr id in indicadoresEspecificos.ElementAt(indicador).IndicadoresEspecificos)
                {
                    ListViewItem item = new ListViewItem(id.descp);
                    item.SubItems.Add(id.peso.ToString());
                    listView1.Items.Add(item);
                }

                label2.Text = "(Peso disponible " + (peso -= float.Parse(Peso.Text)) + "%)";

                if (peso == 0)
                {
                    button1.Enabled = true;
                    agregar.Enabled = false;
                    indicador++;
                }
            }
    
        }

        private void Indicadores_Load(object sender, EventArgs e)
        {
            //GeneralRadioB.Checked = true;
          //  SqlCommand cmd = null;
            //try
            //{
                //con.Open();
                //cmd = new SqlCommand();
                //cmd.Connection = con;
                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "SELECT * FROM INFORME_INDICADORES";
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //dt = ds.Tables[0];
                //Evaluacion.DataSource = dt;
                //Evaluacion.DisplayMember = "NOMBRE";

                /*SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT * FROM INDICADORES";
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dt2 = ds2.Tables[0];
                indicadoresEspecificos.DataSource = dt2;
                indicadoresEspecificos.DisplayMember = "NOMBRE";



            }
            catch (Exception ene)
            {
                MessageBox.Show(ene.ToString());
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (indicador == indicadoresEspecificos.Count())
            {
                this.Close();
            }
            else
            {
                peso = 100;
                agregar.Enabled = true;
                button1.Enabled = false;
                label3.Text = "Especificos " + indicadoresEspecificos.ElementAt(indicador).descp;
                label2.Text = "(Peso disponible " + peso + "%)";
                listView1.Items.Clear();

            }
        }
    }
}
