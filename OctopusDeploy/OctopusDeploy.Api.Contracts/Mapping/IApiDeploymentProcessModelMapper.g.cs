using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentProcessModelMapper
        {
                ApiDeploymentProcessResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentProcessRequestModel request);

                ApiDeploymentProcessRequestModel MapResponseToRequest(
                        ApiDeploymentProcessResponseModel response);

                JsonPatchDocument<ApiDeploymentProcessRequestModel> CreatePatch(ApiDeploymentProcessRequestModel model);
        }
}

/*<Codenesium>
    <Hash>9d5c02d30049347a03b3421229fd0e15</Hash>
</Codenesium>*/