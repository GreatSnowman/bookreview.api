using Dapper;

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
