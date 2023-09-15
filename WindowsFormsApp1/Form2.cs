﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //table column declare
            string userID = TextBox1Value;
            string name = TextBox2Value;
            int birthYear = int.Parse(TextBox3Value); // birth to int
            string addr = TextBox4Value;
            string mobile1 = TextBox5Value;
            int height = int.Parse(TextBox6Value); // height to int

            //DB connection
            string connString = "Data Source=DESKTOP-PLI5MTR\\SQLEXPRESS;Initial Catalog=TestDB;User ID=sa;Password=1234";
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            string sql = "INSERT INTO userTBL (userID, name, birthYear, addr, mobile1, height) " +
                                 "VALUES (@UserID, @Name, @BirthYear, @Addr, @Mobile1, @Height)";

            SqlCommand command = new SqlCommand(sql, connection);

            //파라미터 추가
            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@BirthYear", birthYear);
            command.Parameters.AddWithValue("@Addr", addr);
            command.Parameters.AddWithValue("@Mobile1", mobile1);
            command.Parameters.AddWithValue("@Height", height);

            // 쿼리 실행
            command.ExecuteNonQuery();

            MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");

            connection.Close();
            this.Close();
        }
        // Property textBox value get / set
        public string TextBox1Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string TextBox2Value
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string TextBox3Value
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string TextBox4Value
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string TextBox5Value
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }
        public string TextBox6Value
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
