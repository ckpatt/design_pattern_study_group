// 用戶端
using System;

class BeverageShop {
  static void Main(string[] args){
      MiddleMan bigMouth9 = new MiddleMan();

      // CK 下注
      Customer CK = new Customer("CK");
      CK.setBet("三場7號");

      // 大口九為 CK 下注
      bigMouth9.receiveBet(CK);
      bigMouth9.sendRequest(new Casino());      
  }
}

// 大口九程式碼
class MiddleMan {
    private Customer customer;
    
    public void receiveBet(Customer customer)
    {
        this.customer = customer;
    }
    
    public void sendRequest(Casino casino)
    {
      casino.game(this.customer.getBet());
    }
}

// 顧客程式碼
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

// 廚房程式碼
class Casino {

    public void game(string betContent)
    {
        Console.WriteLine("接受下注：" + betContent + " 比賽即將開始...");
    }
}