using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage("Access token is required.");
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh token is required.");
        }
    }
}
