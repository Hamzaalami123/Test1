using Test1.Enums;

namespace Test1.Models
{
    public class Family
    {
        private static Dictionary<PassengerType, int> maxAllowedPassengers = new Dictionary<PassengerType, int>
        {
        { PassengerType.Adulte, 2 },
        { PassengerType.Enfant, 3 }
        };
        public List<Passenger> Members { get; set; } = new List<Passenger>();

        public int TotalPrice()
        {
            return Members.Sum(member => member.TicketPrice());
        }

        public bool IsFull(PassengerType passengerType)
        {
            int membersCount = Members.Count(member => member.Type == passengerType);
            return membersCount >= GetMaxAllowed(passengerType);
        }

        private static int GetMaxAllowed(PassengerType passengerType)
        {
            if (maxAllowedPassengers.ContainsKey(passengerType))
            {
                return maxAllowedPassengers[passengerType];
            }
            else
            {
                throw new ArgumentException("PassengerType non pris en charge");
            }
        }
    }
}
