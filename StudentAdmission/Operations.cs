using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Static Class
    public static class Operations
    {
        //Local/Global Object Creation
        public static StudentDetails currentLoggedInStudent;
        //Static list creation
        public static List<StudentDetails> studentList=new List<StudentDetails>();
        public static List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
        public static List <AdmissionDetails> admissionList=new List<AdmissionDetails>();


        //Main menu
        public static void MainMenu()
        {
            Console.WriteLine("******Welocome to Syncfusion College******");
            string mainChoice="yes";
            do
            {
                //Need to show the main menu option
                Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Departmentwise seat Availability\n4. exit");
                //Need to get an input from user and validation.
                Console.Write("Select an Option: ");
                int mainOption = int.Parse(Console.ReadLine());
                //Need to create Mainmenu Structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("********Student Registration***********");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*******Student Login*******");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("********Departmentwise Seat Availabilty***********");
                            DepartmentwiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application Exited Successfully");
                            mainChoice="no";
                            break;
                        }
                }
                //Need to iterate until the option is exit.
            } while (mainChoice=="yes");
        }//Main menu ends
        //Student Registration
        public static void StudentRegistration()
        {
            //Need to get required details
            Console.Write("Enter your name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your FatherName : ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your DOB Specified Dd/MM/YYYY ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your gender (Male/Female)");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your PhysicsMark: ");
            int physicsMark=int.Parse(Console.ReadLine());
             Console.Write("Enter your ChemistryMark: ");
            int chemistryMark=int.Parse(Console.ReadLine());
             Console.Write("Enter your MathsMark: ");
            int mathsMark=int.Parse(Console.ReadLine());
            //need to create an object
            StudentDetails student = new StudentDetails(name,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
            //Need to add in the list
            studentList.Add(student);
            //Need to display Confirmation message and ID
            Console.WriteLine($"Registration Successfully.Student ID {student.StudentID}");

        }//Student Registration ends
        //student longin
        public static void StudentLogin()
        {
            //Need to get ID input
            Console.Write("Enter Your student ID: ");
            string loginID=Console.ReadLine().ToUpper();
            //Validate ny its presence in the list
            bool flag=true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    flag=false;
                    //Assigning current user to golbal variable
                    currentLoggedInStudent=student;
                    Console.WriteLine("Logged in successfully");
                    //Need to call  sub menu
                    SubMenu();
                    break;
                }
            }
            if(flag){
                Console.WriteLine("Invalid ID or ID is not present");
            }
            //If not-Invalid data

        }//student longin ends
        // submenu
        public static void SubMenu()
        {
            string subChoice = "yes";
            do{
                Console.WriteLine("*******Submenu********");
                Console.WriteLine("Select an option\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Admission Details\n6. Exit");
                //Need to show sub menu option
                Console.WriteLine("Enter your option: ");
                //Getting user option
                 int subOption=int.Parse(Console.ReadLine());
                 //Need to create Sub menu Structure
                 switch(subOption){
                    case 1:
                    {
                        Console.WriteLine("******** Check Eligibility********");
                        ChechEligibility();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("********Show Details*********");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.Write("*******take Admission*********");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*********Cancel Admission********");
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("**********Admission Details********");
                        AdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("Taking Back to MainMenu");
                        subChoice = "no";
                        break;
                    }
                 }
                //Iterate till the option is exit.
            }while(subChoice=="yes");
        }//Submenu Ends

        //Check El;igibility
        public static void ChechEligibility()
        {
            //Get the CutOff Value As Input
            Console.Write("Enter the cutoff value: ");
            double cutOff=double.Parse(Console.ReadLine());
            //Check eligible or not
            if(currentLoggedInStudent.CheckEligibility(cutOff))
            {
                Console.WriteLine("Student is eligibile");
            }
            else
            {
                Console.WriteLine("Student is Not Eligibile");
            }

        }//CheckEligibility Ends

        //Show Details
        public static void ShowDetails()
        {
            //Need show current Student's Details
            Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}");


        }//Show Details Ends

        //Take Admission
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentwiseSeatAvailability();
            //Ask department ID from user
            Console.Write("Select a department ID: ");
            string departmentID=Console.ReadLine().ToUpper();
            //Check the ID is present or not
            bool flag=true;
            foreach (DepartmentDetails department in departmentList)
            {
                if (departmentID.Equals(department.DepartmentID))
                {
                    flag = false;
                    //Check the student is eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //Check the seat Availability
                        if(department.NumberOfSeats>0)
                        {
                            //Check student altready taken any admission
                            int count =0;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&& admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                //create admission object
                                AdmissionDetails admissionTaken=new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                //reduce seat count.
                                department.NumberOfSeats--;
                                //add to the admission list
                                admissionList.Add(admissionTaken);
                                //Display admission successful message.
                                Console.WriteLine($"You have taken admission successfully. Admission ID: {admissionTaken.AdmissionID}");

                            }
                            else
                            {
                                Console.WriteLine("You have already taken an admission");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You are not eligibile due to low cutoff");
                    }
                    
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Id");
            }


        }//Take Admission Ends
        //Cancel Admission
        public static void CancelAdmission()
        {
            //check the student is taken any admission and display it.
            bool flag=true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&&admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    //cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to department.
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }

                    }
                    break;

                }
            }
            if(flag)
            {
                Console.WriteLine("You have not admission to cancel");
            }
            

        }//CancelAdmission Ends
        //Admission Details
        public static void AdmissionDetails()
        {
            //Need to show current logged in student's Admission details
            Console.WriteLine("|Admission ID|Student ID|Department ID|Admission Date|Admission Status|");
            foreach(AdmissionDetails admission in admissionList){
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    Console.WriteLine($"|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
                }
            }

        }//AdmissionDetails ends

        //Departmentwise Seatr Availability
        public static void DepartmentwiseSeatAvailability()
        {
            //Need show all department details
            Console.WriteLine("|DepartmentID|DepartmentName|NumberOfSeat|");
            foreach (DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID}|{department.NumberOfSeats}");

            }
            Console.WriteLine();
        }//Departmentwise Seatr Availability Ends.

        //Adding default Data
        public static void AddDefaultData()
        {
            StudentDetails student1=new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2=new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.AddRange(new List<StudentDetails>{student1,student2});

            DepartmentDetails department1=new DepartmentDetails("EEE",29);
            DepartmentDetails department2=new DepartmentDetails("CSE",29);
            DepartmentDetails department3=new DepartmentDetails("MECH",30);
            DepartmentDetails department4=new DepartmentDetails("ECE",30);
            departmentList.AddRange(new List<DepartmentDetails>{department1,department2,department3,department4});

            AdmissionDetails admission1=new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            AdmissionDetails admission2=new AdmissionDetails(student2.StudentID,department2.DepartmentID,new DateTime(2022,05,12),AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>{admission1,admission2});

            
            //Console.WriteLine();

        }
        
    }
}