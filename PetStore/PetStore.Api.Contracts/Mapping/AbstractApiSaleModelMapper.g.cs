using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
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
                                               request.FirstName,
                                               request.LastName,
                                               request.PaymentTypeId,
                                               request.PetId,
                                               request.Phone);
                        return response;
                }

                public virtual ApiSaleRequestModel MapResponseToRequest(
                        ApiSaleResponseModel response)
                {
                        var request = new ApiSaleRequestModel();
                        request.SetProperties(
                                response.Amount,
                                response.FirstName,
                                response.LastName,
                                response.PaymentTypeId,
                                response.PetId,
                                response.Phone);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>223dbdb164795cc4becc1202b80344f4</Hash>
</Codenesium>*/