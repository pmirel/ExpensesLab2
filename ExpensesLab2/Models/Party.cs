using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesLab2.Models
{
    public class Party
    {
        public long Id { get; set; }
        public string Shopping { get; set; }
        public decimal totalExpenses { get; set; }
        public long ExpenseId { get; set; }
        public Expense Expense { get; set; }
        public long UserId { get; set; }
        public User User {get; set;}
        
    }
}
