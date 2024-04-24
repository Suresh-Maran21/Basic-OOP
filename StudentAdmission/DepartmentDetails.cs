using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        /*
        a.	AdmissionID – (Auto Increment ID - AID1001)
        */
        //Field
        //Static Field
        private static int s_departmentID=100;

        //Properties
        public string DepartmentID{get;}
        public string DepartmentName{get;set;}
        public int NumberOfSeats{get;set;}

        //Constructors
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            s_departmentID++;
            DepartmentID ="DID"+ s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats  = numberOfSeats;
        }

        public DepartmentDetails(string department)
        {
            string [] values=department.Split(",");
            DepartmentID =values[0];
            s_departmentID=int.Parse(values[0].Remove(0,3));
            DepartmentName=values[1];
            NumberOfSeats  = int.Parse(values[2]);
        }
    }
}