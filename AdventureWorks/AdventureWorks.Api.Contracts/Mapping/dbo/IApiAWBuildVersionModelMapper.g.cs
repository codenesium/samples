using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiAWBuildVersionModelMapper
        {
                ApiAWBuildVersionResponseModel MapRequestToResponse(
                        int systemInformationID,
                        ApiAWBuildVersionRequestModel request);

                ApiAWBuildVersionRequestModel MapResponseToRequest(
                        ApiAWBuildVersionResponseModel response);

                JsonPatchDocument<ApiAWBuildVersionRequestModel> CreatePatch(ApiAWBuildVersionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>048cb6d83a0ba82dbe17a97d78b33f5b</Hash>
</Codenesium>*/