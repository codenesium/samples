using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
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
    <Hash>5d4bb288c88148d493f9523390734fac</Hash>
</Codenesium>*/