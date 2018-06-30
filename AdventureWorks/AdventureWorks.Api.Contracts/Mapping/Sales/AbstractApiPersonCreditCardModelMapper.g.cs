using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPersonCreditCardModelMapper
        {
                public virtual ApiPersonCreditCardResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonCreditCardRequestModel request)
                {
                        var response = new ApiPersonCreditCardResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.CreditCardID,
                                               request.ModifiedDate);
                        return response;
                }

                public virtual ApiPersonCreditCardRequestModel MapResponseToRequest(
                        ApiPersonCreditCardResponseModel response)
                {
                        var request = new ApiPersonCreditCardRequestModel();
                        request.SetProperties(
                                response.CreditCardID,
                                response.ModifiedDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d8dcedb001a05a1c92a66a336063ff3e</Hash>
</Codenesium>*/