using Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Core.ServiceProceses
{
    public interface IManipulationProcesses<TEntity>
    { 
        Func<TEntity, Task<TEntity>> Add { get;}
        Func<TEntity, Task<TEntity>> Update { get;}
        Func<TEntity, Task<TEntity>> Delete { get;}
    }
}
