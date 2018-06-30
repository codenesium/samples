using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiSaleTicketsModelMapper
        {
                public virtual ApiSaleTicketsResponseModel MapRequestToResponse(
                        int id,
                        ApiSaleTicketsRequestModel request)
                {
                        var response = new ApiSaleTicketsResponseModel();
                        response.SetProperties(id,
                                               request.SaleId,
                                               request.TicketId);
                        return response;
                }

                public virtual ApiSaleTicketsRequestModel MapResponseToRequest(
                        ApiSaleTicketsResponseModel response)
                {
                        var request = new ApiSaleTicketsRequestModel();
                        request.SetProperties(
                                response.SaleId,
                                response.TicketId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>5b1399143065c9cddd4bbeb410338dfc</Hash>
</Codenesium>*/