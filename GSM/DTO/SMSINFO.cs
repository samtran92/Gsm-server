using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DTO
{
    public class SMSINFO
    {
        private int smsID;
        private int iD;

        public int ID 
        { 
            get => iD; 
            set => iD = value; 
        }
        public int SmsID 
        { 
            get => smsID; 
            set => smsID = value; 
        }
    }
}
