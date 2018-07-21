using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiPostHistoryTypesModelMapper
        {
                public virtual ApiPostHistoryTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiPostHistoryTypesRequestModel request)
                {
                        var response = new ApiPostHistoryTypesResponseModel();
                        response.SetProperties(id,
                                               request.Type);
                        return response;
                }

                public virtual ApiPostHistoryTypesRequestModel MapResponseToRequest(
                        ApiPostHistoryTypesResponseModel response)
                {
                        var request = new ApiPostHistoryTypesRequestModel();
                        request.SetProperties(
                                response.Type);
                        return request;
                }

                public JsonPatchDocument<ApiPostHistoryTypesRequestModel> CreatePatch(ApiPostHistoryTypesRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPostHistoryTypesRequestModel>();
                        patch.Replace(x => x.Type, model.Type);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>915cb2c2f9120a057e72049e965e3c0b</Hash>
</Codenesium>*/