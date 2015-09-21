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
    public partial class Meta : Form
    {
        SqlConnection con;
        public Meta(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void Meta_Load(object sender, EventArgs e)
        {

        }
    }
}
