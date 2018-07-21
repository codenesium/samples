using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiSaleModelMapper
        {
                ApiSaleResponseModel MapRequestToResponse(
                        int id,
                        ApiSaleRequestModel request);

                ApiSaleRequestModel MapResponseToRequest(
                        ApiSaleResponseModel response);

                JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e0a060b58b8b53dc95221ef0c98b1900</Hash>
</Codenesium>*/