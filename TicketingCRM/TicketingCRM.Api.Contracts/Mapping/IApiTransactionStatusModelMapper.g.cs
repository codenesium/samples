using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTransactionStatusModelMapper
        {
                ApiTransactionStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiTransactionStatusRequestModel request);

                ApiTransactionStatusRequestModel MapResponseToRequest(
                        ApiTransactionStatusResponseModel response);

                JsonPatchDocument<ApiTransactionStatusRequestModel> CreatePatch(ApiTransactionStatusRequestModel model);
        }
}

/*<Codenesium>
    <Hash>ee1fb1ac223a5fdc15ffe76780e1cb82</Hash>
</Codenesium>*/