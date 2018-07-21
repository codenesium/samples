using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentEnvironmentModelMapper
        {
                ApiDeploymentEnvironmentResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentEnvironmentRequestModel request);

                ApiDeploymentEnvironmentRequestModel MapResponseToRequest(
                        ApiDeploymentEnvironmentResponseModel response);

                JsonPatchDocument<ApiDeploymentEnvironmentRequestModel> CreatePatch(ApiDeploymentEnvironmentRequestModel model);
        }
}

/*<Codenesium>
    <Hash>98ec5acc310dfd0e2553831be154b5d9</Hash>
</Codenesium>*/