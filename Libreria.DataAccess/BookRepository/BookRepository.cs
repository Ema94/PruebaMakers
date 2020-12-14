using Libreria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EntityFramework.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.BookRepository
{
    public class BookRepository<TDbContext> 
        : EntityFrameworkRepository<Book, TDbContext>,IBookRepository
        where TDbContext: DbContext
    {
        public BookRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Book>> FindByFilters(string title,DateTime? date,decimal? spend,string autor,int? editorial)
        {
            IQueryable<Book> queryable = entity.AsQueryable();
            if (title != null)
            {
                queryable = queryable.Where(x => x.Title == title);
            }
            if(date != null)
            {
                queryable = queryable.Where(x => x.Date == date);
            }
            if (spend != null)
            {
                queryable = queryable.Where(x => x.Spend == spend.Value);
            }

            if(autor != null)
            {
                queryable = queryable.Where(x => x.Autor == autor);
            }
            if(editorial != null)
            {
                queryable = queryable.Where(x => x.EditorialId == editorial);
            }

            queryable = queryable.Include(x => x.Editorial);

            queryable = queryable.OrderByDescending(x=>x.BookId);

            return await queryable.ToListAsync();
        }

    }
}
