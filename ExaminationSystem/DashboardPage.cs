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
    public partial class DashboardPage : Form
    {
        public static string Id = "";
        //LoginForm lF = new LoginForm();
        //public string Id = lF.id;
        public DashboardPage(string id)
        {
            Id = id;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditProfilePage editProfilePage = new EditProfilePage(Id);
            editProfilePage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TakeExamPage takeExamPage = new TakeExamPage(Id);
            takeExamPage.Show();
        }

        private void DashboardPage_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=your_id;Password=you_pass");
                con.Open();

                string newcon = "select  * from signuptable1 where ID='"+Id+"'";

                SqlCommand cmd = new SqlCommand(newcon, con);
                SqlDataReader dr =  cmd.ExecuteReader();

                if (dr.Read())
                {
                    label8.Text = (dr["Name"].ToString());
                    label9.Text = (dr["ID"].ToString());
                    label10.Text = (dr["Year"].ToString());
                    label11.Text = (dr["Semester"].ToString());
                    label12.Text = (dr["Totalmark"].ToString());
                    label13.Text = (dr["Examno"].ToString());
                    label15.Text = (dr["Rating"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
