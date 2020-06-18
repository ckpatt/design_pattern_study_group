// 用戶端程式碼
using System;

class MainClass {
  public static void Main (string[] args) {
    // 天神降臨
    CarryGod cg = new CarryGod();

    // 抽獎前先存檔，天神創造一個分身
    Console.WriteLine("天神發威，保存進度...");
    Caretaker beforeTry = new Caretaker(cg.createMemento());

    // 抽獎
    cg.tryLuck();
    Console.WriteLine("本次抽獎結果：" + cg.state);

    // 抽完存個檔，免得下次抽更爛
    Console.WriteLine("再開一個分身存個檔嘿嘿...");
    Caretaker bacafterTry1kup = new Caretaker(cg.createMemento());

    Console.WriteLine("*********************");

    // 不滿意先前結果，天神回溯時光
    Console.WriteLine("還不夠便宜！讀取進度...");
    cg.loadState(beforeTry.memento);
    
    // 再次抽獎
    cg.tryLuck();
    Console.WriteLine("本次抽獎結果：" + cg.state);
  }
}

// 天神程式碼
class CarryGod{
  // 抽獎結果
  private string _state;

  // 抽獎
  public void tryLuck() {
    Random rnd = new Random();
    _state = rnd.NextDouble().ToString("0.00");
  }

  // 備份。建立 Memento 物件
  public Memento createMemento(){
    return new Memento(_state);
  }

  // 讀檔。由 Memento 物件獲得資訊
  public void loadState(Memento memento){
    _state = memento.state;
  }

  public string state{
    get { return _state; }
    set { _state = value; }
  }
}

// 備忘錄程式碼
// 紀錄 CarryGod 物件的資訊
class Memento{
  // 抽獎結果
  private string _state;

  public Memento(string state){
    _state = state;
  }

  public string state{
    get { return _state; }
  }
}

// 備忘錄管理者程式碼
// 管理 Memento 物件
class Caretaker{
  private Memento _memento;

  public Caretaker(Memento memento){
    _memento = memento;
  }

  public Memento memento{
    get { return _memento; }
  }
}
