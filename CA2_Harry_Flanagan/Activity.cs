using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_Harry_Flanagan
{
    /*enum*/
    enum TypeOfActivity
    {
        Air,
        Water,
        Land
    }
    class Activity
        {

            /*Propterties*/
            public string Name { get; set; }
            public DateTime ActivityDate { get; set; }
            public decimal Cost { get; set; }
            public string Description { get; set; }
            public TypeOfActivity TypeOfActivity { get; set; }

        /*Constructors*/

        public Activity(string name, string desctiption, DateTime activityDate, TypeOfActivity activityType, decimal cost)
        {
            Name = name;
            Description = desctiption;
            ActivityDate = activityDate;
            TypeOfActivity = activityType;
            Cost = cost;
       
            
        }
        //zero argument constructor
        public Activity()
        {

        }

        /*Methods*/
        public override string ToString()
        {
            string shortDate = ActivityDate.ToShortDateString();
            return $"{Name} - {shortDate}";
        }
    }
 
}
