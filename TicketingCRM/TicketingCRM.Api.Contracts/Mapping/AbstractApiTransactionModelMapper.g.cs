using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiTransactionModelMapper
        {
                public virtual ApiTransactionResponseModel MapRequestToResponse(
                        int id,
                        ApiTransactionRequestModel request)
                {
                        var response = new ApiTransactionResponseModel();
                        response.SetProperties(id,
                                               request.Amount,
                                               request.GatewayConfirmationNumber,
                                               request.TransactionStatusId);
                        return response;
                }

                public virtual ApiTransactionRequestModel MapResponseToRequest(
                        ApiTransactionResponseModel response)
                {
                        var request = new ApiTransactionRequestModel();
                        request.SetProperties(
                                response.Amount,
                                response.GatewayConfirmationNumber,
                                response.TransactionStatusId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>cefe68ad0de20eca112242547de392d3</Hash>
</Codenesium>*/