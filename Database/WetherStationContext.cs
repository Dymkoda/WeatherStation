using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Database
{
    public class WetherStationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WetherStationDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .UseSeeding((context, _) =>
                {
                var users = context.Set<User>().FirstOrDefault();
                if (users == null)
                {
                    var userFaker = new Faker<User>();
                    userFaker.RuleFor(x => x.Name, f => f.Name.FullName());
                    var usersToAdd = userFaker.Generate(1000);
                    context.AddRange(usersToAdd);
                    context.SaveChanges();
                }
            });
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WetherStationDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .UseSeeding((context, _) =>
                {
                    var sensors = context.Set<Sensor>().FirstOrDefault();
                    if (sensors == null)
                    {
                        var sensorFaker = new Faker<Sensor>();
                        sensorFaker.RuleFor(x => x.Name, f => f.Name.FullName());
                        sensorFaker.RuleFor(x => x.Type, f => f.Lorem.Word());
                        sensorFaker.RuleFor(x => x.MeasurementDate, f => f.Date.Past());
                        var sensorToAdd = sensorFaker.Generate(1000);
                        context.AddRange(sensorToAdd);
                        context.SaveChanges();
                    }
                });
        }

    }
}
