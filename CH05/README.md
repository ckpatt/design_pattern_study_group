第05章｜會修電腦不會修收音機？－－依賴倒轉原則
===

介紹
---
**[依賴倒轉原則 (Dependency Inversion Principle, DIP)](https://notfalse.net/1/dip)**

***依賴反轉原則的目的是為了解除高階模組與低階模組的耦合關係***
> * 高階模組不應該依賴於低階模組，兩者都該依賴抽象
> * 抽象不應該依賴於具體實作方式；具體實作方式則應該依賴抽象

- **名詞解釋**

    1. 高階與低階，是相對關係，也就是 `呼叫者 (Caller)` 與 `被呼叫者 (Callee)`
    2. 抽象，是指 `介面 (interface)` 或是 `抽象類別 (Abstract Class)`( 請參考：[介面(interface)、抽象( abstract)、虛擬(virtual)](https://medium.com/@ad57475747/c-%E9%9B%9C%E8%A8%98-%E4%BB%8B%E9%9D%A2-interface-%E6%8A%BD%E8%B1%A1-abstract-%E8%99%9B%E6%93%AC-virtual-%E4%B9%8B%E6%88%91%E8%A6%8B-dc3c5878bb80) )，也就是不知道實作方式，無法直接被實例化
    3. `具體實作方式`，是指有 `實作介面` 的 `非抽象類別`。

範例
---
- **JC今天口渴了，想要喝飲料解渴 :+1:**

    ***依賴**：JC需要喝飲料 --> 解渴*
    
    ```csharp=1
    class Program {
      static void Main() {
        Person p = new Person();

        p.drink();
      }
    }

    class Person
    {
        private Milktea milktea;

        public Person()
        {
            milktea = new Milktea();
        }

        public void drink()
        {
            // 奶茶物件的method
            milktea.absorb();
        }
    }

    class Milktea
    {
        public void absorb()
        {
            Console.WriteLine("Milk tea good good drink!");
        }
    }
    
    // Result:
    // Milk tea good good drink!
    ```
    當JC (Caller)需要呼叫 `Milktea` 類別 (Callee)的實例時，這關係稱為 -- **依賴**
    
- **某次，JC突然想改喝威士忌解渴(!?**
    ```csharp=1
    class Program {
      static void Main() {
        Person p = new Person();

        p.drink();
      }
    }

    class Person
    {
        // private Milktea milktea;
        private Whisky whisky;

        public Person()
        {
            // milktea = new Milktea();
            whisky = new Whisky();
        }

        public void drink()
        {
            // milktea.absorb();
			// 威士忌物件的method
            whisky.shot();
        }
    }

    class Milktea
    {
        public void absorb()
        {
            Console.WriteLine("Milk tea good good drink");
        }
    }

    class Whisky
    {
        public void shot()
        {
            Console.WriteLine("Shot!Shot! Shot!Shot!Shot!");
        }
    }
    
    // Result:
    // Shot!Shot! Shot!Shot!Shot!
    ```
    當高階模組 `Person` 依賴低階模組 `Milktea` 與 `Whisky` 時，意味著低層模組的變動將使得使用高層模組時會受影響，這種緊耦合的關係是個沒有穩定性的設計，所以必須透過 `介面`，使得高階不再依賴低階，來達到依賴的反轉。
    
- **How to do ?**

    *我們真正依賴的，不是實際的類別與物件，而是他所擁有的功能。*
    
    **功能：解渴**，定義介面如下:
    ```csharp=1
    interface IBeverage {

        void absorb();      
    }
    ```
    
    因此，可以將程式碼修改為：
    
    ```csharp=1
    class Program {
      static void Main() {
        Person p = new Person();

        p.drink();
      }
    }

    class Person
    {
        private IBeverage beverage;

        public Person()
        {

            // 得到一個飲料的實例
            // 實際實作種類是 Whisky
            beverage = new Whisky();
        }

        public void drink()
        {
            // 實作介面的method
            beverage.absorb();
        }
    }
    
    interface IBeverage {

        void absorb();      
    }
    
    class Milktea : IBeverage
    {
        public void absorb()
        {
            Console.WriteLine("Milk tea good good drink");
        }
    }

    class Whisky : IBeverage
    {
        public void absorb()
        {
            Console.WriteLine("Shot!Shot! Shot!Shot!Shot!");
        }
    }
    
    // Result:
    // Shot!Shot! Shot!Shot!Shot!
    ```    
    可以看見 `實例` 的建構方式從
    ```csharp
    Whisky whisky = new Whisky();
    ```
    改成了
    ```csharp
    IBeverage beverage = new Whisky();
    ```
    這裡改變 `Person` 依賴的對象，符合了上述DIP的第一點：
    > * 高階模組不應該依賴於低階模組，兩者都該依賴抽象
    
    而 `IBeverage` 不依賴 `Whisky` 和 `Milktea` 的實作方式，也符合了另一點:
    > * 抽象不應該依賴於具體實作方式；具體實作方式則應該依賴抽象

## UML

![](https://i.imgur.com/gIOI041.png)


 - 圖1中，高層物件`Person` 依賴於底層物件`Milktea` 與 `Whisky` 的實現；圖2中，把高層物件`Person` 對底層物件的需求抽象為一個介面 `IBeverage`，底層物件實現了介面，這就是依賴反轉。

    
討論
---
- 所以`依賴倒轉原則`的`倒轉` 是在倒什麼意思的?
  Ans: 原本的高階依賴低階 (JC依賴奶茶、威士忌)，使得JC的行為模式被奶茶、威士忌的實作方式綁死了；而飲料介面的出現，讓各種不同的飲料可以具體實作，進而讓關係變成：低階(飲料)依賴需求(介面)，而需求是高階模組(人)給的。

- 結合[里氏替換原則 Liskov Substitution Principle (LSP)](https://medium.com/@f40507777/%E9%87%8C%E6%B0%8F%E6%9B%BF%E6%8F%9B%E5%8E%9F%E5%89%87-liskov-substitution-principle-adc1650ada53)：
抽象化之間定義好依賴關係，再由各自的具體子類別去實作，達到替換父類別不會影響軟體功能。
    > * 不要繼承不必要的父類別，沒用到而去繼承反而是種累贅甚至會搞壞了整個系統也不一定。
    > * 確保底層的實作會遵守上層介面所定義的行為。



###### 參考資料
> - [程式範例](https://repl.it/repls/WellwornStrangeAggregators)
> - [Design Pattern 章節大綱](https://hackmd.io/@WeiTing35/Design_Patterns)
> - [依賴倒轉原則 (Dependency Inversion Principle, DIP)](https://notfalse.net/1/dip)
> - [介面(interface)、抽象( abstract)、虛擬(virtual)](https://medium.com/@ad57475747/c-%E9%9B%9C%E8%A8%98-%E4%BB%8B%E9%9D%A2-interface-%E6%8A%BD%E8%B1%A1-abstract-%E8%99%9B%E6%93%AC-virtual-%E4%B9%8B%E6%88%91%E8%A6%8B-dc3c5878bb80)
> - [里氏替換原則 Liskov Substitution Principle (LSP)](https://medium.com/@f40507777/%E9%87%8C%E6%B0%8F%E6%9B%BF%E6%8F%9B%E5%8E%9F%E5%89%87-liskov-substitution-principle-adc1650ada53)