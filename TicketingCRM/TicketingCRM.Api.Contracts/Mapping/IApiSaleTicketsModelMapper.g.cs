using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiSaleTicketsModelMapper
        {
                ApiSaleTicketsResponseModel MapRequestToResponse(
                        int id,
                        ApiSaleTicketsRequestModel request);

                ApiSaleTicketsRequestModel MapResponseToRequest(
                        ApiSaleTicketsResponseModel response);

                JsonPatchDocument<ApiSaleTicketsRequestModel> CreatePatch(ApiSaleTicketsRequestModel model);
        }
}

/*<Codenesium>
    <Hash>265a1133ada88119da5eaad5ba2a9dcb</Hash>
</Codenesium>*/