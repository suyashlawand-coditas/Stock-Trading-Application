namespace ClassLibrary;

public class Stock : IEquatable<Stock>
{
    // Fields
    private readonly String _stockSymbol;
    private readonly String _stockName;
    private double _stockPrice;

    static public event Action StockUpdateEvent;
    public void RaiseStockUpdateEvent() {
        StockUpdateEvent.Invoke();
    }

    // Properties
    public String StockSymbol { get => _stockSymbol; }
    public String StockName { get => _stockName; }

    public double StockPrice
    {
        get { return _stockPrice; }
        set { 
            RaiseStockUpdateEvent();
            _stockPrice = value; 
        }
    }

    public Stock(String stockSymbol, String stockName, double initialPrice = 0)
    {
        this._stockSymbol = stockSymbol;
        this._stockName = stockName;
        this._stockPrice = initialPrice;
    }

    public bool Equals(Stock? other)
    {
        if (this._stockSymbol != null && other?._stockSymbol != null)
        {
            return this._stockSymbol == other._stockSymbol;
        }
        return false;
    }
}
