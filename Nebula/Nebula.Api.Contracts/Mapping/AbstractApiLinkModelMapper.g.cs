using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiLinkModelMapper
        {
                public virtual ApiLinkResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkRequestModel request)
                {
                        var response = new ApiLinkResponseModel();
                        response.SetProperties(id,
                                               request.AssignedMachineId,
                                               request.ChainId,
                                               request.DateCompleted,
                                               request.DateStarted,
                                               request.DynamicParameters,
                                               request.ExternalId,
                                               request.LinkStatusId,
                                               request.Name,
                                               request.Order,
                                               request.Response,
                                               request.StaticParameters,
                                               request.TimeoutInSeconds);
                        return response;
                }

                public virtual ApiLinkRequestModel MapResponseToRequest(
                        ApiLinkResponseModel response)
                {
                        var request = new ApiLinkRequestModel();
                        request.SetProperties(
                                response.AssignedMachineId,
                                response.ChainId,
                                response.DateCompleted,
                                response.DateStarted,
                                response.DynamicParameters,
                                response.ExternalId,
                                response.LinkStatusId,
                                response.Name,
                                response.Order,
                                response.Response,
                                response.StaticParameters,
                                response.TimeoutInSeconds);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>fd9f694c3057e3ee72c84ae49e7fad21</Hash>
</Codenesium>*/