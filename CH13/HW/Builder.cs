using System;

public abstract class GuardBuilder {
    public abstract void get_family_info();
    public abstract double get_height();
    public abstract bool has_license();
    
    public abstract void self_introduction();
    public abstract void show_magic();
}

public class Guard:GuardBuilder {
    
    double height = 183;
    bool license = true;

    public override void get_family_info() {
        Console.WriteLine("I have 1 sister, 2 brothers ...");
    }

    public override bool has_license() {
        return license;
    }
    
    public override double get_height() {
        return height;
    }
    
    public override void self_introduction() {
        Console.WriteLine("Hey! I am JC, graduated from Hogwarts.");
    }
    
    public override void show_magic() {
        Console.WriteLine("I can teleport to anywhere.");
    }
}

public class Director {
    public bool pass_stage_one(GuardBuilder builder) {
        Console.WriteLine("[ Stage 1 ]");
        builder.get_family_info();
        return (builder.has_license() && builder.get_height() > 180);
    }
    
     public void stage_two(GuardBuilder builder) {
        Console.WriteLine("\n[ Stage 2 ]");
        builder.self_introduction();
        builder.show_magic();
    }
}

class Program {
    static void Main(string[] args) {
        GuardBuilder g = new Guard();
        Director director = new Director();
        if(director.pass_stage_one(g)){
            director.stage_two(g);
        };
    }
}