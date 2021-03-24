using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class UsersRepository : BaseRepository<User>
    {

        public UsersRepository()
        {

        }
        //public UsersRepository(UnitOfWork uow) : base(uow) { }

        ////public User GetById(int id)
        //// {
        ////     return Items.Where(i => i.Id == id).FirstOrDefault();
        //// }

        //protected override IQueryable<User> CascadeInclude(IQueryable<Book> query)
        //{
        //    return query.Include(c => c.ParentUser);
        //}
    }
}




    //{
    //    private DbSet<User> Items { get; set; }
    //    private DbContext Context { get; set; }

    //    public UsersRepository()
    //    {
    //        Context = new MyDbContext();
    //        Items = Context.Set<User>();
    //    }
    //    public List<User> GetAll(Expression<Func<User, bool>> filter = null)
    //    {
    //        IQueryable<User> query = Items;
    //        if(filter != null)
    //        {
    //            query = query.Where(filter);
    //        } 
            
    //            return query.ToList();
            
    //    }

    //    public User GetById(int id)
    //    {
    //        return Items
    //                    .Where(i => i.Id == id)
    //                    .FirstOrDefault();
    //    }
    //    public User GetFirstOrDefault(Expression<Func<User, bool>> filter)
    //    {
    //        return Items
    //                    .Where(filter)
    //                    .FirstOrDefault();
    //    }

    //    //public User GetByUsernameAndPassword(string username, string password)
    //    //{
    //    //    return Items.
    //    //                Where(u => u.Username == username &&
    //    //                           u.Password == password)
    //    //                .FirstOrDefault();
        
    //    public void Insert(User item)
    //    {
    //        Items.Add(item);
    //        Context.SaveChanges();
    //    }
    //    public void Save( User item)
    //    {
    //        if(item.Id > 0)
    //        {
    //            Items.Update(item);
    //        }
    //        else
    //        {
    //            Items.Add(item);
    //        }

    //        Context.SaveChanges();
    //    }

    //    public void Delete (User item)
    //    {
    //        Items.Remove(item);
    //        Context.SaveChanges();
    //    }
    // }
