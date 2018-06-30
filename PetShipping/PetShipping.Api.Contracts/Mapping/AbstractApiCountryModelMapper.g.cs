using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
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
    <Hash>916ef2dac303525619a108b037ddd487</Hash>
</Codenesium>*/