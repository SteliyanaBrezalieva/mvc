using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository()

        { }

        //public BookRepository(UnitOfWork uow) : base(uow) { }
        ////public Book GetById(int id)
        ////{
        ////    return Items.Where(i => i.Id == id).FirstOrDefault();
        ////}

        //protected override IQueryable<Book> CascadeInclude(IQueryable<Book> query)
        //{
        //    return query.Include(c => c.ParentUser);
        //}
    }
}
