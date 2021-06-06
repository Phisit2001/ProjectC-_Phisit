using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class Form5 : Form

    {
        public Form5()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionSting);
            return conn;
        }
        public void login()
        {
            try
            {
                string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
                MySqlConnection conn = new MySqlConnection(connectionSting);
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT username,password FROM admin WHERE username ='" + textBox1.Text + "'AND password = '" + textBox2.Text + "'", conn))
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Login สำเร็จ");
                        this.Hide();
                        Form6 f = new Form6();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("ใส่ชื่อบัญชีหรือรหัสผ่านของท่านให้ถูกต้อง");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
