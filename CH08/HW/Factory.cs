class WeaponChoose {
    static void Main() {
        WeaponFactory weaponfactory = new FlyingKnifeFactory(); // 如果要改成裝備別板凳，只要把 FlyingKnifeFactory 改成 Campstool 就好
        Weapon flyingKnife = weaponfactory.CreateWeapon();
    
        flyingKnife.fire();
    }
}

//定義武器抽象類別，讓子類別複寫(override)方法(method)
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

class FlyingKnife : Weapon
{
    private int damage = 666;
    
    public override void fire()
    {
        System.Console.WriteLine("Firing mother Li's flying knife!! Damage: " + damage);
    }
}

// 工廠
interface WeaponFactory
{
    Weapon CreateWeapon();
}

class T85Factory : WeaponFactory
{
    public Weapon CreateWeapon()
    {
        return new T85();
    }
}

class T65K2Factory : WeaponFactory
{
    public Weapon CreateWeapon()
    {
        return new T65K2();
    }
}

class CampstoolFactory : WeaponFactory
{
    public Weapon CreateWeapon()
    {
        return new Campstool();
    }
}

class FlyingKnifeFactory : WeaponFactory
{
    public Weapon CreateWeapon()
    {
        return new FlyingKnife();
    }
}
