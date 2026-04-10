using Repository;

using Database;
class Program
{

    static void Main(string[] args)
    {
        using (var context = new WetherStationContext())
        {
            context.Database.EnsureCreated();

            var user = new UserRepository(context);
            var temp = user.GetUser(1);
            Console.WriteLine(temp.Name);
        }
        
    }
}