using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiLinkRequestModel> CreatePatch(ApiLinkRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLinkRequestModel>();
                        patch.Replace(x => x.AssignedMachineId, model.AssignedMachineId);
                        patch.Replace(x => x.ChainId, model.ChainId);
                        patch.Replace(x => x.DateCompleted, model.DateCompleted);
                        patch.Replace(x => x.DateStarted, model.DateStarted);
                        patch.Replace(x => x.DynamicParameters, model.DynamicParameters);
                        patch.Replace(x => x.ExternalId, model.ExternalId);
                        patch.Replace(x => x.LinkStatusId, model.LinkStatusId);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.Order, model.Order);
                        patch.Replace(x => x.Response, model.Response);
                        patch.Replace(x => x.StaticParameters, model.StaticParameters);
                        patch.Replace(x => x.TimeoutInSeconds, model.TimeoutInSeconds);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>b65de9a197ab86918ec7ee3a185e9e32</Hash>
</Codenesium>*/