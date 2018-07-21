using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPersonCreditCardModelMapper
        {
                ApiPersonCreditCardResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonCreditCardRequestModel request);

                ApiPersonCreditCardRequestModel MapResponseToRequest(
                        ApiPersonCreditCardResponseModel response);

                JsonPatchDocument<ApiPersonCreditCardRequestModel> CreatePatch(ApiPersonCreditCardRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a366549d935742a350a5c1187974cdbf</Hash>
</Codenesium>*/