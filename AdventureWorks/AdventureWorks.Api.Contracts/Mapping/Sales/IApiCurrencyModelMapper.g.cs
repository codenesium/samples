using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCurrencyModelMapper
        {
                ApiCurrencyResponseModel MapRequestToResponse(
                        string currencyCode,
                        ApiCurrencyRequestModel request);

                ApiCurrencyRequestModel MapResponseToRequest(
                        ApiCurrencyResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9bc3e536c55d5ff0d3a7694a60d00c56</Hash>
</Codenesium>*/