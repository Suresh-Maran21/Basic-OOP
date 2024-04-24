using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public enum Gender { Select, Male, Female, Transgender }
    /// <summary>
    /// 
    /// This class perform an important function.
    /// 
    /// </summary>
    /// <summary>
    /// Class BankDetails used to create instance for instance for student<see cref="BankDetails"/>
    /// Refer documentation on <see herf=" www.syncfusion.com"/>  
    public class BankDetails
    {
        /*
        Class May contains
        1.Field - Static & Non static
        2.Events
        3.Properties
        4.Indexers
        5.Constructors
        6.Destructors
        7.Methods
        */
        private static int s_customerID = 1000;
        //Auto Property
        //Type "prop" and Press "tab" Key.
        /// <summary>
        /// CustomerID Property used to hold a Customer's ID of instance <see cref="BankDetails"/> 
        /// </summary>
        /// <value></value>
        public string CustomerName{get;set;}
        public string CustomerID{get;set;}
        /// <summary>
        /// FirstName Property used to Hold FirstName of a instance of <see cref="BankDetails"/> 
        /// </summary> <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Balance{get;set;}
        /// <summary>
        /// 
        /// DataType Gender used to select a instance of <see cref="BankDetails"/> Gender Information 
        /// 
        /// </summary>
        /// <value></value>
        public Gender Gender{get;set;}
        /// <summary>
        /// Gneder Property used to hold Gender of instance of <see cref="BankDeastils"/> 
        /// </summary>
        /// <value></value>
        public long Phone{get;set;}
        public string MailID{get;set;}
        public DateTime DOB{get;set;}
        /// <summary>
        /// 
        /// Constructor BankDetails used to initialize default values to its properties. 
        /// 
        /// </summary>
        public BankDetails()
        {
            CustomerName="Enter your name: ";
            Gender = Gender.Select;
        }
        /// <summary>
        /// Constructor BankDetails used to initialize parameter values to its properties.
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="balance"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="mailID"></param>
        /// <param name="dob"></param> <summary>
        /// 
        /// </summary>
        /// <param name="customerName"><customerName parameter  used to assign its value to associated property</param>
        /// <param name="balance"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="mailID"></param>
        /// <param name="dob"></param>
        public BankDetails(string customerName, int balance, Gender gender, long phone, string mailID, DateTime dob)
        {
            s_customerID++;
            CustomerID = "HDFC" + s_customerID;
            CustomerName = customerName;
            Balance = balance;
            Gender = gender;
            Phone = phone;
            MailID = mailID;
            DOB = dob;
        }

    }
    
}