using ExpensesLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesLab2.ViewModel
{
    public class ExpenseDetail
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Sum { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public string Currency { get; set; }
        public TypeOfExpense TypeOfExpense { get; set; }

        public List<CommentForExpenseDetail> Comments { get; set; }

        public static ExpenseDetail FromExpense(Expense expense)
        {
            return new ExpenseDetail
            {
                Id = expense.Id,
                Description = expense.Description,
                Sum = expense.Sum,
                Location = expense.Location,
                DateAdded = expense.DateAdded,
                Currency = expense.Currency,
                TypeOfExpense = expense.TypeOfExpense,
                Comments = expense.Comments.Select(c => CommentForExpenseDetail.FromComment(c)).ToList()
            };
        }
    }
}
