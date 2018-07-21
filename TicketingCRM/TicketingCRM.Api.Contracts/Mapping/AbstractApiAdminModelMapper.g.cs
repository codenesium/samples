using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiAdminModelMapper
        {
                public virtual ApiAdminResponseModel MapRequestToResponse(
                        int id,
                        ApiAdminRequestModel request)
                {
                        var response = new ApiAdminResponseModel();
                        response.SetProperties(id,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Password,
                                               request.Phone,
                                               request.Username);
                        return response;
                }

                public virtual ApiAdminRequestModel MapResponseToRequest(
                        ApiAdminResponseModel response)
                {
                        var request = new ApiAdminRequestModel();
                        request.SetProperties(
                                response.Email,
                                response.FirstName,
                                response.LastName,
                                response.Password,
                                response.Phone,
                                response.Username);
                        return request;
                }

                public JsonPatchDocument<ApiAdminRequestModel> CreatePatch(ApiAdminRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiAdminRequestModel>();
                        patch.Replace(x => x.Email, model.Email);
                        patch.Replace(x => x.FirstName, model.FirstName);
                        patch.Replace(x => x.LastName, model.LastName);
                        patch.Replace(x => x.Password, model.Password);
                        patch.Replace(x => x.Phone, model.Phone);
                        patch.Replace(x => x.Username, model.Username);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>9ca4294544dff9d8aa2d3557584c2778</Hash>
</Codenesium>*/