using Academia.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.Interface
{
    public interface IContextManager
    {
        AcademiaMvcContext GetContext();
    }
}
