class WeaponChoose {
    static void Main() {
        Weapon campstool = WeaponFactory.CreateWeapon("折凳");
    
        campstool.fire();
    }
}

abstract class Weapon
{
    public abstract void fire();
}

class T85 : Weapon
{
    private int damage = 30;
    
    public override void fire()
    {
        System.Console.WriteLine("Firing T85!! Damage: " + damage);
    }
}

class T65K2 : Weapon
{
    private int damage = 50;
    
    public override void fire()
    {
        System.Console.WriteLine("Firing T65K2!! Damage: " + damage);
    }
}

class Campstool : Weapon
{
    private int damage = 87;
    
    public override void fire()
    {
        System.Console.WriteLine("Firing Campstool!! Damage: " + damage);
    }
}

class WeaponFactory
{
    public static Weapon CreateWeapon(string order)
    {
        Weapon w = null;

        switch (order)
        {
            case "T85":
                w = new T85();
                break;
            case "T65K2":
                w = new T65K2();
                break;
            case "折凳":
                w = new Campstool();
                break;
        }
        return w;
    }
}
