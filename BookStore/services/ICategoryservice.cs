using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public interface ICategoryservice
    {
        void Insert(Category C);
        List<Category> LoadAll();
        void Delete(int Id);
        void update(Category C);
        Category Edit(int Id);
    }
}
