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
using log4net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using static System.IO.Directory;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string connString = "Data Source=DESKTOP-PLI5MTR\\SQLEXPRESS;Initial Catalog=TestDB;User ID=sa;Password=1234";

        public Form1()
        {
            log.Info("Form1 Start");
            InitializeComponent();
            this.Load += Form_Load;
            
            this.FormClosing += Form1_FormClosing;
        }
        // 프로그램 시작 후 Datagridview 로드
        private void Form_Load(object sender, EventArgs e)
        {
            log.Debug(MethodBase.GetCurrentMethod().Name + "() Start");
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Success");

                    string viewQuery = @"SELECT * FROM userTBL";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = viewQuery;
                    cmd.Connection = connection;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    DataSet ds = new System.Data.DataSet();
                    adapter.Fill(ds, "userTBL");


                    dataGridView1.DataSource = ds.Tables["userTBL"];

                    //userID는 수정 불가
                    dataGridView1.Columns[0].ReadOnly = true;
                    // 첫 번째 열의 배경색을 변경(수정 불가를 표시)
                    dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.IndianRed;

                }
            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
                MessageBox.Show(ex.ToString(), "에러!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //**데이터 입력받기**
        private void submitButton_Click(object sender, EventArgs e)
        {
            log.Debug(MethodBase.GetCurrentMethod().Name + "() Start");
            try
            {
                // 필수 데이터 공백 검사
                if (String.IsNullOrWhiteSpace(userIDTextBox.Text) ||
                    String.IsNullOrWhiteSpace(nameTextBox.Text) ||
                    String.IsNullOrWhiteSpace(birthYearTextBox.Text) ||
                    String.IsNullOrWhiteSpace(addrTextBox.Text))
                {
                    log.Warn(MethodBase.GetCurrentMethod().Name + "() 공백검사 경고");
                    MessageBox.Show("필수 입력 양식 입니다.");
                    return; // 필수 데이터가 비어있으면 더 이상 진행하지 않고 종료
                }

                // 데이터 입력 형식 검사
                bool isValidData = IsValidUserID(userIDTextBox.Text) &&
                    IsValidName(nameTextBox.Text) &&
                    IsValidBirthYear(birthYearTextBox.Text) &&
                    IsValidAddr(addrTextBox.Text);

                if (!isValidData)
                {
                    log.Warn(MethodBase.GetCurrentMethod().Name + "() 필수 입력 데이터 입력 형식 경고");
                    MessageBox.Show("입력 형식이 올바르지 않습니다. 각 항목의 형식을 확인해 주세요. \n" +
                        "사용자ID : 최대 8자의 영문자 \n" +
                        "이름 : 최대 10자 \n" +
                        "출생연도 : 4자리 숫자 \n" +
                        "지역 : 2자리 문자 (ex. 서울, 경기)");
                    return; // 데이터 형식이 올바르지 않으면 종료
                }

                string mobile1 = mobile1TextBox.Text.Trim();
                string height = heightTextBox.Text.Trim();

                // 전화번호 데이터 형식 검사
                if (!String.IsNullOrWhiteSpace(mobile1) && !IsValidMobileNumber(mobile1))
                {
                    log.Warn(MethodBase.GetCurrentMethod().Name + "() 전화번호 데이터 입력 형식 경고");
                    MessageBox.Show("전화번호의 입력 형식이 올바르지 않습니다. \n ' - ' 를 제외한 숫자 11자리를 입력해주세요.");
                    return; // 전화번호 형식이 올바르지 않으면 종료
                }

                // 키 데이터 형식 검사
                if (!String.IsNullOrWhiteSpace(height) && !IsValidHeight(height))
                {
                    log.Warn(MethodBase.GetCurrentMethod().Name + "() 키 데이터 입력 형식 경고");
                    MessageBox.Show("키의 입력 형식이 올바르지 않습니다. 숫자만을 입력해주세요.");
                    return; // 키 형식이 올바르지 않으면 종료
                }

                Form2 f2 = new Form2();

                f2.TextBox1Value = userIDTextBox.Text;
                f2.TextBox2Value = nameTextBox.Text;
                f2.TextBox3Value = birthYearTextBox.Text;
                f2.TextBox4Value = addrTextBox.Text;
                f2.TextBox5Value = String.IsNullOrWhiteSpace(mobile1) ? "null" : mobile1;
                f2.TextBox6Value = String.IsNullOrWhiteSpace(height) ? "0" : height;

                log.Debug(MethodBase.GetCurrentMethod().Name + "Submit Insert Data To Form2");
                f2.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
            }
            finally
            {

            }
            log.Debug(MethodBase.GetCurrentMethod().Name + "() End");
        }



        // 각 항목에 대한 데이터 형식 검사 메서드를 추가
        private bool IsValidUserID(string userID)
        {
            // DB data type은 char 이므로  문자열 내의 모든 문자가 영문자인지 검사
            bool IsCheck = true;

            Regex engRegex = new Regex(@"[a-zA-Z]");
            Boolean ismatch = engRegex.IsMatch(userID);

            if (!ismatch)
            {
                IsCheck = false;
            }

            return IsCheck && userID.Length <= 8;
        }

        private bool IsValidName(string name)
        {
            // 이름이 최대 10자리 문자열인지 검사
            return name.Length <= 10;
        }

        private bool IsValidBirthYear(string birthYear)
        {
            // 출생연도가 4자리 숫자인지 검사
            int year;
            return int.TryParse(birthYear, out year) && birthYear.Length == 4;
        }

        private bool IsValidAddr(string addr)
        {
            // 지역이 최대 2자리 문자열인지 검사
            return addr.Length == 2;
        }

        private bool IsValidMobileNumber(string mobileNumber)
        {
            // 전화번호가 11자리 숫자인지 검사
            long number;
            return long.TryParse(mobileNumber, out number) && mobileNumber.Length == 11;
        }

        private bool IsValidHeight(string height)
        {
            // 키가 숫자인지 검사
            int value;
            return int.TryParse(height, out value);
        }

        //삭제 버튼 동작 시
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            log.Debug(MethodBase.GetCurrentMethod().Name + "() Start");
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
                        log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Success");

                        string userID = selectedRow.Cells["userID"].Value.ToString();

                        string deleteQuery = "DELETE FROM userTBL WHERE userID = @userID";

                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@userID", userID);
                        log.Debug(MethodBase.GetCurrentMethod().Name + "() Delete Success");
                        deleteCommand.ExecuteNonQuery();
                        
                    }
                    // DataGridView에서 선택된 행 삭제
                    dataGridView1.Rows.Remove(selectedRow);

                    MessageBox.Show("데이터가 삭제되었습니다.");
                }
            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
                MessageBox.Show(ex.ToString(), "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
            log.Debug(MethodBase.GetCurrentMethod().Name + "() End");
        }



        private void UpdateButton_Click(object sender, EventArgs e)
        {
            log.Debug(MethodBase.GetCurrentMethod().Name + "() Start");
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Success");


                    // 선택된 행 가져오기
                    DataGridViewRow selectedRow = dataGridView1.CurrentRow;

                    if (selectedRow.Cells["userID"].Value != null && selectedRow.Cells["userID"].Value.ToString() != "")
                    {
                        string userID = selectedRow.Cells["userID"].Value.ToString();
                        string newName = selectedRow.Cells["name"].Value.ToString();
                        int newBirthYear = Convert.ToInt32(selectedRow.Cells["birthYear"].Value);
                        string newAddr = selectedRow.Cells["addr"].Value.ToString();
                        string newmobile1 = selectedRow.Cells["mobile1"].Value.ToString();
                        int newheight = Convert.ToInt32(selectedRow.Cells["height"].Value);
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


                    MessageBox.Show("변경 사항이 데이터베이스에 저장되었습니다.");
                }
            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
                MessageBox.Show(ex.ToString(), "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

            log.Debug(MethodBase.GetCurrentMethod().Name + "() End");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 폼이 종료될 때 종료 로깅을 추가
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // 사용자에 의한 종료인 경우에만 로그 기록
                log.Info("프로그램이 사용자에 의해 종료되었습니다.");
            }
            else
            {
                log.Info("프로그램이 강제 종료되었습니다.");
            }
        }

        public void UpdateDataGridView()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Success");
                string viewQuery = @"SELECT * FROM userTBL";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = viewQuery;
                cmd.Connection = connection;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet ds = new System.Data.DataSet();
                adapter.Fill(ds, "userTBL");
                
                dataGridView1.DataSource = ds.Tables["userTBL"];
                log.Debug(MethodBase.GetCurrentMethod().Name + "Data Rebinding Success");
                //userID는 수정 불가합니다.
                dataGridView1.Columns[0].ReadOnly = true;
                // 첫 번째 열의 배경색을 변경(수정 불가를 표시)
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.IndianRed;
            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
                MessageBox.Show(ex.ToString(), "에러!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToTextFile_Button_Click(object sender, EventArgs e)
        {
            //파일 저장 위치
            string dir = @"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\bin\Export";
            // 디렉토리 일자별 구분을 위한 현재 연,월,일 파싱

            DateTime currentDateTime = DateTime.Now;

            string year = currentDateTime.ToString("yyyy");
            string month = currentDateTime.ToString("MM");
            string day = currentDateTime.ToString("dd");
            string hour = currentDateTime.ToString("HH");
            string minute = currentDateTime.ToString("mm");
            string second = currentDateTime.ToString("ss");
            string milli = currentDateTime.ToString("FFF");

            string year_dir = @"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\bin\Export\" + year;
            string month_dir = @"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\bin\Export\" + year + @"\" + month;
            string filePathString = $"{year}-{month}-{day}-{hour}-{minute}-{second}-{milli}.txt";
            string fullFilePath = Path.Combine(month_dir, filePathString);
            try
            {
                // Export 디렉토리 존재 여부 확인
                if (!Exists(dir))
                {
                    CreateDirectory(dir);
                }

                // year 디렉토리 존재 여부 확인
                if (!Exists(year_dir))
                {
                    CreateDirectory(year_dir);
                }

                // month 디렉토리 존재 여부 확인
                if (!Exists(month_dir))
                {
                    CreateDirectory(month_dir);
                }

                // 데이터베이스 연결 및 데이터 추출
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    log.Info(MethodBase.GetCurrentMethod().Name + " DB Connection Execution");
                    connection.Open();
                    log.Info(MethodBase.GetCurrentMethod().Name + " DB Connection Success");

                    SqlCommand cmd = new SqlCommand();
                    string viewQuery = "SELECT * FROM userTBL;";
                    cmd.Connection = connection;
                    cmd.CommandText = viewQuery;
                    log.Info(MethodBase.GetCurrentMethod().Name + " DB to Text Execution");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        StringBuilder sb = new StringBuilder();
                        while (reader.Read()) // 모든 행 읽기
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                sb.Append(reader[i].ToString() + "\t"); // 각 컬럼을 \t 구분자와 함께 StringBuilder에 추가
                            }
                            sb.AppendLine();
                        }
                        Console.WriteLine(sb.ToString());
                        log.Info(MethodBase.GetCurrentMethod().Name + " DB to Text Success");

                        // 파일에 데이터 쓰기 (이어쓰기 없음)
                        using (StreamWriter writer = new StreamWriter(fullFilePath, false))
                        {
                            writer.Write(sb.ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
                MessageBox.Show(ex.ToString(), "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
            log.Debug(MethodBase.GetCurrentMethod().Name + "() End");

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 파일 대화 상자 설정
            openFileDialog.Title = "파일 선택"; // 대화 상자 제목
            openFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*"; // 파일 필터
            openFileDialog.FilterIndex = 1; // 기본으로 선택될 필터 인덱스
            openFileDialog.RestoreDirectory = true; // 마지막 디렉토리 기억

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 사용자가 파일을 선택하고 확인을 누르면 선택한 파일 경로를 가져오기
                string selectedFilePath = openFileDialog.FileName;

                // 선택한 파일을 읽어온 후 데이터베이스에 삽입
                try
                {
                    log.Debug("찾은 파일의 데이터 읽기 시작");
                    List<string[]> InsertdataList = new List<string[]>();

                    using (StreamReader reader = new StreamReader(selectedFilePath))
                    {
                        string line;
                        log.Debug("데이터 파싱 시작 및 삽입 시작");
                        while ((line = reader.ReadLine()) != null)
                        {
                            // 각 라인을 파싱하여 데이터베이스에 삽입
                            string[] values = line.Split('\t');
                            InsertdataList.Add(values); // 리스트에 string[] 삽입
                        }
                        log.Debug("데이터 파싱 시작 및 삽입 완료");
                    }
                    InsertDataIntoDatabase(InsertdataList);
                    MessageBox.Show("데이터 삽입 완료");
                    showDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류 발생: " + ex.Message, "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showDataGrid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Execution");
                connection.Open();
                log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Success");

                string selectQuery = "SELECT * FROM InsertTBL";

                SqlCommand command = new SqlCommand(selectQuery, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dt);
            }
            dataGridView2.DataSource = dt;
        }

        // 데이터베이스에 Text file 데이터를 삽입하는 메서드
        private void InsertDataIntoDatabase(List<string[]> InsertdataList)
        {            
            
            using (SqlConnection connection = new SqlConnection(connString))
            {
                log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Execution");
                connection.Open();
                log.Info(MethodBase.GetCurrentMethod().Name + "DB Connection Success");

                string InsertQuery = "INSERT INTO InsertTBL (userID, name, birthYear, addr, mobile1, height) " +
                                     "VALUES (@userID, @name, @birthYear, @addr, @mobile1, @height)";

                SqlCommand command = new SqlCommand(InsertQuery, connection);

                //파라미터 추가
                foreach (var values in InsertdataList)
                {
                    command.Parameters.AddWithValue("@userID", values[0]);
                    command.Parameters.AddWithValue("@name", values[1]);
                    command.Parameters.AddWithValue("@birthYear", int.Parse(values[2]));
                    command.Parameters.AddWithValue("@addr", values[3]);
                    command.Parameters.AddWithValue("@mobile1", values[4]);
                    command.Parameters.AddWithValue("@height", int.Parse(values[5]));

                    // 쿼리 실행
                    log.Info(MethodBase.GetCurrentMethod().Name + "DB ExecuteNonQuery");
                    command.ExecuteNonQuery();
                    log.Info(MethodBase.GetCurrentMethod().Name + "DB ExecuteNonQuery Success");

                    //파라미터 초기화
                    command.Parameters.Clear();
                }                        
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //로그 뷰어
                //현재 날짜의 로그 파일 연결
                //로그 파일 저장 위치
                string log_dir = @"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\bin\Debug\logs";

                DateTime currentDateTime = DateTime.Now;

                string year = currentDateTime.ToString("yyyy");
                string month = currentDateTime.ToString("MM");
                string day = currentDateTime.ToString("dd");

                string year_log_dir = Path.Combine(log_dir, year);
                string month_log_dir = Path.Combine(year_log_dir, month);
                string logString = $"{year}-{month}-{day}.log";
                string fullFilePath = Path.Combine(month_log_dir, logString);
                
                // 로깅 중단(프로세스 빼앗기)
                // 중단 이후의 발생된 로그는 어떻게 하지... 
                log.Logger.Repository.Shutdown();
                
                StringBuilder sb = new StringBuilder();

                if (!Exists(log_dir))
                {
                    MessageBox.Show("로그가 존재하지 않습니다.");
                    return;
                }

                if (!Exists(year_log_dir))
                {
                    MessageBox.Show("해당 연도의 로그가 존재하지 않습니다.");
                    return;
                }

                if (!Exists(month_log_dir))
                {
                    MessageBox.Show("해당 월의 로그가 존재하지 않습니다.");
                    return;
                }

                if (!File.Exists(fullFilePath))
                {
                    MessageBox.Show("로그 파일 찾기 실패");
                    return;
                }

                using (StreamReader reader = new StreamReader(fullFilePath))
                {
                    while (reader.ReadLine() != null)
                    {
                        sb.AppendLine(reader.ReadLine());
                    }
                    reader.Close();
                }

                textBox1.Text = sb.ToString();


            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
                MessageBox.Show(ex.ToString(), "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
            log.Debug(MethodBase.GetCurrentMethod().Name + "() End");

        }        

    }
}
