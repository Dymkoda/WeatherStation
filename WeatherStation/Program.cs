namespace Database;
class Program
{

    static void Main(string[] args)
    {
        using (var context = new WetherStationContext())
        {
            context.Database.EnsureCreated();
        }
    }
}