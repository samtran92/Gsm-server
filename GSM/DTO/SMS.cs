using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DTO
{
    public class SMS
    {
        public SMS(int id, DateTime? Infordatetime)
        {
            this.ID = id;
            this.Infordatetime = Infordatetime;
        }
         public SMS(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Infordatetime = (DateTime)row["Infordatetime"];
        }

        private DateTime? Infordatetime;

        private int iD;

        public int ID { get => iD; set => iD = value; }
        public DateTime? Infordatetime1 { get => Infordatetime; set => Infordatetime = value; }
    }
}
