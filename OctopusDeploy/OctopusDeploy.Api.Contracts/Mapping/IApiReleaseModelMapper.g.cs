using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiReleaseModelMapper
        {
                ApiReleaseResponseModel MapRequestToResponse(
                        string id,
                        ApiReleaseRequestModel request);

                ApiReleaseRequestModel MapResponseToRequest(
                        ApiReleaseResponseModel response);

                JsonPatchDocument<ApiReleaseRequestModel> CreatePatch(ApiReleaseRequestModel model);
        }
}

/*<Codenesium>
    <Hash>1d96cd8a12825fdc77e1ca7082f541a2</Hash>
</Codenesium>*/