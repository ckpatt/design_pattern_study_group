
第04章｜升學求職兩不誤-開放封閉原則（OCP）
===

介紹
---



原則的兩大特徵就是 **對於擴展是開放，對於更改是封閉。** 其概念是希望當工程師在更改系統時，是使得舊版本穩定，且不斷的推出新的版本的同時，原來的程式碼能不動則不動。在書中是以前面的例子舉例，改寫加法運算。

原本在需要一個新功能 “加法” 時，是將 “加法” 寫在 `Operation`類別，但是當發現在往後的需求，需要更多的運算（減法）時，就將 `Operation` 變成父類別，並將各自的運算寫成新的 class。

- **簡化前**
    ```csharp=1
    public class Operation{
        public static double GetResult(double A, double B, string op){
            switch (op){
                case "+":
                    result = A + B;
                    break;

                ...
            }
            return result;
        }
    }
    ```
- **簡化後**
    ```csharp=1
    class OpAdd: Operation{
        public override double GerResult(){
            double res = 0;
            res = A + B;
            return res;
        }
    }
    
    public class Operation{
        public static double GetResult(double A, double B, string op){
            Operation oper = null;
            switch (op){
                case "+":
                    oper = new OpAdd();
                    break;

                ...
            }
            return oper;
        }
    }
    ```

在加入 OCP 後，更改每個運算細節只要到該運算的 class 更改，而不是到原本更改前的 `Operation` class 做更改，使得 `Operation` 能夠封閉，減少耦合。


​    
補充
---
另外在閱讀此章節時，還有參考 [OCP 討論網站](https://howtodoinjava.com/design-patterns/open-closed-principle/) ，其定義基本上和課本大同小異，多出強調以下如何將 OCP 加入程式設計：

**如何將 OCP 加入程式設計?**
1. Implementation inheritance
使用 abstract class 將部分 class 相同的部分抽出，使他們不去重複在不同的 class 定義
2. Interface inheritance
使用 interface 預先定義好該介面所需要的 function （predefined function）

以上兩點在課本 簡單工廠模式 和 附錄 皆有提過，在下方也會有細節補充。至於網站裡提到的例子基本上和課本上的是一樣的，更改前的改動會違反封閉原則，會改到原本架構下的程式碼。但加入 OCP ，將運算類別新增出來後，就可以透過繼承來新增新的運算模組，修改也在新的模組而不會改到原本架構下的程式。

**Abstract class vs. Interface**

這兩者其實相當接近，差別大概在於使用情境，以及其本身的條件限制，詳細請參考 [geeks](https://www.geeksforgeeks.org/difference-between-abstract-class-and-interface-in-java/) 。在使用的情境，以動物來說，鳥類、魚類、哺乳類都是動物（可以使用 abstract class 繼承動物類別），但並不是每個動物都會飛行，只有鳥類可以（鳥類繼承飛行 interface）

Abstract class 通常是重構的過程中，在許多的子類別裡取出共同的 function，但是 interface 像以 預先定義 的方向去想的，先定義好一個 SPEC 的概念。

- **以動物 “飛行” 為例，假設 Interface 定義如下：**

  ```csharp=1
  interface Ifly{
      public void speedUp();
      public void glide();
      ...
  }
  ```

  只要會飛的鳥類都必須實作以上的 interface，定義出每隻鳥是怎麼加速，是怎麼滑翔。預先定義的概念是指，只知道關於飛行需要做到以上的 function。會飛行的不只有鳥類，飛機也會小叮噹也會，不會去管要如何做出加速或滑翔的動作（鳥有可能是快速振動翅膀，飛機則是使用引擎來達到加速，小叮噹則用竹蜻蜓），只管在飛行時必須包含哪些細節動作。

- **以”動物”類別為例，假設 Abstract class 定義如下：**

  ```csharp=1
  public abstract class Animal {
      private double energy;
  	
      abstract void breath();
      public void eat(double foodCalorie) {
          energy+=foodCalorie;
      }
  }
  ```

  

  基本上所有動物的進食都是一樣的，吃進的食物轉成自身能量，像這樣的 `eat()` function 在所有子類別都會使用到且功能一樣，於是就能放在 Abstract class 當中，往後在繼承此` Animal` 類別時就可以直接使用。但以呼吸系統來講，有的動物使用肺部呼吸，有的使用腮呼吸 … 等等，所以各自動物再自行去實現 (implement) 這個預先定義好的 Abstract function。

  

作業
---

CK 上週在設計新的智慧手機時，檢查著手機裡的記憶體，意外的翻到他當年大學期間的青澀照片。CK 看著舊照片，想起幾個死黨當年一起在球場上奔馳揮灑汗水，一起在期末考週苦中作樂，還有，當年經常接送勝後的一個學姊，是他當年的初戀女友。

十年前 CK 交的這女友很特別，是來自編號 JNC-87 星球的外星人，但 CK 一開始並不知情，只知道她有一條細細的咖啡色尾巴，覺得相當性感。某一天，兩人在墾丁海灘約會，因為女友久曬太陽，尾巴竟開始變成紅色了！這時瞞不住了，女友才告訴 CK ，他的真實身份是個外星人，並且告訴他，他的尾巴會根據不同的天氣濕度和溫度，顏色也會有所變化。

女友尾巴程式的架構圖如下，請指出哪裡未滿足 OCP 原則，以及如何修改呢？

![](https://i.imgur.com/f06MsjS.png)

討論
---

- 參考 [HowToDoInJAVA - OCP](https://howtodoinjava.com/design-patterns/open-closed-principle/)

