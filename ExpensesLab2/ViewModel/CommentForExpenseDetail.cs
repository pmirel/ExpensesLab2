using ExpensesLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesLab2.ViewModel
{
    public class CommentForExpenseDetail
    {
        public string Text { get; set; }
        public bool Important { get; set; }

        public static CommentForExpenseDetail FromComment(Comment comment)
        {
            return new CommentForExpenseDetail
            {
                Text = comment.Text,
                Important = comment.Important
            };
        }
    }
}
