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
    public partial class Form1 : Form
    {
        public SqlConnection sqlCon = null;
        bool chelk = false;
        string peremenay;
        public Form1()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);
            sqlCon.Open();
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT name from [Contact] where Id = 3", sqlCon);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    peremenay = dataReader["name"].ToString();
                

                    if (peremenay==" ")
                    {
                        
                        chelk = true;
                        MessageBox.Show("jhkhk");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
           
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (chelk != true)
            {
                profile pr = new profile();
                pr.Show();
            }
            else
            {
                main_form mf = new main_form();
                mf.Show();
           }
        }
    }
}
