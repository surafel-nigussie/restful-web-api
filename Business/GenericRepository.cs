using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;
using System.Data.SqlClient;
using Entity;
using System.Data;

namespace Business
{
    public  class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {

        private WebAPI_ModelContainer _entities;

        public GenericRepository(WebAPI_ModelContainer entities)
        {
            _entities = entities;
        }

        public WebAPI_ModelContainer Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public virtual IQueryable<T> GetAll(int start, int count)
        {

            IQueryable<T> query = _entities.Set<T>().Skip(start).Take(count);
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void AddRange(List<T> entities)
        {
            _entities.Set<T>().AddRange(entities);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public virtual bool HasChanges(T entity)
        {
            WebAPI_ModelContainer ctxt = (WebAPI_ModelContainer)Context;
            return ctxt.ChangeTracker.HasChanges();
        }

        public virtual IEnumerable<T> GetWithRawSql(int ID, string FName)
        {
            var result = Context.Database.SqlQuery<T>(
                                                        "EXEC MySchema.MyProcedure @MyID, @MyFirstName",
                                                        new SqlParameter("MyID", SqlDbType.Int) { Value = Convert.ToInt32(ID) } ,
                                                        new SqlParameter("MyFirstName", SqlDbType.NVarChar) { Value = Convert.ToString(FName) }
                                                    ).ToList();
            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Context != null)
                    {
                        Context.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GenericRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
