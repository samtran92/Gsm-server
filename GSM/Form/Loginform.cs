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
using System.Diagnostics;
using GSM.DAO;

namespace GSM
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
            LoadAccountlist();
        }



        #region Loaddatafrom Database
        public void LoadAccountlist()
        {

        }

        #endregion

        #region Systemfunction
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            if(Login(username,password))
            {
                Form1 form = new Form1();
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong name or password");
            }
        }

        bool Login(string username,string passwork)
        {

            return AccountDAO.Instance.Login(username, passwork);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Loginform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit?","Notification", MessageBoxButtons.OKCancel)!=System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void Loginform_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
