using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0721289e438745b55941b0a0a44a5341</Hash>
</Codenesium>*/