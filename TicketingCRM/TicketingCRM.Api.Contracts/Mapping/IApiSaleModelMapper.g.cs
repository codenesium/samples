using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
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
    <Hash>9c99c57bea97d5584d6c2c8c7c6cfaa0</Hash>
</Codenesium>*/