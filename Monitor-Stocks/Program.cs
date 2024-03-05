using ClassLibrary;

class Program
{
    static List<Stock> stocks = [];
    static List<Person> people = [];

    static void Main()
    {
        List<(int choiceNo, String Name)> menuItems = [
            (1, "Display Stocks"),
            (2, "Display People"),
            (3, "Add Stocks"),
            (4, "Add People"),
            (5, "See Person Portfolio"),
            (6, "Update Price of Stock"),
            (7, "Add Stock to persons portfolio")
        ];

        while (true)
        {
            Console.WriteLine("=== Menu ===");
            foreach ((int choiceNo, String Name) in menuItems)
            {
                Console.WriteLine($"{choiceNo}. {Name}");
            }

            Console.Write("\nEnter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: DisplayStocks(); break;
                case 2: DisplayPeople(); break;
                case 3: AddStocks(); break;
                case 4: AddPerson(); break;
                case 5: DisplayPersonPortfolio(); break;
                case 6: UpdateStockPrice(); break;
                case 7: AddStocksToPersonsPortfolio(); break;
                default: Console.WriteLine("invalid"); break;
            }

        }
    }



    static void AddStocks()
    {
        String choice = "";
        do
        {
            Console.Write("Symbol of Stock: ");
            String stockSymbol = Console.ReadLine()!;
            Console.Write("Name of Stock: ");
            String stockName = Console.ReadLine()!;

            if (stockName == null || stockSymbol == null)
            {
                Console.WriteLine("Invalid Inputs!!");
                break;
            }
            else
            {
                stocks.Add(
                    new Stock(stockSymbol, stockName)
                );
                DisplayStocks();
            }


            Console.Write("Add More (y/n): ");
            choice = Console.ReadLine()!;
        } while (choice.ToLower()[0] != 'n');
    }

    static void AddPerson()
    {
        String choice = "";
        do
        {
            Console.Write("Name: ");
            String personName = Console.ReadLine()!;
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if (personName == null)
            {
                Console.WriteLine("Invalid Inputs");
                break;
            }
            else
            {
                people.Add(
                    new Person(personName, age)
                );
                DisplayPeople();
            }

            Console.Write("Add More (y/n): ");
            choice = Console.ReadLine()!;
        } while (choice?.ToLower()[0] != 'n');
    }

    static void UpdateStockPrice()
    {
        DisplayStocks();
        Console.Write("Select Stock to update: ");
        int updateIndex = Convert.ToInt32(Console.ReadLine());

        Console.Write($"Updated price for {stocks[updateIndex].StockName} ({stocks[updateIndex].StockPrice}): ");
        double updatedPrice = Convert.ToDouble(Console.ReadLine());

        stocks[updateIndex].StockPrice = updatedPrice;
        stocks[updateIndex].RaiseStockUpdateEvent();
        Console.WriteLine($"\nUpdated {stocks[updateIndex].StockName} ({stocks[updateIndex].StockPrice})");
    }

    static void DisplayPersonPortfolio()
    {
        DisplayPeople();
        Console.Write("Enter Person to display: ");
        int index = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();
        people[index].DisplayHoldings();
        Console.WriteLine();
    }

    static void DisplayPeople()
    {
        for (int index = 0; index < people.Count; index++)
        {
            Console.WriteLine($"{index}. {people[index].Name}");
        }
    }

    static void DisplayStocks()
    {
        for (int index = 0; index < stocks.Count; index++)
        {
            Console.WriteLine($"{index}. {stocks[index].StockName} ({stocks[index].StockSymbol})\t Rs.{stocks[index].StockPrice}");
        }
    }

    static void AddStocksToPersonsPortfolio()
    {
        DisplayPeople();
        Console.Write("Person Id: ");
        int personIndex = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        DisplayStocks();

        Console.WriteLine();

        Console.WriteLine("Stock Id: ");
        int stockIndex = Convert.ToInt32(Console.ReadLine());

        people[personIndex].AddStockToList(stocks[stockIndex]);

        Console.WriteLine(":: Updated Holdings ::");

        people[personIndex].DisplayHoldings();
    }
}