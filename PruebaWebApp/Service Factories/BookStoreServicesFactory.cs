using Libreria.DataAccess.CurdBooksProcesses.Implementations;
using Libreria.Db;
using Libreria.Services.BookstoredBooksServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Services.CurdServiceProcesses;
using Libreria.Core.Entities;
namespace PruebaWebApp.ServicesInstances
{
    public static  class BookStoreServicesFactory
    {
        public static  BookCurdServices CreateCurdServices(string connString)
        {
            var Factory = new BookStoreContextFactory(connString);
            var Finder = new EFrameworkBookFinder<BookStoreContext>(Factory.GetContext);
            var FinderCollection = new EFrameworkBookFinderCollection<BookStoreContext>(Factory.GetContext);
            var ManipulatorAdd = new EFrameworkBookManipulator<BookStoreContext>(Factory.GetContext, ManipulatorMetods.Add);
            var ManipulatorUpdate = new EFrameworkBookManipulator<BookStoreContext>(Factory.GetContext, ManipulatorMetods.Update);
            var ManipulatorDelete = new EFrameworkBookManipulator<BookStoreContext>(Factory.GetContext, ManipulatorMetods.Delete);
            var ServiceConfiguration = new BookCurdServiceConfiguration()
            {
                BooksFindProcess = new BookFindServiceProcess<Book>()
                {
                    Find = FinderCollection.FindCollection,
                    FindOne = Finder.Find,
                    FindByFilters = FinderCollection.FindByFilters
                },
                BookManipulatorConfig = new ManipulationProcesses<Book>()
                {
                    Add = ManipulatorAdd.ManipulateBook,
                    Delete = ManipulatorDelete.ManipulateBook,
                    Update = ManipulatorUpdate.ManipulateBook
                }
            };
            var service = new BookCurdServices(ServiceConfiguration);

            return service;
        }
    }
}
