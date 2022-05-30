using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("nationality")]
    public class Nationality
    {
       
        public int Id { set; get; }
        public string Name { set; get; }
        public List<Authors> liauthors { set; get; }
    }
}
