using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExaminationSystem
{
    public partial class SignupPage : Form
    {
        public SignupPage()
        {
            InitializeComponent();
        }
69
        private void SignupPage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string totalMark = "0";
            string examNo = "0";
            string rating = "0";
            string pas1 = textBox5.Text;
            string pas2 = textBox6.Text;
            if (pas1 == pas2)
            {
                try {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                    con.Open();

                    string newcon = "insert into signuptable1(Name,ID,Year, Semester, Password,Totalmark,Examno,Rating) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "','"+totalMark+ "','" + examNo + "', '" + rating + "' )";

                    SqlCommand cmd = new SqlCommand(newcon, con);

                    cmd.ExecuteNonQuery();

                    con.Close();


                    this.Hide();
                    MessageBox.Show("Your Account Successfully Created! Now You can login");
                    HomePage homePage = new HomePage();
                    homePage.Show();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Your Password do not Match!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            HomePage homePage = new HomePage();
            homePage.Show(); 
        }
    }
}
