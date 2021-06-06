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
    public partial class Form2 : Form
    {
        int  amount;
        public Form2()
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
                using (MySqlCommand cmd = new MySqlCommand("SELECT username,password FROM user WHERE username ='" + textBox1.Text + "'AND password = '" + textBox2.Text + "'", conn))
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Program.username = textBox1.Text;
                        MessageBox.Show("Login สำเร็จ");
                        this.Hide();
                        Form4 f = new Form4();
                        f.names = man;
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("รหัสไม่ถูกต้อง");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox2.BringToFront();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox1.BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selecttextAdmin();
            login();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "Package A";
            amount = 40;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "Package B";
            amount = 60;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "Package C";
            amount = 80; 

        }
        private void Dopid()
        {

            MySqlConnection conn = databaseConnection();
            String sql = "INSERT INTO user (username,password,phonenumber,	package,amount) VALUES('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + label15.Text + "','" + amount + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("ขอบคุณที่ใช้บริการ");
            }
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            groupBox2.BringToFront();
        }
        private void getmoney()
        {
            int m = 0;
            if (label15.Text == "Package A")
            {
                m = 360;
            }
            if (label15.Text == "Package B")
            {
                m = 550;
            }
            if (label15.Text == "Package C")
            {
                m = 600;
            }
            textBox6.Text = m.ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (checkUser())
            {
                MessageBox.Show("ชื่อซ้ำ");
            }
            else
            {
                if (radioButton1.Checked == false)
                {
                    if (radioButton2.Checked == false)
                    {
                        if (radioButton3.Checked == false)
                        {
                            MessageBox.Show("กรุณาเลือกเเพ็คเกจ");
                        }
                        else
                        {
                            Dopid();
                            getmoney();
                            groupBox3.BringToFront();

                        }
                    }
                    else
                    {
                        Dopid();
                        getmoney();
                        groupBox3.BringToFront();
                    }

                }
                else
                {
                    Dopid();
                    getmoney();
                    groupBox3.BringToFront();
                }
            }


        }
        string man;
        public void selecttextAdmin()
        {
            String name1 = textBox1.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT   username FROM user WHERE username =\"{ name1}\" ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                man = dr.GetValue(0).ToString();
                
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.Show();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            
            if (textBox7.Text == "")
            {
                MessageBox.Show("กุรุณาใส่จำนวนเงิน");
            }
            else
            {
                int Gtt6 = int.Parse(textBox6.Text);
                int Gtt7 = int.Parse(textBox7.Text);
                if (Gtt7 < Gtt6)
                {
                    MessageBox.Show("กุรุณาใส่จำนวนเงินให้ถูกต้อง");
                }
                else
                {
                    int Gtt8 = Gtt7 - Gtt6;
                    textBox8.Text = Gtt8.ToString();
                    MessageBox.Show("ขอบคุณที่ใช้บริการ");
                    groupBox2.BringToFront();
                }
            }
        }
        public Boolean checkUser()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string username = textBox3.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE username = @user", conn);

            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
