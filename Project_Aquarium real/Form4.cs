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
    public partial class form4 : Form
    {

        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium2;charset=utf8;");
        public form4()
        {
            InitializeComponent();
        }

        
        private MySqlConnection databaseConnection()
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium2;charset=utf8";

            MySqlConnection connect = new MySqlConnection(connectionString);

            return connect;


        }
        //โชว์ในdataGridView
        private void ShowEquipment()
        {
            MySqlConnection conn = databaseConnection();

            DataSet TW = new DataSet();

            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM aquariumproject";

            MySqlDataAdapter te= new MySqlDataAdapter(cmd);

            te.Fill(TW);

            conn.Close();

            dataGridView.DataSource = TW.Tables[0].DefaultView;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ShowEquipment();
        }
        //ปุ่มกลับไปหน้าแรกหน้าlogin
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        //ปุ่มแก้ไข
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("แก้ไขข้อมูลหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int selectedRows = dataGridView.CurrentCell.RowIndex;
                int editid = Convert.ToInt32(dataGridView.Rows[selectedRows].Cells["id"].Value);
                MySqlConnection conn = databaseConnection();               
                String sql = "UPDATE  aquariumproject SET ชื่อ = '" + textBox1.Text + "',รอบโชว์ให้อาหารและการแสดง = '" + textBox2.Text + "',ราคารอบ ='" + textBox3.Text + "',จำนวนคน = '" + textBox4.Text + "',ราคารวมของจำนวนคน= '" + textBox5.Text + "',ราคาบริการเสริม= '" + textBox6.Text + "',รวมราคารอบที่เลือกเพิ่ม= '" + textBox7.Text + "',ราคาทั้งหมด= '" + textBox8.Text + "'WHERE id = '" + editid + "'";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);                
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("ยืนยันการแก้ไขข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowEquipment();
                }
            }                    
        }
        //คลิกdataGridView
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CurrentRow.Selected = true;
            textBox1.Text = dataGridView.Rows[e.RowIndex].Cells["ชื่อ"].FormattedValue.ToString();
            textBox2.Text = dataGridView.Rows[e.RowIndex].Cells["รอบโชว์ให้อาหารและการแสดง"].FormattedValue.ToString();
            textBox3.Text = dataGridView.Rows[e.RowIndex].Cells["ราคารอบ"].FormattedValue.ToString();
            textBox4.Text = dataGridView.Rows[e.RowIndex].Cells["จำนวนคน"].FormattedValue.ToString();
            textBox5.Text = dataGridView.Rows[e.RowIndex].Cells["ราคารวมของจำนวนคน"].FormattedValue.ToString();
            textBox6.Text = dataGridView.Rows[e.RowIndex].Cells["ราคาบริการเสริม"].FormattedValue.ToString();
            textBox7.Text = dataGridView.Rows[e.RowIndex].Cells["รวมราคารอบที่เลือกเพิ่ม"].FormattedValue.ToString();
            textBox8.Text = dataGridView.Rows[e.RowIndex].Cells["ราคาทั้งหมด"].FormattedValue.ToString();
        }
        //ปุ่มลบ
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันลบข้อมูลหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int selectedRows = dataGridView.CurrentCell.RowIndex;
                int deleteid = Convert.ToInt32(dataGridView.Rows[selectedRows].Cells["id"].Value);
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium2;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connection);
                String sql = "DELETE FROM aquariumproject WHERE id = '" + deleteid + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("ยืนยันการลบข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowEquipment();
                }
            }
        }
    }
}
