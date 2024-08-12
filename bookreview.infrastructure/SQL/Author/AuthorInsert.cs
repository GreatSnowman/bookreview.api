using atomic.chicken.common.Models;
using Dapper;
using System.Data;

namespace atomic.chicken.infrastructure.SQL.Author
{
    public static partial class AuthorSQLQueries
	{
        public static DynamicParameters InsertParameters(AuthorModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Forename", model.Forename, DbType.String);
            parameters.Add("@Surname", model.Surname, DbType.String);
            parameters.Add("@AuthorType", model.AuthorType, DbType.Int32);
            parameters.Add("@DateOfBirth", model.DateOfBirth, DbType.DateTime2);

            return parameters;
        }

        public static string Insert()
        {
            return $@"INSERT INTO [dbo].[Authors] 
                       (Forename,
                        Surname,
                        AuthorType,
                        DateOfBirth)
                 OUTPUT INSERTED.Id,
                        INSERTED.Forename,
                        INSERTED.Surname,
                        INSERTED.AuthorType,
                        INSERTED.DateOfBirth
                    VALUES (
                        @Forename,
                        @Surname,
                        @AuthorType,
                        @DateOfBirth);";
        }
    }
}
