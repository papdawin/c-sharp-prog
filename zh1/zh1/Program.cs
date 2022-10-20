string path = "/Users/pdwn/Desktop/mindenfele.csv";
//1. feladat
string text = File.ReadAllText(path);
List<string> temp=new List<string>();
foreach (var el in text.Split("\n")) {
    temp.Add(el);
}
//2. feladat
List<string> szavak = new List<string>();
List<int> szamok = new List<int>();

foreach (var el in temp) {
    string[] values = el.Split(",");
    foreach (var value in values) {
        try {
            szamok.Add(Int32.Parse(value));
        } catch (Exception e) {
            szavak.Add((value));
        }
    }
}
Console.WriteLine("["+szamok.Count()+"] szám és ["+szavak.Count()+"] szó beolvasva");
//3. feladat
foreach (int szam in szamok) 
    if(20<szam)
        Console.Write(szam+", ");
Console.WriteLine();
//linq
IEnumerable<int> linqSorted = szamok.Where(x => x>20);

foreach (int szam in linqSorted)
    Console.Write(szam+", ");

Console.WriteLine();
//4. feladat
Dictionary<int, int> szamMap = new Dictionary<int, int>();
foreach (int szam in szamok) {
    if(!szamMap.ContainsKey(szam))
        szamMap.Add(szam,0);
    szamMap[szam]++;
}
foreach (var szam in szamMap) {
    Console.WriteLine("["+szam.Key+"] szám ["+szam.Value+"]x fordul elő");
}
//linq
var groupedSzamok = szamok.GroupBy(x => x);
foreach (IGrouping<int, int> szam in groupedSzamok) {
    Console.WriteLine("["+szam.Key+"] szám ["+szam.Count()+"]x fordul elő");
}
//5. feladat
Dictionary<char, int> kbetuFrequency = new Dictionary<char, int>();
foreach (var szo in szavak) {
    if (!kbetuFrequency.ContainsKey(szo[0]))
        kbetuFrequency[szo[0]] = 0;
    kbetuFrequency[szo[0]]++;
}

int max = kbetuFrequency.Values.Max();
char mostFrequentLetter=' ';
foreach (KeyValuePair<char,int> betu in kbetuFrequency) {
    if(betu.Value==max)
        mostFrequentLetter=betu.Key;
}

for (int i = 0; i < szavak.Count; i++) {
    if (szavak[i].StartsWith(mostFrequentLetter))
        szavak.RemoveAt(i);
}
Console.WriteLine("Az új szavak hossza: "+szavak.Count()); //az 1. leggyakoribb kezdőbetűjű szó
//linq
string mostFrequentWord = szavak.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
szavak.RemoveAll(x => x == mostFrequentWord);
Console.WriteLine("Az új szavak hossza: "+szavak.Count()); //a 2. leggyakoribb kezdőbetűjű szó
//6. feladat
double avg = szamok.ToArray().Average();
foreach (int el in szamok)
    if (el<avg)
        Console.Write(el+", ");
Console.WriteLine();
//linq
szamok.Where(x => x < avg);
foreach (int el in szamok)
    Console.Write(el+", ");
Console.WriteLine();
//7.feladat
foreach (string el in szavak) {
    el.Count(x => x == 's');
} //nincs kész, eddig jutottam


//9. feladat
Random rnd = new Random();
int num  = rnd.Next(0, 20);
string? input = Console.ReadLine();
string opt = num<int.Parse(input)? "A felhasználói input nagyobb" : "A gépi szám nagyobb";
Console.WriteLine(opt);