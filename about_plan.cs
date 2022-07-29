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
    public partial class about_plan : Form
    {
        public SqlConnection sqlCon = null;
        int m, s, h;
     
        public about_plan()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);
            sqlCon.Open();
            int h = Date.index;
            

            SqlDataReader dataReade = null;


            try
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT colled,hour,discription from [Plan] where id = {h}", sqlCon);


                dataReade = sqlCommand.ExecuteReader();

                while (dataReade.Read())
                {


                    textBox2.Text = dataReade["colled"].ToString();
                    textBox1.Text = dataReade["discription"].ToString();
                    label3.Text = dataReade["hour"].ToString();
                    






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

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox1.Visible = false;
            button2.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
         
            SqlCommand command = new SqlCommand(
                                 $"INSERT INTO [Save] (name,time) VALUES (@name,@time)", sqlCon);
            command.Parameters.AddWithValue("name", textBox2.Text);
            command.Parameters.AddWithValue("time", label5.Text + "." + label6.Text);
           


            SqlCommand command1 = new SqlCommand(
                            $"DELETE from [Plan] WHERE colled = @colled", sqlCon);
            command1.Parameters.AddWithValue("colled", textBox2.Text);

           command1.ExecuteNonQuery();
            this.Close();



            command.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
            label8.Visible = false;
            pictureBox1.Visible = true;

            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            
            h = Convert.ToInt32(label3.Text);
           

            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            s = s - 1;
            if (s == -1)
            {
                m = m - 1;
                s = 59;
                
            }
            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }
            if (h == 0 && m == 0 && s == 0)
            {
                timer1.Stop();
                //SqlCommand command = new SqlCommand(
                //                $"INSERT INTO [Save] (name,time) VALUES (@name,@time)", sqlCon);
                //command.Parameters.AddWithValue("name", label1.Text);
                //command.Parameters.AddWithValue("time", label5.Text + "." + label6.Text);
                //command.ExecuteNonQuery();
                //SqlCommand command1 = new SqlCommand(
                //          $"DELETE from [Plan] WHERE colled = @colled", sqlCon);
                //command1.Parameters.AddWithValue("colled", label1.Text);

                //MessageBox.Show(command1.ExecuteNonQuery().ToString());
                //this.Close();



                //command.ExecuteNonQuery();
                this.Close();
            }


            label5.Text = h.ToString();
            label6.Text = m.ToString();
            label7.Text = s.ToString();
        }
    }
}
