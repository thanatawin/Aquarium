using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Aquarium_real
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3(); // กลับไปหน้าหลัก
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6(); // ไปดูรูปรอบที่ 1
            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7(); // ไปดูรูปรอบที่ 2
            form7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 form8 = new Form8(); // ไปดูรูปรอบที่ 3
            form8.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 form9 = new Form9(); // ไปดูรูปรอบที่ 4
            form9.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 form10 = new Form10(); // ไปดูรูปรอบที่ 5
            form10.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 form11 = new Form11(); // ไปดูรูปรอบที่ 6
            form11.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 form12 = new Form12(); // ไปดูรูปรอบที่ 7
            form12.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form13 = new Form13(); // หน้าเทสรูป2
            form13.Show();
        }
    }
}
