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
    public partial class LoginForm : Form
    {
        public static string id = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usr = comboBox1.Text;
            if (usr == "Student")
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=your_id;Password=you_pass");
                    con.Open();

                    //string newcon = "insert into signuptable(Name,ID,Year, Semester, Password) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "')";

                    string newcon = "select ID from signuptable1 where ID='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";

                    SqlDataAdapter adp = new SqlDataAdapter(newcon, con);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count >= 1)
                    {
                        id = textBox1.Text;
                        //  MessageBox.Show(id);
                        DashboardPage dashboardPage = new DashboardPage(id);
                        dashboardPage.Show();
                        this.Hide();
                    }
                    else
                    {
                        label4.Text = "Wrong ID or Password";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (usr == "Admin")
            {
                string str = textBox1.Text;
                string pas = textBox2.Text;
                if (str == "Admin" && pas == "Admin")
                {
                    this.Hide();
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                }
                else
                {
                    MessageBox.Show("Wrong ID or Password");
                }
            }
            else
            {
                MessageBox.Show("Please Select a User");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
