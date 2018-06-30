using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
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
    <Hash>b445184f0f1352c935357100a4d73e40</Hash>
</Codenesium>*/