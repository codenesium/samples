using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiShipMethodModelMapper
        {
                ApiShipMethodResponseModel MapRequestToResponse(
                        int shipMethodID,
                        ApiShipMethodRequestModel request);

                ApiShipMethodRequestModel MapResponseToRequest(
                        ApiShipMethodResponseModel response);
        }
}

/*<Codenesium>
    <Hash>6ac5170435b1f28a5fe4e8a872e2628b</Hash>
</Codenesium>*/