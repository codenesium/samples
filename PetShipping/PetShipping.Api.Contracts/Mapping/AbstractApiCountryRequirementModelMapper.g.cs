using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiCountryRequirementRequestModel> CreatePatch(ApiCountryRequirementRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiCountryRequirementRequestModel>();
                        patch.Replace(x => x.CountryId, model.CountryId);
                        patch.Replace(x => x.Details, model.Details);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>a43e6a52d47a1641b20d770547375a5b</Hash>
</Codenesium>*/