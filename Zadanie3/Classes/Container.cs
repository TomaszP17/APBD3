using Zadanie3.Exceptions;

namespace Zadanie3.Classes
{
    public abstract class Container(
        double height,
        double containerWeight,
        double depth,
        double maxCargoWeight,
        string containerType,
        Product product)
    {
        private static int _nextId;
        public double CargoWeight { get; set; }
        public double Height { get; set; }
        public double ContainerWeight { get; set; }
        public double Depth { get; set; }
        public int ContainerId { get; set; } = ++_nextId;
        public string? SerialNumber { get; set; } = $"KON-{containerType}-{_nextId}";
        public double MaxCargoWeight { get; set; }
        public string? ContainerType { get; set; }
        public Product? Product { get; set; } = product;
        
        public virtual void EmptyLoad()
        {
            CargoWeight = 0;
            Product = null;
        }
        public virtual void LoadCargo(double toLoadWeight, Product product)
        {
            if (toLoadWeight + CargoWeight > MaxCargoWeight)
            {
                throw new OverfillException("Probujesz przeladowac kontener, nie mozna tak :/");
            }
            CargoWeight += toLoadWeight;
            Product = product;
        }

        public override string ToString()
        {
            return $"{nameof(CargoWeight)}: {CargoWeight}," +
                   $" {nameof(Height)}: {Height}," +
                   $" {nameof(ContainerWeight)}: {ContainerWeight}," +
                   $" {nameof(Depth)}: {Depth}," +
                   $" {nameof(ContainerId)}: {ContainerId}," +
                   $" {nameof(SerialNumber)}: {SerialNumber}," +
                   $" {nameof(MaxCargoWeight)}: {MaxCargoWeight}," +
                   $" {nameof(ContainerType)}: {ContainerType}";
        }
    }
}