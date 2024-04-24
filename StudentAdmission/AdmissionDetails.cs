using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Enum Declaration
    public enum AdmissionStatus{Select,Admitted, Cancelled}
    public class AdmissionDetails
    {
        private static int s_admissionID=1000;
        public string AdmissionID{get;}
        public string StudentID{get;set;}
        public string DepartmentID{get;set;}
        public DateTime AdmissionDate{get;set;}
        public AdmissionStatus AdmissionStatus{get;set;}

        //Constructors
        public AdmissionDetails (string studentId,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            //Auto Incrementation
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentId;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }

        public AdmissionDetails (string admission)
        {
            //Auto Incrementation
            string [] values =admission.Split(",");
            AdmissionID=values[0];
            s_admissionID=int.Parse(values[0].Remove(0,3));
            StudentID=values[1];
            DepartmentID=values[2];
            AdmissionDate=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            AdmissionStatus=Enum.Parse<AdmissionStatus>(values[4]);
        }
    }
}