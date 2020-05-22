using System;

class Client
{
    static void Main(string[] args) 
    {
        BobaTeaMaker.makeBobaTea();
    }
}

class BobaTeaMaker
{
    static public void makeBobaTea()
    {
        Ingredient.buy("奶茶");
        Ingredient.buy("珍珠");
        Equipment.buy("手搖杯");
        Equipment.buy("塑膠杯");
        Equipment.buy("吸管");
        TeaMaker.make("珍奶");
    }
}

class Ingredient
{
    static public void buy(string ingre)
    {
        Console.WriteLine("採購"+ingre+"原料");
    }
}

class Equipment
{
    static public void buy(string equi)
    {
        Console.WriteLine("採購"+equi);
    }
}

class TeaMaker
{
    static public void make(string tea)
    {
        Console.WriteLine("製作"+tea);
    }
}