// 策略模式
class StrategyFactory {
    static void Main() {
        // 依照使用者需求
        // 實體化能夠製作對應飲料調酒的調酒師
        Bartender blackTea = new Bartender("紅茶");
        Bartender milkTea = new Bartender("奶茶");
    
        blackTea.showCocktail();
        milkTea.showCocktail();
    }
}

// 定義抽象類別，讓子類別複寫(override)方法(method)
abstract class Recipe
{
    public abstract string makeCocktail();
}

// 紅茶類別
class BlackTeaRecipe : Recipe
{
    // 複寫父類別的方法
    public override string makeCocktail()
    {
        return "Black tea cocktail";
    }
}

// 奶茶類別
class MilkTeaRecipe : Recipe
{
    // 複寫父類別的方法
    public override string makeCocktail()
    {
        return "Milk tea cocktail";
    }
}

// 策略
class Bartender
{
    // Recipe 實體由 Bartender 負責管理和操作
    private Recipe obj = null;
    
    public Bartender(string type)
    {

        // 讓工廠判斷要實體化哪個物件的部分
        switch (type)
        {
            case "紅茶":
                obj = new BlackTeaRecipe();
                break;
            case "奶茶":
                obj = new MilkTeaRecipe();
                break;
        }
    }

    public void showCocktail()
    {
        System.Console.WriteLine(obj.makeCocktail());
    }
}
