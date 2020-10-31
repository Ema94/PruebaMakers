using Libreria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EntityFramework.Component;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.CurdBooksProcesses.Implementations
{
    public class EFrameworkBookFinder<TDbContext> 
        : IBookFinder
        where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;

        public EFrameworkBookFinder(Func<TDbContext> dbContext)
        {
            this.dbContext = dbContext();
        }

        public async Task<Book> Find(Expression<Func<Book, bool>> Query)
        {
            var BookRepo = new EntityFrameworkRepository<Book, TDbContext>(dbContext);
            var Book = await BookRepo.FindOneAsync(Query, new Expression<Func<Book, object>>[]{
                x=>x.Editorial
            });

            return Book;
        }
    }
}
