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
using log4net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using static System.IO.Directory;
using System.Threading;
using log4net.Config;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using Timer = System.Windows.Forms.Timer;
using log4net.Core;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string connString = "Data Source=DESKTOP-PLI5MTR\\SQLEXPRESS;Initial Catalog=TestDB; User ID=sa;Password=1234";

        private MemoryAppender memoryAppender;

        Timer timer_batch = new Timer();
        Timer timer_log = new Timer();
        public Form1()
        {
            log.Info("Program Start");
            
            InitializeComponent();

            this.Load += Form_Load;

            // log4net 에서 memoryAppender를 이용
            // read/write가 아닌 memory 상에 저장된 로그를 textbox에 전달            

            // log4net 설정 파일을 읽기
            XmlConfigurator.Configure(new System.IO.FileInfo(@"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\log4net.config"));
            
            // MemoryAppender 가져오기
            memoryAppender = ((Hierarchy)LogManager.GetRepository())
                .GetAppenders()
                .OfType<MemoryAppender>()
                .FirstOrDefault();
            

            // Timer를 설정 => 일정 간격으로 로그를 TextBox에 표시            
            timer_log.Interval = 500; // 0.5초마다 업데이트
            timer_log.Tick += Print_log;
            timer_log.Start();

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

                    //환경설정
                    loadJson();
                    //배치 주기
                    string[] batchTime = {"1","3","5","10","30","60"};

                    batchTimer.Items.AddRange(batchTime);
                    // 설정파일에서 배치주기 넣기
                    batchTimer.SelectedItem = getTimer;

                    // 파일 경로 default
                    logFileDirectoryTextBox.Text = getLogFileDirectory;
                    autoExportDirectoryTextBox.Text = getAutoExportDirectory;
                }
            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + "() - " + ex.Message);
                MessageBox.Show(ex.ToString(), "에러!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadJson()
        {
            string path = @"C:\Users\조형욱\source\repos\Solution1\winformConfig.json";

            var json = File.ReadAllText(path);
            var jObject = JObject.Parse(json);

            getTimer = (string)jObject["timer"];
            getLogFileDirectory = (string)jObject["Log File Directory"]+"\\";            
            getAutoExportDirectory = (string)jObject["Export File Directory"];

        }
        private string getTimer { get; set; }
        private string getLogFileDirectory { get; set; }
        private string getAutoExportDirectory { get; set; }
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
                    return;
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
                    return;
                }

                string mobile1 = mobile1TextBox.Text.Trim();
                string height = heightTextBox.Text.Trim();

                // 전화번호 데이터 형식 검사
                if (!String.IsNullOrWhiteSpace(mobile1) && !IsValidMobileNumber(mobile1))
                {
                    log.Warn(MethodBase.GetCurrentMethod().Name + "() 전화번호 데이터 입력 형식 경고");
                    MessageBox.Show("전화번호의 입력 형식이 올바르지 않습니다. \n ' - ' 를 제외한 숫자 11자리를 입력해주세요.");
                    return; 
                }

                // 키 데이터 형식 검사
                if (!String.IsNullOrWhiteSpace(height) && !IsValidHeight(height))
                {
                    log.Warn(MethodBase.GetCurrentMethod().Name + "() 키 데이터 입력 형식 경고");
                    MessageBox.Show("키의 입력 형식이 올바르지 않습니다. 숫자만을 입력해주세요.");
                    return;
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
                //userID는 수정 불가
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
        // 로그 실시간 모니터링
        private void Print_log(object sender, EventArgs e)
        {
            if (memoryAppender != null)
            {
                var events = memoryAppender.GetEvents();
                
                StringBuilder logBuilder = new StringBuilder(textBox1.Text);

                foreach (LoggingEvent loggingEvent in events)
                {
                    // 로그 이벤트를 logBuilder에 추가
                    logBuilder.AppendLine(loggingEvent.RenderedMessage);
                    Console.WriteLine(logBuilder.ToString());
                    // logBuilder의 Line 수 확인
                    string[] lines = logBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    int lineCount = lines.Length;

                    // textBox의 라인 수를 20으로 제한
                    const int maxLines = 20;
                    if (lineCount > maxLines)
                    {
                        // logBuilder에서 초과하는 줄 수를 제거
                        logBuilder = new StringBuilder(string.Join(Environment.NewLine, lines.Skip(lineCount - maxLines)));
                    }
                    
                    // 로그 출력
                    textBox1.Text = logBuilder.ToString();
                }

                // 로그 처리 후 메모리 로그 해제
                memoryAppender.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            log.Info("This is log4net Logging Test A.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.Info("This is log4net Logging Test B.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            log.Info("This is log4net Logging Test C.");
        }






        // ================ 환경 설정 =======================
        private void logFileDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                logFileDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void autoExportDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                autoExportDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void createJson()
        {
            string path = @"C:\Users\조형욱\source\repos\Solution1\winformConfig.json";

            try
            {
                if (!File.Exists(path))
                {
                    using (File.Create(path))
                    {
                        log.Debug("json 파일 생성 성공");
                        MessageBox.Show("파일 생성 성공\n다시 시도해주세요.");
                    }
                }
                else
                {
                    log.Debug("설정값 세팅 시작");
                    InputJson(path, batchTimer.Text, logFileDirectoryTextBox.Text, autoExportDirectoryTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message, "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }        
        private void InputJson(string path, string timer ,string logFileDirectory, string autoExportDirectory)
        {          
            try
            {
                var json = new JObject();
                json.Add("Log File Directory", logFileDirectory);
                json.Add("Export File Directory", autoExportDirectory);
                json.Add("timer", timer);

                string str_json = JsonConvert.SerializeObject(json, Formatting.Indented);

                File.WriteAllText(path, str_json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message, "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        // 환경 설정값 적용 버튼
        private void applybutton_Click(object sender, EventArgs e)
        {
            try
            {
                createJson();
                log4netModify();                

                XmlConfigurator.Configure(new System.IO.FileInfo(@"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\log4net.config"));

                // MemoryAppender 가져오기
                memoryAppender = ((Hierarchy)LogManager.GetRepository())
                    .GetAppenders()
                    .OfType<MemoryAppender>()
                    .FirstOrDefault();

                MessageBox.Show("적용이 완료되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message, "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 파일 추출 자동화 버튼
        private void AutoFileExportButton_Click(object sender, EventArgs e)
        {
            // getTimer 값을 이용하여 타이머 설정
            int interval = int.Parse(getTimer) * 60 * 1000; // 분 단위
            timer_batch.Interval = interval;
            timer_batch.Tick += (s, ev) => autoExporting();
            timer_batch.Start();
            MessageBox.Show("자동 추출 기능을 시작합니다.\n" +
                $"{getTimer} 분 간격");
            autoExportingState.Text = "파일 추출 자동화 진행 중...";
            autoExportingState.ForeColor = Color.Red;
        }

        
        private void autoExporting()
        {            
            try
            {
                DateTime currentDateTime = DateTime.Now;
                loadJson();
                string dir = getAutoExportDirectory;

                string year = currentDateTime.ToString("yyyy");
                string month = currentDateTime.ToString("MM");
                string day = currentDateTime.ToString("dd");
                string hour = currentDateTime.ToString("HH");
                string minute = currentDateTime.ToString("mm");
                string second = currentDateTime.ToString("ss");
                string milli = currentDateTime.ToString("FFF");
                
                string filePathString = $"{year}-{month}-{day}-{hour}-{minute}-{second}-{milli}.txt";
                string fullFilePath = Path.Combine(dir, filePathString);

                                  

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

        private void autoExportingStopButton_Click(object sender, EventArgs e)
        {
            timer_batch.Stop();
            MessageBox.Show("자동 추출 기능이 종료되었습니다.");
            autoExportingState.Text = "파일 추출 자동화 꺼짐";
            autoExportingState.ForeColor = Color.DarkCyan;
        }

        private void log4netModify()
        {
            XmlDocument doc = new XmlDocument();

            // XML file 위치
            doc.Load(@"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\log4net.config");
            XmlNode root = doc.DocumentElement;
            XmlNode subNode1 = root.SelectSingleNode("log4net");
            XmlNode subNode2 = subNode1.SelectSingleNode("appender");
            XmlNode nodeForModify = subNode2.SelectSingleNode("file");

            // 파일 경로 수정
            loadJson();
            nodeForModify.Attributes[0].Value = getLogFileDirectory;

            // XML 저장
            doc.Save(@"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\log4net.config");
        }
    }
}
