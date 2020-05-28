第13章｜好菜每回位不同-建造者模式（Builder）
===

身為一名手搖杯店員，隨手搖一杯黯然銷魂飲也是合情合理。

半糖珍珠加冰塊，微糖波霸去冰，每次都是 **糖、冰度、料**，
繁瑣重複的細節，
是否有更有效率的方式建造呢？

![](https://i.imgur.com/M5rPXBw.png =200x200) ![](https://i.imgur.com/bUyEaAJ.png =200x200) ![](https://i.imgur.com/UGSF1NP.png =200x300)



應用情境
---

「巴 GA！」，飲料店的內場傳來一陣喝斥，
「那杯怎麼又忘了加糖 ... ? 那杯還少放珍珠啊！」老闆狠瞪著。

原來剛來的新員工小 K 還不熟悉搖飲料的方法，
忘東忘西的做了幾杯失敗品出來。

「甜度冰塊，加什麼料，不就這樣而已嗎？！再搖錯我就火掉你」老闆酸著，
無奈的小 K 想著，到底該怎辦才能讓他飯碗保住呢？

還好，他讀過建造者模式，他知道該怎麼做。

- **初版 1**

    ```csharp=1
    class DrinkBuilder{
        private Drink d;
        public DrinkBuilder(Drink d){
            this.d = d;
        }
        
        public void Build(){
            d.add_sugar(0.5);
            d.add_ice(0.3);
            d.add_material("bubble");
        }
    }
    ```
    
-   **初版 2**
    ```csharp=1
    class DrinkBuilder{
        private Drink d;
        public DrinkBuilder(float sugar, float ice, string material){
            d.sugar = sugar;
            d.ice = ice;
            d.material = material;
        }
    }
    
    static void main(){
        DrinkBuilder bubble_tea = new DrinkBuilder(0.3, 0.5, "bubble");
    }
    ```
    
    沒錯，小 K 記得在《大話設計模式》裡頭，是以 "畫火柴人" 為例子，例子是述說在畫火柴人時，因為步驟流程大致一樣，只差在每個細節的微調。
    
搖了一個禮拜後的飲料，小 K 發現了些問題。

`初版一` 每次要新的一杯飲料，就要去複製上一杯的，過程有時會需要 `add_material`，有時又不用，粗心的他仍然會犯忘了加料的失誤。

`初版二` 在建構子的部分，有時會寫得太長。他知道現在只有 3 個參數，那要是到時有 8 個呢？ 12 個呢？在建構時不就程式碼亂到不行嗎？

還好，他讀過建造者模式，他知道該怎麼做。

建構者模式
---
讓我們來看看如何使用建構者模式，來有效率的處理繁複的程序吧
- **建構者模式版**

    ```csharp=1
    public abstract class Builder {
        public abstract void add_ice();
        public abstract void add_sugar();
        public abstract void add_material();
        public abstract List<string> get_result();
    }

    public class BubbleTeaBuiler:Builder {
        List<string> drink = new List<string>();
        double ice = 0.3;
        double sugar = 0.5;
        string material = "bubble";

        public override void add_ice() {
            drink.Add(String.Format("ice: {0}", ice));
        }

        public override void add_material() {
            drink.Add(String.Format("material: {0}", material));
        }

        public override void add_sugar() {
            drink.Add(String.Format("sugar: {0}", sugar));
        }

        public override List<string> get_result() {
            return drink;
        }
    }

    public class Director {
        public void construct(Builder builder) {
            builder.add_ice();
            builder.add_material();
            builder.add_sugar();
        }
    }

    class Program {
        static void Main(string[] args) {
            Builder bubble_tea = new BubbleTeaBuiler();
            Director director = new Director();
            director.construct(bubble_tea);
            List<string> res = bubble_tea.get_result();
            foreach(string s in res) {
                Console.WriteLine(s);
            }
        }
    }
    ```

    建構者模式的精髓是 `abstract function`，將所有必須要做的事情都宣告成 abstract，如此一來在建造新物（搖新的飲料）時，若是忘了 implement（加料、或加糖 ... 等等），則在編譯的時候就會被擋下來，直到實作之後才能夠執行程式。如此一來，拿給客戶的飲料就不用再擔心粗心的問題了！
    
    另外，在建構一物時，也可以更有條理的定義，哪些是普遍性的必須動作。將這些必須的動作都實作之後，如果每個特定的類別有一些特定額外的動作（例如奶蓋需要新的 function "加奶蓋"），則在各自定義。
    
補充
---

可以特別注意到，在 `program.cs` 裡頭的以下程式碼

```csharp=1
Director director = new Director();
Builder bubble_tea = new BubbleTeaBuiler();
director.construct(bubble_tea);
List<string> res = bubble_tea.get_result();
```


可以觀察一下，在這邊的 `bubble_tea` 是以 reference 的 type 被傳進去 `construct`，所以在第 4 行直接對 bubble_tea取值，為何呢？，為何呢？根據 [reference-types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)，可以知道 `class` 是屬於 reference-type（還有 `interface`, `delegate`），所以這樣調用 director 可以直接更改到 `bubble_tea` 的值，另外補充，`Struct` 則是 pass by value，有興趣可以參考 [classes-and-structs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-know-the-difference-passing-a-struct-and-passing-a-class-to-a-method)。

組員一起討論時，也討論到一個問題。既然 class 是 reference-type，那 class 裡頭的 public 變數呢？這邊的 public 變數仍然還是變數，所以是以 pass by value 的方式在傳遞，故不是 reference 唷！

作業
---

上週 CK 請了銀行理專幫他管錢，原希望理專能幫他規劃些投資策略，殊不知這專員啥都不會，連 K 線都不會看。
CK 知道後火了起來，拍桌斥責這專員，憑什麼在銀行工作這麼久，還不被客戶投訴？專員回答：我雖不會任何投資，但我知道任何地下金庫的密碼，有三十億美金正轉到你的戶頭了。
這下可好了，CK 現在超有錢，但聰明的 CK 知道要僱一些保鑣來保護自己，於是他打算舉辦徵才面試：

1. 面試第一關，任何保鑣要提供三等親的家屬資料、保鑣執照，身高至少 180cm
2. 過第一關後才能面試第二關，任何保鑣都要準備一段自介，並且展示自己會的魔法。

請用建造者模式，為要來面試的保鑣寫出一套程式吧！

- [解答](https://github.com/ckpatt/design_pattern_study_group/tree/master/CH13/HW)