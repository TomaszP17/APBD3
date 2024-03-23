using Zadanie3.Interfaces;

namespace Zadanie3.Classes;

public class LiquidContainer(
    double height,
    double containerWeight,
    double depth,
    double maxCargoWeight,
    Product product)
    : Container(
        height,
        containerWeight,
        depth,
        maxCargoWeight,
        "L",
        product), IHazardNotifier
{
    public void SendNotifier(string message)
    {
        Console.WriteLine(message + " problem wystapil w kontenerze o id: " + ContainerId);
    }
    public override void LoadCargo(double toLoadWeight, Product product)
    {
        if (Product is { Dangerous: true })
        {
            var tempMaxCargo = MaxCargoWeight * 0.5;
            if (tempMaxCargo < CargoWeight + toLoadWeight)
            {
                SendNotifier("niebezpieczna akcja");
            }
            base.LoadCargo(toLoadWeight, product);
        }
        else
        {
            var tempMaxCargo = MaxCargoWeight * 0.9;
            if (tempMaxCargo < CargoWeight + toLoadWeight)
            {
                SendNotifier("niebezpieczna akcja");
            }
            base.LoadCargo(toLoadWeight, product);
        }
    }
    
}