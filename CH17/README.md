# 第17章｜在NBA我需要翻譯 -- 轉接器模式(Adapter)

在飲料店打工的你發現老闆新買的封膜機和原本的杯子尺寸不合，怎麼辦呢? 請老闆重新買一台嗎? 還好廠商有提供不同尺寸的轉接器，只需要加夠轉接器就可以使用了。

日常生活中我們很常會用到轉接器，轉接器的功能就是在相同使用目的但不同介面裝置之間轉換，讓兩邊都不用修改設計就可以直接互通 (或單方面使用)，舉例來說，你有一條品質很好的手機充電線，但他只支援 Type-C 的手機，但你新買了一台 iPhone，充電接口是 lightning，這時候如果你有 Type-C to lightning 的轉接頭，就可以直接使用而不用買新的。

軟體中也經常有類似的情境，最常見的是資料庫存取，不同的資料庫有不同的存取方式，但基本上用戶端想做到的事情是幾乎相同的，例如說查詢資料、更新資料等等。透過轉接器模式我們可以對客戶端提供相同的介面，同時底層可以支援不同的實作。

> **轉接器模式 (Adapter)** 將一個類別的介面轉換成客戶希望的另外一個介面。Adapter 模式使得原本由於介面不相容而不能一起工作的那些類別可以一起工作。

## 程式碼

```csharp
using System;

class MakeDrink 
{
    static void Main(string[] args) 
    {
        NewSealingMachine newMachine = new NewSealingMachine();
        newMachine.Seal("奶茶", 90);

        SealingMachine machine = new NewSealingMachineAdapter();
        machine.Seal("奶茶", 90);
    }
}

class SealingMachine
{
    public void Seal(string drink, int size) {
        if (size == 90) {
            Console.WriteLine(drink + " 封口完成!!");
        } else {
            Console.WriteLine("尺寸不支援");
        }
    }
}

class NewSealingMachine
{
    public void Seal(string drink, int size) {
        if (size == 100) {
            Console.WriteLine(drink + " 封口完成!!");
        } else {
            Console.WriteLine("尺寸不支援");
        }
    }
}

class NewSealingMachineAdapter : SealingMachine
{
    private NewSealingMachine machine = new NewSealingMachine();
    public void Seal(string drink, int size) {
        machine.Seal(drink, 90);
    }
}
```

**UML 圖**
![](https://i.imgur.com/jaZsG82.png)
