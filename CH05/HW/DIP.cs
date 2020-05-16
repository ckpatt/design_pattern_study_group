class DIP {
    static void Main() {
    CK firsttry = new CK(new ALuBar());
    CK secondtry = new CK(new HowGBar());
    
    firsttry.orderRamosGinFizz();    
    secondtry.orderRamosGinFizz();        
    }
}

interface IRamosGinFizz {

    void makeRamosGinFizz();
}

class CK
{
    private IRamosGinFizz bar;
        
    public CK(IRamosGinFizz bar)
    {
        this.bar = bar;
    }

    public void orderRamosGinFizz()
    {
        bar.makeRamosGinFizz();
    }
}

class ALuBar:IRamosGinFizz
{

    public void makeRamosGinFizz()
    {
        Console.WriteLine("No Fresh Cream QQ");
    }   
}

class HowGBar:IRamosGinFizz
{
    public void makeRamosGinFizz()
    {
        Console.WriteLine("No Orange Flower Blossom Water QQ");
    }   
}