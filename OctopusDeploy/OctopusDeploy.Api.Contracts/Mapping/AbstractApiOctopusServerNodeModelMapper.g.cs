using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiOctopusServerNodeModelMapper
        {
                public virtual ApiOctopusServerNodeResponseModel MapRequestToResponse(
                        string id,
                        ApiOctopusServerNodeRequestModel request)
                {
                        var response = new ApiOctopusServerNodeResponseModel();
                        response.SetProperties(id,
                                               request.IsInMaintenanceMode,
                                               request.JSON,
                                               request.LastSeen,
                                               request.MaxConcurrentTasks,
                                               request.Name,
                                               request.Rank);
                        return response;
                }

                public virtual ApiOctopusServerNodeRequestModel MapResponseToRequest(
                        ApiOctopusServerNodeResponseModel response)
                {
                        var request = new ApiOctopusServerNodeRequestModel();
                        request.SetProperties(
                                response.IsInMaintenanceMode,
                                response.JSON,
                                response.LastSeen,
                                response.MaxConcurrentTasks,
                                response.Name,
                                response.Rank);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f2e08b58ad1c4912d4e33e7c14550918</Hash>
</Codenesium>*/