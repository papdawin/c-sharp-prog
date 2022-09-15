using System;
using System.Collections.Generic;

namespace test
{
    class Valami
    {
        public static int count = 0;
        public static bool ki=false;
        public Valami() {
            count++;
        }
        ~Valami()
        {
            count--;
            ki = true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                Valami a = new Valami();
                Console.WriteLine(Valami.count);
                if (Valami.ki) break;
            }
        }
    }

    
}
