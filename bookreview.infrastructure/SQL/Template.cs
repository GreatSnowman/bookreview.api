using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.infrastructure.SQL
{
    public static partial class SQLQueries
    {
        public static DynamicParameters AuthorSearchParameter(string criteria)
        {
            var param = new DynamicParameters();
            return param;
        }

        public static string AuthorUpdate()
        {
            return $@"";
        }
    }
}
