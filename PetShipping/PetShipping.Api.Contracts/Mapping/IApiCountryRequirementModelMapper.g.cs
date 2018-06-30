using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiCountryRequirementModelMapper
        {
                ApiCountryRequirementResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequirementRequestModel request);

                ApiCountryRequirementRequestModel MapResponseToRequest(
                        ApiCountryRequirementResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d13e1550d124f6b53c4fd7728aaa92ba</Hash>
</Codenesium>*/