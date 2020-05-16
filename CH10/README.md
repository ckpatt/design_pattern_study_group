第10章｜考題抄錯會做也白搭—範本方法模式(Template Method)
===

**想像一下🤔🤔🤔**
今天要需要一個機器人來幫飲料店搖飲料，點餐時，需要為它更新一份食譜，==每次都為他重新寫一份==。
一杯兩杯還好，但客人一多，要寫幾百次，仔細看看==發現加糖、加冰塊等程序==，好像每次都一樣，這樣==是不是可以先把固定好的食譜，另外分開呢？==


產生飲料食譜🍹
---
今天收到了一份訂單，客人要喝布丁奶茶跟波霸綠茶，由於本店的堅持，加糖跟冰塊的量是固定的，主要需要處理的是茶的類別以及加料，我們該怎麼做？

馬上拿了兩張紙，寫下食譜，準備交給機器人製作飲料。
```csharp=
class TemplateMethodFirstVersion {
    static void Main() {
        
        System.Console.WriteLine("------------------------------------");
        PuddingMilkTeaRecipe Order1= new PuddingMilkTeaRecipe();
        Order1.StartMixing();
        System.Console.WriteLine("------------------------------------");
        BubbleGreenTeaRecipe Order2= new BubbleGreenTeaRecipe();
        Order2.StartMixing();
        System.Console.WriteLine("------------------------------------");       
    }
    
    public class PuddingMilkTeaRecipe
    {
        public void StartMixing(){
            System.Console.WriteLine("Start mixing your drink!");
            AddTea();
            AddMaterial();
            AddSugar();
            AddIce();
            System.Console.WriteLine("Finished!!!!!!!!!!!!!!!!!!!");
        }
        public void AddSugar(){
            System.Console.WriteLine("Add sugar, it's only can be 50% sugar !");
        }
           
        public void AddIce(){
            System.Console.WriteLine("Add ice, it's only can be 30% ice !");
        }
        public void AddMaterial(){
            System.Console.WriteLine("Add Pudding !!!");
        }
        public void AddTea(){
            System.Console.WriteLine("Add Milk Tea !!!");
        }
    }
    
    public class BubbleGreenTeaRecipe
    {
        public void StartMixing(){
            System.Console.WriteLine("Start mixing your drink!");
            AddTea();
            AddMaterial();
            AddSugar();
            AddIce();
            System.Console.WriteLine("Finished!!!!!!!!!!!!!!!!!!!");
        }    
        public void AddSugar(){
            System.Console.WriteLine("Add sugar, it's only can be 50% sugar !");
        }        
        public void AddIce(){
            System.Console.WriteLine("Add ice, it's only can be 30% ice !");
        }
        public void AddMaterial(){
            System.Console.WriteLine("Add Bubble !!!");
        }
        public void AddTea(){
            System.Console.WriteLine("Add Green Tea !!!");
        }
    }    
}
```

由程式碼中可以發現，其中重疊的部分相當多，這也導致程式碼不精簡。從下圖可見，除了`AddMaterial()` 跟`AddTea()`之外，其他都相同。

![](https://i.imgur.com/KVDH5W3.png)

寫兩次還好，但如果今天有一百多種飲料，想必程式碼應該會相當長吧😓😓😓。


![image](https://media.giphy.com/media/23BST5FQOc8k8/source.gif)


於是我們使用**範本方法模式**，來解決此類問題。


---

**範本方法模式 (Template Method)**
---
:::info
定義一個操作中的演算法的骨架，而將一些步驟延遲到子類別中。範本方法使得子類別可以不改變一個演算法的結構，即可重新定義該演算法中的某些步驟。
:::

根據定義，畫出以下的示意圖作為參考。
定義模板方法，橘色圓圈為重複的方法，因此可以套用範本方法模式來設計，定義抽象類別（綠色虛線框框），讓不同的食譜（子類別），來實作（綠色圓圈）。

![](https://i.imgur.com/0Xrlzpg.png)


使用模版，產生飲料食譜🍹
---
由上圖可見，今天我們要準備食譜給機器人，只需要更新不同飲料中的幾個獨立步驟就好，這樣相對有效率，不會花太多時間做重複的事情。

![](https://i.imgur.com/GvdzAGf.png)



UML類別圖
---
#### Template Method UML類別圖
![](https://i.imgur.com/7MSpgnE.png)

#### 範例 UML類別圖

![](https://i.imgur.com/9c1MPpZ.png)
 
#### Template Method(`StartMixing`)
* 樣本方法，定義演算法架構

#### Abstract Class(`TeaRecipe`)
* 定義演算法與操作，可能是具體也可能是抽象，提供子類別因應不同需求做複寫（`override`）。

#### Concrete Class(`PuddingMilkTeaRecipe`、`BubbleGreenTeaRecipe`)
* 具體實作Abstract Class中的Abstract Method


完整程式碼(可在[LeetCode線上編譯器](https://leetcode.com/playground/)實作)
---
```csharp=
class TemplateMethod {
    static void Main() {
        //依據不同的點餐（使用需求），來做出（實體化）不同的食譜（物件）
        TeaRecipe OrderOne= new PuddingMilkTeaRecipe();
        TeaRecipe OrderTwo= new BubbleGreenTeaRecipe();

        System.Console.WriteLine("------------------------------------");
        OrderOne.StartMixing();
        System.Console.WriteLine("------------------------------------");
        OrderTwo.StartMixing();
        System.Console.WriteLine("------------------------------------");
    }
    
    public abstract class TeaRecipe
    {       
        //以下三個為固定的方法
        public void StartMixing(){
            System.Console.WriteLine("Start mixing your drink!");
            AddTea();
            AddMaterial();
            AddSugar();
            AddIce();
            System.Console.WriteLine("Finished!!!!!!!!!!!!!!!!!!!");
        }
        
        public void AddSugar(){
            System.Console.WriteLine("Add sugar, it's only can be 50% sugar !");
        }
           
        public void AddIce(){
            System.Console.WriteLine("Add ice, it's only can be 30% ice !");
        }
      
        //以下兩個為抽象方法，提供子類別實作
        abstract public void AddMaterial();
        abstract public void AddTea();       
    }
       
    //子類別繼承抽象類別，並對其抽象方法進行覆寫
    public class PuddingMilkTeaRecipe : TeaRecipe
    {
        public override void AddMaterial(){
            System.Console.WriteLine("Add Pudding !!!");
        }
        public override void AddTea(){
            System.Console.WriteLine("Add Milk Tea !!!");
        }
    }
    
    public class BubbleGreenTeaRecipe : TeaRecipe
    {
        public override void AddMaterial(){
            System.Console.WriteLine("Add Bubble !!!");
        }
        public override void AddTea(){
            System.Console.WriteLine("Add Green Tea !!!");
        }
    }  
}
```

 
總結
---
* 提供平台，讓程式碼重複利用
* 不變的行為到抽象類別，移除子類別中重複的程式碼
* 父類別實作骨架，子類別實作細節

