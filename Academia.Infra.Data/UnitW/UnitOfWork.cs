using Academia.Infra.Data.Context;
using Academia.Infra.Data.Interface;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.UnitW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcademiaMvcContext _context;

        private bool _dispose;

        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;

        public UnitOfWork()
        {
            _context = _contextManager.GetContext();
        }
        public void BeginTransaction()
        {
            _dispose = false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!_dispose)
            {
                if (dispose)
                {
                    _context.Dispose();
                }
            }
            _dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
