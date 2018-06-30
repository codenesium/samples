using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDeploymentHistoryModelMapper
        {
                ApiDeploymentHistoryResponseModel MapRequestToResponse(
                        string deploymentId,
                        ApiDeploymentHistoryRequestModel request);

                ApiDeploymentHistoryRequestModel MapResponseToRequest(
                        ApiDeploymentHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>33fdae20e8902e04ed318bce65308c39</Hash>
</Codenesium>*/