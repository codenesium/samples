using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>76ae46ea85282d32912f5c415924b828</Hash>
</Codenesium>*/