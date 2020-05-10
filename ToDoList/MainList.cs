using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class MainList : Form
    {

        public MainList()
        {
            InitializeComponent();
        }

        // инициализируем метод load и выгружаем данные в грид
        private void Products_Load(object sender, EventArgs e)
        {
            StatusBox.SelectedIndex = 0;
            load();
        }

        //кнопка Add с вызовом метода что бы добавить данные в БД
        private void button2_Click(object sender, EventArgs e)
        {
            insertData();
 

        }

        //тут пытплся создать метод для 
        /*private bool IfRecordExists(MySqlConnection con, string taskCode)
        {
            MySqlConnection msc = new MySqlConnection();
            msc.Open();
            string sqlSelectAll = "SELECT * FROM project.tasks";
            MySqlCommand cmd = new MySqlCommand(sqlSelectAll, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }

            return true;
        }*/

        //Метод для добавления данных в бд с проверкой что бы обновить
        private void insertData()
        {
            string conStr = "Server = localhost; user = root; database = project; password = гещзшф";
            DateTime date = dateTime.Value;

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO tasks(task, description, date)" + " VALUES " + "('" + this.TaskName.Text + "', '" + this.TaskDescription.Text + "', '" + this.dateTime.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                //тут пытался сделать фрагмент для обновления
                /*var sqlQuery = "";
                if (IfRecordExists(con, this.TaskName.Text))
                {
                    sqlQuery = "UPDATE `project`.`tasks` SET `description` = " + this.TaskDescription.Text + ", " +
                        "`date` =" + this.dateTime.Text + " WHERE `task` = " + this.TaskName.Text + " SELECT* FROM project.tasks";
                }
                else
                {
                    sqlQuery = "INSERT INTO tasks(task, description, date)" + " VALUES " + "('" + this.TaskName.Text + "', '" + this.TaskDescription.Text + "', '" + this.dateTime.Text + "')";
                }*/
            }

        }

        //метод для подключения к баще и выгрузке объектов из базы в грид
        private void load()
        {
            string conStr = "Server = localhost; user = root; database = project; password = гещзшф";

            MySqlConnection con = new MySqlConnection(conStr);

            con.Open();
            string sqlSelectAll = "SELECT * FROM project.tasks";
            MySqlCommand cmd = new MySqlCommand(sqlSelectAll, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        //пытаюсь закрыть приложение, но оно что то не закрывается
        private void MainList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //кнопка удалить но пока тоже не работает(
        private void button1_Click_1(object sender, EventArgs e)
        {
            string conStr = "Server = localhost; user = root; database = project; password = гещзшф";

            MySqlConnection con = new MySqlConnection(conStr);

            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                if (bool.Parse(item.Cells[0].Value.ToString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM `project`.`tasks` WHERE `task` = `" + item.Cells[1].Value.ToString()+ "`", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            } 
        }
    }
}
