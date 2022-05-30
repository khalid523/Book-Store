using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignInModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}
