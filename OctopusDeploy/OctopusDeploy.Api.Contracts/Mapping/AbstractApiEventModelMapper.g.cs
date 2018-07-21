using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiEventModelMapper
        {
                public virtual ApiEventResponseModel MapRequestToResponse(
                        string id,
                        ApiEventRequestModel request)
                {
                        var response = new ApiEventResponseModel();
                        response.SetProperties(id,
                                               request.AutoId,
                                               request.Category,
                                               request.EnvironmentId,
                                               request.JSON,
                                               request.Message,
                                               request.Occurred,
                                               request.ProjectId,
                                               request.RelatedDocumentIds,
                                               request.TenantId,
                                               request.UserId,
                                               request.Username);
                        return response;
                }

                public virtual ApiEventRequestModel MapResponseToRequest(
                        ApiEventResponseModel response)
                {
                        var request = new ApiEventRequestModel();
                        request.SetProperties(
                                response.AutoId,
                                response.Category,
                                response.EnvironmentId,
                                response.JSON,
                                response.Message,
                                response.Occurred,
                                response.ProjectId,
                                response.RelatedDocumentIds,
                                response.TenantId,
                                response.UserId,
                                response.Username);
                        return request;
                }

                public JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiEventRequestModel>();
                        patch.Replace(x => x.AutoId, model.AutoId);
                        patch.Replace(x => x.Category, model.Category);
                        patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Message, model.Message);
                        patch.Replace(x => x.Occurred, model.Occurred);
                        patch.Replace(x => x.ProjectId, model.ProjectId);
                        patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
                        patch.Replace(x => x.TenantId, model.TenantId);
                        patch.Replace(x => x.UserId, model.UserId);
                        patch.Replace(x => x.Username, model.Username);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>53a470ec0decb401d2155e0227fec8ee</Hash>
</Codenesium>*/