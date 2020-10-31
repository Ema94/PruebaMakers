using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Services.BookstoredBooksServices
{
    public interface IBookCurdServices
    {
        Task<Book> FindBooks(Expression<Func<Book, bool>> query);
        Task<IEnumerable<Book>> FindByFilters(string title, DateTime? date, decimal? spend, string Autor, int? Editorial);
        Task<Book> Add(Book book);
        Task<Book> Update(Book book);
        Task<Book> Delete(Book book);
    }
}
