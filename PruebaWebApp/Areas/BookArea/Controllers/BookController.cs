using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Services.BookstoredBooksServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Libreria.Core.Entities;
using PruebaWebApp.Areas.BookArea.Models;
using PruebaWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace PruebaWebApp.Areas.BookArea.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookCurdServices bookCurdServices;

        public BookController(IBookCurdServices bookCurdServices)
        {
            this.bookCurdServices = bookCurdServices;
        }
        [HttpGet("ByFilters")]
        public async Task<BookCollectionResponse> Get(string title,DateTime? date,string autor,int? editorial,decimal? spend)
        {
            try
            {
                var books = await bookCurdServices.FindByFilters(title, date, spend, autor, editorial);
                //para este caso en un futuro lo refactorizaria y llamaria a una view porque la consulta en una app con muchos datos seria pesada
                //y le agregaria una paginacion
                var response = BookCollectionResponsesFactory.Ok();
                response.Books = books;
                return response;
            }
            catch (Exception e)
            {
                var response = BookCollectionResponsesFactory.Error();
                response.Description = e.Message;
                return response;
            }


        }
        [HttpGet("{ById}")]
        public async Task<BaseBookResponse> Get(int id)
        {
            try
            {
                var book = await bookCurdServices.FindBooks(x=>x.BookId == id);
                var response = BookGetResponseFactory.Ok();
                response.Book = book;
                return response;
            }
            catch (Exception e)
            {
                var response = BookGetResponseFactory.Error();
                response.Description = e.Message;
                return response;
            }


        }
 
        [HttpPost]
        public async Task<BaseApiResponse> Post([FromBody] Book book)
        {
            try
            {
                book.Date = DateTime.Now;
                book = await bookCurdServices.Add(book);
                var response = BookManipulateResponsesFactory.Ok();
                return response;
            }
            catch (Exception e)
            {
                var response = BookManipulateResponsesFactory.Error();
                response.Description = e.Message;
                return response;
            }
        }
        [HttpPut]
        public async Task<BaseApiResponse> Put([FromBody] Book book)
        {
            try
            {
                book = await bookCurdServices.Update(book);
                var response = BookManipulateResponsesFactory.Ok();
                return response;
            }
            catch (Exception e)
            {
                var response = BookManipulateResponsesFactory.Error();
                response.Description = e.Message;
                return response;
            }
        }
        [HttpDelete]
        public async Task<BaseApiResponse> Delete(int bookId)
        {
            try
            {
                var book = await bookCurdServices.FindBooks(x => x.BookId == bookId);
                book = await bookCurdServices.Delete(book);
                var response = BookManipulateResponsesFactory.Ok();
                return response;
            }
            catch (Exception e)
            {
                var response = BookManipulateResponsesFactory.Error();
                response.Description = e.Message;
                return response;
            }
        }
    }
}
