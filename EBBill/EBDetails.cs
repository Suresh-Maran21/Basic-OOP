using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class EBDetails
    {
        private static int s_meterID = 1001;
        public string EbID{get;set;}
        public string UserName{get;set;}
        public long Phone{get;set;}
        public string MailID{get;set;}
        public int Units{get;set;}
        public EBDetails(string userName,long phone,string mailID, int units)
        {
            s_meterID++;
            EbID="EB"+s_meterID;
            UserName=userName;
            Phone=phone;
            MailID=mailID;
            Units=units;
        }
    }
}