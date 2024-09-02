using bookreview.common.Models;
using Dapper;

namespace bookreview.infrastructure.SQL
{
    public static partial class PublisherSQLQueries
    {
        public static DynamicParameters InsertParameters(PublisherModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", model.Name);

            return parameters;
        }

        public static string InsertQuery()
        {
            return $@"INSERT INTO Publisher (Name)
                 OUTPUT INSERTED.Id,
                        INSERTED.Name,
                    VALUES (
                        @Name)";
        }
    }
}
