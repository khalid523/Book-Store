using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class vmBook
    {
        public Books Books { set; get; }
        public List<Books> libooks { set; get; }
        public List<Authors> liauthors { set; get; }
        public List<Category> licateogrry { set; get; }
    }
}
