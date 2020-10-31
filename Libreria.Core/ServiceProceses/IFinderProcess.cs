using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Core.ServiceProceses.LibrosFindProcess
{
    public interface FinderProcess<TEntity>
    {
        Func<Expression<Func<TEntity, bool>>, Task<IEnumerable<TEntity>>> Find { get;}
        Func<Expression<Func<TEntity, bool>>, Task<TEntity>> FindOne { get;}
    }
}
