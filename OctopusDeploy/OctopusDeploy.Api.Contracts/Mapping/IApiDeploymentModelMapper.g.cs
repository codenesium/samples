using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentModelMapper
        {
                ApiDeploymentResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentRequestModel request);

                ApiDeploymentRequestModel MapResponseToRequest(
                        ApiDeploymentResponseModel response);

                JsonPatchDocument<ApiDeploymentRequestModel> CreatePatch(ApiDeploymentRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d90e8b21dd48d5b9490d04a1c34809f0</Hash>
</Codenesium>*/