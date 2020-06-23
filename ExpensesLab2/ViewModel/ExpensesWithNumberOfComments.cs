using ExpensesLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesLab2.ViewModel
{
    public class ExpensesWithNumberOfComments
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Sum { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public string Currency { get; set; }
        public TypeOfExpense TypeOfExpense { get; set; }

        public long NumberOfComments { get; set; }
    }
}
