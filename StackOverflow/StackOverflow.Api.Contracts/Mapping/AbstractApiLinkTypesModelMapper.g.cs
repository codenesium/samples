using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiLinkTypesModelMapper
        {
                public virtual ApiLinkTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkTypesRequestModel request)
                {
                        var response = new ApiLinkTypesResponseModel();
                        response.SetProperties(id,
                                               request.Type);
                        return response;
                }

                public virtual ApiLinkTypesRequestModel MapResponseToRequest(
                        ApiLinkTypesResponseModel response)
                {
                        var request = new ApiLinkTypesRequestModel();
                        request.SetProperties(
                                response.Type);
                        return request;
                }

                public JsonPatchDocument<ApiLinkTypesRequestModel> CreatePatch(ApiLinkTypesRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLinkTypesRequestModel>();
                        patch.Replace(x => x.Type, model.Type);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>48d0f7a650eda19e4f3d8cc6274c3828</Hash>
</Codenesium>*/