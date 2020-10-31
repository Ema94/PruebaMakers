using Libreria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Libreria.Db
{
    public class BookStoreContext : DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Editorial> Editoriales { get; set; }
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
: base(options)
        { }

  
    }
}
