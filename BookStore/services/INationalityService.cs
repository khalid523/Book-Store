using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface INationalityService
    {
        void Insert(Nationality N);
        List<Nationality> LoadAll();
    }
}
