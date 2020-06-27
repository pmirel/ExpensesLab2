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
                // Look for any expenses.
                if (context.Expenses.Count() >= 50)
                {
                    return;   // DB table has been seeded
                }

                for (int i = 1; i <= 50; ++i)
                {
                    context.Expenses.Add(
                        new Expense
                        {
                            Description = $"Description-{i}",
                            Sum = i,
                            Location = "Cluj",
                            DateAdded = DateTime.Now,
                            Currency = "Lei",
                            TypeOfExpense = TypeOfExpense.Other
                        }
                    );
                }

                context.SaveChanges();

                
            }
        }
    }
}
