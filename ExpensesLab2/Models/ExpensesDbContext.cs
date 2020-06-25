using Microsoft.EntityFrameworkCore;
using System;

namespace ExpensesLab2.Models
{
    public class ExpensesDbContext : DbContext
    {
        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> User { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
