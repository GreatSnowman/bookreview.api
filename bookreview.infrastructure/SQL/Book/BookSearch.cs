using Dapper;

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
