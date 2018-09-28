using Academia.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Academia.Infra.Data.Context
{
    public class ContextManager : IContextManager
    {

        private const string contextKey = "ContextManager.Context";

        public AcademiaMvcContext GetContext()
        {
            if (HttpContext.Current.Items[contextKey] == null)
            {
                HttpContext.Current.Items[contextKey] = new AcademiaMvcContext();
            }

            return (AcademiaMvcContext)HttpContext.Current.Items[contextKey];
        }
    }
}
