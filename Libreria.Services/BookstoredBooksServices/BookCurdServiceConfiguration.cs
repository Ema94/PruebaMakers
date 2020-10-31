using Libreria.Core.Entities;
using Libreria.Core.ServiceProceses;
using Libreria.Core.ServiceProceses.LibrosFindProcess;
using Libreria.Services.CurdServiceProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Services.BookstoredBooksServices
{
    public class BookCurdServiceConfiguration : IBookCurdServiceConfiguration
    {
        public ManipulationProcesses<Book> BookManipulatorConfig {get;set;}

        public BookFindServiceProcess<Book> BooksFindProcess {get;set;}
    }
}
