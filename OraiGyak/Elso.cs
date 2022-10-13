namespace DefaultNamespace;
enum WeekDays
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
public class Elso
{
    private static Dictionary<WeekDays, string?> _napirend = new();
    public static void enumExcercise()
    {
        _napirend[WeekDays.Monday] = "Weltraum surfen";
        _napirend[WeekDays.Tuesday] = "Rake the leaves";
        
        Console.WriteLine("On which day would you like to add an activity? (Monday:1, Tuesday:2 ...)");
        int day = Int32.Parse(Console.ReadLine());
        Console.WriteLine("What are we doing on "+ (WeekDays)day +" ?");
        string activity = Console.ReadLine();
        _napirend.Add((WeekDays)day-1, activity);
        
        for (int i = 0; i < 7; i++)
        {
            try
            {
                Console.WriteLine((WeekDays)i+"'s program: "+_napirend[(WeekDays)i]);
            }
            catch (Exception e)
            {
                Console.WriteLine("On "+(WeekDays)i+" we had no plans");
            }
        }
    }
}