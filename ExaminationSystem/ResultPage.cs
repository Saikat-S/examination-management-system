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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ExaminationSystem
{
    public partial class ResultPage : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index = 1;
        public static string Id = "";
        public string course = "";
        public int mark;
        public ResultPage(string cr, string st, int mark)
        {
            course = cr;
            Id = st;
            this.mark = mark;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardPage dashboard = new DashboardPage(Id);
            dashboard.Show();
        }

        private void ResultPage_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            listPanel.Add(panel4);
            // index = 0;
            listPanel[0].BringToFront();
            label2.Text = mark.ToString();

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JT5TE1G\\SQLEXPRESS;Initial Catalog=signup;User ID=your_id;Password=you_pass");
                con.Open();

                string newcon = "select  * from qsettable2 where Course='" + course + "'";

                SqlCommand cmd = new SqlCommand(newcon, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    label3.Text = (dr["Q1"].ToString());
                    label5.Text = (dr["A1"].ToString());

                    label7.Text = (dr["Q2"].ToString());
                    label6.Text = (dr["A2"].ToString());

                    label10.Text = (dr["Q3"].ToString());
                    label9.Text = (dr["A3"].ToString());

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (index > 1)
            {
                listPanel[--index].BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
            {
                listPanel[++index].BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listPanel[1].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(course+".pdf", FileMode.Create));
                doc.Open();
                Paragraph title = new Paragraph("                             Course  " + course + "  Answer Sheet\n\n");
                Paragraph para1 = new Paragraph("Question 1 : " + label3.Text + "\n Answer : " + label5.Text + "\n\n" + "Question 2 : " + label7.Text + "\n Answer : " + label6.Text + "\n\n" + "Question 3 : " + label10.Text + "\n Answer : " + label9.Text + "\n\n");

                doc.Add(title);
                doc.Add(para1);
       
                doc.Close();

                MessageBox.Show("Your answer Downloaded!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
