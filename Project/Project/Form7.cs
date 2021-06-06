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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionSting);
            return conn;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "General";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "Quilt";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "PowerLow";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "PowerMedium";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "PowerHight";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "DryLow";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "DryMedium";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "DryHight";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int money = int.Parse(comboBox1.Text);
            money = money * 10;
            textBox6.Text = money.ToString();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("กรุณาใส่ที่อยู่ของท่าน");
            }
            else
            {
                MySqlConnection conn = databaseConnection();
                String sql = "INSERT INTO usernormal (amount,type,wahs,dryer,address,phonenumber,name) VALUES('" + comboBox1.Text + "','" + label7.Text + "','" + label4.Text + "','" + label8.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("ขอบคุณที่ใช้บริการ");
                    comboBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    textBox4.Text = String.Empty;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    radioButton7.Checked = false;
                    radioButton8.Checked = false;
                    groupBox5.BringToFront();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("กุรุณาใส่จำนวนเงิน");
            }
            else
            {
                int Gtm6 = int.Parse(textBox6.Text);
                int Gtm7 = int.Parse(textBox7.Text);
                if (Gtm7 < Gtm6)
                {
                    MessageBox.Show("กุรุณาใส่จำนวนเงินให้ถูกต้อง");
                }
                else
                {
                    int Gtt8 = Gtm7 - Gtm6;
                    textBox8.Text = Gtt8.ToString();
                    MessageBox.Show("ขอบคุณที่ใช้บริการ");
                    this.Hide();
                    Form1 f = new Form1();
                    f.Show();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
