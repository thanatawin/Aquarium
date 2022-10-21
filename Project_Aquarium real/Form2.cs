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
    public partial class Form2 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium;charset=utf8;");
        private MySqlConnection databaseConnection()
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=aquarium;charset=utf8" ;

            MySqlConnection connect = new MySqlConnection(connectionString);

            return connect;


        }

        public Form2()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if(username.Text.Length >= 5 && username.Text.Length <= 20)
            { 
                    if(password.Text.Length >= 5 && password.Text.Length <= 20)
                    {
                            if(password.Text == confirmpassword.Text)
                            {
                                    if(namesurname.Text.Length > 0)
                                    { 
                                        String sql = "INSERT INTO userinfo(username, password, confirmpassword,namesurname) VALUES('" + username.Text + "','" + password.Text + "','" + confirmpassword.Text + "','" + namesurname.Text + "')";

                                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                                        conn.Open();

                                        int rows = cmd.ExecuteNonQuery();

                                        conn.Close();

                                        if (rows > 0) //ถ้ากรอกผ่านครบจะเก็บข้อมูลในdatabase
                                        {
                                            String message = "Are you sure ?";

                                            String title = "SYSTEM";

                                            MessageBoxButtons button = MessageBoxButtons.YesNo;

                                            DialogResult result = MessageBox.Show(message, title, button);

                                            if (result == DialogResult.Yes)
                                            {
                                                this.Hide();

                                                Form1 form1 = new Form1();

                                                form1.Show();
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }           
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please enter your name and surname");
                                    }
                            }
                            else
                            {
                                MessageBox.Show("Password must same!!");
                            }
                    }
                    else
                    {
                        MessageBox.Show("Password must have more than 4 character and less than 21 character");
                    }
            }
            else
            {
                MessageBox.Show("Username must have more than 4 character and less than 21 character");
            }
        }
    }
}
