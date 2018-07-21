using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCurrencyRateModelMapper
        {
                ApiCurrencyRateResponseModel MapRequestToResponse(
                        int currencyRateID,
                        ApiCurrencyRateRequestModel request);

                ApiCurrencyRateRequestModel MapResponseToRequest(
                        ApiCurrencyRateResponseModel response);

                JsonPatchDocument<ApiCurrencyRateRequestModel> CreatePatch(ApiCurrencyRateRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7d388c744feff9e3bb9e8840e0e8615a</Hash>
</Codenesium>*/