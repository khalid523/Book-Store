﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { set; get; }
    }
}
