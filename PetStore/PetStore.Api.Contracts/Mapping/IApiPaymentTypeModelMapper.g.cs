using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiPaymentTypeModelMapper
        {
                ApiPaymentTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiPaymentTypeRequestModel request);

                ApiPaymentTypeRequestModel MapResponseToRequest(
                        ApiPaymentTypeResponseModel response);

                JsonPatchDocument<ApiPaymentTypeRequestModel> CreatePatch(ApiPaymentTypeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>9b2172b0a37887c95e2e7690aaaff442</Hash>
</Codenesium>*/