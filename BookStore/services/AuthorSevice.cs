using BookStore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class AuthorSevice:IAuthorSevice
    {
        Bookcontext context;


        public AuthorSevice(Bookcontext _context)
        {
            context = _context;
        }
        public void Insert(Authors A)
        {

            context.authors.Add(A);
            context.SaveChanges();
        }
        public List<Authors> loadAll() {
            List<Authors> li = context.authors.Include("nationality").ToList();
            return li;
        }
        public void Delete(int Id)
        {
          Authors authors=  context.authors.Find(Id);
            context.authors.Remove(authors);
            context.SaveChanges();
        }
        public Authors Edit(int Id)
        {
            Authors Au = new Authors();
            Au = context.authors.Find(Id);
            return Au;
        }
        public void update(Authors A)
        {
            context.authors.Attach(A);
            context.Entry(A).State = EntityState.Modified;
            context.SaveChanges();

        }


    }
}
