using Pationts.Business_Layer;
using Pationts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pationts
{
    internal class Program
    {
       
            public static readonly CRUD_Operation operation = CRUD_Operation.Instance;
        static void Main(string[] args)

        {
            int role;// to specify if the user is s a doctor or a patiant
            string Dr_ID;
            string Pat_ID;
            string description;
            int Patient_Coice;
            int Doctor_Coice;

            Console.WriteLine("Welcome to our Hospetal System \n  If you are a docor press 1 , and if you are a patient press 2");
            role = Convert.ToInt32(Console.ReadLine());
            if (role == 1 ) // if the user is a doctor
            {
                Console.WriteLine("Hello Doctor, Please enter your Id:");
                Dr_ID = Console.ReadLine();
                var result = operation.GetList1(Dr_ID); // show a doctor with a specific ID
                Console.WriteLine("Welcome");
                foreach (var item in result)
                {
                    Console.WriteLine("Your profile:");
                    Console.WriteLine(
                     item.Id + "\nName: " + item.Name +"\nSpecialty: "+item.Specialty +"\nWorking Hours: "+item.Working_Hours);
                }
                Console.WriteLine("\nchoose a service: 1- Add description 2- Confirm an appointment ");
                Doctor_Coice = Convert.ToInt32(Console.ReadLine());
                if(Doctor_Coice == 1)
                {
                    Console.WriteLine("please provide your patient ID:");
                    Pat_ID = Console.ReadLine();
                    Console.WriteLine("Please provide the description:");
                    description = Console.ReadLine();
                    var result2 = operation.GetList3(Dr_ID,Pat_ID,description); // add description to the DB for a specific patiant related to a doctor
                    if(result2 != null) { Console.WriteLine("description added successfully"); }
                }
                else
                { // cofirm an appointment for a pationt
                    Console.WriteLine("please provide your patient ID:");
                    Pat_ID = Console.ReadLine();
                    var result8 = operation.GetList5(Pat_ID,Dr_ID);
                    if (result8 != null) { Console.WriteLine("Appointment confirmed successfully"); }
                }
                Console.Read();

            }
            if (role == 2) // if the user is a patiant
            {
                Console.WriteLine("Hello Patient, Please enter your Id:");
                Pat_ID=Console.ReadLine();
                Console.WriteLine("Welcome, Your Profile: ");
                var result = operation.GetList(Pat_ID); // show patiant profile with his ID
                foreach (var item in result)
                {

                    Console.WriteLine(
                    "Id: "+item.Id +"\nName: "+item.Name +"\nAge: "+item.Age +"\nGender: "+ item.Gender);
                }
                Console.WriteLine("\nchoose a service: 1- View description 2- Book an appointment ");
                Patient_Coice = Convert.ToInt32(Console.ReadLine());
                if (Patient_Coice == 1)
                {
                    var result3 = operation.GetList4(Pat_ID); // view patiant description
                    foreach (var item in result3)
                    {

                        Console.WriteLine(
                        "Your Description: " + item.Dec_details);
                    }
                    Console.Read();
                }
                else
                {
                    
                    Console.WriteLine("Here all the doctors in the hospital:");
                    var result5 = operation.GetList1(null); // shaw all doctors to pick one by his ID
                    Console.WriteLine("Dr ID \t Dr Name \t Specialy \t Working Days");
                    foreach (var item in result5)
                    {
                        
                        Console.WriteLine(
                         item.Id + "\t" + item.Name + "\t" + item.Specialty + "\t" + item.Working_Hours);
                        
                    }
                    Console.WriteLine("Please enter the doctor ID for your Appointment: ");
                    Dr_ID = Console.ReadLine();
                    var result7 = operation.GetList1(Dr_ID);
                    string workingtime =null;
                    foreach (Doctor item in result7) { workingtime = item.Working_Hours; }
                    Console.WriteLine(workingtime);
                    var result6 = operation.GetList2(Dr_ID,Pat_ID, workingtime); // choose the appointment 
                    if (result6 != null) { Console.WriteLine("Appointment added succesfully"); }

                    Console.Read();
                    // Console.WriteLine("DB open");


                    Console.WriteLine("Write the Dr ID to pick an appointment");
                    Dr_ID = Console.ReadLine();
                    // Console.WriteLine("Database has been closed");
                    Console.Read();
                }
            }
        }
    }
}
