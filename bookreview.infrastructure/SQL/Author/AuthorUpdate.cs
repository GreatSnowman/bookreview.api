using atomic.chicken.common.Models;
using Dapper;
using System.Data;

namespace atomic.chicken.infrastructure.SQL.Author
{
    public static partial class AuthorSQLQueries
	{
        public static DynamicParameters UpdateParameters(AuthorModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", model.Id, DbType.Int64);
            parameters.Add("@Forename", model.Forename, DbType.String);
            parameters.Add("@Surname", model.Surname, DbType.String);
            parameters.Add("@AuthorType", model.AuthorType, DbType.Int16);
            parameters.Add("@DateOfBirth", model.DateOfBirth, DbType.DateTime2);

            return parameters;
        }

        public static string SqlServerUpdate()
        {
            return $@"UPDATE Authors
                    SET
                        Forename = @Forename,
                        Surname = @Surname,
                        AuthorType = @AuthorType,
                        DateOfBirth = @DateOfBirth
                        ModifiedDate = GETUTCDATE()
                 OUTPUT UPDATED.Forename,
                        UPDATED.Surname,
                        UPDATED.AuthorType,
                        UPDATED.DateOfBirth,
                        Where Id = @Id";
        }

        public static string MySqlUpdate()
        {
            return $@"UPDATE Authors
              SET
                  Forename = @Forename,
                  Surname = @Surname,
                  AuthorType = @AuthorType,
                  DateOfBirth = @DateOfBirth,
                  ModifiedDate = UTC_TIMESTAMP()
              WHERE Id = @Id;

              SELECT Forename, Surname, AuthorType, DateOfBirth
              FROM Authors
              WHERE Id = @Id;";
        }
    }
}
