using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCurrencyModelMapper
        {
                ApiCurrencyResponseModel MapRequestToResponse(
                        string currencyCode,
                        ApiCurrencyRequestModel request);

                ApiCurrencyRequestModel MapResponseToRequest(
                        ApiCurrencyResponseModel response);

                JsonPatchDocument<ApiCurrencyRequestModel> CreatePatch(ApiCurrencyRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d3f4230c647b515f3730d74131f0a8ae</Hash>
</Codenesium>*/