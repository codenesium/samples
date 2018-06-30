using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiCountryModelMapper
        {
                public virtual ApiCountryResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequestModel request)
                {
                        var response = new ApiCountryResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiCountryRequestModel MapResponseToRequest(
                        ApiCountryResponseModel response)
                {
                        var request = new ApiCountryRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c696a8582621b91a9725eeacc2521ce1</Hash>
</Codenesium>*/