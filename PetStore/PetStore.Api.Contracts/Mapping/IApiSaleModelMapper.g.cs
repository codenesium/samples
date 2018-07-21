using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
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
    <Hash>91b8637e02088ce8d17242f61c10b407</Hash>
</Codenesium>*/