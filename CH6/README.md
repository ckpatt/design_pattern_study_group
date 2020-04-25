第06章｜穿什麼有這麼重要？-裝飾模式（Decorator）
===

如何既有效率又精簡地，對某 function 加油添醋呢？

前言
---
在閱讀此章節時，我覺得重點可以放在，如何在保有 function 原本的功能下，去增添新的小功能。若要去增添小功能，最直接的方法就是改寫每個需要被修改的 function ，但是若有多個 function 需要相同的加添呢？複製貼上？那如果往後的需求需要去改寫這些加添的小 function 呢？搜尋取代？以下會透過例子來慢慢介紹裝飾模式能夠帶來的效益！

-  **第一版**

    當一個 user 想要穿上 T-shirt，或者想要穿上任何衣服時，都需要去呼叫寫在 `Person` 類別裡的 function，但是若是想要新增穿衣功能，就必須進去 `Person` 做修改，違反了 "開放-封閉原則 OCP(Open/closed principle)"
    ```csharp=1
    class Person{
        private string name;
        public Person(string name){
            this.name = name;
        }
        
        public void wear_tshirt(){
            Console.Write("衣服")
        }
        // ...
    }
    
    static void Main(String[] args){
        Person Jone = new Person("Jone");
        Jone.WearThirts();
        Jone.WearBigTrouser();
        Jone.WearSneakers();
        Jone.Show();
    } 
    ```

- **第二版**

    在第二版所做的改善，是將原本在 `Person` 類別裡面的穿衣 function 都取出，使各自衣物都有自己的類別，並且讓所有的衣物去繼承 `Finery` 父類別。此版的缺點在課本的形容是 "當著眾人面前穿衣服"，跟使用裝飾模式相比，差別在於每穿一件都去執行 `Show()`
    ```csharp=1
    abstract class Finery{
        public abstract void Show();
    }
    
    static void Main(String[] args){
        Person p = new Person("Jone");
        Finery t = new TShirts();
        Finery bt = new BigTrouser();
        
        t.Show();
        bt.Show();
        p.Show();
    } 
    ```
    
- **第三版 (Decorator pattern)**

    在第三版使用了 decorator 的方式，在這邊先補充 `c#` 裡頭 [base()](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base) 的使用方法，`base()` 會去調用父類別的 function。
    > The `base` keyword is used to access members of the base class from within a derived class

    而在理解 `base()` 時，它像是 `Decorator` 的精髓，因為有了 `base()` 才有辦法一層一層的拆開執行。
    
    ```csharp=1
    static void Main(){
        Person p = new Person("Jonec");

        TShirts t = new TShirts();
        BigTrouser b = new BigTrouser();

        t.Decorate(p);
        b.Decorate(t);
        b.Show();
    }
    
    public class TShirts:Finery{
        public override void Show(){
            Console.WriteLine("T-shirt: ");
            base.Show();
        }
    }

    public class BigTrouser : Finery{
        public override void Show(){
            Console.WriteLine("BigTrouser: ");
            base.Show();
        }
    }
    
    public class Finery:Person{
        protected Person component;

        public void Decorate(Person component){
            this.component = component;
        }

        public override void Show(){
            if(component != null){
                component.Show();
            }
        }

        public Finery()
        {}
    }
    ```
    
    在 7, 8 行使用的 `Decorate(Person)`，像是加外殼的感覺。第 7 行將 p 套上一件衣服之後得到 t，第 8 行再將 t 套上衣服得到 b。當執行 `b.Show()` 時，先執行 BigTourse，接著執行 `base.Show()`，`base` 指 `Finery` 這個 class，也就是 33 行的 `Show()`，而因為第 8 行將 component 設置為 t（b 對 t 執行 `Decorate()`），所以才能夠一層一層的解開並且執行。

    **概念圖**

    ![](https://i.imgur.com/I7e6hVI.png)

    
    上述的程式碼就像是一層又包一層的殼，由外而內，一層執行後再執行裡頭包覆的那層函式，若想要變換執行順序，只要變換 Decorate() 的執行順序即可。





作業
---

出了社會的 CK 到了 NASA 公司上班，工作期間，認識了不少的外星人，善於社交的 CK 更是希望能夠維持友善關係，以免近期它們趁著地球人忙著防疫時期，直接入侵並且攻打地球。

CK 過去的大學女友是外星人，所以 CK 對外星人的性格相當了解，知道他們喜歡吃台南勝早的食物，越油越愛，但是因為腦袋構造的關係，它們不知道食物的價格要如何計算，也看不懂數字，於是 CK 打算寫個程式幫它們把食物的價格都算好。

請你透過 `Decorating pattern` ，設計出一個能夠算出食物總額的程式。

- Price list
    - EggRoll: 100$
    - egg: 10$
    - cheese: 12$
    - ham: 5$

- Output
    `Material` 部分是選擇想加的料，可以自行依自己的喜好做替換，`EggRoll 1` 是該蛋餅的名字（JC 喜歡將蛋餅取名字）
    
    ![](https://i.imgur.com/fYzp0Up.png)
    

- [解答](https://github.com/ckpatt/design_pattern_study_group/tree/master/CH6/HW)