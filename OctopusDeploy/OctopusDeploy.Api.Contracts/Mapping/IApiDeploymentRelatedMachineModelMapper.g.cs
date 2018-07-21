using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentRelatedMachineModelMapper
        {
                ApiDeploymentRelatedMachineResponseModel MapRequestToResponse(
                        int id,
                        ApiDeploymentRelatedMachineRequestModel request);

                ApiDeploymentRelatedMachineRequestModel MapResponseToRequest(
                        ApiDeploymentRelatedMachineResponseModel response);

                JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel> CreatePatch(ApiDeploymentRelatedMachineRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b0e4ce0e9f2561d56ee8286f07209025</Hash>
</Codenesium>*/