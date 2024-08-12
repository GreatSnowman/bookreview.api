﻿using atomic.chicken.common.Models;
using Dapper;

namespace atomic.chicken.infrastructure.SQL
{
    public static partial class PublisherSQLQueries
    {
        public static DynamicParameters UpdateParameters(PublisherModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", model.Name);

            return parameters;
        }

        public static string UpdateQuery()
        {
            return $@"INSERT INTO Publisher (Name)
                 OUTPUT INSERTED.Id,
                        INSERTED.Name,
                    VALUES (
                        @Name)";
        }
    }
}