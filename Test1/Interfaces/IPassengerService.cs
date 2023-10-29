using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Models;

namespace Projet_Test1.Interfaces
{
    internal interface IPassengerService
    {
        List<Passenger> CreatePassengers();
        List<Family> DistributePassengersInFamilies(List<Passenger> passengers);
        void DisplayOptimalDistribution(List<Family> families);
    }
}
