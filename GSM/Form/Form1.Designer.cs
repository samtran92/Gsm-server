
namespace GSM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.comboBox_SerialPorts = new System.Windows.Forms.ComboBox();
            this.lblConnectStatus = new System.Windows.Forms.Label();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(13, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "STATUS";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 190);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(991, 242);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(13, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "CONTENT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(37)))), ((int)(((byte)(123)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(828, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 67);
            this.button1.TabIndex = 4;
            this.button1.Text = "Speech";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM8";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnSerialPort);
            // 
            // comboBox_SerialPorts
            // 
            this.comboBox_SerialPorts.FormattingEnabled = true;
            this.comboBox_SerialPorts.Location = new System.Drawing.Point(146, 52);
            this.comboBox_SerialPorts.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_SerialPorts.Name = "comboBox_SerialPorts";
            this.comboBox_SerialPorts.Size = new System.Drawing.Size(672, 33);
            this.comboBox_SerialPorts.TabIndex = 5;
            this.comboBox_SerialPorts.SelectedIndexChanged += new System.EventHandler(this.comboBox_SerialPorts_SelectedIndexChanged);
            // 
            // lblConnectStatus
            // 
            this.lblConnectStatus.AutoSize = true;
            this.lblConnectStatus.Location = new System.Drawing.Point(146, 104);
            this.lblConnectStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblConnectStatus.Name = "lblConnectStatus";
            this.lblConnectStatus.Size = new System.Drawing.Size(0, 25);
            this.lblConnectStatus.TabIndex = 6;
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(37)))), ((int)(((byte)(123)))));
            this.btnSendSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.ForeColor = System.Drawing.Color.White;
            this.btnSendSMS.Location = new System.Drawing.Point(828, 115);
            this.btnSendSMS.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(176, 66);
            this.btnSendSMS.TabIndex = 7;
            this.btnSendSMS.Text = "SendSMS";
            this.btnSendSMS.UseVisualStyleBackColor = false;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 36);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem1,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.loginToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(76, 32);
            this.loginToolStripMenuItem.Text = "Menu";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem1
            // 
            this.loginToolStripMenuItem1.Image = global::GSM.Properties.Resources.login_icon_151220;
            this.loginToolStripMenuItem1.Name = "loginToolStripMenuItem1";
            this.loginToolStripMenuItem1.Size = new System.Drawing.Size(161, 32);
            this.loginToolStripMenuItem1.Text = "Login";
            this.loginToolStripMenuItem1.Click += new System.EventHandler(this.loginToolStripMenuItem1_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::GSM.Properties.Resources.logout;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(161, 32);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::GSM.Properties.Resources.quit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 32);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToTextToolStripMenuItem,
            this.speechToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.toolToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(63, 32);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // saveToTextToolStripMenuItem
            // 
            this.saveToTextToolStripMenuItem.Image = global::GSM.Properties.Resources._3480482;
            this.saveToTextToolStripMenuItem.Name = "saveToTextToolStripMenuItem";
            this.saveToTextToolStripMenuItem.Size = new System.Drawing.Size(201, 32);
            this.saveToTextToolStripMenuItem.Text = "Save to text";
            // 
            // speechToolStripMenuItem
            // 
            this.speechToolStripMenuItem.Image = global::GSM.Properties.Resources.spk;
            this.speechToolStripMenuItem.Name = "speechToolStripMenuItem";
            this.speechToolStripMenuItem.Size = new System.Drawing.Size(201, 32);
            this.speechToolStripMenuItem.Text = "Speech";
            this.speechToolStripMenuItem.Click += new System.EventHandler(this.speechToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Image = global::GSM.Properties.Resources._602495_200;
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(201, 32);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.manualToolStripMenuItem});
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(67, 32);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = global::GSM.Properties.Resources.manual;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.ShortcutKeyDisplayString = "";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(163, 32);
            this.aboutToolStripMenuItem1.Text = "Manual";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Image = global::GSM.Properties.Resources._2940537_200;
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(163, 32);
            this.manualToolStripMenuItem.Text = "About";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 44);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(216)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1017, 444);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.lblConnectStatus);
            this.Controls.Add(this.comboBox_SerialPorts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main GSM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox comboBox_SerialPorts;
        private System.Windows.Forms.Label lblConnectStatus;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}

