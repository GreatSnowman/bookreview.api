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
            parameters.Add("@Publisher", model.Publisher);

            return parameters;
        }

        public static string BookInsert()
        {
            return $@"INSERT INTO Books (
                        Title,
                        Synopsis,
                        ISBN,
                        Year,
                        Publisher)
                 OUTPUT INSERTED.Id,
                        INSERTED.Title,
                        INSERTED.Synopsis,
                        INSERTED.ISBN,
                        INSERTED.Year,
                        INSERTED.Publisher
                    VALUES (
                        @Title,
                        @Synopsis,
                        @ISBN,
                        @Year,
                        @Publisher)";
        }
    }
}
