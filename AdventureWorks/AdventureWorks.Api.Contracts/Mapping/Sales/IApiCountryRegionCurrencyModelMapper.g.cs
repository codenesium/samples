using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCountryRegionCurrencyModelMapper
        {
                ApiCountryRegionCurrencyResponseModel MapRequestToResponse(
                        string countryRegionCode,
                        ApiCountryRegionCurrencyRequestModel request);

                ApiCountryRegionCurrencyRequestModel MapResponseToRequest(
                        ApiCountryRegionCurrencyResponseModel response);
        }
}

/*<Codenesium>
    <Hash>897673d66fef616bd3934fefb2ea9676</Hash>
</Codenesium>*/