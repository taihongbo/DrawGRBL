namespace DrawGRBL
{
    partial class DrawMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PortName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.FirmWare = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.G1 = new System.Windows.Forms.Button();
            this.G2 = new System.Windows.Forms.Button();
            this.G3 = new System.Windows.Forms.Button();
            this.G4 = new System.Windows.Forms.Button();
            this.G0 = new System.Windows.Forms.Button();
            this.G5 = new System.Windows.Forms.Button();
            this.G6 = new System.Windows.Forms.Button();
            this.G7 = new System.Windows.Forms.Button();
            this.G8 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FirmWare);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PortName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本参数";
            // 
            // serialPort1
            // 
            this.serialPort1.ReadBufferSize = 1024;
            this.serialPort1.WriteBufferSize = 1024;
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口：";
            // 
            // PortName
            // 
            this.PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortName.FormattingEnabled = true;
            this.PortName.Location = new System.Drawing.Point(77, 43);
            this.PortName.Name = "PortName";
            this.PortName.Size = new System.Drawing.Size(154, 20);
            this.PortName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // BaudRate
            // 
            this.BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Location = new System.Drawing.Point(77, 69);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(154, 20);
            this.BaudRate.TabIndex = 3;
            // 
            // FirmWare
            // 
            this.FirmWare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirmWare.FormattingEnabled = true;
            this.FirmWare.Location = new System.Drawing.Point(77, 95);
            this.FirmWare.Name = "FirmWare";
            this.FirmWare.Size = new System.Drawing.Size(154, 20);
            this.FirmWare.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "固件：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "打开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(659, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.G8);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.G7);
            this.groupBox2.Controls.Add(this.G6);
            this.groupBox2.Controls.Add(this.G5);
            this.groupBox2.Controls.Add(this.G0);
            this.groupBox2.Controls.Add(this.G4);
            this.groupBox2.Controls.Add(this.G3);
            this.groupBox2.Controls.Add(this.G2);
            this.groupBox2.Controls.Add(this.G1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 113);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "常用操作";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(164, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "设置起点";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // G1
            // 
            this.G1.Location = new System.Drawing.Point(77, 20);
            this.G1.Name = "G1";
            this.G1.Size = new System.Drawing.Size(23, 23);
            this.G1.TabIndex = 9;
            this.G1.UseVisualStyleBackColor = true;
            this.G1.Click += new System.EventHandler(this.G1_Click);
            // 
            // G2
            // 
            this.G2.Location = new System.Drawing.Point(106, 20);
            this.G2.Name = "G2";
            this.G2.Size = new System.Drawing.Size(23, 23);
            this.G2.TabIndex = 10;
            this.G2.UseVisualStyleBackColor = true;
            this.G2.Click += new System.EventHandler(this.G2_Click);
            // 
            // G3
            // 
            this.G3.Location = new System.Drawing.Point(134, 20);
            this.G3.Name = "G3";
            this.G3.Size = new System.Drawing.Size(23, 23);
            this.G3.TabIndex = 11;
            this.G3.UseVisualStyleBackColor = true;
            this.G3.Click += new System.EventHandler(this.G3_Click);
            // 
            // G4
            // 
            this.G4.Location = new System.Drawing.Point(77, 49);
            this.G4.Name = "G4";
            this.G4.Size = new System.Drawing.Size(23, 23);
            this.G4.TabIndex = 12;
            this.G4.UseVisualStyleBackColor = true;
            this.G4.Click += new System.EventHandler(this.G4_Click);
            // 
            // G0
            // 
            this.G0.Location = new System.Drawing.Point(106, 49);
            this.G0.Name = "G0";
            this.G0.Size = new System.Drawing.Size(23, 23);
            this.G0.TabIndex = 13;
            this.G0.UseVisualStyleBackColor = true;
            this.G0.Click += new System.EventHandler(this.G0_Click);
            // 
            // G5
            // 
            this.G5.Location = new System.Drawing.Point(135, 49);
            this.G5.Name = "G5";
            this.G5.Size = new System.Drawing.Size(23, 23);
            this.G5.TabIndex = 14;
            this.G5.UseVisualStyleBackColor = true;
            this.G5.Click += new System.EventHandler(this.G5_Click);
            // 
            // G6
            // 
            this.G6.Location = new System.Drawing.Point(77, 78);
            this.G6.Name = "G6";
            this.G6.Size = new System.Drawing.Size(23, 23);
            this.G6.TabIndex = 15;
            this.G6.UseVisualStyleBackColor = true;
            this.G6.Click += new System.EventHandler(this.G6_Click);
            // 
            // G7
            // 
            this.G7.Location = new System.Drawing.Point(106, 78);
            this.G7.Name = "G7";
            this.G7.Size = new System.Drawing.Size(23, 23);
            this.G7.TabIndex = 16;
            this.G7.UseVisualStyleBackColor = true;
            this.G7.Click += new System.EventHandler(this.G7_Click);
            // 
            // G8
            // 
            this.G8.Location = new System.Drawing.Point(135, 78);
            this.G8.Name = "G8";
            this.G8.Size = new System.Drawing.Size(23, 23);
            this.G8.TabIndex = 17;
            this.G8.UseVisualStyleBackColor = true;
            this.G8.Click += new System.EventHandler(this.G8_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "毫米";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 52);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 19;
            this.radioButton2.Text = "英寸";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(6, 78);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 21);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "行程设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "X：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Y：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "280";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 21);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "280";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(283, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // DrawMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 417);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DrawMain";
            this.Text = "DrawMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DrawMain_FormClosed);
            this.Load += new System.EventHandler(this.DrawMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PortName;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox FirmWare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button G8;
        private System.Windows.Forms.Button G7;
        private System.Windows.Forms.Button G6;
        private System.Windows.Forms.Button G5;
        private System.Windows.Forms.Button G0;
        private System.Windows.Forms.Button G4;
        private System.Windows.Forms.Button G3;
        private System.Windows.Forms.Button G2;
        private System.Windows.Forms.Button G1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}

