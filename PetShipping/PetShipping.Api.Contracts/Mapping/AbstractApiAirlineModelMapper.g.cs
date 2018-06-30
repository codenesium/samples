using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiAirlineModelMapper
        {
                public virtual ApiAirlineResponseModel MapRequestToResponse(
                        int id,
                        ApiAirlineRequestModel request)
                {
                        var response = new ApiAirlineResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiAirlineRequestModel MapResponseToRequest(
                        ApiAirlineResponseModel response)
                {
                        var request = new ApiAirlineRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c253fbbcc1f30c0f2e880e65294fc784</Hash>
</Codenesium>*/