using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiCountryRequirementModelMapper
        {
                ApiCountryRequirementResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequirementRequestModel request);

                ApiCountryRequirementRequestModel MapResponseToRequest(
                        ApiCountryRequirementResponseModel response);

                JsonPatchDocument<ApiCountryRequirementRequestModel> CreatePatch(ApiCountryRequirementRequestModel model);
        }
}

/*<Codenesium>
    <Hash>bedb7122abeadfc45f2e7a1535b33b37</Hash>
</Codenesium>*/