using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCountryRegionModelMapper
        {
                public virtual ApiCountryRegionResponseModel MapRequestToResponse(
                        string countryRegionCode,
                        ApiCountryRegionRequestModel request)
                {
                        var response = new ApiCountryRegionResponseModel();
                        response.SetProperties(countryRegionCode,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiCountryRegionRequestModel MapResponseToRequest(
                        ApiCountryRegionResponseModel response)
                {
                        var request = new ApiCountryRegionRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>911984271774dfe94e062faea4023c12</Hash>
</Codenesium>*/