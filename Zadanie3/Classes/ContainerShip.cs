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
            SendNotifier("Probujesz przeladowac kontener");
        }
        else if (CurrentWeightOfContainers + container.ContainerWeight > MaxWeightOfContainers)
        {
            SendNotifier("Za duza waga kontenerow nie uniesie tego");
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
            SendNotifier("nie ma tego kontenera na tym statku");
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
            SendNotifier("transferuj kontener ktorego nie ma na tym statku");
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