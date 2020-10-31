using Libreria.Core.ServiceProceses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Services.CurdServiceProcesses
{
    public class ManipulationProcesses<TEntity> : IManipulationProcesses<TEntity>
    {
        public Func<TEntity, Task<TEntity>> Add { get; set; }

        public Func<TEntity, Task<TEntity>> Update { get; set; }

        public Func<TEntity, Task<TEntity>> Delete { get; set; }
    }
}
