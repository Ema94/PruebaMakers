using Libreria.Core.Entities;
using Libreria.Core.ServiceProceses;
using Libreria.Core.ServiceProceses.LibrosFindProcess;
using Libreria.Services.CurdServiceProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Services.BookstoredBooksServices
{
    public interface IBookCurdServiceConfiguration
    {
        ManipulationProcesses<Book> BookManipulatorConfig { get; }
        BookFindServiceProcess<Book> BooksFindProcess { get; }
    }
}
