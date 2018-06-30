using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiSaleModelMapper
        {
                ApiSaleResponseModel MapRequestToResponse(
                        int id,
                        ApiSaleRequestModel request);

                ApiSaleRequestModel MapResponseToRequest(
                        ApiSaleResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4705724bb8fe2128886701d720cd92c1</Hash>
</Codenesium>*/