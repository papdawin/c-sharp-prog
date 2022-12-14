class Valami{
    public static int count = 0;
    public static bool ki=false;
    public Valami(){
        count++;
    }
    ~Valami(){
        count--;
        ki = true;
    }
}
class Nulladik {
    public static void garbageCollector(){
        Console.WriteLine("Hello World!");
        while (true){
            Valami a = new Valami();
            Console.WriteLine(Valami.count);
            if (Valami.ki) break;
        }
    }
}
