using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExpensesLab2.Models
{
    public class ExpensesDbContext : IdentityDbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
            : base(options)
        {
        }

       
        

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
