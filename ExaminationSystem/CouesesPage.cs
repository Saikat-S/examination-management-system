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
    public partial class CouesesPage : Form
    {
        public CouesesPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardPage dashboardPage = new DashboardPage("");
            dashboardPage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ExamPage examPage = new ExamPage();
           // examPage.Show();
        }
    }
}
