class ProxyPattern
{
    static void Main()
    {

        Dictionary<double, double> cache = new Dictionary<double, double>();
        IArea area;

        // 第一次計算:
        area = new ProxyCalArea(cache, 5.5);
        Console.WriteLine("The area of the square is {0}", area.CalSquare());
        Console.WriteLine("");

        // 確認Dictionary儲存內容
        Console.WriteLine("In cache list:");
        foreach (var Item in cache)
        {
            Console.WriteLine("Side= " + Item.Key + ", Area= " + Item.Value);
        }

        // 第二次計算:
        Console.WriteLine("");
        area = new ProxyCalArea(cache, 5.5);
        Console.WriteLine("The area of the square is {0}", area.CalSquare());
    }
}

interface IArea
{

    double CalSquare();
}

// 代理的物件
class ProxyCalArea : IArea
{
    private IArea real;
    private Dictionary<double, double> cache;
    private double side;

    public ProxyCalArea(Dictionary<double, double> cache, double side)
    {
        this.cache = cache;
        this.side = side;
        real = new realCalArea(side);
    }

    public double CalSquare()
    {
        if (cache.ContainsKey(side))
            Console.WriteLine("-- Get value from cache --");
        else
            cache.Add(side, real.CalSquare());
        return cache[side];
    }
}

// 真實的物件
class realCalArea : IArea
{

    private double side;

    public realCalArea(double side)
    {
        this.side = side;
    }

    public double CalSquare()
    {
        Console.WriteLine("-- Calculated by RealObj  --");
        return side * side;
    }
}
