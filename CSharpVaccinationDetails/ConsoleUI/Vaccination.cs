using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Vaccination
    {
      
        public DateTime Date { get; set; }
        public TypesOfVaccine ReqTypeVaccine { get; set; }


        public Vaccination( TypesOfVaccine reqTypeVaccine, DateTime date)
        {
            

            this.Date = date;
            this.ReqTypeVaccine = reqTypeVaccine;


        }

    }
   
    public enum TypesOfVaccine
    {
       covishield = 1,
       covaxin
    }
}
