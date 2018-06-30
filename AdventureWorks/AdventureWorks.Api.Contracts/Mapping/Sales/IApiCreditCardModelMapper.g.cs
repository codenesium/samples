using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCreditCardModelMapper
        {
                ApiCreditCardResponseModel MapRequestToResponse(
                        int creditCardID,
                        ApiCreditCardRequestModel request);

                ApiCreditCardRequestModel MapResponseToRequest(
                        ApiCreditCardResponseModel response);
        }
}

/*<Codenesium>
    <Hash>e43c60ce1d4d110c9f98beb219f5f5c5</Hash>
</Codenesium>*/