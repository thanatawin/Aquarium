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
    public partial class Form14 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium2;charset=utf8;");
        public Form14()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium2;charset=utf8";

            MySqlConnection connect = new MySqlConnection(connectionString);

            return connect;


        }
        //ลืมลบค้าบ
        private void Form14_Load(object sender, EventArgs e)
        {
           
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM aquariumproject WHERE ชื่อ like '%{textBox1.Text}%'";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            dataGridView.DataSource = ds.Tables[0].DefaultView;
        }
        //ปุ่มback
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
