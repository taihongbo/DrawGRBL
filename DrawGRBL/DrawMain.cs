using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DrawGRBL
{
    public partial class DrawMain : Form
    {
        public delegate void Displaydelegate(byte[] InputBuf);
        public Displaydelegate disp_delegate;
        public bool RecordMacro;
        public DateTime MouseDownBegin;
        public DateTime MouseDownEnd;
        public int MouseX;
        public int MouseY;
        public string DataReceivedOK;
        public string commOldName;
        public string AllCommand;
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
            RecordMacro = false;
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
                    if (this.PortName.Text != "")
                    {
                        this.serialPort1.PortName = this.PortName.Text;
                        this.serialPort1.BaudRate = Convert.ToInt32(this.BaudRate.Text);
                        this.serialPort1.Open();
                        this.toolStripStatusLabel1.Text = "端口已打开";
                        this.button1.Enabled = false;
                        this.button2.Enabled = true;

                        this.button3.Enabled = true;
                        this.button4.Enabled = true;
                        this.button5.Enabled = true;
                        this.button6.Enabled = true;
                        this.button7.Enabled = true;
                        this.button8.Enabled = true;
                    }
                    else {

                        this.toolStripStatusLabel1.Text = "端口已关闭";
                        this.button1.Enabled = true;
                        this.button2.Enabled = false;

                        this.button3.Enabled = true;
                        this.button4.Enabled = true;
                        this.button5.Enabled = true;
                        this.button6.Enabled = true;
                        this.button7.Enabled = true;
                        this.button8.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.toolStripStatusLabel1.Text = "端口已关闭";
                this.button1.Enabled = true;
                this.button2.Enabled = false;

                this.button3.Enabled = true;
                this.button4.Enabled = true;
                this.button5.Enabled = true;
                this.button6.Enabled = true;
                this.button7.Enabled = true;
                this.button8.Enabled = true;
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
                    this.toolStripStatusLabel1.Text = "端口已关闭";
                    this.button1.Enabled = true;
                    this.button2.Enabled = false;

                    this.button3.Enabled = false;
                    this.button4.Enabled = false;
                    this.button5.Enabled = false;
                    this.button6.Enabled = false;
                    this.button7.Enabled = false;
                    this.button8.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void TestCom()
        {
            switch (this.FirmWare.Text)
            {
                case "GRBL":
                    this.SerialPortWriteLine("$$");
                    this.SerialPortWriteLine("$G");
                    break;
                default:
                    break;
            }
        }

        private void SetBasePoint()
        {
            switch (this.FirmWare.Text)
            {
                case "GRBL":
                    this.SerialPortWriteLine("G10 P0 L20 X0 Y0 Z0");
                    break;
                default:
                    break;
            }
        }
        private void GoBasePoint()
        {
            string speed = this.numSpeed.Value.ToString();
            switch (this.FirmWare.Text)
            {
                case "GRBL":
                    this.SerialPortWriteLine("G21");
                    this.SerialPortWriteLine("G90");
                    this.SerialPortWriteLine("S1000");
                    this.SerialPortWriteLine("F" + speed.ToString());
                    this.SerialPortWriteLine("G0Z0");
                    this.SerialPortWriteLine("M5");
                    this.SerialPortWriteLine("G4 P0.2");
                    this.SerialPortWriteLine("G90 G0 X0 Y0");
                    this.SerialPortWriteLine("G90 G0 Z0");
                    break;
                default:
                    break;
            }
        }
        private void GoPoint(int Type)
        {
            if (this.numSpeed.Value > 10000) { this.numSpeed.Value = 10000; }
            string speed = this.numSpeed.Value.ToString();
            string comm = "";
            string unit = "G21"; // 毫米 G20 英寸  //G90或G91 - 绝对和增量距离 
            switch (this.FirmWare.Text)
            {
                case "GRBL":
                    if (Type == 0)
                    {
                        comm = "G90 G0 X0 Y0";
                        this.SerialPortWriteLine(comm);
                        comm = "G90 G0 Z0";
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 1)
                    {
                        comm = "$J=" + unit + "G90X-1Y-1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 2)
                    {
                        comm = "$J=" + unit + "G90Y-1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 3)
                    {
                        comm = "$J=" + unit + "G90X+1Y-1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 4)
                    {
                        comm = "$J=" + unit + "G90X-1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 5)
                    {
                        comm = "$J=" + unit + "G90X+1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 6)
                    {
                        comm = "$J=" + unit + "G90X-1Y+1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 7)
                    {
                        comm = "$J=" + unit + "G90Y+1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 8)
                    {
                        comm = "$J=" + unit + "G90X+1Y+1F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    break;
                default:
                    break;
            }
        }
        private void GoPoint(int Type, int x, int y)
        {
            if (this.numSpeed.Value > 10000) { this.numSpeed.Value = 10000; }
            string speed = this.numSpeed.Value.ToString();
            string comm = "";
            string unit = "G21"; // 毫米 G20 英寸   //G90或G91 - 绝对和增量距离 
            switch (this.FirmWare.Text)
            {
                case "GRBL":
                    if (Type == 9)
                    {
                        comm = unit + "G90" + "X" + x.ToString() + "Y" + y.ToString() + "F" + speed;
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == 10)
                    {
                        //暂停
                        double number = x / 1000;
                        comm = "G4 P" + number.ToString();
                        this.SerialPortWriteLine(comm);
                    }

                    break;
                default:
                    break;
            }
        }


        private void TestPen(string Type)
        {
            string comm = "";

            switch (this.FirmWare.Text)
            {
                case "GRBL":
                    if (Type == "DOWN")
                    {
                        comm = "M3S1000";
                        this.SerialPortWriteLine(comm);
                        comm = "G4 P0.2";
                        this.SerialPortWriteLine(comm);
                    }
                    else if (Type == "UP")
                    {
                        comm = "M5";
                        this.SerialPortWriteLine(comm);
                        comm = "G4 P0.2";
                        this.SerialPortWriteLine(comm);
                    }
                    break;
                default:
                    break;
            }
        }
        private void SerialPortWriteLine(string comm)
        {
            int nSuspend = Convert.ToInt16(this.suspend.Value);
            this.AllCommand = this.AllCommand + Environment.NewLine + comm;
            try
            {
                if (this.serialPort1.IsOpen)
                {
                    this.Stop(nSuspend);
                    this.DataReceivedOK = "";
                    this.serialPort1.WriteLine(comm);
                    this.toolStripStatusLabel3.Text = comm;
                    while (DataReceivedOK.ToLower() != "ok")
                    {
                        this.DataReceivedOK = "ok";
                    }
                }
            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel2.Text = ex.Message.ToString();
            }

        }

        private void ExecutiveMacro(string Macro)
        {
            this.GoBasePoint();

            string[] MacroList = Macro.Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < MacroList.Length; i++)
            {
                string commandTxT = MacroList[i].Trim();
                if (commandTxT != "")
                {
                    GRBLcommand comm = GetGRBLcommand(commandTxT);
                    ExecutiveComm(comm);
                }
            }
            this.GoBasePoint();
        }

        private void ExecutiveComm(GRBLcommand comm)
        {
            if (comm.Name == "Delayed")
            {
                this.GoPoint(10, comm.X , 0);
                //this.Stop(comm.X * 1000); 
            }
            else if (comm.Name == "MouseDown")
            {
                if (this.commOldName != "MouseDown")
                {
                    TestPen("UP");
                } 
                this.GoPoint(9, comm.X, comm.Y);
                this.commOldName = "MouseDown";
            }
            else if (comm.Name == "PenDown")
            { 
                if (this.commOldName != "PenDown")
                {
                    TestPen("DOWN");
                }
                this.commOldName = "PenDown";
            }
            else if (comm.Name == "MouseUp")
            {
                if (this.commOldName != "MouseUp")
                {
                    TestPen("UP");
                } 
                this.GoPoint(9, comm.X, comm.Y);
                this.commOldName = "MouseUp";
            }
            else if (comm.Name == "PenUp")
            {
                if (this.commOldName != "PenUp")
                {
                    TestPen("UP");
                }
                this.commOldName = "PenUp";
            }
            else if (comm.Name == "MouseMove")
            { 
                if (this.commOldName != "MouseMove")
                {
                    TestPen("DOWN");
                }
                this.GoPoint(9, comm.X, comm.Y);
                this.commOldName = "MouseMove";
            }
        }


        private void Stop(double number = 1000)
        {
            var t = DateTime.Now.AddMilliseconds(number);
            while (DateTime.Now < t)
            {
                Application.DoEvents();
            }
        }
        private GRBLcommand GetGRBLcommand(string comm)
        {
            // MouseDown: 117 , 250
            //   MouseUp: 117 , 250
            // MouseMove: 123
            GRBLcommand a = new GRBLcommand();
            a.Type = 9;
            string[] m = comm.Split(':');
            if (m.Length > 0)
            {
                a.Name = m[0].Trim();
                if (a.Name == "Delayed")
                {
                    a.X = Convert.ToInt16(m[1]);
                }
                else
                {
                    string[] n = m[1].Split(',');
                    a.X = Convert.ToInt16(n[0]);
                    a.Y = Convert.ToInt16(n[1]);
                }
            }
            return a;
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
            this.toolStripStatusLabel2.Text = "";
            this.toolStripStatusLabel3.Text = "";
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
                DataReceivedOK = inLine;
                Byte[] InputBuf = System.Text.Encoding.Default.GetBytes(inLine);
                this.BeginInvoke(disp_delegate, InputBuf);  //disp_delegate是定义的委托事件，在委托事件中调用修改UI的程序
            }
            catch (TimeoutException ex) //超时处理
            {
                MessageBox.Show(ex.ToString());
                DataReceivedOK = "error";
            }
            Application.DoEvents();
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            try
            {
                string inLine = serialPort1.ReadLine();
                DataReceivedOK = inLine;
                Byte[] InputBuf = System.Text.Encoding.Default.GetBytes(inLine);
                this.BeginInvoke(disp_delegate, InputBuf);  //disp_delegate是定义的委托事件，在委托事件中调用修改UI的程序
            }
            catch (TimeoutException ex) //超时处理
            {
                MessageBox.Show(ex.ToString());
                DataReceivedOK = "error";
            }
            Application.DoEvents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SetBasePoint();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.GoBasePoint();
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (this.RecordMacro == false)
            //{
            //    int x = e.X;
            //    int y = e.Y;
            //    int top = (this.pictureBox1.Height - Convert.ToInt32(this.txtY.Text)) / 2;
            //    int left = (this.pictureBox1.Width - Convert.ToInt32(this.txtX.Text)) / 2;
            //    x = x - left;
            //    y = y - top;
            //    if (x > 0 && y > 0 && x < Convert.ToInt32(this.txtX.Text) && y < Convert.ToInt32(this.txtY.Text))
            //    {
            //        GoPoint(9, x, y);
            //    }
            //}
        }

        private void drawGrids(Graphics e)
        {

            Graphics g = e;
            g.Clear(Color.White);
            Pen myPen = Pens.Blue;

            int top = (this.pictureBox1.Height - Convert.ToInt32(this.txtY.Text)) / 2;
            int left = (this.pictureBox1.Width - Convert.ToInt32(this.txtX.Text)) / 2;


            g.DrawRectangle(myPen, left, top, Convert.ToInt32(this.txtX.Text), Convert.ToInt32(this.txtY.Text));

            for (int i = 0; i < Convert.ToInt32(this.txtX.Text); i++)
            {
                g.DrawLine(myPen, new Point(i + left, top), new Point(i + left, Convert.ToInt32(this.txtY.Text) + top));
                i += 5;
            }

            for (int j = 0; j < Convert.ToInt32(this.txtY.Text); j++)
            {
                g.DrawLine(myPen, new Point(left, j + top), new Point(Convert.ToInt32(this.txtX.Text) + left, j + top));
                j += 5;
            }

            Application.DoEvents();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawGrids(e.Graphics);

        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            drawGrids(g);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TestPen("DOWN"); //M3
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TestPen("UP"); //M5 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.GoBasePoint();

            MouseDownBegin = DateTime.Now;
            MouseDownEnd = DateTime.Now;

            if (this.button7.Text == "录制动作")
            {
                this.button7.Text = "停止录制";
            }
            else
            {
                this.button7.Text = "录制动作";
            }

            if (this.button7.Text == "停止录制")
            {
                this.RecordMacro = true;
                this.txtMacro.Text = "";
                this.button8.Enabled = false;
            }
            else
            {
                this.RecordMacro = false;
                this.button8.Enabled = true;
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.RecordMacro == true)
            {
                int x = e.X;
                int y = e.Y;
                int top = (this.pictureBox1.Height - Convert.ToInt32(this.txtY.Text)) / 2;
                int left = (this.pictureBox1.Width - Convert.ToInt32(this.txtX.Text)) / 2;
                x = x - left;
                y = y - top;
                if (x > 0 && y > 0 && x < Convert.ToInt32(this.txtX.Text) && y < Convert.ToInt32(this.txtY.Text))
                {
                    MouseDownBegin = DateTime.Now;
                    string oldMacro = this.txtMacro.Text;
                    string newMacro = "";
                    newMacro = newMacro + "MouseDown :" + x.ToString() + " , " + y.ToString() + System.Environment.NewLine;
                    if (Math.Abs(this.MouseX - e.X) > 5 || Math.Abs(this.MouseY - e.Y) > 5)
                    {
                        this.txtMacro.Text = oldMacro + newMacro;
                        this.MouseX = e.X;
                        this.MouseY = e.Y;
                        GRBLcommand comm = new GRBLcommand();
                        comm.Name = "MouseDown";
                        comm.Type = 9;
                        comm.X = x;
                        comm.Y = y;
                        this.ExecutiveComm(comm);
                    }

                }
            }


        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.RecordMacro == true)
            {
                int x = e.X;
                int y = e.Y;
                int top = (this.pictureBox1.Height - Convert.ToInt32(this.txtY.Text)) / 2;
                int left = (this.pictureBox1.Width - Convert.ToInt32(this.txtX.Text)) / 2;
                x = x - left;
                y = y - top;
                if (x > 0 && y > 0 && x < Convert.ToInt32(this.txtX.Text) && y < Convert.ToInt32(this.txtY.Text))
                {
                    MouseDownBegin = DateTime.Now;
                    MouseDownEnd = DateTime.Now;
                    string oldMacro = this.txtMacro.Text;
                    string newMacro = "";
                    newMacro = newMacro + "  MouseUp :" + x.ToString() + " , " + y.ToString() + System.Environment.NewLine;
                    this.txtMacro.Text = oldMacro + newMacro;
                    this.MouseX = e.X;
                    this.MouseY = e.Y;
                    GRBLcommand comm = new GRBLcommand();
                    comm.Name = "MouseUp";
                    comm.Type = 9;
                    comm.X = x;
                    comm.Y = y;
                    this.ExecutiveComm(comm);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.RecordMacro == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int x = e.X;
                    int y = e.Y;
                    int top = (this.pictureBox1.Height - Convert.ToInt32(this.txtY.Text)) / 2;
                    int left = (this.pictureBox1.Width - Convert.ToInt32(this.txtX.Text)) / 2;
                    x = x - left;
                    y = y - top;
                    if (x > 0 && y > 0 && x < Convert.ToInt32(this.txtX.Text) && y < Convert.ToInt32(this.txtY.Text))
                    {
                        string oldMacro = this.txtMacro.Text;
                        string newMacro = "";

                        MouseDownEnd = DateTime.Now;
                        TimeSpan ts = MouseDownEnd.Subtract(MouseDownBegin).Duration();
                        this.toolStripStatusLabel3.Text = ts.Seconds.ToString();
                        if (ts.Seconds > 0)
                        {
                            newMacro = newMacro + "  Delayed :" + ts.Seconds.ToString() + System.Environment.NewLine;
                        }
                        newMacro = newMacro + "MouseMove :" + x.ToString() + " , " + y.ToString() + System.Environment.NewLine;
                        if (Math.Abs(this.MouseX - e.X) > 5 || Math.Abs(this.MouseY - e.Y) > 5)
                        {
                            MouseDownBegin = DateTime.Now;
                            MouseDownEnd = DateTime.Now;
                            this.txtMacro.Text = oldMacro + newMacro;
                            this.MouseX = e.X;
                            this.MouseY = e.Y;
                            GRBLcommand comm = new GRBLcommand();
                            comm.Name = "MouseMove";
                            comm.Type = 9;
                            comm.X = x;
                            comm.Y = y;
                            this.ExecutiveComm(comm);
                        }

                    }
                }
            }

        }



        private void button8_Click(object sender, EventArgs e)
        {
            if (this.RecordMacro == false)
            {
                this.AllCommand = "";
                if (this.txtMacro.Text != "")
                {
                    this.ExecutiveMacro(this.txtMacro.Text);
                }
                this.textBox1.Text = this.AllCommand;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string[] AAA = this.textBox1.Text.Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < AAA.Length; i++)
            {
                string comm = AAA[i];
                if (this.serialPort1.IsOpen)
                {
                    if (comm != "")
                    {
                        this.SerialPortWriteLine(comm);
                    }
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.InitSerial();
            this.OpenCom();
        }
    }

    public class GRBLcommand
    {

        public string Name { get; set; }
        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

    }
} 