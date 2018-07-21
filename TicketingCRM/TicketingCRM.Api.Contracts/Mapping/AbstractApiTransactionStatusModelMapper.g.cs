using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiTransactionStatusModelMapper
        {
                public virtual ApiTransactionStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiTransactionStatusRequestModel request)
                {
                        var response = new ApiTransactionStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiTransactionStatusRequestModel MapResponseToRequest(
                        ApiTransactionStatusResponseModel response)
                {
                        var request = new ApiTransactionStatusRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }

                public JsonPatchDocument<ApiTransactionStatusRequestModel> CreatePatch(ApiTransactionStatusRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTransactionStatusRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>75b24662fb53a38a26c38c51f30b4d13</Hash>
</Codenesium>*/