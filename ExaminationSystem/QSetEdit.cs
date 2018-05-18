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
    public partial class QSetEdit : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;
        public string course;
        public QSetEdit()
        {
            InitializeComponent();
        }
        private void QSetEdit_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            // index = 0;
            listPanel[index].BringToFront();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                listPanel[--index].BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
            {
                listPanel[++index].BringToFront();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = comboBox1.Text;
            if (str == "1st Year 1st Semester")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CSE-1101");
                comboBox2.Items.Add("CSE-1103");
                comboBox2.Items.Add("CSE-1105");
                comboBox2.Items.Add("CSE-1107");
                comboBox2.Items.Add("CSE-1109");
            }
            else if (str == "1st Year 2nd Semester")
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                con.Open();

                // string newcon = "insert into qsettable(Semester,Course,Q1, Q2, Q3) VALUES ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "')";
                string newcon = "update qsettable2 set Semester='" + comboBox1.Text + "',Course='" + comboBox2.Text + "',Q1='" + textBox1.Text + "',Q11='" + textBox2.Text + "',Q12='" + textBox3.Text + "',Q13='" + textBox4.Text + "',Q14='" + textBox5.Text + "',A1='" + textBox6.Text + "',Q2='" + textBox12.Text + "',Q21='" + textBox11.Text + "',Q22='" + textBox10.Text + "',Q23='" + textBox9.Text + "',Q24='" + textBox8.Text + "',A2='" + textBox7.Text + "',Q3='" + textBox18.Text + "',Q31='" + textBox17.Text + "',Q32='" + textBox16.Text + "',Q33='" + textBox15.Text + "',Q34='" + textBox14.Text + "',A3='" + textBox13.Text + "' where Course='" + course + "';";

                SqlCommand cmd = new SqlCommand(newcon, con);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Question Save Seccessfuly");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            course = comboBox2.Text;
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=sa;Password=369@saikat");
                con.Open();

                string newcon = "select  * from qsettable2 where Course='" + course + "'";

                SqlCommand cmd = new SqlCommand(newcon, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textBox1.Text = (dr["Q1"].ToString());
                    textBox2.Text = (dr["Q11"].ToString());
                    textBox3.Text = (dr["Q12"].ToString());
                    textBox4.Text = (dr["Q13"].ToString());
                    textBox5.Text = (dr["Q14"].ToString());
                    textBox6.Text = (dr["A1"].ToString());

                    textBox12.Text = (dr["Q2"].ToString());
                    textBox11.Text = (dr["Q21"].ToString());
                    textBox10.Text = (dr["Q22"].ToString());
                    textBox9.Text = (dr["Q23"].ToString());
                    textBox8.Text = (dr["Q24"].ToString());
                    textBox7.Text = (dr["A2"].ToString());

                    textBox18.Text = (dr["Q3"].ToString());
                    textBox17.Text = (dr["Q31"].ToString());
                    textBox16.Text = (dr["Q32"].ToString());
                    textBox15.Text = (dr["Q33"].ToString());
                    textBox14.Text = (dr["Q34"].ToString());
                    textBox13.Text = (dr["A3"].ToString());


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
