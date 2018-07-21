using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
        public abstract class AbstractApiFileTypeModelMapper
        {
                public virtual ApiFileTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiFileTypeRequestModel request)
                {
                        var response = new ApiFileTypeResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiFileTypeRequestModel MapResponseToRequest(
                        ApiFileTypeResponseModel response)
                {
                        var request = new ApiFileTypeRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }

                public JsonPatchDocument<ApiFileTypeRequestModel> CreatePatch(ApiFileTypeRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiFileTypeRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>b32fab27190d990ab2c3fdd838b67b9d</Hash>
</Codenesium>*/