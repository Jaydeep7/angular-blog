using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TelerikWinFormsApp1
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public SqlConnection cn;
        public SqlDataAdapter da;
        public DataSet ds = new DataSet();

        public RadForm1()
        {
            InitializeComponent();

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study\Code\Rnd\TelerikWinFormsApp1\Database1.mdf;Integrated Security=True");
            da = new SqlDataAdapter("select * from temp", cn);
            da.Fill(ds);
            radGridView1.DataSource = ds.Tables[0];

        }
    }
}
