using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Core.Entities;
using PruebaWebApp.Models;

namespace PruebaWebApp.Areas.BookArea.Models
{
    public class BaseBookResponse : BaseApiResponse
    {
        public Book Book { get; set; }
    }
    public class BookCollectionResponse : BaseApiResponse
    {
        public IEnumerable<Book> Books { get; set; }
    }

}
