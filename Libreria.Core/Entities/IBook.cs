using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Core.Entities
{
    public interface IBook
    {
        int BookId { get; }
        string Title { get; }
        DateTime Date { get; }
        decimal Spend { get; }
        decimal SugestedPrice { get; }
        string Autor { get; }
        Editorial Editorial { get; }
    }
}
