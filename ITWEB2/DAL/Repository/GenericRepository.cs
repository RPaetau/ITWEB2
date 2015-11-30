﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal Context context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(Context context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The code Expression<Func<TEntity, bool>> filter means the caller will provide a lambda expression based on the TEntity type,
        ///  and this expression will return a Boolean value. 
        /// For example, if the repository is instantiated for the Student entity type, 
        /// the code in the calling method might specify student => student.LastName == "Smith" for the filter parameter.
        /// 
        /// The code Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy also means the caller will provide a lambda expression. 
        /// But in this case, the input to the expression is an IQueryable object for the TEntity type. 
        /// The expression will return an ordered version of that IQueryable object. 
        /// For example, if the repository is instantiated for the Student entity type, 
        /// the code in the calling method might specify q => q.OrderBy(s => s.LastName) for the orderBy parameter.
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges(); // Skal tilføjes her da der ikker oprettet en "Unit of Work" klasse

        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            context.SaveChanges(); // Skal tilføjes her da der ikker oprettet en "Unit of Work" klasse
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges(); // Skal tilføjes her da der ikker oprettet en "Unit of Work" klasse
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges(); // Skal tilføjes her da der ikker oprettet en "Unit of Work" klasse
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}