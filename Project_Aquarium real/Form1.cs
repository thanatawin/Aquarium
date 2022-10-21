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

namespace Project_Aquarium_real
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium;charset=utf8;");


        public static DataTable maintable;
        //ปุ่มlogin
        public void DataAdapterLogin(String query)
        {
            conn.Open();
            var cmd = new MySqlCommand(query, conn); //ไว้เช็คข้อมูลในdatabaseถ้าผ่านให้ไปฟอร์ม3

            DataTable table2= new DataTable();            

            new MySqlDataAdapter(cmd).Fill(table2);

            maintable = table2;

            if (table2.Rows.Count > 0)
            {
                this.Hide();
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                MessageBox.Show("NOT FOUND USER");
            }
            conn.Close();
        }
        //ปุ่มadmin
        public void DataAdapterLogin2(String query)
        {
            conn.Open();
            var cmd = new MySqlCommand(query, conn);

            DataTable table3 = new DataTable();

            new MySqlDataAdapter(cmd).Fill(table3);

            maintable = table3;

            if (table3.Rows.Count > 0)
            {
                this.Hide();
                form4 form4 = new form4();
                form4.Show();
            }
            else
            {
                MessageBox.Show("NOT FOUND USER");
            }
            conn.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }
        //ปุ่มไปRegis
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกการระบบหรือไม่", "!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.Close();
        }
        //ปุ่มlogin เอาข้อมูลในtextboxไปเช็คในฟังก์ชั่นด้านบน
        private void button1_Click_1(object sender, EventArgs e)
        {
            string login = "SELECT * FROM userinfo WHERE username = '" + username.Text + "' AND password ='" + password.Text + "'"; 

            DataAdapterLogin(login); 
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            string admin = "SELECT * FROM admin WHERE username = '" + username.Text + "' AND password ='" + password.Text + "'";

            DataAdapterLogin2(admin);
        }
    }
}
