using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLDatabaseLogMapper
        {
                BODatabaseLog MapModelToBO(
                        int databaseLogID,
                        ApiDatabaseLogRequestModel model);

                ApiDatabaseLogResponseModel MapBOToModel(
                        BODatabaseLog boDatabaseLog);

                List<ApiDatabaseLogResponseModel> MapBOToModel(
                        List<BODatabaseLog> items);
        }
}

/*<Codenesium>
    <Hash>6bbd4f239aa9a0525ba1fc9d92800716</Hash>
</Codenesium>*/