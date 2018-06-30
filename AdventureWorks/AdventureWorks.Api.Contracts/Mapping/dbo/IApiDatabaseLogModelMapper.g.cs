using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiDatabaseLogModelMapper
        {
                ApiDatabaseLogResponseModel MapRequestToResponse(
                        int databaseLogID,
                        ApiDatabaseLogRequestModel request);

                ApiDatabaseLogRequestModel MapResponseToRequest(
                        ApiDatabaseLogResponseModel response);
        }
}

/*<Codenesium>
    <Hash>85d6c5bafe27994097ba993067cecca8</Hash>
</Codenesium>*/