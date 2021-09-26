using GSM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DAO
{
    public class SMSDAO
    {
        private static SMSDAO instance;

        public static SMSDAO Instance
        {
            get { if (instance == null) instance = new SMSDAO(); return SMSDAO.instance; }
            private set { SMSDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private SMSDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetSMSList");

            // Mỗi datarow trong data.row
            foreach (DataRow item in data.Rows) 
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}
