using System;
using System.Collections.Generic;
namespace EmployeePayrollManagement;
class Program{
    public static void Main(string[] args){
        List<EmployeeDetail> empList = new List<EmployeeDetail>();
        int n;
        do{
            Console.WriteLine("Hello Employee!! Here the menu,");
            Console.WriteLine("##### PRESS #####\n1.Registration\n2.Login\n3.Exit");
            n = int.Parse(Console.ReadLine());

            switch(n)
            {
                case 1:
                {
                    Console.WriteLine("Employee Registration Form");
                    Console.Write("Employee Name : ");
                    string empName = Console.ReadLine();
                    Console.Write("Gender : ");
                    Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
                    Console.Write("Role : ");
                    string role = Console.ReadLine();
                    Console.Write("Work Location : ");
                    WorkLocation workLocation = Enum.Parse<WorkLocation>(Console.ReadLine(), true);
                    Console.Write("Team Name : ");
                    string teamName = Console.ReadLine();
                    Console.Write("Date of Joining DD/MM/YYYY : ");
                    DateTime doj = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.Write("Number of Working Days in Month : ");
                    int WorkingDays = int.Parse(Console.ReadLine());
                    Console.Write("Number of Leave Taken in Month : ");
                    int leaveTake=int.Parse(Console.ReadLine());

                    EmployeeDetail empInfo=new EmployeeDetail(empName,role,workLocation,teamName,doj,WorkingDays,leaveTake,gender);
                    Console.WriteLine("You have registered successfully");
                    Console.WriteLine("Your Emp ID : "+ empInfo.EmpID);
                    empList.Add(empInfo);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("##### LoGIN #####");
                    Console.WriteLine("Enter your Emp ID : ");
                    string userID = Console.ReadLine();
                    bool flag = true;

                    foreach (EmployeeDetail i in empList){
                        if(i.EmpID == userID){
                            Console.WriteLine($"##### Welocome {i.EmpName}!!");
                            Console.WriteLine("##### PRESS #####\n1.Salary Details\n2.Employee Details\n3.Exit");
                            int input = int.Parse(Console.ReadLine());
                            switch(input){
                                case 1:
                                {
                                    Console.WriteLine("##### SALARY DETAILS #####");
                                    Console.WriteLine($"Your Salary is : {Salary(i.WorkingDays, i.LeaveTaken)}");
                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine("##### EMPLOYEE DETAILS #####");
                                    Console.WriteLine($"Employee ID : {i.EmpID}");
                                    Console.WriteLine($"Employee Name : {i.EmpName}");
                                    Console.WriteLine($"Gender : {i.Gender}");
                                    Console.WriteLine($"Role : {i.Role}");
                                    Console.WriteLine($"Work Location : {i.WorkLocation}");
                                    Console.WriteLine($"Team Name : {i.TeamName}");
                                    Console.WriteLine($"Date Of Joining : {i.DOJ.ToString("dd/MM/yyyy")}");
                                    break;
                                }
                                case 3:
                                {
                                    break;
                                }
                                default:
                                {
                                    Console.WriteLine("Invalid Option");
                                    break;
                                }
                            }
                            flag=false;
                        }
                    }
                    if(flag)
                    {
                        Console.WriteLine("Invalid Employee ID");
                        break;
                    }
                    break;
                }
                case 3:
                {
                    break;
                }
            }
        }while(n!=3);
    }
    public static int Salary(int a, int b){
        return (a-b) * 500;
    }
}
