using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public abstract class AbstractApiPersonRefModelMapper
        {
                public virtual ApiPersonRefResponseModel MapRequestToResponse(
                        int id,
                        ApiPersonRefRequestModel request)
                {
                        var response = new ApiPersonRefResponseModel();
                        response.SetProperties(id,
                                               request.PersonAId,
                                               request.PersonBId);
                        return response;
                }

                public virtual ApiPersonRefRequestModel MapResponseToRequest(
                        ApiPersonRefResponseModel response)
                {
                        var request = new ApiPersonRefRequestModel();
                        request.SetProperties(
                                response.PersonAId,
                                response.PersonBId);
                        return request;
                }

                public JsonPatchDocument<ApiPersonRefRequestModel> CreatePatch(ApiPersonRefRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPersonRefRequestModel>();
                        patch.Replace(x => x.PersonAId, model.PersonAId);
                        patch.Replace(x => x.PersonBId, model.PersonBId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>4cdd6b8a7e4ef113631aec7e111e673f</Hash>
</Codenesium>*/