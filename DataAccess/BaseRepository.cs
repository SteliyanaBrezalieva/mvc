using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class BaseRepository<T> where T : BaseEntity
    {

        protected DbSet<T> Items { get; set; }
        protected DbContext Context { get; set; }


        public BaseRepository()
        {
            Context = new MyDbContext();
            Items = Context.Set<T>();
        }



        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            //IQueryable<T> query = Items;
            //if (filter != null)
            //{
            //    query = query.Where(filter);
            //}

            return Items.ToList();
            //return query.ToList();

        }

        public T GetById(int id)
        {
            return Items
                        .Where(i => i.Id == id)
                        .FirstOrDefault();
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return Items
                        .Where(filter)
                        .FirstOrDefault();
        }

        //public User GetByUsernameAndPassword(string username, string password)
        //{
        //    return Items.
        //                Where(u => u.Username == username &&
        //                           u.Password == password)
        //                .FirstOrDefault();

        public void Add(T item)
        {
            Items.Add(item);
            Context.SaveChanges();
        }
        //public void Save(T item)
        //{
        //    if (item.Id > 0)
        //    {
        //        Items.Update(item);
        //    }
        //    else
        //    {
        //        Items.Add(item);
        //    }

        //    Context.SaveChanges();
        //}


        public void Update(T item)
        {
            Items.Update(item);
           Context.SaveChanges();
        }

        public void Delete(T item)
        {
            Items.Remove(item);
            Context.SaveChanges();
        }
    }
}

