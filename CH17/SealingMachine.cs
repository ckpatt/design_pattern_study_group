using System;

class MakeDrink 
{
    static void Main(string[] args) 
    {
        NewSealingMachine newMachine = new NewSealingMachine();
        newMachine.Seal("奶茶", 90);

        SealingMachine machine = new NewSealingMachineAdapter();
        machine.Seal("奶茶", 90);
    }
}

class SealingMachine
{
    public void Seal(string drink, int size) {
        if (size == 90) {
            Console.WriteLine(drink + " 封口完成!!");
        } else {
            Console.WriteLine("尺寸不支援");
        }
    }
}

class NewSealingMachine
{
    public void Seal(string drink, int size) {
        if (size == 100) {
            Console.WriteLine(drink + " 封口完成!!");
        } else {
            Console.WriteLine("尺寸不支援");
        }
    }
}

class NewSealingMachineAdapter : SealingMachine
{
    private NewSealingMachine machine = new NewSealingMachine();
    public void Seal(string drink, int size) {
        machine.Seal(drink, 90);
    }
}