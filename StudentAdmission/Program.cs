using System;
namespace StudentAdmission;
class Program{
    public static void Main(string[] args){
        //Default Data Calling
        FileHandling.Create();
        //Operations.AddDefaultData();
        FileHandling.ReadFromCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}
