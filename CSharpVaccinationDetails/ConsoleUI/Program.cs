using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private List<BenificiaryDetails> benificiaryDetails = new List<BenificiaryDetails>();
        static void Main(string[] args)
        {
            
            Program userObject = new Program();
            userObject.DefaultUserDetails();
            
            string option = string.Empty;
            do
            {


                Console.WriteLine("Application For Vaccination Drive");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Beneficiary Registarion 2. Vaccination 3.Exit");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine(" ");
                Console.WriteLine("Enter the input");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Benificiar Details");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Enter the name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the phone number: ");
                    long phoneNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the city: ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter the age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("------Enter the gender-----\n1. Male\n2. Female\n3. Others: ");
                    PersonGender gender = (PersonGender)int.Parse(Console.ReadLine());

                    BenificiaryDetails benificiary = new BenificiaryDetails(name, phoneNumber, city, age, gender);
                    Console.WriteLine($"Your Register Number : {benificiary.RegistartionNumber}");
                    Console.WriteLine("--------------------------------------");




                }
                else if (input == 2)
                {
                    userObject.Vaccinations();

                }
                else if (input == 3)
                {
                    Environment.Exit(-1);
                }
                else
                {
                    Console.WriteLine("Enter the valid Input");
                }

                Console.WriteLine("Enter the option----YES/NO");
                option = Console.ReadLine().ToUpper();

            } while (option == "YES");
            Console.ReadLine();
        }
        public void DefaultUserDetails()
        {
            var data1 = new BenificiaryDetails("Yuvanesh", 09978675, "HHH", 65, (PersonGender)1);
            var data2 = new BenificiaryDetails("vish", 089797, "CMR", 98, (PersonGender)1);
            benificiaryDetails.Add(data1);
            benificiaryDetails.Add(data2);
        }
       

        public void Vaccinations()
        {
            string userOption;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("------->> Vaccine Details <<----------");
            Console.WriteLine("--------------------------------------");
            Console.Write("Register Number : ");
            int registerNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            foreach (BenificiaryDetails details in benificiaryDetails)
            {
                if (details.RegistartionNumber == registerNumber)
                {
                    Console.WriteLine($"Welcome Mr/Ms : {details.Name}");
                    Console.WriteLine("--------------------------------------");
                    do
                    {
                        Console.WriteLine("1. Take vaccination");
                        Console.WriteLine("2. Vaccination History");
                        Console.WriteLine("3. Next Due Date");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("--------------------------------------");
                        Console.Write("Enter Your Option : ");
                        int userChoose = int.Parse(Console.ReadLine());
                        switch (userChoose)
                        {
                            case 1:
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("Which Vaccine Do you Want ? ");
                                Console.WriteLine(" 1. CovinShild\n 2. Covaxin\n 3. Sputnic");
                                Console.WriteLine("--------------------------------------");
                                Console.Write("Enter Your Option : ");
                                TypesOfVaccine reqTypeVaccine = (TypesOfVaccine)int.Parse(Console.ReadLine());
                                Console.WriteLine("--------------------------------------");
                                if (details.RegistartionNumber == registerNumber)
                                {
                                    Vaccination user = new Vaccination(reqTypeVaccine, DateTime.Now);

                                    if (details.Vaccination == null)
                                    {
                                        details.Vaccination = new List<Vaccination>();
                                    }
                                    details.Vaccination.Add(user);
                                }
                                Console.WriteLine("You Have Vaccinated Succesfully");
                                break;
                            case 2:
                                VaccinHistory(registerNumber);
                                break;
                            case 3:
                                DueDate(registerNumber);
                                break;
                            case 4:

                            default:
                                Console.WriteLine("Invalid Option");
                                break;

                        }
                        Console.WriteLine("--------------------------------------");
                        Console.Write("Do you want to continue ? ( yes / no ) : ");
                        userOption = Console.ReadLine().ToLower();
                    }
                    while (userOption == "yes");
                }
            }
        }
        public void VaccinHistory(int registernumber)
        {
            foreach (BenificiaryDetails detail in benificiaryDetails)
            {
                if (detail.RegistartionNumber == registernumber)
                {
                    if (detail.Vaccination != null)
                    {
                        Console.WriteLine($"Name : {detail.Name}\n" +
                                          $"Age : {detail.Age}\n" +
                                          $"Gender : {detail.Gender}\n" +
                                          $"Mobile Number : {detail.PhoneNumber} \n" +
                                          $"City : {detail.City}\n" +
                                          $"Vaccination : {detail.Vaccination[0].ReqTypeVaccine}");
                    }
                }
            }
        }
        void DueDate(int regno)
        {
            foreach (BenificiaryDetails detail in benificiaryDetails)
            {
                if (detail.RegistartionNumber == regno)
                {
                    if (detail.Vaccination != null)
                    {
                        if (detail.Vaccination.Count == 1)
                        {
                            Console.WriteLine($"Next Vaccine Due :{detail.Vaccination[0].ReqTypeVaccine}");
                            Console.WriteLine($"Next Due date :{detail.Vaccination[0].Date.AddDays(15)}");
                        }

                        else if (detail.Vaccination.Count == 2)
                        {
                            Console.WriteLine("You Have Completed The Vaccination Course.\nThanks For Your Participation in The Vaccination Drive");
                        }
                    }
                }
            }
        }
      

        
        
    }
}
