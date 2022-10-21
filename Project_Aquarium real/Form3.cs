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
    public partial class Form3 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium2;charset=utf8;");
        private MySqlConnection databaseConnection()
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium2;charset=utf8";

            MySqlConnection connect = new MySqlConnection(connectionString);

            return connect;


        }
        public Form3()
        {
            InitializeComponent();
        }
        int sum = 0;
        //จริงๆไม่ต้องมีก็ได้เพราะแก้ให้มันมีชื่อเหมือนหน้าสมัครแล้ว (อันนี้จะเป็นการกดEnterแล้วเลื่อนลงล่าง)
        /*private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (ชื่อ.Text == "")
                {
                    MessageBox.Show("กรุณาพิมพ์ชื่อ-นามสกุลด้วยค้าบบบ", "!");
                    ชื่อ.Focus();
                }
                else
                {
                    รอบโชว์ให้อาหารและการแสดง.Focus();
                }
        }*/
        //ข้อมูลในคอมโบบล็อก
        private void Form3_Load(object sender, EventArgs e)
        {
            รอบโชว์ให้อาหารและการแสดง.Items.Add("1.มหัศจรรย์ฟงไฟรลี้ลับ(Mystic Forest feeding)");
            รอบโชว์ให้อาหารและการแสดง.Items.Add("2.นาก(Otters)");
            รอบโชว์ให้อาหารและการแสดง.Items.Add("3.เพนกวิน(Penguins)");
            รอบโชว์ให้อาหารและการแสดง.Items.Add("4.ปลาอะเมซอนยักษ์(Giant Amazonian)");
            รอบโชว์ให้อาหารและการแสดง.Items.Add("5.ฉลาม(Shark Alley)");
            รอบโชว์ให้อาหารและการแสดง.Items.Add("6.ปลากระเบน(Stingrays)");
            รอบโชว์ให้อาหารและการแสดง.Items.Add("7.มหัศจรรย์แห่งท้องทะเล(Open Ocean)");
            ชื่อ.Text = Form1.maintable.Rows[0][4].ToString();
        }
        //เรตราคารอบ
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = รอบโชว์ให้อาหารและการแสดง.SelectedItem.ToString();
            switch (str)
            {
                case "1.มหัศจรรย์พงไพรลี้ลับ(Mystic Forest feeding)": ราคารอบ.Text = "165"; break;
                case "2.นาก(Otters)": ราคารอบ.Text = "150"; break;
                case "3.เพนกวิน(Penguins)": ราคารอบ.Text = "175"; break;
                case "4.ปลาอะเมซอนยักษ์(Giant Amazonian)": ราคารอบ.Text = "175"; break;
                case "5.ฉลาม(Shark Alley)": ราคารอบ.Text = "180"; break;
                case "6.ปลากระเบน(Stingrays)": ราคารอบ.Text = "160"; break;
                case "7.มหัศจรรย์แห่งท้องทะเล(Open Ocean)": ราคารอบ.Text = "175"; break;
            }
        }
        //โปรโมชั่น
        private void button1_Click(object sender, EventArgs e)
        {
            if (จำนวนคน.Value <= 10 )
            {
                double price = 0, num = 0, sum = 0;
                num = double.Parse(จำนวนคน.Text);
                price = double.Parse(ราคารอบ.Text);
                sum = price * num;
                รวมราคาของจำนวนคน.Text = sum.ToString("#,##.00");
            }
            if (จำนวนคน.Value > 10)
            {
                double price = 0, num = 0, sum = 0;
                num = double.Parse(จำนวนคน.Text);
                price = double.Parse(ราคารอบ.Text);
                sum = (price * num) * 50 / 100;
                รวมราคาของจำนวนคน.Text = sum.ToString("#,##.00");
            }
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
        //บริการเสริม
        private void button2_Click(object sender, EventArgs e)
        {
            sum = 0;
            if (checkBox1.Checked) sum += 85;
            if (checkBox2.Checked) sum += 20;
            if (checkBox3.Checked) sum += 35;
            ราคาบริการเสริม.Text = sum.ToString("#,##.00");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }
        //รอบที่เลือกเพิ่ม
        private void button3_Click(object sender, EventArgs e)
        {
            sum = 0;
            if (checkBox4.Checked) sum += 165;
            if (checkBox5.Checked) sum += 150;
            if (checkBox6.Checked) sum += 175;
            if (checkBox7.Checked) sum += 175;
            if (checkBox8.Checked) sum += 180;
            if (checkBox9.Checked) sum += 160;
            if (checkBox10.Checked) sum += 175;
            if (checkBox1.Checked)
            {
                textBox1.Text = " ✓ ";
            }
            else
            {
                textBox1.Text = "";
            }
            if (checkBox2.Checked)
            {
                textBox2.Text = " ✓ ";
            }
            else
            {
                textBox2.Text = "";
            }
            if (checkBox3.Checked)
            {
                textBox3.Text = " ✓ ";
            }
            else
            {
                textBox3.Text = "";
            }
            if (checkBox4.Checked)
            {
                textBox4.Text = " ✓ ";
            }
            else
            {
                textBox4.Text = "";
            }
            if (checkBox5.Checked)
            {
                textBox5.Text = " ✓ ";
            }
            else
            {
                textBox5.Text = "";
            }
            if (checkBox6.Checked)
            {
                textBox6.Text = " ✓ ";
            }
            else
            {
                textBox6.Text = "";
            }
            if (checkBox7.Checked)
            {
                textBox7.Text = " ✓ ";
            }
            else
            {
                textBox7.Text = "";
            }
            if (checkBox8.Checked)
            {
                textBox8.Text = " ✓ ";
            }
            else
            {
                textBox8.Text = "";
            }
            if (checkBox9.Checked)
            {
                textBox9.Text = " ✓ ";
            }
            else
            {
                textBox9.Text = "";
            }
            if (checkBox10.Checked)
            {
                textBox10.Text = " ✓ ";
            }
            else
            {
                textBox10.Text = "";
            }
            รวมราคารอบที่เลือกเพิ่ม.Text = sum.ToString("#,##.00");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }
        //ล้างข้อมูล
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการล้างข้อมูลหรือไม่", "เตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ชื่อ.Clear();
                รวมราคาของจำนวนคน.Text = "0.00";
                ราคารอบ.Text = "0.00";
                ราคาบริการเสริม.Text = "0.00";
                รวมราคารอบที่เลือกเพิ่ม.Text = "0.00";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                จำนวนคน.Text = "0";
                รอบโชว์ให้อาหารและการแสดง.Text = "---กรุณาเลือกรอบ---";
                ราคาทั้งหมด.Text = "0.00";
                ชื่อ.Focus();
            }
        }
        //ราคารวมทั้งหมด
        private void button5_Click(object sender, EventArgs e)
        {
            double total1 = 0, total2 = 0, total3 = 0, sum = 0;
            total1 = double.Parse(รวมราคาของจำนวนคน.Text);
            total2 = double.Parse(ราคาบริการเสริม.Text);
            total3 = double.Parse(รวมราคารอบที่เลือกเพิ่ม.Text);
            sum = total1 + total2 + total3;
            ราคาทั้งหมด.Text = sum.ToString("#,##.00");
        }
        //ออกจากระบบ
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกการระบบหรือไม่", "!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.Close();
        }

        //ปุ่มกดยืนยันนน   ถ้ากดปุ่มที่9ก็แอดข้อมูลลงในdatabase
        private void button9_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO aquariumproject(id, ชื่อ, รอบโชว์ให้อาหารและการแสดง, ราคารอบ, จำนวนคน,ราคารวมของจำนวนคน, ราคาบริการเสริม,รวมราคารอบที่เลือกเพิ่ม, ราคาทั้งหมด) VALUES('" + ชื่อ.Text + "','" + ชื่อ.Text + "', '" + รอบโชว์ให้อาหารและการแสดง.Text + "', '" + ราคารอบ.Text + "', '" + จำนวนคน.Text + "', '" + รวมราคาของจำนวนคน.Text + "', '" + ราคาบริการเสริม.Text + "', '" + รวมราคารอบที่เลือกเพิ่ม.Text + "', '" + ราคาทั้งหมด.Text + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                String message = " Are you sure? ";

                String title = "SYSTEM";

                MessageBoxButtons button = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, button);

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();


                if (result == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("  Aquarium  ", new Font("Arial", 36, FontStyle.Regular), Brushes.Black, new Point(40, 40));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(500, 160));
            e.Graphics.DrawString(".......................................................... ", new Font("Arial", 36, FontStyle.Regular), Brushes.Black, new Point(26, 250));
            e.Graphics.DrawString("ชื่อ-นามสกุล ", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 360));
            e.Graphics.DrawString("รอบที่เลือก", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 420));
            e.Graphics.DrawString("ราคารอบ", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 480));
            e.Graphics.DrawString("จำนวนคน", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 540));
            e.Graphics.DrawString("รวมราคาของจำนวนคน", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 600));
            e.Graphics.DrawString("ราคาบริการเสริม", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 650));
            e.Graphics.DrawString("รวมราคารอบที่เลือกเพิ่ม", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 700));           
            // รับค่าราคาต่างๆ
            e.Graphics.DrawString(ชื่อ.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 360));
            e.Graphics.DrawString(รอบโชว์ให้อาหารและการแสดง.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 420));
            e.Graphics.DrawString(ราคารอบ.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 480));
            e.Graphics.DrawString(จำนวนคน.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 540));
            e.Graphics.DrawString(รวมราคาของจำนวนคน.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 600));
            e.Graphics.DrawString(ราคาบริการเสริม.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 650));
            e.Graphics.DrawString(รวมราคารอบที่เลือกเพิ่ม.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 700));
            e.Graphics.DrawString(ราคาทั้งหมด.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 1110));

            // หน่วยราคารายเมนู
            e.Graphics.DrawString(" บาท ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(720, 480));
            e.Graphics.DrawString(" คน ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(720, 540));
            e.Graphics.DrawString(" บาท ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(720, 600));
            e.Graphics.DrawString(" บาท ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(720, 650));
            e.Graphics.DrawString(" บาท ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(720, 700));
            e.Graphics.DrawString(" บาท ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(720, 1110));
            e.Graphics.DrawString(".......................................................... ", new Font("Arial", 36, FontStyle.Regular), Brushes.Black, new Point(26, 820));
            e.Graphics.DrawString(" ราคาทั้งหมด : ", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, new Point(20, 1100));
            //ปุ่ม ✓ 
            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(30, 890));
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(30, 930));
            e.Graphics.DrawString(textBox3.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(30, 970));
            e.Graphics.DrawString(textBox4.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 890));
            e.Graphics.DrawString(textBox5.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 930));
            e.Graphics.DrawString(textBox6.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 970));
            e.Graphics.DrawString(textBox7.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 1010));
            e.Graphics.DrawString(textBox8.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(480, 890));
            e.Graphics.DrawString(textBox9.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(480, 930));
            e.Graphics.DrawString(textBox10.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(480, 970));
            //ปุ่มเช็ค
            e.Graphics.DrawString("อาหารเที่ยง", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(80, 880));
            e.Graphics.DrawString("ขนมกินเล่น", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(80, 920));
            e.Graphics.DrawString("ของที่ระลึก", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(80, 960));
            e.Graphics.DrawString("รอบที่1", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(350, 880));
            e.Graphics.DrawString("รอบที่2", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(350, 920));
            e.Graphics.DrawString("รอบที่3", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(350, 960));
            e.Graphics.DrawString("รอบที่4", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(350, 1000));
            e.Graphics.DrawString("รอบที่5", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(530, 880));
            e.Graphics.DrawString("รอบที่6", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(530, 920));
            e.Graphics.DrawString("รอบที่7", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(530, 960));
        }
        // ไปหน้ารูปภาพ
        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form13 = new Form13(); 
            form13.Show();
        }
        //เดี๋ยวลบค้าบ
        private void จำนวนคน_ValueChanged(object sender, EventArgs e)
        {

        }
        //ปุ่มไปดูประวัติเลอออออออออออ
        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form14 form14 = new Form14();
            form14.Show();
        }
        //ขก.ออกไปหน้าหลักดีกว่าาา
        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
