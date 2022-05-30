using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignUpModelView
    {
        public SignUpModel signUpModel { set; get; }
        public List<IdentityRole> lirole { set; get; }
    }
}
