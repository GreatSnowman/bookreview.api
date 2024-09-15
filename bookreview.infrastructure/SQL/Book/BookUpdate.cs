using bookreview.common.Models;
using Dapper;

namespace bookreview.infrastructure.SQL
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
            parameters.Add("@PublisherId", model.PublisherId);

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
                        PublisherId = @PublisherId)
                 OUTPUT UPDATED.Id,
                        UPDATED.Title,
                        UPDATED.Synopsis,
                        UPDATED.ISBN,
                        UPDATED.Year,
                        UPDATED.PublisherId
                        Where Id = @Id";
        }
    }
}
