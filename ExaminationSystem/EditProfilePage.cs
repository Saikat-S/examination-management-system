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
    public partial class EditProfilePage : Form
    {
        public static string Id = "";
        public EditProfilePage(string st)
        {
            Id = st;
            InitializeComponent();
        }

        private void EditProfilePage_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                con.Open();

                string newcon = "select  * from signuptable1 where ID='" + Id + "'";

                SqlCommand cmd = new SqlCommand(newcon, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textBox1.Text = (dr["Name"].ToString());
                    textBox2.Text = (dr["ID"].ToString());
                    textBox3.Text = (dr["Year"].ToString());
                    textBox4.Text = (dr["Semester"].ToString());
                    textBox5.Text = (dr["Password"].ToString());
                    textBox6.Text = (dr["Password"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string pas1 = textBox5.Text;
            string pas2 = textBox6.Text;
            if (pas1 == pas2)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                    con.Open();

                    string newcon = "update signuptable1 set Name='" + textBox1.Text + "',ID='" + textBox2.Text + "',Year='" + textBox3.Text + "', Semester='" + textBox4.Text + "', Password='" + textBox5.Text + "' where ID='" + Id + "';";

                    SqlCommand cmd = new SqlCommand(newcon, con);

                    SqlDataReader dr = cmd.ExecuteReader();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Id = textBox2.Text;

                this.Hide();
                MessageBox.Show("Your Profile Successfully Saved!");
                DashboardPage dashboardPage = new DashboardPage(Id);
                dashboardPage.Show();
            }
            else
            {
                MessageBox.Show("Your Password do not Match!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardPage dashboardPage = new DashboardPage(Id);
            dashboardPage.Show();
        }
    }
}
