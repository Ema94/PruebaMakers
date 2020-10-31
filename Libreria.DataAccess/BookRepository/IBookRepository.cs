using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.BookRepository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> FindByFilters(string title, DateTime? date, decimal? spend, string autor, int? editorial);
    }
}
