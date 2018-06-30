using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiSaleModelMapper
        {
                public virtual ApiSaleResponseModel MapRequestToResponse(
                        int id,
                        ApiSaleRequestModel request)
                {
                        var response = new ApiSaleResponseModel();
                        response.SetProperties(id,
                                               request.IpAddress,
                                               request.Notes,
                                               request.SaleDate,
                                               request.TransactionId);
                        return response;
                }

                public virtual ApiSaleRequestModel MapResponseToRequest(
                        ApiSaleResponseModel response)
                {
                        var request = new ApiSaleRequestModel();
                        request.SetProperties(
                                response.IpAddress,
                                response.Notes,
                                response.SaleDate,
                                response.TransactionId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>5386b793130bd682cbe2911ded54bcc7</Hash>
</Codenesium>*/