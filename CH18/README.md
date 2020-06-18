第18章｜如果再回到從前 -- 備忘錄模式(Memento Pattern)
===

# 備忘錄模式？
備忘錄模式簡單說就是存檔機制。

UML 架構大概如下：
![](https://i.imgur.com/nD3DVPG.png)

* Originator：
可以想像成遊戲進度，**包含當前遊戲資訊**。
* Memento：
**由 Originator 建立**，可以想成存檔完成前的**緩衝過程**，例如存檔時，遊戲畫面會顯示「正在儲存，請勿拔除電源...」、「Saving...」。
* Caretaker：
**存檔清單**，包含既有的存檔資料。

# 備忘錄模式範例
直接來看一個例子吧！
正臨炎炎夏日，飲料也開始了各式各樣的促銷活動，小7或全家在這個時候也會推出**抽獎打折**活動，最常見的像是89折、79折、1折或是免費。

今天萬能的天神金凱瑞也想試試手氣，身為天神的他，時間倒流是輕而易舉，所以他就可以一直抽一直抽，直到他滿意為止。
![](https://i.imgur.com/JOd6cMV.png)

關於這樣的程式碼，我們先來看傳統方式會怎麼寫吧！

## 傳統方式
最簡單想到的方式就是**直接做一個物件，儲存當前結果**。


程式碼如下，[點我看程式碼](https://repl.it/@KTingLee/Ch18v1#main.cs)：

**CarryGod.cs**

```csharp
using System;

class CarryGod{
  // 抽獎結果
  private string _state;

  // 抽獎
  public void tryLuck() {
    Random rnd = new Random();
    _state = rnd.NextDouble().ToString("0.00");
  }

  public string state{
    get { return _state; }
    set { _state = value; }
  }

}
```

**用戶端**

```csharp
using System;

class MainClass {
  public static void Main (string[] args) {
    // 天神降臨
    CarryGod cg = new CarryGod();

    // 抽獎前先存檔，天神創造一個分身
    Console.WriteLine("天神發威，保存進度...");
    CarryGod beforeTry = new CarryGod();

    // 抽獎
    cg.tryLuck();
    Console.WriteLine("本次抽獎結果：" + cg.state);

    // 抽完存個檔，免得下次抽更爛
    Console.WriteLine("再開一個分身存個檔嘿嘿...");
    CarryGod afterTry1 = new CarryGod();
    afterTry1.state = cg.state;

    Console.WriteLine("*********************");

    // 不滿意先前結果，天神回溯時光
    Console.WriteLine("還不夠便宜！讀取進度...");
    cg.state = beforeTry.state;
    
    // 再次抽獎
    cg.tryLuck();
    Console.WriteLine("本次抽獎結果：" + cg.state);
  }
}
```

### 傳統方式問題

* 用戶端的職責太大，要建立備份物件還要知道物件細節
* 物件屬性多的話，備份、讀取將相當冗長

**用戶端**不但要建立備份物件，同時還**要知道物件的屬性有哪些**，才能加以備份。
目前的物件只有一個屬性 `state`，所以備份起來相對容易，但若屬性有許多個，則備份就會變得落落長。

## 利用備忘錄模式
為了**減輕用戶端的職責**，可以引入備忘錄模式，協助物件備份與讀取。

首先還是先來看 UML 架構圖吧！
![](https://i.imgur.com/jwEpW1Z.png)

在 **CarryGod** 類別中，有一個 "能建立備份物件的方法" `createMemento()` 以及 "讀取備份物件的方法" `loadState(Memento)`。

而 **Caretaker** 類別將紀錄備份物件。

相關程式碼如下，[點我看程式碼](https://repl.it/@KTingLee/Ch18v2#main.cs)：

**CarryGod.cs**

```csharp
using System;

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
```

**Memento.cs**

```csharp
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
```

**Caretaker.cs**

```csharp
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
```

**用戶端**

```csharp
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
```

### 備忘錄模式結果說明

* 備份、讀取的工作劃分清晰
* 備份、讀取過程封裝。用戶端不需要知道欲備份之物件細節。

利用備忘錄模式，可以清楚明白，備份的資料都將由 **Caretaker** 物件取得，實際的備份資料將放在 **Memento** 物件。

同時，用戶端不必再瞭解**哪些資料要備份、讀取時要取得哪些資料**，這些細節都封裝在 **CarryGod** 類別本身。

# 結論
利用備忘錄模式，可以將職責劃分清晰，備份、讀取的過程也將進行良好的封裝。
但備忘錄模式的缺點也相當明顯，就是**物件必須完整儲存，因此備份的資料一多，將相當消耗資源**。

# 作業

CK 最近迷上了一齣台劇 ---「想見你」，戲中女主角聽著伍佰的音樂便會回到過去，而這個片段也讓 CK 想起之前對付外星人的回憶。

那時 CK 在追捕一個濫殺無辜的外星人，雖然對手相當強大，但還好 CK 有研發部門提供的時光回溯機器，因此每被對手擊倒一次，便回到對戰前，並重新閃過對手的攻擊。

就這樣不停重複，最終解決敵人。

請利用備忘錄模式，讓 CK 的時光機器能夠發揮作用吧！

[點我看程式碼](https://repl.it/@KTingLee/Ch18Hw#main.cs)


