using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("authors")]
    public class Authors
    {
        public int Id { set; get; }
        public string Name { set; get; }
        [ForeignKey("nationality")]
        public int nationality_id { set; get; }
        public Nationality nationality { set; get; }
       
        public List<Books> books { set; get;
        }
        [NotMapped]
        public IFormFile Image { set; get; }
        public string ImagePath { set; get; }
    }
}
