using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTransactionStatusModelMapper
        {
                ApiTransactionStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiTransactionStatusRequestModel request);

                ApiTransactionStatusRequestModel MapResponseToRequest(
                        ApiTransactionStatusResponseModel response);
        }
}

/*<Codenesium>
    <Hash>f5855e3a9f7ad7ce7d6f507cf20f9fc4</Hash>
</Codenesium>*/