
namespace GSM
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // loginToolStripMenuItem1
            // 
            this.loginToolStripMenuItem1.Image = global::GSM.Properties.Resources.login_icon_151220;
            this.loginToolStripMenuItem1.Name = "loginToolStripMenuItem1";
            this.loginToolStripMenuItem1.Size = new System.Drawing.Size(161, 32);
            this.loginToolStripMenuItem1.Text = "Login";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::GSM.Properties.Resources.logout;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(161, 32);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::GSM.Properties.Resources.quit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 32);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.saveToTextToolStripMenuItem.Click += new System.EventHandler(this.saveToTextToolStripMenuItem_Click);
            // 
            // speechToolStripMenuItem
            // 
            this.speechToolStripMenuItem.Image = global::GSM.Properties.Resources.spk;
            this.speechToolStripMenuItem.Name = "speechToolStripMenuItem";
            this.speechToolStripMenuItem.Size = new System.Drawing.Size(201, 32);
            this.speechToolStripMenuItem.Text = "Speech";
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Image = global::GSM.Properties.Resources._602495_200;
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(201, 32);
            this.historyToolStripMenuItem.Text = "History";
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1156, 38);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 553);
            this.panel1.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(438, 544);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(456, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(685, 544);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(216)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1156, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
    }
}