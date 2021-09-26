using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Speech.Synthesis;
using _18_Jun_2021.Models;
using System.Threading;
using GSM.DAO;

namespace GSM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string RxString;
        string smsshow;
        #region System Event Function
        // Initialize a new instance of the SpeechSynthesizer.  
        SpeechSynthesizer synth = new SpeechSynthesizer();

        // Create a prompt from a string.  
        Prompt color = new Prompt("What is your favorite color?");
        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();
            string txtcontent = textBox1.Text;
            // Create a prompt from a string.  
            Prompt color = new Prompt(txtcontent);
            synth.SpeakAsync(color);

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void speechToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Loginform().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            configGMS();
            SendSMS();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            #region test1_ok
            //            string test = @"
            //+CMT: ""+84977413768"","""",""21/09/08,19:30:03+28""
            //Xin chao buoi toi day la tin nhan tu dong
            //";
            //            //ShortMessageCollection messages = new ShortMessageCollection();
            //            //Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
            //            //Regex r = new Regex(@"\+CMT:(.+)+\W");
            //            //Regex r = new Regex(@"\n(.+)");
            //            Regex r = new Regex(@"\+CMT:(.+)\n |\n");
            //             //Match m = r.Match(test);

            //             MatchCollection matches = r.Matches(test);
            //            foreach (Match match in matches)
            //            {
            //                GroupCollection groups = match.Groups;
            //                textBox1.Text = groups[0].Value;
            //                //MessageBox.Show(groups[0].Value);
            //                //MessageBox.Show(groups[1].Value);
            //            }
            //            //MessageBox.Show(test);
            #endregion
            #region test2_stack_ok
            Stack teststack = new Stack();
            //Stack<string> teststack = new Stack<string>();
            teststack.Push("172-7nzqgeDQeB18IOMneobQWo2J22+vd6nfSeV7JK5gjrStntI6E+2xE5poJVndRCoXuCwBuFc1+Yxhb9+c1kiDB37u9gOkEbFOZ7M50z9PZba9/frADyO7xew+FV0Pcah/q+SuQYlmMekNk29PP2GUE");
            teststack.Push("thang2");
            teststack.Push("thang3");
            teststack.Push("thang4");
            teststack.Push("thang5");
            teststack.Push("thang6");
            teststack.Push("thang70xfff");
            int Length = teststack.Count;
            string[] test3 = new string[Length];
            string laststr = teststack.Peek().ToString();

            if (laststr.EndsWith("0xffff") == true)
            {
                for (int i = 0; i < Length; i++)
                {
                    test3[i] = teststack.Pop().ToString();
                    //textBox1.Text += test3[i].ToString();
                    //teststack.Pop().ToString());
                }
            }

            string abc = string.Concat(test3.Reverse());
            textBox1.Text = abc;
            MessageBox.Show(abc);
            #endregion
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_SerialPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Loginform().ShowDialog();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manualform form2 = new Manualform();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The product is developed by team Thangdoan. Nha Trang 2021");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History form = new History();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
        #endregion

        #region Process Port
        /* Tong so Serial Port */
        int intlen = 0;
        string targetSePort = "COM8";
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if (intlen != ports.Length)
            {
                intlen = ports.Length;
                /* cap nhat combo box voi danh sach moi */
                comboBox_SerialPorts.Items.Clear();
                for (int i=0; i< intlen; i++)
                {
                    comboBox_SerialPorts.Items.Add(ports[i]);
                }
            }
            if (targetSePort == comboBox_SerialPorts.Text)
            {
                if (false == serialPort.IsOpen)
                {
                    serialPort.Open();
                    lblConnectStatus.Text = "Connected with " + targetSePort + " and wait for comming message !";
                }
            }
        }
        /* ReceivedBytesThreshold ( in properties of serialPort ) to config the cause of this interrupt */
        int Counter = 0;
        private void OnSerialPort(object sender, SerialDataReceivedEventArgs e)
        {
            #region ok code
            string[] message;
            string cmdSend = "";

            /* Doc tat ca du lieu trong buff Serial Port */
            string cmdRead = serialPort.ReadExisting();

            /* Giai ma tin nhan */
            message = cmdRead.Split(new char[] { '-' });

            if (message[0] == (message[1].Count() - 1).ToString())
            {
                /* San sang de doc message */
                Display(SymDecryptMethod(message[1].ToString()));
                cmdSend = "OK";
            }
            else
            {
                cmdSend = "NG";
            }

            /* Thong bao nhan message thanh cong ? */
            serialPort.WriteLine(SymEncryptMethod(cmdSend));

            Counter++;
            #endregion

            #region OK_Thang
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            //Chưa dùng tới
            /* Doc tat ca du lieu trong buff Serial Port */
            //RxString += serialPort.ReadExisting();
            //this.Invoke(new EventHandler(DisplaySMSText));
            #endregion
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            RxString += serialPort.ReadExisting();
            Regex r = new Regex(@"\n(.+)");
            MatchCollection matches = r.Matches(RxString);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                //DsSMS(groups[0].Value);
                //Hiển thị
                JoinStackSMS(groups[0].Value);
            }
        }
        
        private delegate void DlDisplay(string s);
        private void Display(string s)
        {
            if (textBox1.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display);
                textBox1.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox1.Text = s;
            }
        }
        
        private delegate void jsDisplay(string valueok);
        private void DsSMS(string valueok)
        {
            if (textBox1.InvokeRequired)
            {
                jsDisplay sd = new jsDisplay(DsSMS);
                textBox1.Invoke(sd, new object[] { valueok });
                //JoinStackSMS(valueok);
            }
            else
            {
                textBox1.Text = valueok;
                //JoinStackSMS(valueok);
            }
        }
        private void DisplaySMSText(object sender, EventArgs e)
        {
            /* Lọc bỏ các ký tự thừa */
            Regex r = new Regex(@"\n(.+)");
            MatchCollection matches = r.Matches(RxString);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                //DsSMS(groups[0].Value);
                //Hiển thị
                JoinStackSMS(groups[0].Value);
            }
        }
        Stack mystack = new Stack();
        private void JoinStackSMS(string valueok)
        {
            mystack.Push(valueok);
            //try
            {
                int Length = mystack.Count;
                string[] test3 = new string[Length];
                string laststr = mystack.Peek().ToString();
                //if(serialPort.ReadTimeout == 2000)
                {
                    //if (laststr.EndsWith("0xffff") == true)
                    {
                        for (int i = 0; i < Length; i++)
                        {
                            test3[i] = mystack.Pop().ToString();
                            //textBox1.Text += test3[i].ToString();
                            //teststack.Pop().ToString());
                        }
                    }
                }

                string abc = string.Concat(test3.Reverse());
                textBox1.Text = (abc);
                //DsSMS(abc);
            }
            //catch (Exception ex)
            {

            }
        }
        #endregion

        #region Process GSM
        public void configGMS()
        {
            serialPort.WriteLine("AT+CMGF=1"); // Set mode to Text(1) or PDU(0)
            Thread.Sleep(1000); // Give a second to write
            serialPort.WriteLine("AT+CPMS=\"SM\""); // Set storage to SIM(SM)
            Thread.Sleep(1000);
            serialPort.WriteLine("AT+CMGR=1");
            Thread.Sleep(1000);
            serialPort.WriteLine("AT+CMGL=\"ALL\""); // What category to read ALL, REC READ, or REC UNREAD
            Thread.Sleep(1000);
            serialPort.Write("\r");
            Thread.Sleep(1000);

            serialPort.WriteLine("AT+CNMI=2,2");
            Thread.Sleep(1000);
        }
        public delegate void SetTextCallback(string message);
        private void SendSMS()
        {
            try
            {
                //serialPort.Open();
                serialPort.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                serialPort.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                serialPort.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                //Send sms from textbox
                //serialPort.WriteLine("AT+CMGS=\"" + textBox1.Text + "\""+ Environment.NewLine);
                serialPort.WriteLine("AT+CMGS=\"" + "+84977413768" + "\"" + Environment.NewLine);
                Thread.Sleep(100);

                serialPort.WriteLine("Xin chao, day la tin nhan tu dong" + Environment.NewLine);
                Thread.Sleep(100);

                serialPort.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);

                var response = serialPort.ReadExisting();
                if (response.Contains("ERROR"))
                    MessageBox.Show("Send faill!", "Messeage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("SMS Send", "Messeage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void ReadSMS()
        {
            //serialPort.WriteLine("AT+CMGF=1"); // Set mode to Text(1) or PDU(0)
            //Thread.Sleep(1000); // Give a second to write
            //serialPort.WriteLine("AT+CPMS=\"SM\""); // Set storage to SIM(SM)
            //Thread.Sleep(1000);
            //serialPort.WriteLine("AT+CMGR=1");
            //Thread.Sleep(1000);
            //serialPort.WriteLine("AT+CMGL=\"ALL\""); // What category to read ALL, REC READ, or REC UNREAD
            //Thread.Sleep(1000);
            //serialPort.Write("\r");
            //Thread.Sleep(1000);

            //serialPort.WriteLine("AT+CNMI=2,2"); 
            //Thread.Sleep(1000);
        }
        
        #endregion

        #region Crypto service
        protected string SymEncryptMethod(string plainText)
        {
            var rsaHelper = new RsaHelper();
            string symKey = (rsaHelper._publicKey).ToString();

            /* 128 byte of encrypted message */
            string encryptedstring = StringCipher.Encrypt(plainText, symKey);

            return (encryptedstring);
        }
        protected string SymDecryptMethod(string encryptedstring)
        {
            var rsaHelper = new RsaHelper();
            string symKey = (rsaHelper._publicKey).ToString();

            /* 128 byte of encrypted message */
            string decryptedstring = StringCipher.Decrypt(encryptedstring, symKey);

            return (decryptedstring);
        }
        #endregion
    }
}
