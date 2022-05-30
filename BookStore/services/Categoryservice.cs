using BookStore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class Categoryservice:ICategoryservice
    {
        Bookcontext context;
        public Categoryservice(Bookcontext _context)
        {
            context = _context;
        }
        public void Insert(Category C)
        {
            context.cateogrries.Add(C);
            context.SaveChanges();
        }
        public List<Category> LoadAll()
        {
         List<Category> li = context.cateogrries.ToList();
            return li;
        }
        public void Delete(int Id)
        {
            Category category = context.cateogrries.Find(Id);
            context.cateogrries.Remove(category);
            context.SaveChanges();
        }
        public Category Edit(int Id)
        {
            Category CA = new Category();
            CA = context.cateogrries.Find(Id);
            return CA;
        }
        public void update(Category C)
        {
            context.cateogrries.Attach(C);
            context.Entry(C).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
