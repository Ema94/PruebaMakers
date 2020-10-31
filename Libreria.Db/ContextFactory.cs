using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Db
{
    public class BookStoreContextFactory
    {
        private readonly string connString;

        public BookStoreContextFactory(string connString)
        {
            this.connString = connString;
        }

        public BookStoreContext GetContext()
        {
            return new BookStoreContext(new DbContextOptionsBuilder<BookStoreContext>()
            .UseSqlServer(connString).Options);
        }
    }
}

