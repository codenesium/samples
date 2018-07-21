using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCountryRegionModelMapper
        {
                ApiCountryRegionResponseModel MapRequestToResponse(
                        string countryRegionCode,
                        ApiCountryRegionRequestModel request);

                ApiCountryRegionRequestModel MapResponseToRequest(
                        ApiCountryRegionResponseModel response);

                JsonPatchDocument<ApiCountryRegionRequestModel> CreatePatch(ApiCountryRegionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>8c881f8c5a0db19a4f838035629ebd73</Hash>
</Codenesium>*/