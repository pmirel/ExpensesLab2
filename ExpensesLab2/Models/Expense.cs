 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesLab2.Models
{
    public enum TypeOfExpense
    {
        Food = 0,
        Utilities = 1,
        Transportation = 2,
        Outing = 3,
        Groceries = 4,
        Clothes = 5,
        Electronics = 6,
        Other = 7
    }
    public class Expense
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Sum { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public string Currency  {get; set;}
        public TypeOfExpense TypeOfExpense { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
