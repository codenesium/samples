using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiServerTaskModelMapper
        {
                public virtual ApiServerTaskResponseModel MapRequestToResponse(
                        string id,
                        ApiServerTaskRequestModel request)
                {
                        var response = new ApiServerTaskResponseModel();
                        response.SetProperties(id,
                                               request.CompletedTime,
                                               request.ConcurrencyTag,
                                               request.Description,
                                               request.DurationSeconds,
                                               request.EnvironmentId,
                                               request.ErrorMessage,
                                               request.HasPendingInterruptions,
                                               request.HasWarningsOrErrors,
                                               request.JSON,
                                               request.Name,
                                               request.ProjectId,
                                               request.QueueTime,
                                               request.ServerNodeId,
                                               request.StartTime,
                                               request.State,
                                               request.TenantId);
                        return response;
                }

                public virtual ApiServerTaskRequestModel MapResponseToRequest(
                        ApiServerTaskResponseModel response)
                {
                        var request = new ApiServerTaskRequestModel();
                        request.SetProperties(
                                response.CompletedTime,
                                response.ConcurrencyTag,
                                response.Description,
                                response.DurationSeconds,
                                response.EnvironmentId,
                                response.ErrorMessage,
                                response.HasPendingInterruptions,
                                response.HasWarningsOrErrors,
                                response.JSON,
                                response.Name,
                                response.ProjectId,
                                response.QueueTime,
                                response.ServerNodeId,
                                response.StartTime,
                                response.State,
                                response.TenantId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>ba65d278860d84f928e547b74817b2ef</Hash>
</Codenesium>*/