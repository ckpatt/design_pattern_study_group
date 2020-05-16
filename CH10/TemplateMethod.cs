class TemplateMethod {
    static void Main() {
        //依據不同的點餐（使用需求），來做出（實體化）不同的食譜（物件）
        TeaRecipe OrderOne= new PuddingMilkTeaRecipe();
        TeaRecipe OrderTwo= new BubbleGreenTeaRecipe();

        System.Console.WriteLine("------------------------------------");
        OrderOne.StartMixing();
        System.Console.WriteLine("------------------------------------");
        OrderTwo.StartMixing();
        System.Console.WriteLine("------------------------------------");
    }
    
    public abstract class TeaRecipe
    {       
        //以下三個為固定的方法
        public void StartMixing(){
            System.Console.WriteLine("Start mixing your drink!");
            AddTea();
            AddMaterial();
            AddSugar();
            AddIce();
            System.Console.WriteLine("Finished!!!!!!!!!!!!!!!!!!!");
        }
        
        public void AddSugar(){
            System.Console.WriteLine("Add sugar, it's only can be 50% sugar !");
        }
           
        public void AddIce(){
            System.Console.WriteLine("Add ice, it's only can be 30% ice !");
        }
      
        //以下兩個為抽象方法，提供子類別實作
        abstract public void AddMaterial();
        abstract public void AddTea();       
    }
       
    //子類別繼承抽象類別，並對其抽象方法進行覆寫
    public class PuddingMilkTeaRecipe : TeaRecipe
    {
        public override void AddMaterial(){
            System.Console.WriteLine("Add Pudding !!!");
        }
        public override void AddTea(){
            System.Console.WriteLine("Add Milk Tea !!!");
        }
    }
    
    public class BubbleGreenTeaRecipe : TeaRecipe
    {
        public override void AddMaterial(){
            System.Console.WriteLine("Add Bubble !!!");
        }
        public override void AddTea(){
            System.Console.WriteLine("Add Green Tea !!!");
        }
    }  
}