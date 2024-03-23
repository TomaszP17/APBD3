namespace Zadanie3.Classes;

public class Product(
    string name,
    bool dangerous,
    double temp
    )
{
    public string Name { get; } = name;
    public bool Dangerous { get; } = dangerous;
    public double Temp { get; } = temp;

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Dangerous)}: {Dangerous}, {nameof(Temp)}: {Temp}";
    }
}