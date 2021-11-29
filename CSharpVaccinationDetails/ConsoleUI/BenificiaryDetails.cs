using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class BenificiaryDetails
    {
        public int RegistartionNumber { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public PersonGender Gender { get; set; }
        public List<Vaccination> Vaccination { get; internal set; }

        public List<BenificiaryDetails> benificiaryDetails = new List<BenificiaryDetails>();

        private int autoIncrementRegistrationNumber = 100;
       

        public BenificiaryDetails( string name, long phoneNumber, string city, int age, PersonGender gender)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.City = city;
            this.Age = age;
            this.Gender = gender;
            this.RegistartionNumber = autoIncrementRegistrationNumber;
            autoIncrementRegistrationNumber++;
        }
      
    }
    public enum PersonGender
    {
        Male = 1,
        Female,
        Others
    }
}
