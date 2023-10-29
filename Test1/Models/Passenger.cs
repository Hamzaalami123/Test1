using Projet_Test1.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Enums;

namespace Test1.Models
{
    
    public class Passenger
    {

        public string ID { get; set; }
        public PassengerType Type { get; set; }
        public int Age { get; set; }
        public string Family { get; set; }
        public bool RequiresExtraSeat { get; set; }

        public Passenger(string id, PassengerType type, int age, string family, bool requiresExtraSeat)
        {
            ID = id;
            Type = type;
            Age = age;
            Family = family;
            RequiresExtraSeat = requiresExtraSeat;
        }

        public int TicketPrice()
        {
            if (Type == PassengerType.Adulte)
            {
                return RequiresExtraSeat ? 500 : 250;
            }
            else if (Type == PassengerType.Enfant)
            {
                return 150;
            }
            return 0;
        }

        public bool Alone()
        {
            return (Family == Const.DASH);
        }

    }
}
