using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiCommentsModelMapper
        {
                public virtual ApiCommentsResponseModel MapRequestToResponse(
                        int id,
                        ApiCommentsRequestModel request)
                {
                        var response = new ApiCommentsResponseModel();
                        response.SetProperties(id,
                                               request.CreationDate,
                                               request.PostId,
                                               request.Score,
                                               request.Text,
                                               request.UserId);
                        return response;
                }

                public virtual ApiCommentsRequestModel MapResponseToRequest(
                        ApiCommentsResponseModel response)
                {
                        var request = new ApiCommentsRequestModel();
                        request.SetProperties(
                                response.CreationDate,
                                response.PostId,
                                response.Score,
                                response.Text,
                                response.UserId);
                        return request;
                }

                public JsonPatchDocument<ApiCommentsRequestModel> CreatePatch(ApiCommentsRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiCommentsRequestModel>();
                        patch.Replace(x => x.CreationDate, model.CreationDate);
                        patch.Replace(x => x.PostId, model.PostId);
                        patch.Replace(x => x.Score, model.Score);
                        patch.Replace(x => x.Text, model.Text);
                        patch.Replace(x => x.UserId, model.UserId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>7345d238ada1d124f45b25598d79923c</Hash>
</Codenesium>*/