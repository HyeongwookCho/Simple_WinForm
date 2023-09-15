using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            

            // 필수 데이터 공백 검사
            if (String.IsNullOrWhiteSpace(userIDTextBox.Text) &&
                String.IsNullOrWhiteSpace(nameTextBox.Text) &&
                String.IsNullOrWhiteSpace(birthYearTextBox.Text) &&
                String.IsNullOrWhiteSpace(addrTextBox.Text))
            {
                MessageBox.Show("필수 입력 양식 입니다.");
            }
            else
            {
                Form2 f2 = new Form2();

                f2.TextBox1Value = userIDTextBox.Text;
                f2.TextBox2Value = nameTextBox.Text;
                f2.TextBox3Value = birthYearTextBox.Text;
                f2.TextBox4Value = addrTextBox.Text;
                f2.TextBox5Value = mobile1TextBox.Text;
                f2.TextBox6Value = heightTextBox.Text;

                f2.ShowDialog();
            }
            
           
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-PLI5MTR\\SQLEXPRESS;Initial Catalog=TestDB;User ID=sa;Password=1234";
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            string sql = "SELECT * FROM userTBL";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "userTBL");

            dataGridView1.DataSource = ds.Tables["userTBL"];

        }
    }
}
