using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTransactionModelMapper
        {
                ApiTransactionResponseModel MapRequestToResponse(
                        int id,
                        ApiTransactionRequestModel request);

                ApiTransactionRequestModel MapResponseToRequest(
                        ApiTransactionResponseModel response);

                JsonPatchDocument<ApiTransactionRequestModel> CreatePatch(ApiTransactionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e6aa3213a73fb97e35ec08165dc5ba28</Hash>
</Codenesium>*/