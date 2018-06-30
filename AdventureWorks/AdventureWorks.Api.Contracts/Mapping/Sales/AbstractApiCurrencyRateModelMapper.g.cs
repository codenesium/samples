using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCurrencyRateModelMapper
        {
                public virtual ApiCurrencyRateResponseModel MapRequestToResponse(
                        int currencyRateID,
                        ApiCurrencyRateRequestModel request)
                {
                        var response = new ApiCurrencyRateResponseModel();
                        response.SetProperties(currencyRateID,
                                               request.AverageRate,
                                               request.CurrencyRateDate,
                                               request.EndOfDayRate,
                                               request.FromCurrencyCode,
                                               request.ModifiedDate,
                                               request.ToCurrencyCode);
                        return response;
                }

                public virtual ApiCurrencyRateRequestModel MapResponseToRequest(
                        ApiCurrencyRateResponseModel response)
                {
                        var request = new ApiCurrencyRateRequestModel();
                        request.SetProperties(
                                response.AverageRate,
                                response.CurrencyRateDate,
                                response.EndOfDayRate,
                                response.FromCurrencyCode,
                                response.ModifiedDate,
                                response.ToCurrencyCode);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8a6ffb742c1d57dc7ad55ce5c23f9545</Hash>
</Codenesium>*/