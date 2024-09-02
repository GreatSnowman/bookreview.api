using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.infrastructure.SQL.Book
{
    public static partial class BookSqlQueries
    {
        public static DynamicParameters SearchParameters()
        {
           var parameters = new DynamicParameters();
            return parameters;
        }

        public static string SearchQu()
        {
            return $@"SELECT * FROM Book";
        }
    }
}
