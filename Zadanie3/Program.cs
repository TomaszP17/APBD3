using Zadanie3.Classes;


List<Container> containers = new List<Container>();
List<ContainerShip> containerShips = new List<ContainerShip>();
while (true)
{
    Console.WriteLine("Lista konterenowcow: ");
    if(containerShips.Count == 0)
    {
        Console.WriteLine("Brak");
    }
    else
    {
        foreach (var containerShip in containerShips)
        {
            Console.WriteLine(containerShip.ToString());
        }
    }
    Console.WriteLine("Lista konetenerow:");
    if(containers.Count == 0)
    {
        Console.WriteLine("Brak");
    }
    else
    {
        foreach (var container in containers)
        {
            Console.WriteLine(container.ToString());
        }
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Witaj w programie");
    Console.WriteLine("Możliwe akcje:");
    Console.WriteLine("1. Dodaj kontenerowiec");
    Console.WriteLine("2. Usun kontenerowiec");
    Console.WriteLine("3. Dodaj kontener");
    
    var action = Console.ReadLine();
    
    switch (action)
    {
        case "1":
            Console.WriteLine("Podaj maksymalna predkosc kontenerowca:");
            var maxContainerSpeed = Console.ReadLine();
            Console.WriteLine("Podaj maksymalna ilosc konteenrow:");
            var maxNumberOfContainers = Console.ReadLine();
            Console.WriteLine("Podaj maksymalna sume wag kontenerow przewozonych przez kontenerowiec");
            var maxWeightOfContainers = Console.ReadLine();
            
            var containerShip = new ContainerShip(
                [],
                double.Parse(maxContainerSpeed),
                int.Parse(maxNumberOfContainers),
                double.Parse(maxWeightOfContainers));
            
            containerShips.Add(containerShip);
            break;
        case "2":
            Console.WriteLine("Podaj id kontenerowca do usuniecia:");
            var id = Console.ReadLine();
            containers.Remove(containers.Find(x => x.ContainerId == int.Parse(id)));
            Console.WriteLine("Usuniete zostalo kontener");
            break;
        case "3":
            Console.WriteLine("Podaj typ kontenera jaki ma to byc");
            var type = Console.ReadLine();
            if (type.Equals("Liquid"))
            {
                
            }
            break;
        default:
            Console.WriteLine("Wybrales nieprawidlowy numer akcji.");
            break;
    }
    
}
