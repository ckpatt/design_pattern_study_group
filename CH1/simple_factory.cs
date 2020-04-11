//程式碼實踐簡單工廠模式
//如上述舉例，去販賣機投飲料的範例
class simple_factory {
    static void Main() {
        
        //依照使用者需求
        //實體化（販賣機掉出）相對應的物件（飲料）
        //可以想像成，使用者站在販賣機前面，按下奶茶or紅茶的按鈕
        Drink red_tea_order =DrinkFactory.CreateDrink("紅茶");
        Drink milk_tea_order =DrinkFactory.CreateDrink("奶茶");
    
        red_tea_order.show_drink();
        milk_tea_order.show_drink();

    }
}

    //定義抽象類別，讓子類別複寫(override)方法(method)
    abstract class Drink
    {
        public abstract void show_drink();
    }

    //紅茶類別
    class RedTea : Drink
    {
        private int drink_price=30;
        //複寫父類別的方法
        public override void show_drink()
        {
            System.Console.WriteLine("Red tea: $"+drink_price);
        }
    }
    
    //奶茶類別
    class MilkTea : Drink
    {
        private int drink_price=50;

        public override void show_drink()
        {
            System.Console.WriteLine("Milk tea: $"+drink_price);
        }
    }

//工廠
//注意命名內要有Factory
class DrinkFactory
    {
        //創立物件
        //static 函數宣告：讓在主程式中，不需要實體化物件就可以使用
        public static Drink CreateDrink(string oper)
        {
            Drink obj = null;
            //讓工廠判斷要實體化哪個物件的部分
            //可以想像成販賣機上的按鈕
            
            switch (oper)
            {
                case "紅茶":
                    obj = new RedTea();
                    break;
                case "奶茶":
                    obj = new MilkTea();
                    break;              
            }
            return obj;
        }
    }
