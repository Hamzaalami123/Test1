using Projet_Test1.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Projet_Test1.Services;

class Program
{
    static void Main()
    {
        var passengerService = ResolveServiceDI();

        var passengers = passengerService.CreatePassengers();

        var families = passengerService.DistributePassengersInFamilies(passengers);

        passengerService.DisplayOptimalDistribution(families);

    }

    private static IPassengerService ResolveServiceDI()
    {
        // Configuration du service DI
        var serviceProvider = new ServiceCollection()
            .AddTransient<IPassengerService, PassangerService>()
            .BuildServiceProvider();

        // Résolution de la dépendance
        var passengerService = serviceProvider.GetRequiredService<IPassengerService>();
        return passengerService;
    }

}