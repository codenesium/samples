using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCountryRegionModelMapper
        {
                ApiCountryRegionResponseModel MapRequestToResponse(
                        string countryRegionCode,
                        ApiCountryRegionRequestModel request);

                ApiCountryRegionRequestModel MapResponseToRequest(
                        ApiCountryRegionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>40d83ab1dcb54e25f9aed8df8734dc8d</Hash>
</Codenesium>*/