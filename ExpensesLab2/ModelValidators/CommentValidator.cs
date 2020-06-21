using ExpensesLab2.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ExpensesLab2.ModelValidators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Id).NotNull();

            RuleFor(x => x.Text)
                .Length(3, 20)
                .WithMessage("Text must have minimum 3 characters and maximum 20.");

            RuleFor(x => x.Important)
                .NotEmpty()
                .WithMessage("You must select the importance of this comment");

            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text cannot be empty.");
        }
    }
}
