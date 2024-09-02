using Dapper;
using System.Data;

namespace bookreview.infrastructure.SQL.Author
{
	public static partial class AuthorSQLQueries
	{
		public static DynamicParameters GetByIdParameters(int Id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@Id", Id, DbType.Int32);

			return parameters;
		}

		public static string GetByIdQuery()
		{
			return $@"SELECT * FROM Author Where Id = @Id";
		}
	}
}
