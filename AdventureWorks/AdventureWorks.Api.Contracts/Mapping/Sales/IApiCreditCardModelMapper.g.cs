using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCreditCardModelMapper
        {
                ApiCreditCardResponseModel MapRequestToResponse(
                        int creditCardID,
                        ApiCreditCardRequestModel request);

                ApiCreditCardRequestModel MapResponseToRequest(
                        ApiCreditCardResponseModel response);

                JsonPatchDocument<ApiCreditCardRequestModel> CreatePatch(ApiCreditCardRequestModel model);
        }
}

/*<Codenesium>
    <Hash>8f304ccd4c69db01688518a435dbeeff</Hash>
</Codenesium>*/