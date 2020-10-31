using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.CurdBooksProcesses
{
    public interface IBookManipulator
    {
        Task<Book> ManipulateBook(Book book);
    }
}
