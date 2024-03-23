using Zadanie3.Exceptions;

namespace Zadanie3.Classes
{
    public class CoolingContainer(
        double height,
        double containerWeight,
        double depth,
        double maxCargoWeight,
        Product product,
        double temperature)
        : Container(
            height,
            containerWeight,
            depth,
            maxCargoWeight,
            "C",
            product)
    {
        public string ProductType { get; } = product.Name;
        public double Temperature { get; } = temperature;

        public override void LoadCargo(double toLoadWeight, Product product)
        {
            if (ProductType != product.Name || CoolingProductDataBase.Products.All(p => p.Name != product.Name))
            {
                throw new InvalidProductTypeException("Bad product type.");
            }
            if (Temperature < product.Temp)
            {
                throw new InvalidProductTemperatureException("Bad product temperature.");
            }
            base.LoadCargo(toLoadWeight, product);
        }
    }
}