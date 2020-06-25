using ExpensesLab2.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ExpensesLab2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExpensesDbContext(serviceProvider.GetRequiredService<DbContextOptions<ExpensesDbContext>>()))
            {
                if (!context.User.Any())
                {
                    context.User.Add(new User
                    {
                        FirstName = "Mirel",
                        LastName = "Ionut",
                        Username = "Imirel",
                        Password = HashUtils.GetHashString("parolasigura")
                    });
                    context.SaveChanges();
                }
                // Look for any expenses.
                if (context.Expenses.Any())
                {
                    return;   // DB table has been seeded
                }

                context.Expenses.AddRange(
                    new Expense
                    {
                        Description = "Cumparatura",
                        Sum = 12.25,
                        Location = "Lidl",
                        DateAdded = DateTime.Now,
                        Currency = "Lei",
                        TypeOfExpense = TypeOfExpense.Food

                    },

                    new Expense
                    {
                        Description = "Imbracaminte",
                        Sum = 25.56,
                        Location = "H&M",
                        DateAdded = DateTime.Now,
                        Currency = "Lei",
                        TypeOfExpense = TypeOfExpense.Clothes

                    },

                    new Expense
                    {
                        Description = "Papuci",
                        Sum = 10,
                        Location = "PapucSRL",
                        DateAdded = DateTime.Now,
                        Currency = "Lei",
                        TypeOfExpense = TypeOfExpense.Clothes

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
