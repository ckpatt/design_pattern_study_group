第11章｜無熟人難辦事—迪米特法則(Demeter Law)
===

# 名詞解釋
* 依賴倒轉原則：
**透過抽象類別或介面**的方式降低高、低層模組間的耦合度，低層模組的設計必須滿足抽象類別或介面的基本要求。
* 迪米特法則：
降低類別之間的耦合度。當兩個類別不必彼此直接通信時，可以透過第三方來幫忙類別方法的調用。**對自己依賴的類別，知道越少越好**。


# 迪米特法則介紹
1. 類別之間，應該要互相保持最低程度的了解(做好 private)。
2. 各自的工作盡可能封裝在自己的類別中，再用 public 的方式讓外部使用。
3. 迪米特法則的一個英文解釋是：Only talk to your immediate friends.(只與直接朋友溝通。如果是陌生的朋友，就透過第三方來傳話。)

在程式中，物件之間大部分都有耦合關係，例如一個類別方法中，又會使用其他類別，這時兩個類別彼此就有耦合關係。只是這兩個類別彼此是 "直接的朋友" 還是 "陌生的朋友" 呢？

## 直接的朋友

想像一下，到飲料店點餐時，有些飲料店只有櫃檯是開放的，做飲料的空間是隱藏的。此時我們點餐的流程會是

客人：你好，我要一份大奶微微

店員：好，一份大奶微微(輸出點餐紙並交給後臺)

在這個過程中，店員作為後臺與客人的連接橋梁，因為客人與店員直接接觸，所以兩者是直接朋友；而客人完全不會碰到後臺，所以兩者是陌生朋友。

畫成 UML 架構圖大致如下：
![](https://i.imgur.com/3ezYqHQ.png)


實作內容如下，[點我看程式碼](https://repl.it/@KTingLee/Ch11Mediumv1)：

**Clerk.cs**

```csharp
class Clerk {
    private Customer customer;
    
    public void receiveOrder(Customer customer)
    {
        this.customer = customer;
    }
    
    public void sendJob(Kitchen worker)
    {
      worker.prepareOrder(this.customer.getOrder());
    }
}
```

**Customer.cs**

```csharp
class Customer {
    private string content;
    
    public Customer(string name)
    {
        this.content = name;
    }
    
    public string getOrder()
    {
        return content;
    }
}
```

**Kitchen.cs**

```csharp
class Kitchen {
    private string name;

    public Kitchen(string name)
    {
        this.name = name;
    }

    public void prepareOrder(string orderContent)
    {
        Console.WriteLine("內場員工" + name + " 正在製作 " + orderContent);
    }
}
```

**用戶端**

```csharp
using System;

class BeverageShop {
  static void Main(string[] args){
      Clerk clerk = new Clerk();
      
      clerk.receiveOrder(new Customer("大奶微微"));
      clerk.sendJob(new Kitchen("小帥哥"));      
  }
}
```


**那甚麼是 "直接朋友" 呢？** 有種說法是：
在一個類別的方法中，可以**再呼叫**的方法應只能來自：
1. 類別本身的方法
2. 傳給該方法的參數
3. 該方法中建立之物件
4. 該類別成員的方法

對照 Clerk 類別的 `sendJob()` 方法為例，該方法實作內容中，又使用到的函數來自：
* **參數**的函數：`worker.prepareOrder()`
* 自身類別之**成員** `this.customer.getOrder()`。

所以 Clerk 類別與 Kitchen、Customer 是直接朋友。

# 總結
簡單的說，迪米特法則就是 "盡可能做好封裝"(將工作劃分清楚)，且可透過第三方來調用兩個沒有直接關係的類別(降低耦合度)。

課本提及，依賴倒轉原則與迪米特法則類似，因為一樣有提及第三方調用類別的概念，但我認為前者是專注在 "耦合度"，而後者專注在 "封裝"。

---

# 作業
整天與外星人相處的 CK 總算閒了下來，難得放假的日子 CK 決定去賭場賭個兩把，但礙於公司規定無法直接進賭場下注，所以 CK 透過地方混混 - 大口九的幫忙。賺錢能抽成的大口九當然二話不說，拿起電話向另一頭說「帳號是123456789，密碼：45699。買３場７號獨贏阿，３場７號阿！」
雖然 CK 一向賭運不好，但小賭怡情，賭一次沒賺，那也可以賭兩次呀！

UML圖與程式碼如下，請你找出不滿足迪米特法則的部分，並說明原因：
![](https://i.imgur.com/RTwx6WH.png)

**程式碼**[點我看程式碼](https://repl.it/@KTingLee/Ch11Mediumhomeworkquestion)

```csharp
// MiddleMan.cs (大口九程式碼)
class MiddleMan {
    private Customer customer;
    
    public void receiveBet(Customer customer)
    {
        this.customer = customer;
    }
    
    public void sendRequest(Casino casino)
    {
      casino.game(this.customer);
    }
}

// Customer.cs (顧客程式碼)
class Customer {
    private string bet;
    
    public Customer(string name)
    {
        this.bet = name;
    }
    
    public void setBet(string target)
    {
      this.bet = target;
    }

    public string getBet()
    {
        return bet;
    }
}

// Casino.cs (賭場程式碼)
class Casino {

    public void game(Customer customer)
    {
      customer.setBet("三場7號");
      Console.WriteLine("接受下注：" + customer.getBet() + " 比賽即將開始...");
    }
}

// 用戶端
using System;

class BeverageShop {
  static void Main(string[] args){
      MiddleMan bigMouth9 = new MiddleMan();

      // CK 下注
      Customer CK = new Customer("CK");

      // 大口九為 CK 下注
      bigMouth9.receiveBet(CK);
      bigMouth9.sendRequest(new Casino());
  }
}
```




# 參考來源
1. [大話設計模式 - Ch11](https://www.tenlong.com.tw/products/9789866761799)
2. [迪米特法则](https://blog.csdn.net/kaituozhe_sh/article/details/104089928)
3. [迪米特法則(Law of Demeter)](http://glj8989332.blogspot.com/2018/04/design-pattern-law-of-demeter.html)
4. [封裝與迪米特法則](https://www.ithome.com.tw/voice/98670)