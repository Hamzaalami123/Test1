

using Projet_Test1.Const;
using Test1.Enums;
using Test1.Models;

namespace TestProject
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestTotalPriceCalculation()
        {
            // Créer une famille pour les tests
            var family = new Family();
            var passenger1 = new Passenger("1", PassengerType.Adulte, 30, "A", false);
            var passenger2 = new Passenger("2", PassengerType.Enfant, 8, "A", false);
            var passenger3 = new Passenger("3", PassengerType.Adulte, 35, "B", true);
            family.Members.AddRange(new List<Passenger> { passenger1, passenger2, passenger3 });

            // Le prix total pour cette famille devrait être de 500 + 150 + 250 = 900
            Assert.AreEqual(900, family.TotalPrice());
        }

        [TestMethod]
        public void TestFamilyIsFullWithMaxAdults()
        {
            // Créer une famille avec 2 adultes (maximum)
            var family = new Family();
            family.Members.AddRange(new List<Passenger>
        {
            new Passenger("1", PassengerType.Adulte, 30, "A", false),
            new Passenger("2", PassengerType.Adulte, 32, "A", false),
        });

            // Cette famille est pleine, IsFull() devrait renvoyer true
            Assert.IsTrue(family.IsFull());
        }

        [TestMethod]
        public void TestFamilyIsFullWithMaxChildren()
        {
            // Créer une famille avec 3 enfants (maximum)
            var family = new Family();
            family.Members.AddRange(new List<Passenger>
        {
            new Passenger("3", PassengerType.Enfant, 7, "A", false),
            new Passenger("4", PassengerType.Enfant, 4, "A", false),
            new Passenger("5", PassengerType.Enfant, 2, "A", false),
        });

            // Cette famille est pleine, IsFull() devrait renvoyer true
            Assert.IsTrue(family.IsFull());
        }

        [TestMethod]
        public void TestFamilyIsNotFull()
        {
            // Créer une famille avec 2 adultes et 2 enfants (non pleine)
            var family = new Family();
            family.Members.AddRange(new List<Passenger>
        {
            new Passenger("6", PassengerType.Adulte, 30, "A", false),
            new Passenger("8", PassengerType.Enfant, 7, "A", false),
            new Passenger("9", PassengerType.Enfant, 4, "A", false),
        });

            // Cette famille n'est pas pleine, IsFull() devrait renvoyer false
            Assert.IsFalse(family.IsFull());
        }

        [TestMethod]
        public void TestPassengerIsAlone()
        {
            // Créer un passager sans family
            var passenger = new Passenger("1", PassengerType.Adulte, 30, Const.DASH, false);

            // Ce passenger est sans, Alone() devrait renvoyer true
            Assert.IsTrue(passenger.Alone());
        }
    }

}