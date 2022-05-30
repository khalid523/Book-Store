using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("cateogries")]
    public class Category
    {
        public int Id { set; get; }
        public string code { set; get; }
        [Required(ErrorMessage = "please fill Name")]
        public string Name { set; get; }
        public List<Books> libooks { set; get; }

    }
}
