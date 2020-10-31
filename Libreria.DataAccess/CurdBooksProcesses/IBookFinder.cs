using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.CurdBooksProcesses
{
    public interface IBookFinder
    {
       Task<Book> Find(Expression<Func<Book, bool>> Query);
    }
}
