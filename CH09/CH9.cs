class CkWeaponMax : ICloneable
{
    private Algorithm algorithm;
    private string inventor;
    private string assemblyMethod;
    private string material;
    
    public CkWeaponMax(string inventor)
    {
        this.inventor = inventor;
    }
    
    public void setSecretInfo(string assemblyMethod, string material, Algorithm algorithm)
    {
        this.assemblyMethod = assemblyMethod;
        this.material = material;
        this.algorithm = new Algorithm();
    }
    
    public void Display()
    {
        Console.WriteLine("{0}", inventor);
        Console.WriteLine("{0} {1}", assemblyMethod, material);
        Console.WriteLine("{0} {1} {2}", algorithm.Researcher, algorithm.PowerComputation);
    } 
    
    public Object Clone()
    {
        return (Object)this.MemberwiseClone();
    }
}

class Algorithm : ICloneable
{
    private string Researcher;
    public string PowerComputation
    {
        get { return powerComputation; }
        set { powerComputation = value; }
    }
    
    public Object Clone()
    {
        return (Object)this.MemberwiseClone();
    }
}