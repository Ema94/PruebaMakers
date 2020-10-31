using Libreria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EntityFramework.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.CurdBooksProcesses.Implementations
{
    public class EFrameworkBookManipulator<TDbContext>
        : IBookManipulator
        where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;
        private readonly int manipulationMethod;
        private readonly Dictionary<int, Func<Book, Task<Book>>> Methods;
        private IEntityFrameworkRepository<Book, TDbContext> entityFrameworkRepository;
        public EFrameworkBookManipulator(Func<TDbContext> dbContext, int manipulationMethod)
        {
            this.dbContext = dbContext();
            this.manipulationMethod = manipulationMethod;
            this.entityFrameworkRepository = new EntityFrameworkRepository<Book, TDbContext>(this.dbContext);

            this.Methods = new Dictionary<int, Func<Book, Task<Book>>>()
            {
                {ManipulatorMetods.Add,entityFrameworkRepository.AddAsync },
                {ManipulatorMetods.Update,entityFrameworkRepository.UpdateAsync },
                {ManipulatorMetods.Delete,entityFrameworkRepository.DeleteAsync }
            };
        }

        public async  Task<Book> ManipulateBook(Book book)
        {
            var method = Methods.FirstOrDefault(x => x.Key == manipulationMethod);
           
            var bookManipulate = await method.Value(book);

            return bookManipulate;
        }
    }
}
