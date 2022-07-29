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
    public partial class Form2 : Form
    {
        public SqlConnection sqlCon = null;

        public Form2()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(
                                  $"INSERT INTO [Plan] (colled,hour,discription,state) VALUES (@colled,@hour,@discription,@state)", sqlCon);
            command.Parameters.AddWithValue("colled", textBox2.Text);
            command.Parameters.AddWithValue("hour", textBox3.Text);
            command.Parameters.AddWithValue("discription", textBox1.Text);
            command.Parameters.AddWithValue("state",comboBox1.Text);
     
            ;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";



            command.ExecuteNonQuery();
        }
    }
}
