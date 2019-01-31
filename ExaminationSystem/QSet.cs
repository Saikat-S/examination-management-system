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
    public partial class QSet : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;
        public QSet()
        {
            InitializeComponent();
        }
        private void QSet_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
           // index = 0;
            listPanel[index].BringToFront();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=your_id;Password=you_pass");
                con.Open();

                // string newcon = "insert into qsettable(Semester,Course,Q1, Q2, Q3) VALUES ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "')";
                string newcon = "insert into qsettable2(Semester,Course,Q1,Q11,Q12,Q13,Q14,A1,Q2,Q21,Q22,Q23,Q24,A2,Q3,Q31,Q32,Q33,Q34,A3) VALUES ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox12.Text + "', '" + textBox11.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox18.Text + "', '" + textBox17.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + textBox13.Text + "','" + textBox14.Text + "')";

                SqlCommand cmd = new SqlCommand(newcon, con);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Question Set Seccessfuly");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                listPanel[--index].BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
            {
                listPanel[++index].BringToFront();
            }
        }
    }
}
