using System;
namespace HW6 {
    public class Cheese : Material {
        int price;
        string name;
        public Cheese(int price, string name) {
            this.price = price;
            this.name = name;
        }

        public override void Add(int money) {
            output(name, price);
            money += price;
            base.Add(money);
        }

    }

    public class Egg : Material {
        int price;
        string name;
        public Egg(int price, string name) {
            this.price = price;
            this.name = name;
        }

        public override void Add(int money) {
            output(name, price);
            money += price;
            base.Add(money);
        }

    }

    public class Ham : Material {
        int price;
        string name;
        public Ham(int price, string name) {
            this.price = price;
            this.name = name;
        }

        public override void Add(int money) {
            output(name, price);
            money += price;
            base.Add(money);
        }

    }
}
