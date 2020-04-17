using System;
namespace HW6 {
    public class Material : EggRoll {

        protected EggRoll p;

        public Material() { }

        public Material(int price, string name) { }

        private int otherPrice = 0;

        protected void output(string name, int price) {
            Console.WriteLine("  + {0, 3}$ : {1}", price, name);
        }

        public void Decorate(EggRoll p) {
            this.p = p;
        }

        public override void Add(int price) {

            if (p != null) {
                p.Add(price);
            }
        }

        public void Calculate() {
            Add(otherPrice);
        }

    }
}
