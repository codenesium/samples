using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public abstract class AbstractApiPersonModelMapper
        {
                public virtual ApiPersonResponseModel MapRequestToResponse(
                        int personId,
                        ApiPersonRequestModel request)
                {
                        var response = new ApiPersonResponseModel();
                        response.SetProperties(personId,
                                               request.PersonName);
                        return response;
                }

                public virtual ApiPersonRequestModel MapResponseToRequest(
                        ApiPersonResponseModel response)
                {
                        var request = new ApiPersonRequestModel();
                        request.SetProperties(
                                response.PersonName);
                        return request;
                }

                public JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPersonRequestModel>();
                        patch.Replace(x => x.PersonName, model.PersonName);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>9b28bd6ee4f2dbd2f47039a21d15103f</Hash>
</Codenesium>*/