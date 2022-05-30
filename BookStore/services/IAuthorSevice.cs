using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface IAuthorSevice
    {
        void Insert(Authors A);
        List<Authors> loadAll();
        void Delete(int Id);
        Authors Edit(int Id);
        void update(Authors A);
    }
}
