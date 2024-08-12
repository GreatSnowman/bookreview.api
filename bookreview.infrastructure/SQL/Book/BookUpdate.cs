using atomic.chicken.common.Models;
using Dapper;

namespace atomic.chicken.infrastructure.SQL
{
    public static partial class BookSqlQueries
    {
        public static DynamicParameters BookUpdateParameters(BookModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", model.Id);
            parameters.Add("@Title", model.Title);
            parameters.Add("@Synopsis", model.Synoposis);
            parameters.Add("@ISBN", model.ISBN);
            parameters.Add("@Year", model.YearPublished);
            parameters.Add("@Publisher", model.Publisher);

            return parameters;
        }

        public static string BookUpdate()
        {
            return $@"UPDATE Books
                    SET
                        Title = @Title,
                        Synopsis = @Synopsis,
                        ISBN = @ISBn,
                        Year = @Year,
                        Publisher = @Publisher)
                 OUTPUT UPDATED.Id,
                        UPDATED.Title,
                        UPDATED.Synopsis,
                        UPDATED.ISBN,
                        UPDATED.Year,
                        UPDATED.Publisher
                        Where Id = @Id";
        }
    }
}
