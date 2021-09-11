// This seems to work for both SQLite and SQL Server. No GUID need for ConcurrencyToken
#region snippet
using Sporty.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sporty.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SportyContext context)
        {
            // Look for any event.
            if (context.Events.Any())
            {
                return;   // DB has been seeded
            }

            var alexander = new User
            {
                FirstName = "Carson",
                LastName = "Alexander"
            };

            var alonso = new User
            {
                FirstName = "Meredith",
                LastName = "Alonso"
            };

            var anand = new User
            {
                FirstName = "Arturo",
                LastName = "Anand"
            };

            var barzdukas = new User
            {
                FirstName = "Gytis",
                LastName = "Barzdukas"
            };

            var li = new User
            {
                FirstName = "Yan",
                LastName = "Li"
            };

            var justice = new User
            {
                FirstName = "Peggy",
                LastName = "Justice"
            };

            var norman = new User
            {
                FirstName = "Laura",
                LastName = "Norman"
            };

            context.Users.AddRange(new[] {alexander, alonso, anand, barzdukas, li, justice, norman});
            context.SaveChanges();

            var alex_vs_alonso = new Event {
                Date = DateTime.Parse("2021-09-11"),
                Time = DateTime.Parse("15:00"),
                Duration = 60,
                Title = string.Empty,
                Members = new List<User>{alexander, alonso}
            };

            var alex_vs_li = new Event {
                Date = DateTime.Parse("2021-09-12"),
                Time = DateTime.Parse("15:00"),
                Duration = 30,
                Title = string.Empty,
                Members = new List<User>{alexander, li}
            };

            context.Events.AddRange(new[] {alex_vs_alonso, alex_vs_li});
            context.SaveChanges();
        }
    }
}
#endregion
