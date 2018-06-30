using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesPersonModelMapper
        {
                ApiSalesPersonResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesPersonRequestModel request);

                ApiSalesPersonRequestModel MapResponseToRequest(
                        ApiSalesPersonResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d8e37b1bbda21314f5ce58465eb00db9</Hash>
</Codenesium>*/