using MySql.Data.MySqlClient;
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

namespace ToDoList
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String connString = "Server=localhost;user=root;database=todo;password=гещзшф;";
            //todo: проверка логина и пароля
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            MySqlCommand sCom = new MySqlCommand(@"SELECT * FROM project.users where username='"+this.textBox1.Text+"' and password='"+this.textBox2.Text+"'", con);
            MySqlDataReader dr;

            dr = sCom.ExecuteReader();

            int count = 0;
            while (dr.Read())
            {
                count++;
            }

            if (count==1)
            {
                this.Hide();
                MainList products = new MainList();
                //stockMain main = new stockMain();
                products.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
 
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
