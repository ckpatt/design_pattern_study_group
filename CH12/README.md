第12章｜多頭市場股票還會虧錢？—外觀模式
===

前言
---
如果今天你想喝珍奶，你得自己去買原料，自己去買容器設備，再拿去手搖店請店員幫你搖出一杯好喝的珍珠奶茶，只是喝杯珍奶有必要這麼麻煩嗎？

上面的例子是一個非常違反直覺的範例，在現實生活中不太常看到這樣的例子，但軟體設計中經常有類似的狀況，例如你今天想從 Google Map 下載一些地圖資料，查詢資料庫中的使用者購買紀錄，再交給某個機器學習 API 判斷該客戶在該區域消費的可能性，最後把這資料存回資料庫，這之間你需要和 Google Map API、使用者資料庫、機器學習 API 等不同的 Service 互動，你必須知道所有 Service 的使用方法，並將其撰寫在不同的客戶端裡。

這樣的設計讓客戶端與這些服務的耦合度變得相當高，如果今天想要更改其中一個 API，那麼你必須修改所有客戶端的程式碼，違反了依賴倒轉原則，且客戶端必須知道這些 API 的存取方式違反了迪米特法則。

我們可以用外觀模式來解決這樣的問題，外觀模式簡單來說將這些下層的操作通通包裝起來變成更簡單的統一介面，客戶端只需要知道如何操作這個介面，且當底層 API 更改時，只需要修改這層介面即可。

> **外觀模式(Facade)** 為子系統中的一組介面提供一個一致的介面，此模式定義了一個高層介面，這個介面使得這一子系統更加容易使用。

程式碼
---

以喝珍奶為例，若沒有應用外觀模式，程式碼可能長這樣

```csharp
class Client
{
    static void Main(string[] args) 
    {
        Ingredient.buy("奶茶");
        Ingredient.buy("珍珠");
        Equipment.buy("手搖杯");
        Equipment.buy("塑膠杯");
        Equipment.buy("吸管");
        TeaMaker.make("珍奶");
    }
}

class Ingredient
{
    static public void buy(string ingre)
    {
        Console.WriteLine("採購"+ingre+"原料");
    }
}

class Equipment
{
    static public void buy(string equi)
    {
        Console.WriteLine("採購"+equi);
    }
}

class TeaMaker
{
    static public void make(string tea)
    {
        Console.WriteLine("製作"+tea);
    }
}
```

若加了外觀模式則可簡化相當多的客戶端程式碼

```csharp
class Client
{
    static void Main(string[] args) 
    {
        BobaTeaMaker.makeBobaTea();
    }
}

class BobaTeaMaker
{
    static public void makeBobaTea()
    {
        Ingredient.buy("奶茶");
        Ingredient.buy("珍珠");
        Equipment.buy("手搖杯");
        Equipment.buy("塑膠杯");
        Equipment.buy("吸管");
        TeaMaker.make("珍奶");
    }
}

class Ingredient
{
    static public void buy(string ingre)
    {
        Console.WriteLine("採購"+ingre+"原料");
    }
}

class Equipment
{
    static public void buy(string equi)
    {
        Console.WriteLine("採購"+equi);
    }
}

class TeaMaker
{
    static public void make(string tea)
    {
        Console.WriteLine("製作"+tea);
    }
}
```

如果今天想修改製作珍奶的方式，例如加入椰果，可直接在 `BobaTeaMaker` 的介面中進行修改，而不必修改客戶端。這就是外觀模式。

UML圖

![](https://i.imgur.com/VSmbnEe.png)

外觀模式的基本結構
---

![](https://i.imgur.com/CPeVHQE.png)

```csharp
// 子系統
class SubSystemOne
{
    public void MethodOne()
    {
        Console.WriteLine("Method 1");
    }
}

// SubsystemTwo, Three, ... similar

// 外觀類別
class Facade
{
    SubsystemOne one;
    SubsystemTwo two;
    // three, four, ... etc.
    
    public Facate()
    {
        one = new SubSystemOne();
        two = new SubSystemTwo();
        // three, four, ... etc.
    }
    
    public void MethodA()
    {
        Console.WriteLine("Method Set A");
        one.MethodOne();
        two.MethodTwo();
        four.MethodFour();
    }
    
    public void MethodB()
    {
        Console.WriteLine("Method Set B");
        two.MethodTwo();
        three.MethodThree();
    }
}

// 用戶端
static void Main(string[] args)
{
    Facade facade = new Facade();
    
    facade.MethodA();
    facade.MethodB();
}
```

作業
---

### 描述
賭運不好的 CK 連出千都大失敗，原來大口九是該賭場的暗樁，把 CK 給他的錢假裝全都輸光實際上是自己抽了一點之後全都交給賭場了！灰心 CK 求償無門，還好能進 NASA 的 CK 智商還算高，沒有把家產都 all-in，想了想之後他決定還是用正規一點的投資賺錢比較保險，但市場上金融商品眾多，平常忙於工作的 CK 實在無法親自一個一個關注，只好找銀行理專幫忙管理資產，並定期向 CK 回報投資狀況。

請參考以下 UML 圖寫一個理專的類別 (更新價格的方式隨意，重點是外觀模式的結構)

![](https://i.imgur.com/56lhFnf.png)

解答 ([GitHub]() / [repl.it](https://repl.it/@d4n1el/CH12))