using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using GSM.DAO;
using System.Windows.Forms;
using GSM.DTO;

namespace GSM
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            //LoadAccountList();
            LoadSMS();
        }
        #region Method
        void LoadAccountList()
        {

            string query = "EXEC dbo.USP_GetAccountByUserName @userName";

            //dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "Admin" });
        }
        void LoadSMS()
        {
            List <Table> tableList = SMSDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = SMSDAO.TableWidth, Height = SMSDAO.TableHeight };
                
                btn.Text = item.ID + Environment.NewLine + item.Sms;

                btn.Click += Btn_Click; ;
                btn.Tag = item;

                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        void ShowSMS(int id)
        {

        }
        #endregion

        #region Event
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = (sender as Table).ID;
            ShowSMS(tableID);
        }
        private void History_Load(object sender, EventArgs e)
        {

        }

        private void saveToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
    }
}
