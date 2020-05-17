// 用戶端
using System;

class AutoCar {
  public static void Main (string[] args) {
    Console.WriteLine("自動車執行 小火龍 資料填寫任務囉！");
    AlienDocument Charmander = new Charmander();
    Charmander.autoRun();
  }
}

// 自動車任務(模板) - 用來跑外星人資料
abstract class AlienDocument{
  protected void positionA(){
    Console.WriteLine("自動車前往人事處領取外星人資料表");
  }
  protected void positionB(){
    Console.WriteLine("自動車前往註冊處審核蓋印章");
  }
  protected void positionC(){
    Console.WriteLine("自動車前往 51 區繳交資料");
  }
  // 資料填寫會因為外星人不同而有所不同，所以由子類別實現
  public abstract void fillDocument();

  // 自動車將所有過程做一個邏輯處理
  public void autoRun(){
    positionA();
    fillDocument();
    positionB();
    positionC();
  }
}

// 外星人資料(子類別實作) - 小火龍
class Charmander : AlienDocument{
  public override void fillDocument(){
    Console.WriteLine("小火龍的資料填寫中...");
  }
}

// 外星人資料(子類別實作) - 杰尼龜
class Squirtle : AlienDocument{
  public override void fillDocument(){
    Console.WriteLine("杰尼龜的資料填寫中...");
  }
}