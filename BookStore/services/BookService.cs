using BookStore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class BookService:IBookService
    {
        Bookcontext context;
        public BookService(Bookcontext _context)
        {
            context = _context;
        }
        public void Insert(Books B)
        {
            context.books.Add(B);
            context.SaveChanges();

        }
        public List<Books> loadAll()
        {
            List<Books> li = context.books.Include("authors").Include("cateogrry").ToList();
            return li;
        }
        public void Delete(int Id)
        {
            Books books = context.books.Find(Id);
            context.books.Remove(books);
            context.SaveChanges();

        }
      
        public Books Edit(int Id)
        {
            
            Books books = new Books();
            books = context.books.Find(Id);
            return books;
        }
        public void Update(Books B)
        {
            context.books.Attach(B);
            context.Entry(B).State = EntityState.Modified;
            context.SaveChanges();


        }
        }
}
