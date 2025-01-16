using OnlineStore.app.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Auth.Exceptions
{
    public class EmailOrPasswordInvalidException : BaseException
    {
        public EmailOrPasswordInvalidException() : base("Email or password is invalid.")
        {
        }
    }
}
