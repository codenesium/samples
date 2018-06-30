using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiSaleTicketsModelMapper
        {
                ApiSaleTicketsResponseModel MapRequestToResponse(
                        int id,
                        ApiSaleTicketsRequestModel request);

                ApiSaleTicketsRequestModel MapResponseToRequest(
                        ApiSaleTicketsResponseModel response);
        }
}

/*<Codenesium>
    <Hash>c03cd4c3cd186d297b43a59e0fc87cfd</Hash>
</Codenesium>*/