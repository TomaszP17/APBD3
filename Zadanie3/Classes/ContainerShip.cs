using Zadanie3.Interfaces;

namespace Zadanie3.Classes;

public class ContainerShip(
    List<Container> containers,
    double maxSpeed,
    int maxNumberOfContainers,
    double maxWeightOfContainers) : IHazardNotifier
{
    private static int _nextId;
    public int ShipId { get; set; } = ++_nextId;
    public List<Container> Containers { get; set; } = containers;
    public double MaxSpeed { get; set; } = maxSpeed;
    public int MaxNumberOfContainers { get; set; } = maxNumberOfContainers;
    public double MaxWeightOfContainers { get; set; } = maxWeightOfContainers;
    private double CurrentWeightOfContainers => Containers.Sum(c => c.ContainerWeight);

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxNumberOfContainers)
        {
            SendNotifier("You try to load too many containers.");
        }
        else if (CurrentWeightOfContainers + container.ContainerWeight > MaxWeightOfContainers)
        {
            SendNotifier("You try to load too heavy container.");
        }
        else
        {
            Containers.Add(container);
        }
    }
    public void LoadContainer(List<Container> theContainers)
    {
        foreach (var container in theContainers)
        {
            LoadContainer(container);
        }
    }
    
    public void UnloadContainer(Container container)
    {
        if (Containers.Contains(container))
        {
            Containers.Remove(container);
        }
        else
        {
            SendNotifier("You try to unload container that is not on the ship.");
        }
    }
    
    public void UnloadAllContainers()
    {
        Containers.Clear();
    }

    public void replaceContainer(int fContainerId, Container sContainer)
    {
        Containers[Containers.FindIndex(c => c.ContainerId == fContainerId)] = sContainer;
    }

    public void transferContainer(ContainerShip from, ContainerShip to, int id)
    {
        var container = from.Containers.Find(x => x.ContainerId == id);
        if (from.Containers.Contains(container))
        {
            to.LoadContainer(container);
            from.UnloadContainer(container);
        }
        else
        {
            SendNotifier("You try to transfer container that is not on the ship.");
        }
    }
    
    public void SendNotifier(string message)
    {
        Console.WriteLine(message);
    }

    public override string ToString()
    {
        return $"{nameof(Containers)}: {Containers.Count}," +
               $" {nameof(MaxSpeed)}: {MaxSpeed}," +
               $" {nameof(MaxNumberOfContainers)}: {MaxNumberOfContainers}," +
               $" {nameof(MaxWeightOfContainers)}: {MaxWeightOfContainers}," +
               $" {nameof(CurrentWeightOfContainers)}: {CurrentWeightOfContainers}";
    }
}