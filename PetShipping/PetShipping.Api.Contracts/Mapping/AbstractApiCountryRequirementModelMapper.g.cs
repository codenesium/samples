using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiCountryRequirementModelMapper
        {
                public virtual ApiCountryRequirementResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequirementRequestModel request)
                {
                        var response = new ApiCountryRequirementResponseModel();
                        response.SetProperties(id,
                                               request.CountryId,
                                               request.Details);
                        return response;
                }

                public virtual ApiCountryRequirementRequestModel MapResponseToRequest(
                        ApiCountryRequirementResponseModel response)
                {
                        var request = new ApiCountryRequirementRequestModel();
                        request.SetProperties(
                                response.CountryId,
                                response.Details);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>17d4ee05d0a969c1c5b6c48f4f57ec2a</Hash>
</Codenesium>*/