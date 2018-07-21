using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiActionTemplateModelMapper
        {
                public virtual ApiActionTemplateResponseModel MapRequestToResponse(
                        string id,
                        ApiActionTemplateRequestModel request)
                {
                        var response = new ApiActionTemplateResponseModel();
                        response.SetProperties(id,
                                               request.ActionType,
                                               request.CommunityActionTemplateId,
                                               request.JSON,
                                               request.Name,
                                               request.Version);
                        return response;
                }

                public virtual ApiActionTemplateRequestModel MapResponseToRequest(
                        ApiActionTemplateResponseModel response)
                {
                        var request = new ApiActionTemplateRequestModel();
                        request.SetProperties(
                                response.ActionType,
                                response.CommunityActionTemplateId,
                                response.JSON,
                                response.Name,
                                response.Version);
                        return request;
                }

                public JsonPatchDocument<ApiActionTemplateRequestModel> CreatePatch(ApiActionTemplateRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiActionTemplateRequestModel>();
                        patch.Replace(x => x.ActionType, model.ActionType);
                        patch.Replace(x => x.CommunityActionTemplateId, model.CommunityActionTemplateId);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.Version, model.Version);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>03d8e73ac34475aa7ab1e9bd2e4ec1c5</Hash>
</Codenesium>*/