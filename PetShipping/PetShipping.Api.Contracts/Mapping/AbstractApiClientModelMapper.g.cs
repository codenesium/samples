using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiClientModelMapper
        {
                public virtual ApiClientResponseModel MapRequestToResponse(
                        int id,
                        ApiClientRequestModel request)
                {
                        var response = new ApiClientResponseModel();
                        response.SetProperties(id,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Notes,
                                               request.Phone);
                        return response;
                }

                public virtual ApiClientRequestModel MapResponseToRequest(
                        ApiClientResponseModel response)
                {
                        var request = new ApiClientRequestModel();
                        request.SetProperties(
                                response.Email,
                                response.FirstName,
                                response.LastName,
                                response.Notes,
                                response.Phone);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c8ae66536bdcae2282b0d617663eac53</Hash>
</Codenesium>*/