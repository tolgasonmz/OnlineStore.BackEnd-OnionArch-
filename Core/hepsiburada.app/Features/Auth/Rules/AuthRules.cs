using hepsiburada.app.Bases;
using hepsiburada.app.Features.Auth.Exceptions;
using hepsiburada.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.app.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null)
            {
                throw new UserAlreadyExistException();
            }
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool isPasswordCheck)
        {
            if (user is null || !isPasswordCheck)
            {
                throw new EmailOrPasswordInvalidException();
            }
            return Task.CompletedTask;
        }
    }
}
