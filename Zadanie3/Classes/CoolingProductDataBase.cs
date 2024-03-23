namespace Zadanie3.Classes;

public class CoolingProductDataBase
{
    public static List<Product> Products { get; set; }
    
    static CoolingProductDataBase()
    {
        Products = new List<Product>
        {
            new Product("Bananas", false, 13.3),
            new Product("Chocolate", false, 18),
            new Product("Fish", false, 2),
            new Product("Meat", false, -15),
            new Product("Ice cream", false, -18),
            new Product("Frozen pizza", false, -30),
            new Product("Cheese", false, 7.2),
            new Product("Sausages", false, 5),
            new Product("Butter", false, 20.5),
            new Product("Eggs", false, 19)
        };
    }
}