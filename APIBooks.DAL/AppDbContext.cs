using APIBooks.DAL.Modes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBooks.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Author> Authors {  get; set; }
        public DbSet<Book> Books { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}
