class Decorator {
    static void Main(string[] args) {
            EggRoll p1 = new EggRoll(100, "EggRoll 1");

            Cheese cheese = new Cheese(12, "cheese");
            Ham ham = new Ham(5, "ham");
            Egg egg = new Egg(10, "egg");

            Console.WriteLine("Material: ");
            ham.Decorate(p1);
            cheese.Decorate(ham);
            egg.Decorate(cheese);

            egg.Calculate();
    }
    
    public class EggRoll {
        protected int price;
        protected string name;

        public EggRoll() {
        }

        public EggRoll(int price, string name) {
            this.price = price;
            this.name = name;
        }

        public virtual void Add(int price) {
            price += this.price;
            Console.WriteLine("\n[ {0} ] total price: {1}$", name, price);
        }
    }
     
    public class Material : EggRoll {

        protected EggRoll p;

        public Material() { }

        public Material(int price, string name) {}

        private int base_cost = 0;
        private int increase = 0;

        protected void output(string name, int price) {
            Console.WriteLine("  + {0, 3}$ : {1}", price, name);
        }

        public void Decorate(EggRoll p) {
            this.p = p;
        }

        public override void Add(int price) {
            if (p != null) {
                p.Add(price+increase);
            }
        }

        public void Calculate() {
            Add(base_cost);
        }

    }
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