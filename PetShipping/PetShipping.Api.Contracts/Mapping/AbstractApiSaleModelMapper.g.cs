using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiSaleModelMapper
        {
                public virtual ApiSaleResponseModel MapRequestToResponse(
                        int id,
                        ApiSaleRequestModel request)
                {
                        var response = new ApiSaleResponseModel();
                        response.SetProperties(id,
                                               request.Amount,
                                               request.ClientId,
                                               request.Note,
                                               request.PetId,
                                               request.SaleDate,
                                               request.SalesPersonId);
                        return response;
                }

                public virtual ApiSaleRequestModel MapResponseToRequest(
                        ApiSaleResponseModel response)
                {
                        var request = new ApiSaleRequestModel();
                        request.SetProperties(
                                response.Amount,
                                response.ClientId,
                                response.Note,
                                response.PetId,
                                response.SaleDate,
                                response.SalesPersonId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>4dc2f7f923c1d12d6fa2218e127f38a4</Hash>
</Codenesium>*/