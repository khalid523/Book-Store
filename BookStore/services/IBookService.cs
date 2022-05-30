using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface IBookService
    {
        void Insert(Books B);
        List<Books> loadAll();
        void Delete(int Id);
        Books Edit(int Id);

        void Update(Books B);

    }
}
