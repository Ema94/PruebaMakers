using Libreria.Core.Entities;
using Libreria.Core.ServiceProceses.LibrosFindProcess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Core.BookServicesProcess
{
    public interface IBookFindServiceProcess : FinderProcess<Book>
    {
        Func<string, DateTime?, decimal?, string, int?, Task<IEnumerable<Book>>> FindByFilters { get; }
    }
}
