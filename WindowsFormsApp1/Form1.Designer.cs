
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.mobile1TextBox = new System.Windows.Forms.TextBox();
            this.birthYearTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.autoExportingState = new System.Windows.Forms.Label();
            this.autoExportingStopButton = new System.Windows.Forms.Button();
            this.AutoFileExportButton = new System.Windows.Forms.Button();
            this.ToTextFile_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.applybutton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.autoExportDirectory = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.autoExportDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.batchTimer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logFileDirectory = new System.Windows.Forms.Button();
            this.logFileDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(14, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(851, 512);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.submitButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(843, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "유저 등록";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.2828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.7172F));
            this.tableLayoutPanel1.Controls.Add(this.heightTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.mobile1TextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.birthYearTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userIDTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addrTextBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 44);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 376);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heightTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.heightTextBox.Location = new System.Drawing.Point(169, 314);
            this.heightTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(612, 29);
            this.heightTextBox.TabIndex = 17;
            // 
            // mobile1TextBox
            // 
            this.mobile1TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mobile1TextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mobile1TextBox.Location = new System.Drawing.Point(169, 252);
            this.mobile1TextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mobile1TextBox.Name = "mobile1TextBox";
            this.mobile1TextBox.Size = new System.Drawing.Size(612, 29);
            this.mobile1TextBox.TabIndex = 16;
            // 
            // birthYearTextBox
            // 
            this.birthYearTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.birthYearTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.birthYearTextBox.Location = new System.Drawing.Point(169, 128);
            this.birthYearTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.birthYearTextBox.Name = "birthYearTextBox";
            this.birthYearTextBox.Size = new System.Drawing.Size(612, 29);
            this.birthYearTextBox.TabIndex = 14;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameTextBox.Location = new System.Drawing.Point(169, 66);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(612, 29);
            this.nameTextBox.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(3, 310);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 66);
            this.label12.TabIndex = 11;
            this.label12.Text = "키";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(3, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 62);
            this.label9.TabIndex = 8;
            this.label9.Text = "전화번호";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(3, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 62);
            this.label8.TabIndex = 7;
            this.label8.Text = "지역*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(3, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 62);
            this.label6.TabIndex = 5;
            this.label6.Text = "출생연도*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 62);
            this.label4.TabIndex = 3;
            this.label4.Text = "이름*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "사용자 ID*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userIDTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userIDTextBox.Location = new System.Drawing.Point(169, 4);
            this.userIDTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(612, 29);
            this.userIDTextBox.TabIndex = 12;
            // 
            // addrTextBox
            // 
            this.addrTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addrTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addrTextBox.Location = new System.Drawing.Point(169, 190);
            this.addrTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.Size = new System.Drawing.Size(612, 29);
            this.addrTextBox.TabIndex = 18;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Silver;
            this.submitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.submitButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.submitButton.ForeColor = System.Drawing.Color.Black;
            this.submitButton.Location = new System.Drawing.Point(707, 428);
            this.submitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(97, 41);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.autoExportingState);
            this.tabPage2.Controls.Add(this.autoExportingStopButton);
            this.tabPage2.Controls.Add(this.AutoFileExportButton);
            this.tabPage2.Controls.Add(this.ToTextFile_Button);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.UpdateButton);
            this.tabPage2.Controls.Add(this.DeleteButton);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(843, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "테이블 뷰어";
            // 
            // autoExportingState
            // 
            this.autoExportingState.AutoSize = true;
            this.autoExportingState.BackColor = System.Drawing.Color.White;
            this.autoExportingState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.autoExportingState.ForeColor = System.Drawing.Color.DarkCyan;
            this.autoExportingState.Location = new System.Drawing.Point(7, 442);
            this.autoExportingState.Name = "autoExportingState";
            this.autoExportingState.Size = new System.Drawing.Size(159, 17);
            this.autoExportingState.TabIndex = 8;
            this.autoExportingState.Text = "파일 추출 자동화 꺼짐";
            // 
            // autoExportingStopButton
            // 
            this.autoExportingStopButton.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.autoExportingStopButton.Location = new System.Drawing.Point(727, 434);
            this.autoExportingStopButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autoExportingStopButton.Name = "autoExportingStopButton";
            this.autoExportingStopButton.Size = new System.Drawing.Size(104, 38);
            this.autoExportingStopButton.TabIndex = 7;
            this.autoExportingStopButton.Text = "STOP";
            this.autoExportingStopButton.UseVisualStyleBackColor = true;
            this.autoExportingStopButton.Click += new System.EventHandler(this.autoExportingStopButton_Click);
            // 
            // AutoFileExportButton
            // 
            this.AutoFileExportButton.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AutoFileExportButton.Location = new System.Drawing.Point(571, 434);
            this.AutoFileExportButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoFileExportButton.Name = "AutoFileExportButton";
            this.AutoFileExportButton.Size = new System.Drawing.Size(149, 38);
            this.AutoFileExportButton.TabIndex = 5;
            this.AutoFileExportButton.Text = "Auto Export";
            this.AutoFileExportButton.UseVisualStyleBackColor = true;
            this.AutoFileExportButton.Click += new System.EventHandler(this.AutoFileExportButton_Click);
            // 
            // ToTextFile_Button
            // 
            this.ToTextFile_Button.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ToTextFile_Button.Location = new System.Drawing.Point(474, 434);
            this.ToTextFile_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToTextFile_Button.Name = "ToTextFile_Button";
            this.ToTextFile_Button.Size = new System.Drawing.Size(90, 38);
            this.ToTextFile_Button.TabIndex = 4;
            this.ToTextFile_Button.Text = "Export";
            this.ToTextFile_Button.UseVisualStyleBackColor = true;
            this.ToTextFile_Button.Click += new System.EventHandler(this.ToTextFile_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "User List";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UpdateButton.Location = new System.Drawing.Point(741, 5);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(90, 42);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Save";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DeleteButton.Location = new System.Drawing.Point(643, 5);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(90, 42);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(1, 51);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(835, 375);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(843, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Text->DB 삽입";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "userTBL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(729, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "파일 찾기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 45);
            this.label3.TabIndex = 1;
            this.label3.Text = "TestDB.userTBL에 삽입할 .txt 데이터를 입력해주세요.\r\n\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(27, 88);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(787, 371);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(843, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "로그 뷰어";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(662, 460);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "실시간 모니터링 중...";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(842, 479);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.applybutton);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.panel3);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(843, 483);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "환경 설정";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // applybutton
            // 
            this.applybutton.Location = new System.Drawing.Point(742, 451);
            this.applybutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applybutton.Name = "applybutton";
            this.applybutton.Size = new System.Drawing.Size(95, 26);
            this.applybutton.TabIndex = 2;
            this.applybutton.Text = "적용";
            this.applybutton.UseVisualStyleBackColor = true;
            this.applybutton.Click += new System.EventHandler(this.applybutton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "배치 프로세스";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.autoExportDirectory);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.autoExportDirectoryTextBox);
            this.panel3.Controls.Add(this.batchTimer);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(47, 198);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 188);
            this.panel3.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(241, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "분";
            // 
            // autoExportDirectory
            // 
            this.autoExportDirectory.Location = new System.Drawing.Point(614, 138);
            this.autoExportDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.autoExportDirectory.Name = "autoExportDirectory";
            this.autoExportDirectory.Size = new System.Drawing.Size(95, 26);
            this.autoExportDirectory.TabIndex = 1;
            this.autoExportDirectory.Text = "찾아보기..";
            this.autoExportDirectory.UseVisualStyleBackColor = true;
            this.autoExportDirectory.Click += new System.EventHandler(this.autoExportDirectory_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "배치 주기";
            // 
            // autoExportDirectoryTextBox
            // 
            this.autoExportDirectoryTextBox.Location = new System.Drawing.Point(27, 138);
            this.autoExportDirectoryTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.autoExportDirectoryTextBox.Name = "autoExportDirectoryTextBox";
            this.autoExportDirectoryTextBox.Size = new System.Drawing.Size(565, 25);
            this.autoExportDirectoryTextBox.TabIndex = 0;
            // 
            // batchTimer
            // 
            this.batchTimer.FormattingEnabled = true;
            this.batchTimer.Location = new System.Drawing.Point(114, 40);
            this.batchTimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.batchTimer.Name = "batchTimer";
            this.batchTimer.Size = new System.Drawing.Size(121, 23);
            this.batchTimer.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "DB -> Text File 추출 위치";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "로그 파일 위치";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.logFileDirectory);
            this.panel1.Controls.Add(this.logFileDirectoryTextBox);
            this.panel1.Location = new System.Drawing.Point(47, 90);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 75);
            this.panel1.TabIndex = 0;
            // 
            // logFileDirectory
            // 
            this.logFileDirectory.Location = new System.Drawing.Point(614, 25);
            this.logFileDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFileDirectory.Name = "logFileDirectory";
            this.logFileDirectory.Size = new System.Drawing.Size(95, 26);
            this.logFileDirectory.TabIndex = 1;
            this.logFileDirectory.Text = "찾아보기..";
            this.logFileDirectory.UseVisualStyleBackColor = true;
            this.logFileDirectory.Click += new System.EventHandler(this.logFileDirectory_Click);
            // 
            // logFileDirectoryTextBox
            // 
            this.logFileDirectoryTextBox.Location = new System.Drawing.Point(19, 25);
            this.logFileDirectoryTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFileDirectoryTextBox.Name = "logFileDirectoryTextBox";
            this.logFileDirectoryTextBox.Size = new System.Drawing.Size(573, 25);
            this.logFileDirectoryTextBox.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 531);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "유저 정보 관리 프로그램";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox mobile1TextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.TextBox birthYearTextBox;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button ToTextFile_Button;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button AutoFileExportButton;
        private System.Windows.Forms.Button applybutton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button autoExportDirectory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox autoExportDirectoryTextBox;
        private System.Windows.Forms.ComboBox batchTimer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logFileDirectory;
        private System.Windows.Forms.TextBox logFileDirectoryTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button autoExportingStopButton;
        private System.Windows.Forms.Label autoExportingState;
        private System.Windows.Forms.Label label15;
    }
}

