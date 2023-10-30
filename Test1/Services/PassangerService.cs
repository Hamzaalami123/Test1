using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Test1.Models;
using Projet_Test1.Interfaces;
using System.Text;
using System.Text.Json;

namespace Projet_Test1.Services
{
    internal class PassangerService:IPassengerService
    {
        List<Passenger> IPassengerService.CreatePassengers()
        {
            string filePath = @"../../../Data/passengers.csv";
            var passengers = ReadPassengersFromCSV(filePath);

            return passengers.Take(200).ToList();
        }
        private List<Passenger> ReadPassengersFromCSV(string filePath)
        {
            try
            {
                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Encoding = Encoding.UTF8, // Our file uses UTF-8 encoding.
                    Delimiter = ";", // The delimiter is a comma.
                    HasHeaderRecord = false,
                };
                using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (var textReader = new StreamReader(fs, Encoding.UTF8))
                    using (var csv = new CsvReader(textReader, configuration))
                    {
                        csv.Context.TypeConverterOptionsCache.GetOptions<bool>().BooleanFalseValues.Add("Non");
                        csv.Context.TypeConverterOptionsCache.GetOptions<bool>().BooleanTrueValues.Add("Oui");

                        var passengers = csv.GetRecords<Passenger>().ToList();
                        return passengers;
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs de lecture du fichier CSV
                Console.WriteLine("Erreur lors de la lecture du fichier CSV : " + ex.Message);
                return new List<Passenger>(); // Ou une liste vide ou une autre valeur par défaut, selon votre besoin.
            }
        }


        List<Family> IPassengerService.DistributePassengersInFamilies(List<Passenger> passengers)
        {
            // Triez les passagers par prix décroissant.
            passengers = passengers.OrderByDescending(p => p.TicketPrice()).ToList();

            var families = new List<Family>();

            foreach (Passenger passenger in passengers)
            {
                // Essayez de trouver une famille à laquelle le passager peut être ajouté.
                var targetFamily = families.FirstOrDefault(family =>
                    !family.IsFull(passenger.Type) &&
                    family.Members.First().Family == passenger.Family &&
                    !passenger.Alone());

                if (targetFamily != null)
                {
                    targetFamily.Members.Add(passenger);
                }
                else
                {
                    // Si aucune famille ne convient, créez une nouvelle famille.
                    var newFamily = new Family();
                    newFamily.Members.Add(passenger);
                    families.Add(newFamily);
                }
            }

            return families;
        }


        void IPassengerService.DisplayOptimalDistribution(List<Family> families)
        {
            int totalRevenue = families.Sum(family => family.TotalPrice());

            // Affichez la répartition optimale des passagers et familles ainsi que le chiffre d'affaires total généré.
            foreach (Family family in families)
            {
                Console.WriteLine(value: $"Famille :{family.Members.First().Family}");
                foreach (Passenger member in family.Members)
                {
                    Console.WriteLine($"  - {member.ID}, Type : {member.Type},Famille : {member.Family}, Age : {member.Age}, Prix : {member.TicketPrice()} €");
                }
                Console.WriteLine($"Prix total pour la famille : {family.TotalPrice()} €\n");
            }

            Console.WriteLine($"Chiffre d'affaires total généré : {totalRevenue} €");
        }
    }
}
