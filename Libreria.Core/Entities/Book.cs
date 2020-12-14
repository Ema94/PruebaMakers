using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Core.Entities
{
    public class Book : IBook
    {
        public int BookId{get;set;}

        public string Title{get;set;}

        public DateTime Date{get;set;}

        public decimal Spend{get;set;}

        public decimal SugestedPrice{get;set;}

        public string Autor{get;set;}

        public int EditorialId { get; set; }
        public Editorial Editorial{get;set;}
    }
}
