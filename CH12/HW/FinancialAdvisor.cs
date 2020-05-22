using System;

class CK
{
    static void Main(string[] args) 
    {
        FinancialAdvisor advisor = new FinancialAdvisor();
        advisor.depositAssets(10000);
        advisor.investment();
        advisor.reportBenefit();
    }
}

class FinancialAdvisor
{
    private int assets;
    private int benefit;
    private Stock stock;
    private Future future;
    private Bond bond;
    
    public FinancialAdvisor()
    {
        assets = 0;
        stock = new Stock();
        future = new Future();
        bond = new Bond();
    }

    public void depositAssets(int amount)
    {
        assets += amount;
        benefit = 0;
    }

    public void reportBenefit()
    {
        Console.WriteLine("目前一共賺了 " + benefit + " 元");
    }

    public void investment()
    {
        int price, hold;

        price = stock.getPrice();
        assets -= price * 100;
        benefit -= price * 100;
        stock.buy(100, price);

        price = future.getPrice();
        assets -= price * 100;
        benefit -= price * 100;
        future.buy(100, price);

        price = bond.getPrice();
        assets -= price * 100;
        benefit -= price * 100;
        bond.buy(100, price);

        price = stock.getPrice();
        hold = stock.getHold();
        assets += price * hold;
        benefit += price * hold;
        stock.sell(hold, price);

        price = future.getPrice();
        hold = future.getHold();
        assets += price * hold;
        benefit += price * hold;
        future.sell(hold, price);

        price = bond.getPrice();
        hold = bond.getHold();
        assets += price * hold;
        benefit += price * hold;
        bond.sell(hold, price);
    }
}

class Stock
{
    private Random rnd = new Random();
    
    private int price;
    private int hold;

    public Stock()
    {
        price = rnd.Next(100);
        hold = 0;
    }

    public int getPrice()
    {
        return price;
    }

    public int getHold()
    {
        return hold;
    }

    public void buy(int amount, int price)
    {
        hold += amount;
        Console.WriteLine("以 "+price+" 元買進股票 "+amount+" 單位");
        this.price = rnd.Next(100);
    }

    public void sell(int amount, int price)
    {
        hold -= amount;
        Console.WriteLine("以 "+price+" 元出售股票 "+amount+" 單位");
        this.price = rnd.Next(100);
    }
}

class Future
{
    private Random rnd = new Random();
    
    private int price;
    private int hold;

    public Future()
    {
        price = rnd.Next(100);
    }

    public int getPrice()
    {
        return price;
    }

    public int getHold()
    {
        return hold;
    }

    public void buy(int amount, int price)
    {
        hold += amount;
        Console.WriteLine("以 "+price+" 元買進期貨 "+amount+" 單位");
        this.price = rnd.Next(100);
    }

    public void sell(int amount, int price)
    {
        hold -= amount;
        Console.WriteLine("以 "+price+" 元出售期貨 "+amount+" 單位");
        this.price = rnd.Next(100);
    }
}

class Bond
{
    private Random rnd = new Random();
    
    private int price;
    private int hold;

    public Bond()
    {
        price = rnd.Next(100);
    }

    public int getPrice()
    {
        return price;
    }

    public int getHold()
    {
        return hold;
    }

    public void buy(int amount, int price)
    {
        hold += amount;
        Console.WriteLine("以 "+price+" 元買進債券 "+amount+" 單位");
        this.price = rnd.Next(100);
    }

    public void sell(int amount, int price)
    {
        hold -= amount;
        Console.WriteLine("以 "+price+" 元出售債券 "+amount+" 單位");
        this.price = rnd.Next(100);
    }
}