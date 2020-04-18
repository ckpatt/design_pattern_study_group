// 程式碼實踐簡單工廠模式
// 如上述舉例，去販賣機投飲料的範例
class SimpleFactory {
    static void Main() {
        // 依照使用者需求
        // 實體化（販賣機掉出）相對應的物件（飲料）
        // 可以想像成，使用者站在販賣機前面，按下奶茶or紅茶的按鈕
        Drink blackTea = DrinkFactory.CreateDrink("紅茶");
        Drink milkTea = DrinkFactory.CreateDrink("奶茶");
    
        blackTea.showDrink();
        milkTea.showDrink();
    }
}

// 定義抽象類別，讓子類別複寫(override)方法(method)
abstract class Drink
{
    public abstract void showDrink();
}

// 紅茶類別
class BlackTea : Drink
{
    private int drinkPrice = 30;
    // 複寫父類別的方法
    public override void showDrink()
    {
        System.Console.WriteLine("Black tea: $" + drinkPrice);
    }
}

// 奶茶類別
class MilkTea : Drink
{
    private int drinkPrice = 50;

    public override void showDrink()
    {
        System.Console.WriteLine("Milk tea: $" + drinkPrice);
    }
}

// 工廠
// 注意命名內要有Factory
class DrinkFactory
{
    // 創立物件
    // static 函數宣告：讓在主程式中，不需要實體化物件就可以使用
    public static Drink CreateDrink(string order)
    {
        Drink obj = null;

        // 讓工廠判斷要實體化哪個物件的部分
        // 可以想像成販賣機上的按鈕
        switch (order)
        {
            case "紅茶":
                obj = new BlackTea();
                break;
            case "奶茶":
                obj = new MilkTea();
                break;              
        }
        return obj;
    }
}
