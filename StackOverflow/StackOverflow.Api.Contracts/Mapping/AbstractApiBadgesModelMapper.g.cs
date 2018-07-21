using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiBadgesModelMapper
        {
                public virtual ApiBadgesResponseModel MapRequestToResponse(
                        int id,
                        ApiBadgesRequestModel request)
                {
                        var response = new ApiBadgesResponseModel();
                        response.SetProperties(id,
                                               request.Date,
                                               request.Name,
                                               request.UserId);
                        return response;
                }

                public virtual ApiBadgesRequestModel MapResponseToRequest(
                        ApiBadgesResponseModel response)
                {
                        var request = new ApiBadgesRequestModel();
                        request.SetProperties(
                                response.Date,
                                response.Name,
                                response.UserId);
                        return request;
                }

                public JsonPatchDocument<ApiBadgesRequestModel> CreatePatch(ApiBadgesRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiBadgesRequestModel>();
                        patch.Replace(x => x.Date, model.Date);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.UserId, model.UserId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>9a9e572f5979855ac9399eb72b33e17f</Hash>
</Codenesium>*/