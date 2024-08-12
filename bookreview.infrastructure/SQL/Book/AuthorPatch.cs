using atomic.chicken.common.Models;
using Dapper;

namespace atomic.chicken.infrastructure.SQL.Book
{
    public static partial class BookSlQueries
	{
        public static DynamicParameters PatchParameter(PatchModel model)
        {
            var param = new DynamicParameters();
            param.Add("@Value", model.PropertyValue);
            param.Add("@Id", model.Id);

            return param;
        }

        public static string PatchQuery(string propertyName)
        {
            return $@"
            UPDATE Author SET @{propertyName} = @Value, 
                        ModifiedDate = GETUTCDATE()
            Where Id = @Id;";
        }

        public static string PatchQueryMySql(string propertyName)
        {
            return $@"
                UPDATE Author SET {propertyName} = @Value, 
                            ModifiedDate = UTC_TIMESTAMP()
                WHERE Id = @Id;";
        }
    }
}
