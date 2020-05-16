class Attack {
    static void Main() {
        Soldier solider=new Soldier(new RKO());             //士兵配備的招式
        System.Console.WriteLine(solider.start_attack());   //士兵攻擊
    }
}   

class Soldier{
   
    private Strategy cs;
    
    public Soldier(Strategy strategy){ //於建構式中 決定士兵的攻擊模式 
        cs=strategy;
    }    
    public string start_attack(){
        return cs.attack();     
    }
}

//抽象類別 提供不同招式複寫
abstract class Strategy{
    
    public abstract string attack();
}

//不同招式類別
class RKO : Strategy{
    public override string attack(){
        return "This is RKO";
    }
}

class AA: Strategy {
    public override string attack(){
        return "This is AA";
    }
}