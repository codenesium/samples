using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiSpaceXSpaceFeatureModelMapper
        {
                ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceXSpaceFeatureRequestModel request);

                ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
                        ApiSpaceXSpaceFeatureResponseModel response);

                JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> CreatePatch(ApiSpaceXSpaceFeatureRequestModel model);
        }
}

/*<Codenesium>
    <Hash>8f34f7697c38b0be4a51e4767ef3975c</Hash>
</Codenesium>*/