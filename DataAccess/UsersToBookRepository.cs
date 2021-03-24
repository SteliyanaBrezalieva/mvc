using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class UsersToBookRepository : BaseRepository<UserToBook>
    {

        public UsersToBookRepository()

        { }
        //public UsersToBookRepository(UnitOfWork uow) : base(uow) { }
        //protected override IQueryable<UserToBook> CascadeInclude(IQueryable<UserToBook> query)
        //{
        //    return query.Include(utc => utc.ParentBook)
        //                .Include(utc => utc.ParentUser);
        //}

    }
}
