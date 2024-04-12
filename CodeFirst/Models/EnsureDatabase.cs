using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class EnsureDatabase
    {
        public static void Migrate(CodeFirstDbContext ctx) 
        {
            if (ctx.Database.GetPendingMigrations().Any())
            {
                ctx.Database.Migrate();
            }

            if (!ctx.Items.Any())
            {
                ctx.Items.AddRange(
                new Item() { Description = "Kartofeln", Shop = "lidl" },
                new Item() { Description = "Orange", Shop = "Rewe" },
                new Item() { Description = "Äpfel", Shop = "Edeka" },
                new Item() { Description = "Bohnen", Shop = "Edeka" }

                );
                ctx.SaveChanges();
            }
        }
    }
}
