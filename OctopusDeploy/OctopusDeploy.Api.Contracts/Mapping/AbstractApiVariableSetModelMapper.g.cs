using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiVariableSetModelMapper
        {
                public virtual ApiVariableSetResponseModel MapRequestToResponse(
                        string id,
                        ApiVariableSetRequestModel request)
                {
                        var response = new ApiVariableSetResponseModel();
                        response.SetProperties(id,
                                               request.IsFrozen,
                                               request.JSON,
                                               request.OwnerId,
                                               request.RelatedDocumentIds,
                                               request.Version);
                        return response;
                }

                public virtual ApiVariableSetRequestModel MapResponseToRequest(
                        ApiVariableSetResponseModel response)
                {
                        var request = new ApiVariableSetRequestModel();
                        request.SetProperties(
                                response.IsFrozen,
                                response.JSON,
                                response.OwnerId,
                                response.RelatedDocumentIds,
                                response.Version);
                        return request;
                }

                public JsonPatchDocument<ApiVariableSetRequestModel> CreatePatch(ApiVariableSetRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiVariableSetRequestModel>();
                        patch.Replace(x => x.IsFrozen, model.IsFrozen);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.OwnerId, model.OwnerId);
                        patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
                        patch.Replace(x => x.Version, model.Version);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>67a0a609a2922628d4b573d6225956ab</Hash>
</Codenesium>*/