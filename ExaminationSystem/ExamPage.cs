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
    public partial class ExamPage : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;
        int mark = 0;
        string a1, a2, a3;
        public static string course = " ";
        public static string Id = "";
        //private Panel panel2;
        // private Panel panel3;

        public ExamPage(string cr, string st)
        {
            course = cr;
            Id = st;
            InitializeComponent();
        }

        private void ExamPage_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            //listPanel.Add(panel4);
            listPanel[index].BringToFront();

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                con.Open();

                string newcon = "select  * from qsettable2 where Course='" + course + "'";

                SqlCommand cmd = new SqlCommand(newcon, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    label3.Text = (dr["Q1"].ToString());
                    label4.Text = (dr["Q2"].ToString());
                    label6.Text = (dr["Q3"].ToString());

                    radioButton1.Text = (dr["Q11"].ToString());
                    radioButton2.Text = (dr["Q12"].ToString());
                    radioButton3.Text = (dr["Q13"].ToString());
                    radioButton4.Text = (dr["Q14"].ToString());
                    a1 = (dr["A1"].ToString());

                    radioButton5.Text = (dr["Q21"].ToString());
                    radioButton6.Text = (dr["Q22"].ToString());
                    radioButton7.Text = (dr["Q23"].ToString());
                    radioButton8.Text = (dr["Q24"].ToString());
                    a2 = (dr["A2"].ToString());

                    radioButton9.Text = (dr["Q31"].ToString());
                    radioButton10.Text = (dr["Q32"].ToString());
                    radioButton11.Text = (dr["Q33"].ToString());
                    radioButton12.Text = (dr["Q34"].ToString());
                    a3 = (dr["A3"].ToString());
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
            this.Hide();
            DashboardPage dashboard = new DashboardPage(Id);
            dashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1 )
            {
                listPanel[++index].BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(index > 0)
            {
                listPanel[--index].BringToFront();
            }
        }

       // private void panel4_Paint(object sender, PaintEventArgs e)
       // {

       // }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            TakeExamPage takeExam = new TakeExamPage(Id);
            takeExam.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true && radioButton1.Text == a1)
            {
                mark++;
                //a1 = radioButton1.Text;
            }
            else if(radioButton2.Checked == true && a1 == radioButton2.Text)
            {
                mark++;
            }
            else if (radioButton3.Checked == true && a1 == radioButton3.Text)
            {
                mark++;
            }
            else if (radioButton4.Checked == true && a1 == radioButton4.Text)
            {
                mark++;
            }

            if (radioButton5.Checked == true && a2 == radioButton5.Text)
            {
               mark++;
            }
            else if (radioButton6.Checked == true && a2 == radioButton6.Text)
            {
                mark++;
            }
            else if (radioButton7.Checked == true && a2 == radioButton7.Text)
            {
                mark++;
            }
            else if (radioButton8.Checked == true && a2 == radioButton8.Text)
            {
                mark++;
            }

            if (radioButton9.Checked == true && a3 == radioButton9.Text)
            {
                mark++;
            }
            else if (radioButton10.Checked == true && a3 == radioButton10.Text)
            {
                mark++;
            }
            else if (radioButton11.Checked == true && a3 == radioButton11.Text)
            {
               mark++;
            }
            else if (radioButton12.Checked == true && a3 == radioButton12.Text)
            {
                mark++;
            }

            string s1 = "";
            string s2 = "";
            string s3= "";

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                con.Open();

                string newcon = "select  * from signuptable1 where ID='" + Id + "'";

                SqlCommand cmd = new SqlCommand(newcon, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    s1 = (dr["Totalmark"].ToString());
                    s2 = (dr["Examno"].ToString());
                    s3 = (dr["Rating"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int totalMark = Int32.Parse(s1);
            int examNo = Int32.Parse(s2);
            float rating = float.Parse(s3);

            totalMark += mark;
            examNo++;
            rating = (float)totalMark / (float)examNo;

            s1 = totalMark.ToString();
            s2 = examNo.ToString();
            s3 = rating.ToString();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                con.Open();

                string newcon = "update signuptable1 set Totalmark='" + s1 + "',Examno='" + s2 + "',Rating='" + s3 + "' where ID='" + Id + "';";

                SqlCommand cmd = new SqlCommand(newcon, con);

                SqlDataReader dr = cmd.ExecuteReader();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            this.Hide();
            ResultPage resultPage = new ResultPage(course, Id, mark);
            resultPage.Show();
        }
    }
}
