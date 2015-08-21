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
    public partial class GestiondePersonal : Form
    {
        SqlConnection con;
        private List<DependientesEmpleados> hijos;
        public GestiondePersonal(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dependientes depen = new Dependientes();
            depen.ShowDialog();
            hijos = depen.hijos;
        }

        private void GestiondePersonal_Load(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                con.Open();

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = "SELECT ID_EMPLEADO FROM EMPLEADOS WHERE ID_DEPTO=" + (DepartamentoTrabajo.SelectedIndex + 1) + " AND CONCAT(NOMBRE,' ',APELLIDO)=" + "'" + Jefe.GetItemText(Jefe.SelectedItem) + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
                DataTable dt1 = new DataTable();
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];
                int idJefe;
                if (dt1.Rows.Count == 0)
                    idJefe = 0;
                else
                    idJefe = int.Parse(dt1.Rows[0][0].ToString());

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_EMPLEADOS";
                if (idJefe == 0)
                    cmd.Parameters.Add("@JEFE", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@JEFE", SqlDbType.Int).Value = idJefe;
                cmd.Parameters.Add("@DEPTO", SqlDbType.Int).Value = DepartamentoTrabajo.SelectedIndex + 1;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Nombre.Text;
                cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar).Value = Apellido.Text;
                cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = Direcion.Text;
                cmd.Parameters.Add("@ESTADO_CIVIL", SqlDbType.Char).Value = 'c';
                cmd.Parameters.Add("@NIVEL_EDUCACIONAL", SqlDbType.VarChar).Value = NivelEducacion.GetItemText(NivelEducacion.SelectedItem);

                cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = int.Parse(Telefono.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT COUNT(*) from EMPLEADOS";
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];



                for (int x = 0; x < hijos.Count(); x++)
                {
                    SqlCommand cmd4 = new SqlCommand();
                    cmd4.Connection = con;
                    cmd4.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd4.CommandText = "SP_INSERT_DEPENDIENTE";
                    cmd4.Parameters.Add("@ID_EMPLEADO", SqlDbType.Int).Value = int.Parse(dt.Rows[0][0].ToString());
                    cmd4.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = hijos.ElementAt(x);
                    cmd4.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = hijos.ElementAt(x);
                    cmd4.ExecuteNonQuery();
                    cmd4.Dispose();
                }


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
            }

        }
    }
}
