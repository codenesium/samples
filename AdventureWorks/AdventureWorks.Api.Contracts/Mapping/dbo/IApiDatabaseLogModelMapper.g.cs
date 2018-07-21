using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiDatabaseLogModelMapper
        {
                ApiDatabaseLogResponseModel MapRequestToResponse(
                        int databaseLogID,
                        ApiDatabaseLogRequestModel request);

                ApiDatabaseLogRequestModel MapResponseToRequest(
                        ApiDatabaseLogResponseModel response);

                JsonPatchDocument<ApiDatabaseLogRequestModel> CreatePatch(ApiDatabaseLogRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c3d284d38b3da7f1fc2c744f1160f51d</Hash>
</Codenesium>*/