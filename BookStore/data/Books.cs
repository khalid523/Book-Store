using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("Books")]
    public class Books
    {
        public int Id { set; get; }
        public string BookName { set; get; }
        public string Year { set; get; }
        public string price { set; get; }
        public string stock { set; get; }
       
        [ForeignKey("authors")]
        public int authors_id { set; get; }
        public Authors authors { set; get; }
        [ForeignKey("cateogrry")]
        public int cateogrry_id { set; get; }
        public Category cateogrry { set; get; }
        [NotMapped]
        public IFormFile Image { set; get; }
        public string ImagePath { set; get; }
    }
}
