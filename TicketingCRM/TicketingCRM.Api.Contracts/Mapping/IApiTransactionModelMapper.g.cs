using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTransactionModelMapper
        {
                ApiTransactionResponseModel MapRequestToResponse(
                        int id,
                        ApiTransactionRequestModel request);

                ApiTransactionRequestModel MapResponseToRequest(
                        ApiTransactionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1dc6bc0dfc0a02f05f00b4b39dd6f3f0</Hash>
</Codenesium>*/