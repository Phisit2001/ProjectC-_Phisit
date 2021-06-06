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
    public partial class Form4 : Form
    {
        int amount2;
        int amount;
        string package;
        public Form4()
        {
            InitializeComponent();
        }
        public String names;
        private MySqlConnection databaseConnection()
        {
            string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionSting);
            return conn;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            label8.Text = Program.username;
            label10.Text = names;

            try
            {
                string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
                MySqlConnection conn = new MySqlConnection(connectionSting);
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT amount FROM user WHERE username ='" + label8.Text + "'", conn))
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        amount = Convert.ToInt32(dr.GetValue(0).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            label20.Text = amount.ToString();


            try
            {
                string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
                MySqlConnection conn = new MySqlConnection(connectionSting);
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT package FROM user WHERE username ='" + label8.Text + "'", conn))
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        package = dr.GetValue(0).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            label19.Text = package.ToString();
            showotw();
            showotw2();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showotw2();
            groupBox6.BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "General";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Quilt";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Text = "PowerLow";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label5.Text = "PowerMedium";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label5.Text = "PowerHight";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "DryLow";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "DryMedium";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "DryHight";
        }
        private void showotw()
        {
            string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection con = new MySqlConnection(connectionSting);
            DataSet ds = new DataSet();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = $"SELECT * FROM history WHERE us =\"{label10.Text}\" ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void showotw2()
        {
            string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection con = new MySqlConnection(connectionSting);
            DataSet ds = new DataSet();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = $"SELECT * FROM history WHERE us =\"{label10.Text}\" ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            con.Close();
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            amount = Convert.ToInt32(label20.Text);
            amount = amount - Convert.ToInt32(comboBox1.Text);
            if (amount < 0)
            {
                MessageBox.Show("ตอนนี้จำนวนของท่านเหลือ 0 กรุณาสมัครแพ็คเกจเพิ่ม ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                amount = amount + Convert.ToInt32(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("จำนวนที่เหลือของคุณคือ : " + amount.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MySqlConnection conn = databaseConnection();
                String sql = "UPDATE user SET amount ='" + amount + "'WHERE username = '" + label8.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                label20.Text = amount.ToString();

                if (textBox2.Text == "")
                {
                    MessageBox.Show("กรุณาใส่ที่อยู่ของท่าน");
                }
                else
                {

                    MySqlConnection conn2 = databaseConnection();
                    String sql2 = "INSERT INTO history (amount,type,wahs,dryer,address,name,us) VALUES('" + comboBox1.Text + "','" + label4.Text + "','" + label5.Text + "','" + label7.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + label10.Text + "')";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                    conn2.Open();
                    int rows2 = cmd2.ExecuteNonQuery();
                    if (rows2 > 0)
                    {
                        MessageBox.Show("ขอบคุณที่ใช้บริการ");
                        comboBox1.Text = String.Empty;
                        textBox2.Text = String.Empty;
                        textBox3.Text = String.Empty;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        radioButton7.Checked = false;
                        radioButton8.Checked = false;
                    }
                    showotw();
                    showotw2();
                }
            
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            showotw();
            groupBox5.BringToFront();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("กรุณาใส่ที่อยู่ของท่าน");
            }
            else
            {
                int selectedRow = dataGridView2.CurrentCell.RowIndex;
                int editId = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["id"].Value);
                MySqlConnection conn = databaseConnection();
                String sql = "UPDATE history SET type = '" + label13.Text + "',wahs = '" + label16.Text + "',dryer = '" + label17.Text + "',address = '" + textBox6.Text + "',name = '" + textBox5.Text + "' WHERE id = '" + editId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                    textBox5.Text = String.Empty;
                    textBox6.Text = String.Empty;
                    radioButton9.Checked = false;
                    radioButton10.Checked = false;
                    radioButton11.Checked = false;
                    radioButton12.Checked = false;
                    radioButton13.Checked = false;
                    radioButton14.Checked = false;
                    radioButton15.Checked = false;
                    radioButton16.Checked = false;
                }
                showotw();
                showotw2();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "General";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "Quilt";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            label16.Text = "PowerLow";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            label16.Text = "PowerMedium";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            label16.Text = "PowerHight";
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            label17.Text = "Drymedium";
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            label17.Text = "DryMedium";
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            label17.Text = "DryHight";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("กรุณเลือกจำนวน");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void getmoney()
        {
            int m = 0;
            if (label32.Text == "Package A")
            {
                m = 360;
            }
            if (label32.Text == "Package B")
            {
                m = 550;
            }
            if (label32.Text == "Package C")
            {
                m = 600;
            }
            textBox1.Text = m.ToString();

        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox7.Focus();
            {
                if (radioButton19.Checked == false)
                {
                    if (radioButton18.Checked == false)
                    {
                        if (radioButton17.Checked == false)
                        {
                            MessageBox.Show("กรุณาเลือกเเพ็คเกจ");
                        }
                        else
                        {
                            getmoney();
                            groupBox11.BringToFront();

                        }
                    }
                    else
                    {
                        getmoney();
                        groupBox11.BringToFront();
                    }

                }
                else
                {
                    getmoney();
                    groupBox11.BringToFront();
                }
            }

        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            label32.Text = "Package A";
            amount2 = 40;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            label32.Text = "Package B";
            amount2 = 60;
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            label32.Text = "Package C";
            amount2 = 80;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("กุรุณาใส่จำนวนเงิน");
            }
            else
            {
                int Gtt6 = int.Parse(textBox1.Text);
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

                    amount2 = amount2 + Convert.ToInt32(label20.Text);
                    label19.Text = label32.Text;
                    MySqlConnection conn = databaseConnection();
                    String sql = "UPDATE user SET amount ='" + amount2 + "',package = '" + label32.Text + "'WHERE username = '" + label8.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    label20.Text = amount2.ToString();
                    groupBox1.BringToFront();
                }

            }

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            groupBox10.BringToFront();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
