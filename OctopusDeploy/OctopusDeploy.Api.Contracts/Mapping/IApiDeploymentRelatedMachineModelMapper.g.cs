using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentRelatedMachineModelMapper
        {
                ApiDeploymentRelatedMachineResponseModel MapRequestToResponse(
                        int id,
                        ApiDeploymentRelatedMachineRequestModel request);

                ApiDeploymentRelatedMachineRequestModel MapResponseToRequest(
                        ApiDeploymentRelatedMachineResponseModel response);
        }
}

/*<Codenesium>
    <Hash>18f3403c1edc0806e42daeef32c03c87</Hash>
</Codenesium>*/