using bookreview.common.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
