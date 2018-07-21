using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCountryRegionCurrencyModelMapper
        {
                ApiCountryRegionCurrencyResponseModel MapRequestToResponse(
                        string countryRegionCode,
                        ApiCountryRegionCurrencyRequestModel request);

                ApiCountryRegionCurrencyRequestModel MapResponseToRequest(
                        ApiCountryRegionCurrencyResponseModel response);

                JsonPatchDocument<ApiCountryRegionCurrencyRequestModel> CreatePatch(ApiCountryRegionCurrencyRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d8a9751666371fd8445d8c8e4d68a73f</Hash>
</Codenesium>*/