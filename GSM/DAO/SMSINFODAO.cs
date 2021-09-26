using GSM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DAO
{
    // Lấy thông tin SMS Info
    public class SMSINFODAO
    {
        private static SMSINFODAO instance;

        public static SMSINFODAO Instance
        {
            get { if (instance == null) instance = new SMSINFODAO(); return SMSINFODAO.instance; }
            private set { SMSINFODAO.instance = value; }
        }

        private SMSINFODAO() {}

        public int GetUncheckSMSIdByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * from dbo.SMSINFO WHERE Id = "+ id +"AND Infordatetime = GETDATE()");
            if(data.Rows.Count > 0)
            {
                SMS sms = new SMS(data.Rows[0]);
                return sms.ID;
            }
            return  -1;
        }
    }
}
