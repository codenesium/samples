using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiDestinationModelMapper
        {
                public virtual ApiDestinationResponseModel MapRequestToResponse(
                        int id,
                        ApiDestinationRequestModel request)
                {
                        var response = new ApiDestinationResponseModel();
                        response.SetProperties(id,
                                               request.CountryId,
                                               request.Name,
                                               request.Order);
                        return response;
                }

                public virtual ApiDestinationRequestModel MapResponseToRequest(
                        ApiDestinationResponseModel response)
                {
                        var request = new ApiDestinationRequestModel();
                        request.SetProperties(
                                response.CountryId,
                                response.Name,
                                response.Order);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>05c8637bcd967ecc8dfb7ccaab07e52e</Hash>
</Codenesium>*/