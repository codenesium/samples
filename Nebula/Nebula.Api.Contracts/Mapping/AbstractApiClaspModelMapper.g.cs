using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiClaspModelMapper
        {
                public virtual ApiClaspResponseModel MapRequestToResponse(
                        int id,
                        ApiClaspRequestModel request)
                {
                        var response = new ApiClaspResponseModel();
                        response.SetProperties(id,
                                               request.NextChainId,
                                               request.PreviousChainId);
                        return response;
                }

                public virtual ApiClaspRequestModel MapResponseToRequest(
                        ApiClaspResponseModel response)
                {
                        var request = new ApiClaspRequestModel();
                        request.SetProperties(
                                response.NextChainId,
                                response.PreviousChainId);
                        return request;
                }

                public JsonPatchDocument<ApiClaspRequestModel> CreatePatch(ApiClaspRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiClaspRequestModel>();
                        patch.Replace(x => x.NextChainId, model.NextChainId);
                        patch.Replace(x => x.PreviousChainId, model.PreviousChainId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>6106a29cd1506ab584dc40debe2c7cd1</Hash>
</Codenesium>*/