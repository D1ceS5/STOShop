using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int  Passwords_PasswordId { get; set; }
        public int  Logins_LoginId { get; set; }
        public int AccountTypes_AccountTypeId { get; set; }
    }
}