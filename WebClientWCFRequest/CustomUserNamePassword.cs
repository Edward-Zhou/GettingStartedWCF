using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace WebClientWCFRequest
{
    public class CustomUserNamePassword:System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "test1" && password == "test1") && !(userName == "test2" && password == "test2"))
            {
                throw new SecurityTokenException("Unknown Username or Password");
            }
        }
    }
}