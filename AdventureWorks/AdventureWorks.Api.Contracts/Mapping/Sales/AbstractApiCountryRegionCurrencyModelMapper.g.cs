using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCountryRegionCurrencyModelMapper
        {
                public virtual ApiCountryRegionCurrencyResponseModel MapRequestToResponse(
                        string countryRegionCode,
                        ApiCountryRegionCurrencyRequestModel request)
                {
                        var response = new ApiCountryRegionCurrencyResponseModel();
                        response.SetProperties(countryRegionCode,
                                               request.CurrencyCode,
                                               request.ModifiedDate);
                        return response;
                }

                public virtual ApiCountryRegionCurrencyRequestModel MapResponseToRequest(
                        ApiCountryRegionCurrencyResponseModel response)
                {
                        var request = new ApiCountryRegionCurrencyRequestModel();
                        request.SetProperties(
                                response.CurrencyCode,
                                response.ModifiedDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>ab7d2058b1384e437f38214f99376474</Hash>
</Codenesium>*/