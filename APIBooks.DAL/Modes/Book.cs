using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBooks.DAL.Modes
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublisherYear { get; set; }
        public int Price { get; set; }
        public int authorId { get; set; }
        public Author author { get; set; }

    }
}
