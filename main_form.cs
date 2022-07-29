using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Планировщие_задач_EcoTime
{
    public partial class main_form : Form
    {
        public SqlConnection sqlCon = null;
        public int n { get; set; }

        public main_form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);
            sqlCon.Open();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        

        private void label4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            
            f2.Show();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();

            SqlDataReader dataReade = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT id,colled,hour,state from [Plan]" , sqlCon);
                dataReade = sqlCommand.ExecuteReader();
                ListViewItem item = null;
                while (dataReade.Read())
                {

                    string choose = dataReade["state"].ToString();
                    
                    if (choose == "Важная срочная")
                    {

                        item = new ListViewItem(new string[] { Convert.ToString(dataReade["id"]), Convert.ToString(dataReade["colled"]), Convert.ToString(dataReade["hour"]) });
                        listView1.Items.Add(item);
                    }
                    else if(choose == "Важная несрочная")
                    {
                        item = new ListViewItem(new string[] { Convert.ToString(dataReade["id"]),Convert.ToString(dataReade["colled"]), Convert.ToString(dataReade["hour"]) });
                        listView2.Items.Add(item);
                    }
                    else if (choose == "Срочная неважная")
                    {
                        item = new ListViewItem(new string[] { Convert.ToString(dataReade["id"]),Convert.ToString(dataReade["colled"]), Convert.ToString(dataReade["hour"]) });
                        listView3.Items.Add(item);
                    }
                    else if (choose == "Несрочная неважная")
                    {
                        item = new ListViewItem(new string[] { Convert.ToString(dataReade["id"]),Convert.ToString(dataReade["colled"]), Convert.ToString(dataReade["hour"]) });
                        listView4.Items.Add(item);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (dataReade != null && !dataReade.IsClosed)
                {
                    dataReade.Close();
                }
            }

        }

        private void listView1_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
                    return;
                ListViewItem item = listView1.SelectedItems[0];
                 Date.index = int.Parse(item.Text);
                
            about_plan ap = new about_plan();
            ap.Show();
            
            

            

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_Click(object sender, EventArgs e)
        { 


            if (listView2.SelectedItems.Count == 0)
                return;
            ListViewItem item = listView2.SelectedItems[0];
            Date.index = int.Parse(item.Text);

            about_plan ap = new about_plan();
            ap.Show();
        }

        private void listView3_Click(object sender, EventArgs e)
        {

            if (listView3.SelectedItems.Count == 0)
                return;
            ListViewItem item = listView3.SelectedItems[0];
            Date.index = int.Parse(item.Text);

            about_plan ap = new about_plan();
            ap.Show();
        }

        private void listView4_Click(object sender, EventArgs e)
        {

            if (listView4.SelectedItems.Count == 0)
                return;
            ListViewItem item = listView4.SelectedItems[0];
            Date.index = int.Parse(item.Text);

            about_plan ap = new about_plan();
            ap.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            about_me am = new about_me();
            am.Show();
        }
    }
    
}
