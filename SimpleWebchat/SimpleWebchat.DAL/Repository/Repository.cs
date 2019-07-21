using SimpleWebchat.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SimpleWebchatContext Context;

        public Repository(SimpleWebchatContext context)
        {
            Context = context;
        }
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
        public TEntity FirstOrDefault()
        {
            return Context.Set<TEntity>().FirstOrDefault();
        }
        public TEntity Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            SaveChanges();

            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            SaveChanges();

            return entity;
        }
        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            SaveChanges();
        }
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> tempEntityList = Context.Set<TEntity>().Where(predicate);

            foreach (var entityItem in tempEntityList)
                Context.Set<TEntity>().Remove(entityItem);

            SaveChanges();
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }
        private bool SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }

                throw raise;
            }
            catch (Exception)
            {

            }

            return true;
        }
    }
}
