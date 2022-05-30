using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Vmauthoers
    {
        public Authors authors { set; get; }
        public List<Nationality> liationalities { set; get; }
        public List<Authors> liauthors { set; get; }
    }
}
