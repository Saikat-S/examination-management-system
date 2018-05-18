using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class TakeExamPage : Form
    {
        public static string course = "";
        public static string Id = "";
        public TakeExamPage(string st)
        {
            Id = st;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardPage dashboardPage = new DashboardPage(Id);
            dashboardPage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardPage dashboardPage = new DashboardPage(Id);
            dashboardPage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CouesesPage coursesPage = new CouesesPage();
            coursesPage.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string str = comboBox1.Text;
            if(str == "1st Year 1st Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-1101");
                comboBox2.Items.Add("CSE-1103");
                comboBox2.Items.Add("CSE-1105");
                comboBox2.Items.Add("CSE-1107");
                comboBox2.Items.Add("CSE-1109");
            }
            else if(str == "1st Year 2nd Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-1201");
                comboBox2.Items.Add("CSE-1203");
                comboBox2.Items.Add("CSE-1205");
                comboBox2.Items.Add("CSE-1207");
                comboBox2.Items.Add("CSE-1209");
            }
            else if (str == "2nd Year 1st Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-2101");
                comboBox2.Items.Add("CSE-2103");
                comboBox2.Items.Add("CSE-2105");
                comboBox2.Items.Add("CSE-2107");
                comboBox2.Items.Add("CSE-2109");
            }
            else if (str == "2nd Year 2nd Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-2201");
                comboBox2.Items.Add("CSE-2203");
                comboBox2.Items.Add("CSE-2205");
                comboBox2.Items.Add("CSE-2207");
                comboBox2.Items.Add("CSE-2209");
            }
            else if (str == "3rd Year 1st Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-3101");
                comboBox2.Items.Add("CSE-3103");
                comboBox2.Items.Add("CSE-3105");
                comboBox2.Items.Add("CSE-3107");
                comboBox2.Items.Add("CSE-3109");
            }
            else if (str == "3rd Year 2nd Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-3201");
                comboBox2.Items.Add("CSE-3203");
                comboBox2.Items.Add("CSE-3205");
                comboBox2.Items.Add("CSE-3207");
                comboBox2.Items.Add("CSE-3209");
            }
            else if (str == "4th Year 1st Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-4101");
                comboBox2.Items.Add("CSE-4103");
                comboBox2.Items.Add("CSE-4105");
                comboBox2.Items.Add("CSE-4107");
                comboBox2.Items.Add("CSE-4109");
            }
            else if (str == "4th Year 2nd Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-4201");
                comboBox2.Items.Add("CSE-4203");
                comboBox2.Items.Add("CSE-4205");
                comboBox2.Items.Add("CSE-4207");
                comboBox2.Items.Add("CSE-4209");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please Select Your Year & Course");
            }
            else {
                this.Hide();
                course = comboBox2.Text;
                ExamPage examPage = new ExamPage(course, Id);
                examPage.Show();
            }
        }

        private void TakeExamPage_Load(object sender, EventArgs e)
        {

        }
    }
}
