using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Enum Declaration
    public enum Gender{Select, Male, Female}
    public class StudentDetails
    {
        //Field
        //Static field
        private static int s_studentID = 3000;
        //Properties
        public string StudentID{get;} //Read Only property
        public string StudentName{get;set;}
        public string FatherName{get;set;}
        public DateTime DOB{get;set;}
        public Gender Gender{get;set;}
        public int PhysicsMark{get;set;}
        public int ChemistryMark{get;set;}
        public int MathsMark{get;set;}

        //Constructors
        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender, int physicsMark,int chemistryMark,int mathsMark)
        {
            //Auto Incrementation
            s_studentID++;
            StudentID = "SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            PhysicsMark=physicsMark;
            ChemistryMark=chemistryMark;
            MathsMark=mathsMark;
        }
        public StudentDetails(string student)
        {
            string [] values = student.Split(",");
            StudentID = values[0];
            s_studentID=int.Parse(values[0].Remove(0,2));
            StudentName=values[1];
            FatherName=values[2];
            DOB=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender=Enum.Parse<Gender>(values[4]);
            PhysicsMark=int.Parse(values[5]);
            ChemistryMark=int.Parse(values[6]);
            MathsMark=int.Parse(values[7]);

        }

        //Methods
        public double Average()
        {
            int total=PhysicsMark+ChemistryMark+MathsMark;
            double average=(double)total/3;
            return average;

        }
        public bool CheckEligibility(double CutOff)
        {
            if(Average()>= CutOff){
                return true;
            }else{
                return false;
            }
        }
    }
}