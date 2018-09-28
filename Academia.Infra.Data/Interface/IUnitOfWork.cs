using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void SaveChanges();
    }
}
