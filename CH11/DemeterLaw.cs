// 用戶端程式碼
using System;

class BeverageShop {
  static void Main(string[] args){
      Clerk clerk = new Clerk();
      
      clerk.receiveOrder(new Customer("大奶微微"));
      clerk.sendJob(new Kitchen("小帥哥"));      
  }
}

// 櫃台程式碼
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

// 顧客程式碼
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

// 內場程式碼
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