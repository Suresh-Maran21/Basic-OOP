using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    public enum WorkLocation{Select,Onsite,Remote,Hybrid}
    public enum Gender {Select,Male,Female}
    public class EmployeeDetail
    {
        private static int s_empId=1000;
        public string EmpID{get;set;}
        public string EmpName{get;set;}
        public string Role{get;set;}
        public WorkLocation WorkLocation{get;set;}
        public string TeamName{get;set;}
        public DateTime DOJ{get;set;}
        public int WorkingDays{get;set;}
        public int LeaveTaken{get;set;}
        public Gender Gender{get;set;}
        public string MailID{get;set;}

        public EmployeeDetail(string empName,string role,WorkLocation workLocation,string teamName,DateTime doj,int workingDays,int leaveTake,Gender gender )
        {
            s_empId++;
            EmpID="SF"+s_empId;
            EmpName = empName;
            Role = role;
            WorkLocation = workLocation;
            TeamName=teamName;
            DOJ=doj;
            WorkingDays=workingDays;
            LeaveTaken=leaveTake;
            Gender=gender;
        }
    }
}