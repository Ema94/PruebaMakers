using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//Hola, las  validaciones deberian ir en una entidad que valide independiente de esta capa. por cuestiones de tiempo lo introduzco aqui, pero la forma correcta
// seria crear una entidad validadora y una capa de validacion independiente de la capa de servicios.
namespace Libreria.Services.BookstoredBooksServices
{
    public class BookCurdServices : IBookCurdServices
    {
        private readonly IBookCurdServiceConfiguration bookServiceConfiguration;

        public BookCurdServices(IBookCurdServiceConfiguration bookServiceConfiguration)
        {
            this.bookServiceConfiguration = bookServiceConfiguration;
        }

        public async Task<Book> Add(Book book)
        {
            if(book == null)
            {
                throw new Exception("For delete one book this must have a bookId");
            }

            if (book.EditorialId == 0)
            {
                throw new Exception("The EditorialId can't null");
            }

            await bookServiceConfiguration.BookManipulatorConfig.Add(book);
            return book;

        }

        public async Task<Book> Delete(Book book)
        {
            if (book.BookId == 0)
            {
                throw new Exception("For delete one book this must have a bookId"); 
            }
            await bookServiceConfiguration.BookManipulatorConfig.Delete(book);
            return book;
        }

    

        public async Task<Book> FindBooks(Expression<Func<Book, bool>> query)
        {
            return await bookServiceConfiguration.BooksFindProcess.FindOne(query);
        }

        public async Task<IEnumerable<Book>> FindByFilters(string title, DateTime? date, decimal? spend, string autor, int? editorial)
        {
            return await bookServiceConfiguration.BooksFindProcess.FindByFilters(title, date, spend, autor, editorial);
        }

        public async Task<IEnumerable<Book>> FindMany(Expression<Func<Book, bool>> query)
        {
            return await bookServiceConfiguration.BooksFindProcess.Find(query);
        }

        public async Task<Book> Update(Book book)
        {
            if (book.BookId == 0)
            {
                throw new Exception("For update one book this must have a bookId");
            }
          
            await bookServiceConfiguration.BookManipulatorConfig.Update(book);
            return book;
        }
    }
}
