第07章｜為他人做嫁衣－－代理模式（Proxy）
===

介紹
---

- 定義： 為**其他物件**提供一種**代理**以控制對這個物件的存取

- UML：

![](https://i.imgur.com/UY5xsim.png)

<br>

> 圖中包含三大類別：
> 
> **`Subject`**：是一個抽象類別或介面，定義`Proxy`和`RealSubject`的共同介面，當任何有使用`RealObject`的地方皆能使用`Proxy`。
> 
> **`RealSubject`**：被代理的角色，也就是`Proxy`所代表的真實實體。
> 
> **`Proxy`**：保存一個參考使得代理可以存取實體，並提供一個與`Subject`相同的介面，這樣代理就可以用來代替實體。

<br>

- **使用時機**：

    透過代理模式，可以在要控制原始物件的操作時，加入一些其他的動作或判斷，來減少非必要的複雜計算，減少頻繁地客戶端與伺服器端的溝通及改善使用者體驗等，所以可以簡單的分成兩個時機：
    * 存取權利需要控制時
    * 在存取時需要提供其他的功能時

- **應用**：

    * 遠端代理：代理遠端程式執行，可以為不同地址空間的物件提供一個本地的代理物件。例如透過WebService的WSDL定義產生中介檔的函式庫，透過這個函式庫就可以存取WebService。
    * 虛擬代理：將複雜或耗時實體，利用代理模式的物件替代。例如使用網頁讀取圖片時，會先用＂Loadiing...＂或圖框等畫面給客戶端看，當真實圖片載入完成後，再實際顯示給客戶端。
    * 安全代理：控制原始物件存取權限。
    * 智慧代理：提供比原始物件更多服務，比如計算物件被呼叫的次數。
    * 快取代理：將物件的運算結果儲存在臨時的共同空間，不同客戶端可以取這些共同的結果。

範例
---

- 安全代理實作

	```csharp=1
	class Program
	{
		static void Main(string[] args)
		{
			IWine wine = new ProxyWine(new Buyer(16));
			wine.BuyWine();

			wine = new ProxyWine(new Buyer(25));
			wine.BuyWine();
		}
	}

	interface IWine
	{
		void BuyWine();
	}

	// 代理的物件
	class ProxyWine : IWine
	{
		private Buyer buyer;
		private IWine realWine;

		public ProxyWine(Buyer buyer)
		{
			this.buyer = buyer;
			realWine = new Wine();
		}

		// 代理物件新增判斷的功能
		void IWine.BuyWine()
		{
			Console.WriteLine("Your age: {0}", buyer.Age);
			if (buyer.Age < 18)
				Console.WriteLine("Sorry you are too young to buy.");
			else
				realWine.BuyWine();
		}
	}

	// 真實的物件
	class Wine : IWine
	{
		void IWine.BuyWine()
		{
			Console.WriteLine("You got a bottle of wine.");
		}
	}

	class Buyer
	{
		private int age;

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		public Buyer(int age)
		{
			this.age = age;
		}
	}

	// Result:
	// Your age: 16
	// Sorry you are too young to buy.
	// Your age: 25
	// You got a bottle of wine.
	```

作業
---
- [**快取代理練習**](https://leetcode.com/playground/vshQ7Qkx)


討論
---

###### 參考資料
> - [程式範例](https://repl.it/repls/FabulousSlategreyDeletions)
> - [章節大綱](https://hackmd.io/@WeiTing35/Design_Patterns)
> - [Proxy 代理模式](https://ithelp.ithome.com.tw/articles/10222056)