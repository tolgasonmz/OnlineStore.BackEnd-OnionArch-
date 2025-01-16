using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("Full Name")
                .WithMessage("Full name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("Last Name")
                .WithMessage("Last name is required");

            RuleFor(x => x.FirstName)
                .Matches(@"^[a-zA-Z\s]+$")
                .WithMessage("Full name must contain only letters");

            RuleFor(x => x.LastName)
                .Matches(@"^[a-zA-Z\s]+$")
                .WithMessage("Full name must contain only letters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithName("Email")
                .WithMessage("Email is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(20)
                .WithName("Password")
                .WithMessage("Password is required");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithName("Confirm Password")
                .WithMessage("Passwords do not match");
        }
    }
}
