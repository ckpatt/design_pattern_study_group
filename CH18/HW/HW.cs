// 用戶端程式碼
using System;

class MainClass {
  public static void Main (string[] args) {
    Role CK = new Role();
    CK.display();

    // 戰鬥前紀錄
    Caretaker beforeFight = new Caretaker(CK.createMemento());

    // 戰鬥
    CK.fight();
    CK.display();
    
    // 不滿意血量，重新讀檔
    CK.loadState(beforeFight.memento);
    CK.display();
  }
}

// 角色程式碼
class Role{
  private int _hp = 100;

  // 戰鬥，計算剩餘血量
  public void fight(){
    Random rnd = new Random();
    int damage = Convert.ToInt16(rnd.NextDouble()*100);
    _hp -= damage;
  }

  // 顯示血量
  public void display(){
    Console.WriteLine("目前血量為..." + _hp);
  }

  // 備份。建立 Memento 物件
  public Memento createMemento(){
    return new Memento(_hp);
  }

  // 讀檔。由 Memento 物件獲得資訊
  public void loadState(Memento memento){
    _hp = memento.Hp;
  }
}

// 備忘錄程式碼
// 紀錄 Role 物件的資訊
class Memento{
  // 血量
  private int _hp;

  public Memento(int hp){
    _hp = hp;
  }

  public int Hp{
    get { return _hp; }
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