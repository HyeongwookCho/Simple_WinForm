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

        private string connString = "Data Source=DESKTOP-PLI5MTR\\SQLEXPRESS;Initial Catalog=TestDB;User ID=sa;Password=1234";
        public Form1()
        {
            InitializeComponent();
            this.Load += Form_Load;
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

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();

                string viewQuery = @"SELECT * FROM userTBL";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = viewQuery;
                cmd.Connection = connection;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet ds = new System.Data.DataSet();
                adapter.Fill(ds, "userTBL");
                

                dataGridView1.DataSource = ds.Tables["userTBL"];

                //userID는 수정 불가합니다.
                dataGridView1.Columns[0].ReadOnly = true;
                // 첫 번째 열의 배경색을 변경(수정 불가를 표시)
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.IndianRed;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "에러!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 선택된 행 가져오기
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;

                if (selectedRow != null)
                {
                    // 데이터베이스에서 해당 행 삭제
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        
                        string userID = selectedRow.Cells["userID"].Value.ToString();

                        string deleteQuery = "DELETE FROM userTBL WHERE userID = @userID";

                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@userID", userID);

                        deleteCommand.ExecuteNonQuery();
                        
                    }
                    // DataGridView에서 선택된 행 삭제
                    dataGridView1.Rows.Remove(selectedRow);

                    MessageBox.Show("데이터가 삭제되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["userID"].Value != null && row.Cells["userID"].Value.ToString() != "")
                        {
                            string userID = row.Cells["userID"].Value.ToString();
                            string newName = row.Cells["name"].Value.ToString();
                            int newBirthYear = Convert.ToInt32(row.Cells["birthYear"].Value);
                            string newAddr = row.Cells["addr"].Value.ToString();
                            string newmobile1 = row.Cells["mobile1"].Value.ToString();
                            int newheight = Convert.ToInt32(row.Cells["height"].Value);
                            // 업데이트 쿼리
                            string updateQuery = "UPDATE userTBL SET name = @name, birthYear = @birthYear, addr = @addr, mobile1 = @mobile1, height = @height WHERE userID = @userID";

                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@userID", userID);
                            updateCommand.Parameters.AddWithValue("@name", newName);
                            updateCommand.Parameters.AddWithValue("@birthYear", newBirthYear);
                            updateCommand.Parameters.AddWithValue("@addr", newAddr);
                            updateCommand.Parameters.AddWithValue("@mobile1", newmobile1);
                            updateCommand.Parameters.AddWithValue("@height", newheight);

                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("변경 사항이 데이터베이스에 저장되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
