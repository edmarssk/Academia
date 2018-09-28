using Academia.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Academia.Infra.Data.Context;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using Academia.Infra.Data.Interface;

namespace Academia.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;

        protected AcademiaMvcContext _context;

        public DbSet<TEntity> DbSet;


        public BaseRepository()
        {
            try
            {
                _context = _contextManager.GetContext();
                DbSet = _context.Set<TEntity>();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public virtual void Add(TEntity obj)
        {
            try
            {
                DbSet.Add(obj);
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return DbSet.ToList();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public virtual void Update(TEntity obj)
        {
            try
            {
                var entry = _context.Entry(obj);
                DbSet.Attach(obj);
                entry.State = EntityState.Modified;

               
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public virtual void Remove(TEntity obj)
        {
            try
            {
                DbSet.Remove(obj);
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public virtual IEnumerable<TEntity> find(Expression<Func<TEntity, bool>> Predicate)
        {
            try
            {
                return DbSet.Where(Predicate);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            // O GC é o gestor de lixo do dot net, ele verifica se a classe está sem utilização, assim, exclui da memoria.
            GC.SuppressFinalize(this);
        }

    }
}
