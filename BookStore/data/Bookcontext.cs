using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class Bookcontext : IdentityDbContext<ApplicationUser>
    {
        IConfiguration config;
        public Bookcontext(IConfiguration _config)
        {
            config = _config;
        }
       public DbSet<Books> books { set; get; }
        public DbSet<Category> cateogrries { set; get; }
        public DbSet<Authors> authors { set; get; }
        public DbSet<Nationality> nationalities { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionbookstore"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
