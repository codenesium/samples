using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiHandlerModelMapper
        {
                public virtual ApiHandlerResponseModel MapRequestToResponse(
                        int id,
                        ApiHandlerRequestModel request)
                {
                        var response = new ApiHandlerResponseModel();
                        response.SetProperties(id,
                                               request.CountryId,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Phone);
                        return response;
                }

                public virtual ApiHandlerRequestModel MapResponseToRequest(
                        ApiHandlerResponseModel response)
                {
                        var request = new ApiHandlerRequestModel();
                        request.SetProperties(
                                response.CountryId,
                                response.Email,
                                response.FirstName,
                                response.LastName,
                                response.Phone);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c9360b790a7c2b1a776aff4d7067f7f5</Hash>
</Codenesium>*/