using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.CurdBooksProcesses
{
    public interface IBookCollectionFinder
    {
        Task<IEnumerable<Book>> FindCollection(Expression<Func<Book, bool>> Query);
        Task<IEnumerable<Book>> FindByFilters(string title, DateTime? date, decimal? spend, string autor,int? editorial);
    }
}
