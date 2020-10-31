using Libreria.Core.BookServicesProcess;
using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Services.BookstoredBooksServices
{
    public class BookFindServicesProcess : IBookFindServiceProcess
    {
        public Func<string, DateTime?, decimal?, string, int?, Task<IEnumerable<Book>>> FindByFilters { get; set; }

        public Func<Expression<Func<Book, bool>>, Task<IEnumerable<Book>>> Find { get; set; }

        public Func<Expression<Func<Book, bool>>, Task<Book>> FindOne { get; set; }
    }
}
