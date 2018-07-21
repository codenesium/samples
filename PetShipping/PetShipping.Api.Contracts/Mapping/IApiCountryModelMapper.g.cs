using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiCountryModelMapper
        {
                ApiCountryResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequestModel request);

                ApiCountryRequestModel MapResponseToRequest(
                        ApiCountryResponseModel response);

                JsonPatchDocument<ApiCountryRequestModel> CreatePatch(ApiCountryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>fdfa6f49f81cf9280a4bd813ef39c014</Hash>
</Codenesium>*/