using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPersonCreditCardModelMapper
        {
                ApiPersonCreditCardResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonCreditCardRequestModel request);

                ApiPersonCreditCardRequestModel MapResponseToRequest(
                        ApiPersonCreditCardResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fb2b512864ebdc98c171e2ec10b73ccd</Hash>
</Codenesium>*/