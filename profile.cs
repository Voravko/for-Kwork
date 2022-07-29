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
    public partial class profile : Form
    {
        public SqlConnection sqlCon = null;
        Bitmap path = null;
        public profile()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);
            sqlCon.Open();
        }

        private void profile_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    //this.pictureBox2.Size = image.Size;
                    pictureBox1.Image = image;
                    path = image;
                    pictureBox1.Invalidate();
                    pictureBox1.Visible = true;
                    
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            label3.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            label4.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label9.Visible = true;
            label5.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                                  $"INSERT INTO [Contact] (name,busyness,goal) VALUES (@name,@busyness,@goal)", sqlCon);
            command.Parameters.AddWithValue("name", textBox2.Text);
            command.Parameters.AddWithValue("busyness", textBox3.Text);
            command.Parameters.AddWithValue("goal", textBox1.Text);
            command.ExecuteNonQuery();

            this.Close();
            main_form m = new main_form();
            m.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
