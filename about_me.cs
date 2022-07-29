using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Планировщие_задач_EcoTime
{
    public partial class about_me : Form
    {
        public SqlConnection sqlCon = null;
        public about_me()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);
            sqlCon.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlDataReader dataReade = null;
            ListViewItem item = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT id,name,time from [Save]", sqlCon);
                
                dataReade = sqlCommand.ExecuteReader();

                while (dataReade.Read())
                {

                    item = new ListViewItem(new string[] { Convert.ToString(dataReade["id"]), Convert.ToString(dataReade["name"]), Convert.ToString(dataReade["time"]) });
                    listView1.Items.Add(item);



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReade != null && !dataReade.IsClosed)
                {
                    dataReade.Close();
                }
            }
        }
    }
}
