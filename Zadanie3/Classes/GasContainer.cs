using Zadanie3.Interfaces;
using Zadanie3.Exceptions;

namespace Zadanie3.Classes
{
    public class GasContainer(
        double height,
        double containerWeight,
        double depth,
        double maxCargoWeight,
        Product product,
        double pressure)
        : Container(
            height,
            containerWeight,
            depth,
            maxCargoWeight,
            "G",
            product), IHazardNotifier
    {
        public double Pressure { get; } = pressure;

        public void SendNotifier(string message)
        {
            Console.WriteLine(message + " problem wystapil w kontenerze o id: " + ContainerId);
        }
        public override void EmptyLoad()
        {
            CargoWeight *= 0.05;
        }
        public override void LoadCargo(double toLoadWeight, Product product)
        {
            if (toLoadWeight + CargoWeight > MaxCargoWeight)
            {
                SendNotifier("Probujesz przeladowac kontener, nie mozna tak :/");
                throw new OverfillException("Probujesz przeladowac kontener, nie mozna tak :/");
            }
            CargoWeight += toLoadWeight;
            Product = product;
        }

        public override string ToString()
        {
            return base.ToString() + $", pressure: {Pressure}";
        }
    }
}