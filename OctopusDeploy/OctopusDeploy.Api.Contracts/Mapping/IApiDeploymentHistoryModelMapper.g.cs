using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentHistoryModelMapper
        {
                ApiDeploymentHistoryResponseModel MapRequestToResponse(
                        string deploymentId,
                        ApiDeploymentHistoryRequestModel request);

                ApiDeploymentHistoryRequestModel MapResponseToRequest(
                        ApiDeploymentHistoryResponseModel response);

                JsonPatchDocument<ApiDeploymentHistoryRequestModel> CreatePatch(ApiDeploymentHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>99d3fe381173c9aa214e37b0cc235943</Hash>
</Codenesium>*/