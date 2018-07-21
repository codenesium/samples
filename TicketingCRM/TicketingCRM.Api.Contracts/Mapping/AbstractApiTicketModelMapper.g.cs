using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiTicketModelMapper
        {
                public virtual ApiTicketResponseModel MapRequestToResponse(
                        int id,
                        ApiTicketRequestModel request)
                {
                        var response = new ApiTicketResponseModel();
                        response.SetProperties(id,
                                               request.PublicId,
                                               request.TicketStatusId);
                        return response;
                }

                public virtual ApiTicketRequestModel MapResponseToRequest(
                        ApiTicketResponseModel response)
                {
                        var request = new ApiTicketRequestModel();
                        request.SetProperties(
                                response.PublicId,
                                response.TicketStatusId);
                        return request;
                }

                public JsonPatchDocument<ApiTicketRequestModel> CreatePatch(ApiTicketRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTicketRequestModel>();
                        patch.Replace(x => x.PublicId, model.PublicId);
                        patch.Replace(x => x.TicketStatusId, model.TicketStatusId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>9b6f55a01a865f1ecc539cdd5f085662</Hash>
</Codenesium>*/