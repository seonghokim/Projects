namespace WindowsFormsApplication2
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
            this.components = new System.ComponentModel.Container();
            this.voltage_enter = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.voltage_dac_ch1 = new System.Windows.Forms.TextBox();
            this.voltage_dac_ch2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.voltage_reset = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dac_using = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dynamic_enter_ch1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dynamic_using_ch1 = new System.Windows.Forms.PictureBox();
            this.all_off_ch1 = new System.Windows.Forms.Button();
            this.static_enter_ch1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.static_using_ch1 = new System.Windows.Forms.PictureBox();
            this.static_output_ch1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dynamic_hz_ch1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.static_input_ch1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dynamic_enter_ch2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dynamic_using_ch2 = new System.Windows.Forms.PictureBox();
            this.all_off_ch2 = new System.Windows.Forms.Button();
            this.static_enter_ch2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.static_using_ch2 = new System.Windows.Forms.PictureBox();
            this.static_output_ch2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dynamic_hz_ch2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.static_input_ch2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dac_using)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamic_using_ch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.static_using_ch1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamic_using_ch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.static_using_ch2)).BeginInit();
            this.SuspendLayout();
            // 
            // voltage_enter
            // 
            this.voltage_enter.Location = new System.Drawing.Point(338, 62);
            this.voltage_enter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.voltage_enter.Name = "voltage_enter";
            this.voltage_enter.Size = new System.Drawing.Size(77, 27);
            this.voltage_enter.TabIndex = 0;
            this.voltage_enter.Text = "Enter";
            this.voltage_enter.UseVisualStyleBackColor = true;
            this.voltage_enter.Click += new System.EventHandler(this.voltage_enter_Click);
            // 
            // voltage_dac_ch1
            // 
            this.voltage_dac_ch1.Location = new System.Drawing.Point(63, 63);
            this.voltage_dac_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.voltage_dac_ch1.Name = "voltage_dac_ch1";
            this.voltage_dac_ch1.Size = new System.Drawing.Size(112, 26);
            this.voltage_dac_ch1.TabIndex = 2;
            // 
            // voltage_dac_ch2
            // 
            this.voltage_dac_ch2.Location = new System.Drawing.Point(198, 63);
            this.voltage_dac_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.voltage_dac_ch2.Name = "voltage_dac_ch2";
            this.voltage_dac_ch2.Size = new System.Drawing.Size(112, 26);
            this.voltage_dac_ch2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.voltage_reset);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dac_using);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.voltage_enter);
            this.groupBox1.Controls.Add(this.voltage_dac_ch2);
            this.groupBox1.Controls.Add(this.voltage_dac_ch1);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(44, 119);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(429, 132);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voltage(DAC)";
            // 
            // voltage_reset
            // 
            this.voltage_reset.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.voltage_reset.Location = new System.Drawing.Point(342, 98);
            this.voltage_reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.voltage_reset.Name = "voltage_reset";
            this.voltage_reset.Size = new System.Drawing.Size(68, 17);
            this.voltage_reset.TabIndex = 18;
            this.voltage_reset.Text = "RESET";
            this.voltage_reset.UseVisualStyleBackColor = true;
            this.voltage_reset.Click += new System.EventHandler(this.voltage_reset_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9F);
            this.label11.Location = new System.Drawing.Point(8, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "사용중";
            // 
            // dac_using
            // 
            this.dac_using.BackColor = System.Drawing.Color.Transparent;
            this.dac_using.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dac_using.Location = new System.Drawing.Point(21, 69);
            this.dac_using.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dac_using.Name = "dac_using";
            this.dac_using.Size = new System.Drawing.Size(18, 16);
            this.dac_using.TabIndex = 16;
            this.dac_using.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(235, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "CH2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(99, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "CH1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dynamic_enter_ch1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dynamic_using_ch1);
            this.groupBox2.Controls.Add(this.all_off_ch1);
            this.groupBox2.Controls.Add(this.static_enter_ch1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.static_using_ch1);
            this.groupBox2.Controls.Add(this.static_output_ch1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dynamic_hz_ch1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.static_input_ch1);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(563, 46);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(556, 146);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HV Channel1";
            // 
            // dynamic_enter_ch1
            // 
            this.dynamic_enter_ch1.Location = new System.Drawing.Point(444, 72);
            this.dynamic_enter_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamic_enter_ch1.Name = "dynamic_enter_ch1";
            this.dynamic_enter_ch1.Size = new System.Drawing.Size(77, 27);
            this.dynamic_enter_ch1.TabIndex = 14;
            this.dynamic_enter_ch1.Text = "Enter";
            this.dynamic_enter_ch1.UseVisualStyleBackColor = true;
            this.dynamic_enter_ch1.Click += new System.EventHandler(this.dynamic_enter_ch1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F);
            this.label8.Location = new System.Drawing.Point(307, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "사용중";
            // 
            // dynamic_using_ch1
            // 
            this.dynamic_using_ch1.BackColor = System.Drawing.Color.Transparent;
            this.dynamic_using_ch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dynamic_using_ch1.Location = new System.Drawing.Point(320, 78);
            this.dynamic_using_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamic_using_ch1.Name = "dynamic_using_ch1";
            this.dynamic_using_ch1.Size = new System.Drawing.Size(18, 16);
            this.dynamic_using_ch1.TabIndex = 12;
            this.dynamic_using_ch1.TabStop = false;
            // 
            // all_off_ch1
            // 
            this.all_off_ch1.Location = new System.Drawing.Point(220, 16);
            this.all_off_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.all_off_ch1.Name = "all_off_ch1";
            this.all_off_ch1.Size = new System.Drawing.Size(125, 27);
            this.all_off_ch1.TabIndex = 11;
            this.all_off_ch1.Text = "ALL OFF";
            this.all_off_ch1.UseVisualStyleBackColor = true;
            this.all_off_ch1.Click += new System.EventHandler(this.all_off_ch1_Click);
            // 
            // static_enter_ch1
            // 
            this.static_enter_ch1.Location = new System.Drawing.Point(93, 107);
            this.static_enter_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_enter_ch1.Name = "static_enter_ch1";
            this.static_enter_ch1.Size = new System.Drawing.Size(77, 27);
            this.static_enter_ch1.TabIndex = 7;
            this.static_enter_ch1.Text = "Enter";
            this.static_enter_ch1.UseVisualStyleBackColor = true;
            this.static_enter_ch1.Click += new System.EventHandler(this.static_enter_ch1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F);
            this.label7.Location = new System.Drawing.Point(4, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "사용중";
            // 
            // static_using_ch1
            // 
            this.static_using_ch1.BackColor = System.Drawing.Color.Transparent;
            this.static_using_ch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.static_using_ch1.Location = new System.Drawing.Point(17, 78);
            this.static_using_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_using_ch1.Name = "static_using_ch1";
            this.static_using_ch1.Size = new System.Drawing.Size(18, 16);
            this.static_using_ch1.TabIndex = 9;
            this.static_using_ch1.TabStop = false;
            // 
            // static_output_ch1
            // 
            this.static_output_ch1.Location = new System.Drawing.Point(138, 71);
            this.static_output_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_output_ch1.Name = "static_output_ch1";
            this.static_output_ch1.Size = new System.Drawing.Size(77, 27);
            this.static_output_ch1.TabIndex = 7;
            this.static_output_ch1.Text = "Output";
            this.static_output_ch1.UseVisualStyleBackColor = true;
            this.static_output_ch1.Click += new System.EventHandler(this.static_output_ch1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F);
            this.label3.Location = new System.Drawing.Point(402, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dynamic";
            // 
            // dynamic_hz_ch1
            // 
            this.dynamic_hz_ch1.Location = new System.Drawing.Point(356, 74);
            this.dynamic_hz_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamic_hz_ch1.Name = "dynamic_hz_ch1";
            this.dynamic_hz_ch1.Size = new System.Drawing.Size(78, 26);
            this.dynamic_hz_ch1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 12F);
            this.label4.Location = new System.Drawing.Point(106, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Static";
            // 
            // static_input_ch1
            // 
            this.static_input_ch1.Location = new System.Drawing.Point(52, 71);
            this.static_input_ch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_input_ch1.Name = "static_input_ch1";
            this.static_input_ch1.Size = new System.Drawing.Size(77, 27);
            this.static_input_ch1.TabIndex = 0;
            this.static_input_ch1.Text = "Input";
            this.static_input_ch1.UseVisualStyleBackColor = true;
            this.static_input_ch1.Click += new System.EventHandler(this.static_input_ch1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dynamic_enter_ch2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dynamic_using_ch2);
            this.groupBox3.Controls.Add(this.all_off_ch2);
            this.groupBox3.Controls.Add(this.static_enter_ch2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.static_using_ch2);
            this.groupBox3.Controls.Add(this.static_output_ch2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.dynamic_hz_ch2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.static_input_ch2);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(563, 223);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(556, 146);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HV Channel2";
            // 
            // dynamic_enter_ch2
            // 
            this.dynamic_enter_ch2.Location = new System.Drawing.Point(444, 71);
            this.dynamic_enter_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamic_enter_ch2.Name = "dynamic_enter_ch2";
            this.dynamic_enter_ch2.Size = new System.Drawing.Size(77, 27);
            this.dynamic_enter_ch2.TabIndex = 14;
            this.dynamic_enter_ch2.Text = "Enter";
            this.dynamic_enter_ch2.UseVisualStyleBackColor = true;
            this.dynamic_enter_ch2.Click += new System.EventHandler(this.dynamic_enter_ch2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F);
            this.label5.Location = new System.Drawing.Point(307, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "사용중";
            // 
            // dynamic_using_ch2
            // 
            this.dynamic_using_ch2.BackColor = System.Drawing.Color.Transparent;
            this.dynamic_using_ch2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dynamic_using_ch2.Location = new System.Drawing.Point(320, 78);
            this.dynamic_using_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamic_using_ch2.Name = "dynamic_using_ch2";
            this.dynamic_using_ch2.Size = new System.Drawing.Size(18, 16);
            this.dynamic_using_ch2.TabIndex = 12;
            this.dynamic_using_ch2.TabStop = false;
            // 
            // all_off_ch2
            // 
            this.all_off_ch2.Location = new System.Drawing.Point(220, 16);
            this.all_off_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.all_off_ch2.Name = "all_off_ch2";
            this.all_off_ch2.Size = new System.Drawing.Size(125, 27);
            this.all_off_ch2.TabIndex = 11;
            this.all_off_ch2.Text = "ALL OFF";
            this.all_off_ch2.UseVisualStyleBackColor = true;
            this.all_off_ch2.Click += new System.EventHandler(this.all_off_ch2_Click);
            // 
            // static_enter_ch2
            // 
            this.static_enter_ch2.Location = new System.Drawing.Point(93, 107);
            this.static_enter_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_enter_ch2.Name = "static_enter_ch2";
            this.static_enter_ch2.Size = new System.Drawing.Size(77, 27);
            this.static_enter_ch2.TabIndex = 7;
            this.static_enter_ch2.Text = "Enter";
            this.static_enter_ch2.UseVisualStyleBackColor = true;
            this.static_enter_ch2.Click += new System.EventHandler(this.static_enter_ch2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F);
            this.label6.Location = new System.Drawing.Point(3, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "사용중";
            // 
            // static_using_ch2
            // 
            this.static_using_ch2.BackColor = System.Drawing.Color.Transparent;
            this.static_using_ch2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.static_using_ch2.Location = new System.Drawing.Point(17, 78);
            this.static_using_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_using_ch2.Name = "static_using_ch2";
            this.static_using_ch2.Size = new System.Drawing.Size(18, 16);
            this.static_using_ch2.TabIndex = 9;
            this.static_using_ch2.TabStop = false;
            // 
            // static_output_ch2
            // 
            this.static_output_ch2.Location = new System.Drawing.Point(138, 71);
            this.static_output_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_output_ch2.Name = "static_output_ch2";
            this.static_output_ch2.Size = new System.Drawing.Size(77, 27);
            this.static_output_ch2.TabIndex = 7;
            this.static_output_ch2.Text = "Output";
            this.static_output_ch2.UseVisualStyleBackColor = true;
            this.static_output_ch2.Click += new System.EventHandler(this.static_output_ch2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 12F);
            this.label9.Location = new System.Drawing.Point(402, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Dynamic";
            // 
            // dynamic_hz_ch2
            // 
            this.dynamic_hz_ch2.Location = new System.Drawing.Point(356, 74);
            this.dynamic_hz_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamic_hz_ch2.Name = "dynamic_hz_ch2";
            this.dynamic_hz_ch2.Size = new System.Drawing.Size(78, 26);
            this.dynamic_hz_ch2.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 12F);
            this.label10.Location = new System.Drawing.Point(106, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Static";
            // 
            // static_input_ch2
            // 
            this.static_input_ch2.Location = new System.Drawing.Point(52, 71);
            this.static_input_ch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.static_input_ch2.Name = "static_input_ch2";
            this.static_input_ch2.Size = new System.Drawing.Size(77, 27);
            this.static_input_ch2.TabIndex = 0;
            this.static_input_ch2.Text = "Input";
            this.static_input_ch2.UseVisualStyleBackColor = true;
            this.static_input_ch2.Click += new System.EventHandler(this.static_input_ch2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(313, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 16);
            this.label12.TabIndex = 19;
            this.label12.Text = "V";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(177, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "V";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 397);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dac_using)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamic_using_ch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.static_using_ch1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamic_using_ch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.static_using_ch2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button voltage_enter;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox voltage_dac_ch1;
        private System.Windows.Forms.TextBox voltage_dac_ch2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox static_using_ch1;
        private System.Windows.Forms.Button static_output_ch1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button static_input_ch1;
        private System.Windows.Forms.TextBox dynamic_hz_ch1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox dynamic_using_ch1;
        private System.Windows.Forms.Button all_off_ch1;
        private System.Windows.Forms.Button static_enter_ch1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button dynamic_enter_ch1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button dynamic_enter_ch2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox dynamic_using_ch2;
        private System.Windows.Forms.Button all_off_ch2;
        private System.Windows.Forms.Button static_enter_ch2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox static_using_ch2;
        private System.Windows.Forms.Button static_output_ch2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dynamic_hz_ch2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button static_input_ch2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox dac_using;
        private System.Windows.Forms.Button voltage_reset;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}

