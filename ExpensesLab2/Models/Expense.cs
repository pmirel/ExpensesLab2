 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesLab2.Models
{
    public enum TypeOfExpense
    {
        Food,
        Utilities,
        Transportation,
        Outing,
        Groceries,
        Clothes,
        Electronics,
        Other
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
