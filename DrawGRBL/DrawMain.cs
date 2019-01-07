using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawGRBL
{
    public partial class DrawMain : Form
    {
        public delegate void Displaydelegate(byte[] InputBuf);
        public Displaydelegate disp_delegate;

        public DrawMain()
        {
            InitializeComponent();
        }

        private void DrawMain_Load(object sender, EventArgs e)
        {
            //接收数据委托
            disp_delegate = new Displaydelegate(DispUI);
            InitSerial();
            OpenCom();
        }



        #region 初始化串口设备

        private void InitSerial()
        {
            string[] ArryPort = SerialPort.GetPortNames();
            this.PortName.Items.Clear();

            for (int i = 0; i < ArryPort.Length; i++)
            {
                this.PortName.Items.Add(ArryPort[i]);
            }

            if (this.PortName.Items.Count > 0)
            {
                this.PortName.SelectedIndex = 0;
            }

            this.BaudRate.Items.Add("2400");
            this.BaudRate.Items.Add("4800");
            this.BaudRate.Items.Add("9600");
            this.BaudRate.Items.Add("19200");
            this.BaudRate.Items.Add("38400");
            this.BaudRate.Items.Add("43000");
            this.BaudRate.Items.Add("56000");
            this.BaudRate.Items.Add("57600");
            this.BaudRate.Items.Add("115200");
            this.BaudRate.Items.Add("230400");
            this.BaudRate.SelectedIndex = 8;


            this.FirmWare.Items.Add("GRBL");
            this.FirmWare.SelectedIndex = 0;
            this.toolStripStatusLabel1.Text = "";
            this.toolStripStatusLabel2.Text = "";
            this.toolStripStatusLabel3.Text = "";
        }

        private void OpenCom()
        {
            try
            {
                if (!this.serialPort1.IsOpen)
                {
                    this.serialPort1.PortName = this.PortName.Text;
                    this.serialPort1.BaudRate = Convert.ToInt32(this.BaudRate.Text);
                    this.serialPort1.Open();
                    this.toolStripStatusLabel1.Text = "端口已打开";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CloseCom()
        {
            try
            {
                if (this.serialPort1.IsOpen)
                {
                    GoBasePoint();
                    this.serialPort1.Close();
                    this.toolStripStatusLabel1.Text =  "端口已关闭";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void TestCom()
        {
            if (this.serialPort1.IsOpen)
            {
                switch (this.FirmWare.Text)
                {
                    case "GRBL":
                        this.serialPort1.WriteLine("$$");
                        this.serialPort1.WriteLine("$G");
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetBasePoint()
        {
            if (this.serialPort1.IsOpen)
            {
                switch (this.FirmWare.Text)
                {
                    case "GRBL":
                        this.serialPort1.WriteLine("G10 P0 L20 X0 Y0 Z0");
                        break;
                    default:
                        break;
                }
            }
        }
        private void GoBasePoint()
        {
            if (this.serialPort1.IsOpen)
            {
                switch (this.FirmWare.Text)
                {
                    case "GRBL":
                        this.serialPort1.WriteLine("G90 G0 X0 Y0");

                        this.serialPort1.WriteLine("G90 G0 Z0");
                        break;
                    default:
                        break;
                }
            }
        }
        private void GoPoint(int Type)
        {
            if (this.numericUpDown1.Value > 10000) { this.numericUpDown1.Value = 10000; }
            string speed = this.numericUpDown1.Value.ToString();
            string comm = "";
            string unit = "G21";
            //G90或G91 - 绝对和增量距离
            if (this.radioButton1.Checked == true) { unit = "G21"; } else { unit = "G20"; }

            if (this.serialPort1.IsOpen)
            {
                switch (this.FirmWare.Text)
                {
                    case "GRBL":
                        if (Type == 0)
                        {
                            comm = "G90 G0 X0 Y0";
                            this.serialPort1.WriteLine(comm);
                            comm = "G90 G0 Z0";
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 1)
                        {
                            comm = "$J=" + unit + "G90X-1Y-1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 2)
                        {
                            comm = "$J=" + unit + "G90Y-1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 3)
                        {
                            comm = "$J=" + unit + "G90X+1Y-1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 4)
                        {
                            comm = "$J=" + unit + "G90X-1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 5)
                        {
                            comm = "$J=" + unit + "G90X+1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 6)
                        {
                            comm = "$J=" + unit + "G90X-1Y+1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 7)
                        {
                            comm = "$J=" + unit + "G90Y+1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        else if (Type == 8)
                        {
                            comm = "$J=" + unit + "G90X+1Y+1F" + speed;
                            this.serialPort1.WriteLine(comm);
                        }
                        this.toolStripStatusLabel2.Text = comm;
                        break;
                    default:
                        break;
                }
            }
        }
        private void GoPoint(int Type, int x, int y)
        {
            if (this.numericUpDown1.Value > 10000) { this.numericUpDown1.Value = 10000; }
            string speed = this.numericUpDown1.Value.ToString();
            string comm = "";
            string unit = "G21";

            //G90或G91 - 绝对和增量距离
            if (this.radioButton1.Checked == true) { unit = "G21"; } else { unit = "G20"; }

            if (this.serialPort1.IsOpen)
            {
                switch (this.FirmWare.Text)
                {
                    case "GRBL":
                        if (Type == 9)
                        {
                            comm = "$J=" + unit + "G90" + "X" + x.ToString() + "Y" + y.ToString() + "F" + speed; 
                            this.serialPort1.WriteLine(comm);
                        }
                        this.toolStripStatusLabel2.Text = comm;
                        break;
                    default:
                        break;
                }
            }
        }

        //更新UI界面
        public void DispUI(byte[] InputBuf)
        {
            string str = System.Text.Encoding.Default.GetString(InputBuf);
            this.toolStripStatusLabel2.Text = str;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            OpenCom();
            TestCom();
            this.toolStripStatusLabel2.Text = "";
            this.toolStripStatusLabel3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseCom();
        }

        private void DrawMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseCom();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string inLine = serialPort1.ReadLine();
                Byte[] InputBuf = System.Text.Encoding.Default.GetBytes(inLine);
                this.BeginInvoke(disp_delegate, InputBuf);  //disp_delegate是定义的委托事件，在委托事件中调用修改UI的程序
            }
            catch (TimeoutException ex) //超时处理
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            try
            {
                string inLine = serialPort1.ReadLine();
                Byte[] InputBuf = System.Text.Encoding.Default.GetBytes(inLine);
                this.BeginInvoke(disp_delegate, InputBuf);  //disp_delegate是定义的委托事件，在委托事件中调用修改UI的程序
            }
            catch (TimeoutException ex) //超时处理
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SetBasePoint();
        }

        private void G1_Click(object sender, EventArgs e)
        {
            this.GoPoint(1);
        }

        private void G2_Click(object sender, EventArgs e)
        {
            this.GoPoint(2);
        }

        private void G3_Click(object sender, EventArgs e)
        {
            this.GoPoint(3);
        }

        private void G4_Click(object sender, EventArgs e)
        {
            this.GoPoint(4);
        }

        private void G0_Click(object sender, EventArgs e)
        {
            this.GoPoint(0);
        }

        private void G5_Click(object sender, EventArgs e)
        {
            this.GoPoint(5);
        }

        private void G6_Click(object sender, EventArgs e)
        {
            this.GoPoint(6);
        }

        private void G7_Click(object sender, EventArgs e)
        {
            this.GoPoint(7);
        }

        private void G8_Click(object sender, EventArgs e)
        {
            this.GoPoint(8);
        }
         
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            int top = (this.pictureBox1.Height - Convert.ToInt32(this.textBox2.Text)) / 2;
            int left = (this.pictureBox1.Width - Convert.ToInt32(this.textBox1.Text)) / 2;

            x = x - left;
            y = y - top;

            if (x > 0 && y > 0 && x < Convert.ToInt32(this.textBox1.Text) && y < Convert.ToInt32(this.textBox2.Text)) {
                GoPoint(9, x, y);
                this.toolStripStatusLabel3.Text = "X="+x.ToString() + ",Y="+y.ToString();
            } 
            
        }

        private void drawGrids(PaintEventArgs e)
        {


            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Pen myPen = Pens.Blue;

            int top =( this.pictureBox1.Height - Convert.ToInt32(this.textBox2.Text))/2;
            int left =( this.pictureBox1.Width - Convert.ToInt32(this.textBox1.Text))/2;


            g.DrawRectangle(myPen, left, top,  Convert.ToInt32(this.textBox1.Text), Convert.ToInt32(this.textBox2.Text) );

            for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); i++)
            {
                g.DrawLine(myPen, new Point(i+left, top), new Point(i+ left, Convert.ToInt32(this.textBox2.Text) + top));
                i += 5;
            }

            for (int j = 0; j < Convert.ToInt32(this.textBox2.Text); j++)
            {
                g.DrawLine(myPen, new Point(left, j+top), new Point(Convert.ToInt32(this.textBox1.Text) + left, j+top));
                j += 5;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawGrids(e);
        }
    }
}
