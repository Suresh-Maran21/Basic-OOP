using System;
using System.Collections.Generic;
namespace EBBill;
class Program
{
    public static void Main(string[] args)
    {
        List<EBDetails> ebList=new List<EBDetails>();
        int n;
        do{
            Console.WriteLine("***** Press *****\n1. Registration\n2. Login\n3. Exit");
            n = int.Parse(Console.ReadLine());
            switch(n)
            {
                case 1:
                {
                    Console.WriteLine("Registration From");
                    Console.Write("Enter Your User Name: ");
                    string userName=Console.ReadLine();
                    Console.Write("Enter Your Phone Number: ");
                    long phone=long.Parse(Console.ReadLine());
                    Console.Write("Enter Your Mail ID: ");
                    string mailID=Console.ReadLine();
                    Console.Write("Enter the Units: ");
                    int units = int.Parse(Console.ReadLine());

                    EBDetails ebInfo = new EBDetails(userName,phone,mailID,units);
                    Console.WriteLine("You have registered Successfully");
                    Console.WriteLine("Your Meter ID: "+ebInfo.EbID);
                    ebList.Add(ebInfo);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("***** LOGIN ******");
                    Console.Write("Enter Your Meter ID :");
                    string userID = Console.ReadLine();
                    bool flag = true;
                    foreach(EBDetails i in ebList)
                    {
                        if(i.EbID == userID)
                        {
                            Console.WriteLine($"WELOME{i.UserName}");
                            Console.WriteLine("***** PRESS *****\n1. Calculate Amount\n2. User Details\n3. Exit");
                            int input = int.Parse(Console.ReadLine());
                            switch(input)
                            {
                                case 1:
                                {
                                    Console.WriteLine("***** EB Amount ******");
                                    Console.WriteLine($"Meter ID : {i.EbID}");
                                    Console.WriteLine($"user Name : {i.UserName}");
                                    Console.WriteLine($"unit : {i.Units}");
                                    Console.WriteLine($"Amount : {EBBill(i.Units)}");
                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine("***** User Details *****");
                                    Console.WriteLine($"Meter ID : {i.EbID}");
                                    Console.WriteLine($"User Name : {i.UserName}");
                                    Console.WriteLine($"Phone Number : {i.Phone}");
                                    Console.WriteLine($"Mail ID : {i.MailID}");
                                    break;
                                }
                                case 3:
                                {
                                    break;
                                }
                                default:
                                {
                                    Console.WriteLine("Invalid Meter ID");
                                    break;
                                }
                            }
                            flag = false;
                        }
                    }
                    if(flag){
                        Console.WriteLine("Invalid Meter ID");
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
    public static int EBBill(int a)
    {
        return a*5;
    }
}
