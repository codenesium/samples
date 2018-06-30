using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCustomerModelMapper
        {
                ApiCustomerResponseModel MapRequestToResponse(
                        int customerID,
                        ApiCustomerRequestModel request);

                ApiCustomerRequestModel MapResponseToRequest(
                        ApiCustomerResponseModel response);
        }
}

/*<Codenesium>
    <Hash>f568e0f0531d655849f98e8eb97a1414</Hash>
</Codenesium>*/