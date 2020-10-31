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
    public class EFrameworkBookFinderCollection<TDbContext> 
        : IBookCollectionFinder
        where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;

        public EFrameworkBookFinderCollection(Func<TDbContext> dbContext)
        {
            this.dbContext = dbContext();
        }

        public async  Task<IEnumerable<Book>> FindByFilters(string title, DateTime? date, decimal? spend, string autor,int? editorial)
        {
            var BookRepo = new BookRepository.BookRepository<TDbContext>(dbContext);

            var Books = await BookRepo.FindByFilters(title, date, spend, autor,editorial);

            return Books;
        }

        public async Task<IEnumerable<Book>> FindCollection(Expression<Func<Book, bool>> Query=null)
        {
            var BookRepo = new EntityFrameworkRepository<Book, TDbContext>(dbContext);
            if(Query == null)
            {
                return await BookRepo.GetAllAsync();
            }
            var Books = await BookRepo.FindManyAsync(Query,null, new Expression<Func<Book, object>>[]{
                x=>x.Editorial
            });

            return Books;
        }

       
    }
}
