using ClassLibrary;

public class Person
{
    public String Name { get; set; }
    public int Age { get; set; }
    private readonly List<Stock> holdings = [];
    double netWorth = 0;

    public Person(String name, int age) {
        this.Name = name;
        this.Age = age;
        Stock.StockUpdateEvent += ReCalculateNetWorth;
    }

    public void DisplayHoldings()
    {
        Console.WriteLine($"=== Holdings of {Name} ===");
        int counter = 0;
        foreach (Stock holding in holdings)
        {
            Console.WriteLine($"{++counter}. {holding.StockName}\t{holding.StockPrice}");
        }
        Console.WriteLine($"\nTotal Price:\t{netWorth}");
    }

    public void AddStockToList(Stock stock)
    {
        this.holdings.Add(stock);
        ReCalculateNetWorth();
    }

    private void ReCalculateNetWorth() {
        Console.WriteLine("Recalculating...");
        double finalValue = 0;
        foreach (Stock stock in holdings)
        {
            finalValue += stock.StockPrice;
        }

        netWorth = finalValue;
    }
}