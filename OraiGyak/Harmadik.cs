using System.Text;

namespace DefaultNamespace;

public class Harmadik
{
    private static List<int> fizetesek = new List<int>();
    public static void saveTime()
    {
        randomizeSalaries();
        //bin-write
        BinaryWriter binWriter = new BinaryWriter(File.Open("binary.bin", FileMode.Create));
        var clock = System.Diagnostics.Stopwatch.StartNew();
        foreach (var fizetes in fizetesek)
        {
            binWriter.Write(fizetes);    
        }
        clock.Stop();
        Console.WriteLine("binary write: "+clock.Elapsed);
        
        randomizeSalaries();
        //bin-update
        clock = System.Diagnostics.Stopwatch.StartNew();
        foreach (var fizetes in fizetesek)
        {
            binWriter.Write(fizetes);    
        }
        clock.Stop();
        Console.WriteLine("binary update: "+clock.Elapsed);
        binWriter.Close();
        
        //bin-read
        BinaryReader binReader = new BinaryReader(File.Open("binary.bin", FileMode.Create));
        clock = System.Diagnostics.Stopwatch.StartNew();
        fizetesek = new();
        while (binReader.PeekChar() != -1) {
            fizetesek.Add(binReader.ReadInt32());
        }
        clock.Stop();
        Console.WriteLine("binary read: "+clock.Elapsed);
        binReader.Close();
        
        //text 
        
        randomizeSalaries(); 
        StreamWriter sw = new("text.txt");
        clock = System.Diagnostics.Stopwatch.StartNew();
        foreach (var fizetes in fizetesek) {
            sw.WriteLine(fizetes);
        }
        clock.Stop();
        Console.WriteLine("text write: "+clock.Elapsed);
        
        randomizeSalaries();
        
        clock = System.Diagnostics.Stopwatch.StartNew();
        foreach (var fizetes in fizetesek)
        {
            sw.Write(fizetes);    
        }
        clock.Stop();
        Console.WriteLine("text update: "+clock.Elapsed);
        sw.Close();

        StreamReader sr = new("text.txt");
        clock = System.Diagnostics.Stopwatch.StartNew();
        fizetesek = new();
        for (int i = 0; i < 100_000; i++) {
            fizetesek.Add(sr.Read());
        }
        clock.Stop();
        Console.WriteLine("text read: "+clock.Elapsed);
        sr.Close();
    }

    private static void randomizeSalaries()
    {
        var rnd = new Random();
        fizetesek.Clear();
        for (int i = 0; i < 100_000; i++) {
            fizetesek.Add(rnd.Next(200_000, 5_500_000));    
        }   
    }
}