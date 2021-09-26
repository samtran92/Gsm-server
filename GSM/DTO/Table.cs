using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DTO
{
    public class Table
    {
        // Hàm dựng
        public Table(int id, string sms )
        {
            this.ID = id;
            this.Sms = sms;
        }
        // Hàm dựng
        public Table(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.Sms = row["SMS"].ToString();
        }

        private string sms;
        private int iD;

        public int ID 
        { 
            get => iD; 
            set => iD = value; 
        }
        public string Sms 
        { 
            get => sms; 
            set => sms = value; 
        }
    }
}
