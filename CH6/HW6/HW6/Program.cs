using System;

namespace HW6 {
    class Program {
        static void Main(string[] args) {
            EggRoll p1 = new EggRoll("EggRoll 1");

            Cheese cheese = new Cheese(12, "cheese");
            Ham ham = new Ham(5, "ham");
            Egg egg = new Egg(10, "egg");

            Console.WriteLine("Material: ");
            ham.Decorate(p1);
            cheese.Decorate(ham);
            egg.Decorate(cheese);

            egg.Calculate();


        }
    }
}
