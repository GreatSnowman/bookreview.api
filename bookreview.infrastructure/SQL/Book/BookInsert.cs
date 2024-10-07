using bookreview.common.Models;
using Dapper;

namespace bookreview.infrastructure.SQL
{
    public static partial class BookSqlQueries
    {
        public static DynamicParameters BookInsertParameters(BookModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Title", model.Title);
            parameters.Add("@Synopsis", model.Synoposis);
            parameters.Add("@ISBN", model.ISBN);
            parameters.Add("@Year", model.YearPublished);
            parameters.Add("@PublisherId", model.PublisherId);

            return parameters;
        }

        public static string BookInsert()
        {
            return $@"INSERT INTO Books (
                        Title,
                        Synopsis,
                        ISBN,
                        Year,
                        PublisherId)
                 OUTPUT INSERTED.Id
                    VALUES (
                        @Title,
                        @Synopsis,
                        @ISBN,
                        @Year,
                        @PublisherId)";
        }
    }
}
