using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiTeamModelMapper
        {
                public virtual ApiTeamResponseModel MapRequestToResponse(
                        int id,
                        ApiTeamRequestModel request)
                {
                        var response = new ApiTeamResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.OrganizationId);
                        return response;
                }

                public virtual ApiTeamRequestModel MapResponseToRequest(
                        ApiTeamResponseModel response)
                {
                        var request = new ApiTeamRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.OrganizationId);
                        return request;
                }

                public JsonPatchDocument<ApiTeamRequestModel> CreatePatch(ApiTeamRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTeamRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.OrganizationId, model.OrganizationId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>358b9f7f74da54aef465828624c5bfc6</Hash>
</Codenesium>*/