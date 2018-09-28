using Academia.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace Academia.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorsHandlerPublic());
        }
    }
}
