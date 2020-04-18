using System;

namespace HW6 {
    public class EggRoll {
        protected int price = 100;
        private string name;

        public EggRoll() {
        }

        public EggRoll(string name) {
            this.name = name;
        }

        public virtual void Add(int price) {
            price += this.price;
            Console.WriteLine("\n[ {0} ] total price: {1}$", name, price);
        }

    }
}