using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCreditCardModelMapper
        {
                public virtual ApiCreditCardResponseModel MapRequestToResponse(
                        int creditCardID,
                        ApiCreditCardRequestModel request)
                {
                        var response = new ApiCreditCardResponseModel();
                        response.SetProperties(creditCardID,
                                               request.CardNumber,
                                               request.CardType,
                                               request.ExpMonth,
                                               request.ExpYear,
                                               request.ModifiedDate);
                        return response;
                }

                public virtual ApiCreditCardRequestModel MapResponseToRequest(
                        ApiCreditCardResponseModel response)
                {
                        var request = new ApiCreditCardRequestModel();
                        request.SetProperties(
                                response.CardNumber,
                                response.CardType,
                                response.ExpMonth,
                                response.ExpYear,
                                response.ModifiedDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>46ada9d17ffea855e530e4a03a8c4630</Hash>
</Codenesium>*/