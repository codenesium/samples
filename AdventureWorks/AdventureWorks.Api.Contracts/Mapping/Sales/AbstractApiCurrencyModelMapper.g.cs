using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCurrencyModelMapper
        {
                public virtual ApiCurrencyResponseModel MapRequestToResponse(
                        string currencyCode,
                        ApiCurrencyRequestModel request)
                {
                        var response = new ApiCurrencyResponseModel();
                        response.SetProperties(currencyCode,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiCurrencyRequestModel MapResponseToRequest(
                        ApiCurrencyResponseModel response)
                {
                        var request = new ApiCurrencyRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>1f2f66c4fd1a61b3c7fcf42edacb9f44</Hash>
</Codenesium>*/