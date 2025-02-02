using bookreview.common.Models;
using Dapper;

namespace bookreview.infrastructure.SQL
{
    public static partial class PublisherSQLQueries
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
            UPDATE Publisher SET @{propertyName} = @Value, 
                        ModifiedDate = GETUTCDATE()
            Where Id = @Id;";
        }
    }
}
