using OnlineStore.app.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Auth.Exceptions
{
    public class UserInvalidException : BaseException
    {
        public UserInvalidException() : base("User is Invalid")
        {
        }
    }
}
