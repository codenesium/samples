using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCurrencyRateModelMapper
        {
                ApiCurrencyRateResponseModel MapRequestToResponse(
                        int currencyRateID,
                        ApiCurrencyRateRequestModel request);

                ApiCurrencyRateRequestModel MapResponseToRequest(
                        ApiCurrencyRateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>af669b218d61278c21ff6307dde9d958</Hash>
</Codenesium>*/