using OnlineStore.app.Bases;
using OnlineStore.app.Features.Auth.Exceptions;
using OnlineStore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Auth.Rules
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
        
        public Task RefreshTokenShouldNotBeInvalid(DateTime? expiryDate)
        {
            if (expiryDate < DateTime.Now)
            {
                throw new RefreshTokenInvalidException();
            }
            return Task.CompletedTask;
        }

        public Task UserShouldNotBeInvalid(User? user)
        {
            if (user is null)
            {
                throw new UserInvalidException();
            }
            return Task.CompletedTask;
        }
    }
}
