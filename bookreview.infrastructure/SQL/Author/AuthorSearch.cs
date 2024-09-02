using Dapper;
using System.Data;

namespace bookreview.infrastructure.SQL.Author
{
	public static partial class AuthorSQLQueries
	{
		public static DynamicParameters AuthorSearchParameter(string criteria)
		{
			var param = new DynamicParameters();
			param.Add("@Criteria", DbType.String);

			return param;
		}

		public static string AuthorUpdate()
		{
			return $@"";
		}
	}
}
