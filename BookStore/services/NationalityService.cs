using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class NationalityService:INationalityService
    {
        Bookcontext context;
        public NationalityService(Bookcontext _context)
        {
            context = _context;
        }
        public void Insert(Nationality N)
        {
            context.nationalities.Add(N);
            context.SaveChanges();
        }
        public List<Nationality> LoadAll()
        {
            List<Nationality> li = context.nationalities.ToList();
            return li;
        }
    }
}
