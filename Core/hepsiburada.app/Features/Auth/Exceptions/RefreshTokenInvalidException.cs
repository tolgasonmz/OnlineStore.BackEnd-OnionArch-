using hepsiburada.app.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.app.Features.Auth.Exceptions
{
    public class RefreshTokenInvalidException : BaseException
    {
        public RefreshTokenInvalidException() : base("Refresh Token is Invalid")
        {
        }
    }
}
