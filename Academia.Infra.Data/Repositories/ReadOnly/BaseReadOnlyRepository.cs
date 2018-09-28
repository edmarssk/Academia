using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.Repositories.ReadOnly
{
    public class BaseReadOnlyRepository
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["AcademiaMvc"].ConnectionString);
            }
        }
    }
}
